using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using NZWalks.UI.Models.DTO;

namespace NZWalks.UI.Controllers
{
    public class RegionsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public RegionsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<RegionDto> response = new List<RegionDto>();
            //Get regions from the api
            var client = _httpClientFactory.CreateClient();

            var httpResponseMessage = await client.GetAsync("https://localhost:7186/api/Regions");

            httpResponseMessage.EnsureSuccessStatusCode();

            response.AddRange(await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<RegionDto>>());


            return View(response);
        }

        [HttpGet]
        public IActionResult Add()
        {

            return View();  
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddRegionViewModel addRegionViewModel)
        {
            var client = _httpClientFactory.CreateClient();

            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://localhost:7186/api/Regions"),
                Content = new StringContent(JsonSerializer.Serialize(addRegionViewModel), Encoding.UTF8, "application/json")

            };

            var httpResponseMessage = await client.SendAsync(httpRequestMessage);
            httpResponseMessage.EnsureSuccessStatusCode();

            var response = await httpResponseMessage.Content.ReadFromJsonAsync<RegionDto>();

            if(response != null)
            {
                return RedirectToAction("Index", "Regions");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var client = _httpClientFactory.CreateClient();

            var response = await client.GetFromJsonAsync<RegionDto>($"https://localhost:7186/api/Regions/{id.ToString()}");

            if(response != null)
            {
                return View(response);
            }

            return View(null);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RegionDto regionDto)
        {
            var client = _httpClientFactory.CreateClient();

            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri($"https://localhost:7186/api/Regions/{regionDto.Id}"),
                Content = new StringContent(JsonSerializer.Serialize(regionDto), Encoding.UTF8, "application/json")
            };

            var httpResponseMessage = await client.SendAsync(httpRequestMessage);
            httpResponseMessage.EnsureSuccessStatusCode();

            var response = await httpResponseMessage.Content.ReadFromJsonAsync<RegionDto>();

            if(response != null)
            {
                return RedirectToAction("Index", "Regions");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(RegionDto regionDto)
        {
            var client = _httpClientFactory.CreateClient();

            var httpResponseMessage = await client.DeleteAsync($"https://localhost:7186/api/Regions/{regionDto.Id}");
            httpResponseMessage.EnsureSuccessStatusCode() ;

            return RedirectToAction("Index", "Regions");

        }
    }
}
