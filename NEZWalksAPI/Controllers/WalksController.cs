using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Create([FromBody] AddWalksRequestDto addWalkRequestDto)
        {
            //Map DTO to Domain model
            var walkDomainModel = mapper.Map<Walk>(addWalkRequestDto);

            await walkRepository.CreateAsync(walkDomainModel);

            //Map domain model to DTO

            return Ok(mapper.Map<WalkDto>(walkDomainModel));

        }

        //Get Walk

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var walksDomainModel = await walkRepository.GetAllAsync();
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

    }
}
