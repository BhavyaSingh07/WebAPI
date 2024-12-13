using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.CustomActionFilters;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO;
using NZWalksAPI.Repositories;

namespace NZWalksAPI.Controllers
{
    [Route("api/[controller]")]  
    [ApiController]
    public class WalksController : ControllerBase
    { 
        private readonly IWalkRepository _walkRepository;
        private readonly IMapper _mapper;
        public WalksController(IWalkRepository walkRepository , IMapper mapper)
        {
            this._walkRepository = walkRepository;
            this._mapper = mapper;
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            
               var walkDomainModel = _mapper.Map<Walk>(addWalkRequestDto);

               await _walkRepository.CreateAsync(walkDomainModel);

               return Ok(_mapper.Map<WalkDto>(walkDomainModel));
           
        }


        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery, [FromQuery] string?sortBy, [FromQuery] bool? isAscending, [FromQuery] int pageNumber=1, [FromQuery] int pageSize=100)
        {
            var walksDomainModel = await _walkRepository.GetAllAsync(filterOn,filterQuery,sortBy,isAscending ?? true,pageNumber,pageSize);

            //throw new Exception("This is a new exception");

            return Ok(_mapper.Map<List<WalkDto>>(walksDomainModel));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walkDomainModel = await _walkRepository.GetByIdAsync(id);

            if(walkDomainModel == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<WalkDto>(walkDomainModel));
        }


        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id,UpdateWalkRequestDto updateWalkRequestDto)
        {
            var walkDomainModel = _mapper.Map<Walk>(updateWalkRequestDto);

            walkDomainModel = await _walkRepository.UpdateAsync(id, walkDomainModel);

            if(walkDomainModel == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<WalkDto>(walkDomainModel));
            
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute]Guid id)
        {
            var deletedWalkDomainModel = await _walkRepository.DeleteAsync(id);

            if(deletedWalkDomainModel == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<WalkDto>(deletedWalkDomainModel));    
        }
    }
}
