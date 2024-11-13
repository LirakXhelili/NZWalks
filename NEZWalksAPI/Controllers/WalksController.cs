using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NEZWalksAPI.CustomActionsFilters;
using NEZWalksAPI.Models.Domain;
using NEZWalksAPI.Models.DTO;
using NEZWalksAPI.Repositories;

namespace NEZWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;

        public WalksController(IMapper mapper,IWalkRepository walkRepository)
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }
        //Create walk 
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddWalksRequestDto addWalkRequestDto)
        {

            //Map DTO to Domain model
            var walkDomainModel = mapper.Map<Walk>(addWalkRequestDto);

            await walkRepository.CreateAsync(walkDomainModel);

            //Map domain model to DTO

            return Ok(mapper.Map<WalkDto>(walkDomainModel));



        }

        //Get Walk
        //GET: /api/walk?filterOn=Name&filterQuery=Track

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery)
        {
            var walksDomainModel = await walkRepository.GetAllAsync(filterOn, filterQuery);
            //Map domain model to dto
            return Ok(mapper.Map<List<WalkDto>>(walksDomainModel));
        }

        //Get Walk by ID
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walkDomainModel = await walkRepository.GetByIdAsync(id);

            if(walkDomainModel == null) { return NotFound(); }

            //Map domain model to Dto
            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }

        //Update Walk
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, UpdateWalkRequestDto updateWalkRequestDto)
        {

            //Map to dto to domain model
            var walkDomainModel = mapper.Map<Walk>(updateWalkRequestDto);

            walkDomainModel = await walkRepository.UpdateAsync(id, walkDomainModel);

            if (walkDomainModel == null) { return NotFound(); }

            //Map domainModel into dto
            return Ok(mapper.Map<WalkDto>(walkDomainModel));

        }
        
        //Delete Walk
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
           var deletedWalkDomainModel =  await walkRepository.DeleteAsync(id);
            if(deletedWalkDomainModel == null) { return NotFound(); }

            //Map Domain model to dto
            return Ok(mapper.Map<WalkDto>(deletedWalkDomainModel));
        }

    }
}
