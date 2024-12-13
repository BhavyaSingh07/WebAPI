using System.Text.Json;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalksAPI.CustomActionFilters;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO;
using NZWalksAPI.Repositories;

namespace NZWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class RegionsController : ControllerBase
    {
        //private readonly NZWalksDbContext _dbContext;
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<RegionsController> _logger;
        public RegionsController(IRegionRepository regionRepository, IMapper mapper, ILogger<RegionsController> logger)
        {
            //this._dbContext = dbContext;
            this._regionRepository = regionRepository;
            this._mapper = mapper;
            this._logger = logger;
        }


        [HttpGet]
        //[Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("GetAll Action Method was invoked");

            var regionsDomain = await _regionRepository.GetAllAsync();

            //var regionsDto = new List<RegionDto>();
            //foreach (var regionDomain in regionsDomain)
            //{
            //    regionsDto.Add(new RegionDto()
            //    {
            //        Id = regionDomain.Id,
            //        Code = regionDomain.Code,
            //        Name = regionDomain.Name,
            //        RegionImageUrl = regionDomain.RegionImageUrl
            //    });
            //}

            _logger.LogInformation($"Finished get all rquest with data : {JsonSerializer.Serialize(regionsDomain)}");

            var regionsDto = _mapper.Map<List<RegionDto>>(regionsDomain);

            return Ok(regionsDto);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        //[Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var regionDomain = await _regionRepository.GetByIdAsync(id);
            if (regionDomain == null)
            {
                return NotFound();
            }
            //var regionDto = new RegionDto()
            //{
            //    Id = regionDomain.Id,
            //    Code = regionDomain.Code,
            //    Name = regionDomain.Name,
            //    RegionImageUrl = regionDomain.RegionImageUrl
            //};

            var regionDto = _mapper.Map<RegionDto>(regionDomain);

            return Ok(regionDto);
        }

        [HttpPost]
        [ValidateModel]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] AddRegionRequest addRegionRequest)
        {
            //var regionDomainModel = new Region
            //{
            //    Code = addRegionRequest.Code,
            //    Name = addRegionRequest.Name,
            //    RegionImageUrl = addRegionRequest.RegionImageUrl
            //};

            var regionDomainModel = _mapper.Map<Region>(addRegionRequest);

            await _regionRepository.CreateAsync(regionDomainModel);

            //var regionDto = new RegionDto
            //{
            //    Id = regionDomainModel.Id,
            //    Code = regionDomainModel.Code,
            //    Name = regionDomainModel.Name,
            //    RegionImageUrl = regionDomainModel.RegionImageUrl
            //};

            var regionDto = _mapper.Map<RegionDto>(regionDomainModel);

            return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
            
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequest updateRegionRequest)
        {
            //var regionDomainModel = new Region
            //{
            //    Code = updateRegionRequest.Code,
            //    Name = updateRegionRequest.Name,
            //    RegionImageUrl = updateRegionRequest.RegionImageUrl
            //};

            var regionDomainModel = _mapper.Map<Region>(updateRegionRequest);

            regionDomainModel = await _regionRepository.UpdateAsync(id, regionDomainModel);


            if (regionDomainModel == null)
            {
                return NotFound();
            }

            //var regionDto = new RegionDto
            //{
            //    Id = regionDomainModel.Id,
            //    Code = regionDomainModel.Code,
            //    Name = regionDomainModel.Name,
            //    RegionImageUrl = regionDomainModel.RegionImageUrl
            //};

            var regionDto = _mapper.Map<RegionDto>(regionDomainModel);

            return Ok(regionDto);
            
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> Delete([FromRoute]Guid id)
        {
            var regionDomainModel = await _regionRepository.DeleteAsync(id);

            if(regionDomainModel == null)
            {
                return NotFound();
            }

            //var regionDto = new RegionDto
            //{
            //    Id = regionDomainModel.Id,
            //    Code = regionDomainModel.Code,
            //    Name = regionDomainModel.Name,
            //    RegionImageUrl = regionDomainModel.RegionImageUrl
            //};

            var regionDto = _mapper.Map<RegionDto>(regionDomainModel);

            return Ok(regionDto);
        }
    }
}
