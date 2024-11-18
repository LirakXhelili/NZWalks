using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NEZWalksAPI.CustomActionsFilters;
using NEZWalksAPI.Data;
using NEZWalksAPI.Models.Domain;
using NEZWalksAPI.Models.DTO;
using NEZWalksAPI.Repositories;
using NEZWalksAPI.CustomActionsFilters;
using Microsoft.AspNetCore.Authorization;
using System.Text.Json;

namespace NEZWalksAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
   
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;
        private readonly ILogger<RegionsController> logger;

        public RegionsController(NZWalksDbContext dbContext,
            IRegionRepository regionRepository,
            IMapper mapper,
            ILogger<RegionsController> logger)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
            this.logger = logger;
        }
        [HttpGet]
        //[Authorize(Roles ="Reader")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                throw new Exception("This is a custom exception");

                //Get Data from database - Domain models

                var regionsDomain = await regionRepository.GetAllAsync();

                //Mpa Domain Models to 
                //var regionsDto = mapper.Map<List<RegionDto>>(regionsDomain);
                //Return DTO (never return Domain Models)

                logger.LogInformation($"Finished GetAllRegions request with data: {JsonSerializer.Serialize(regionsDomain)}");
                return Ok(mapper.Map<List<RegionDto>>(regionsDomain));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }

           
            
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles ="Reader")]
        public async Task<IActionResult> GetById([FromRoute]Guid id)
        {
            //var region = dbContext.Regions.Find(id);
            //Get region Domain model form Database
            var regionDomain = await regionRepository.GetByIdAsync(id);
            if (regionDomain == null)
            {
                return NotFound();
            }

            //Map or convert Domain Modal to DTO
            
            return Ok(mapper.Map<RegionDto>(regionDomain));
        }

        //POST To create new Region.
        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            
                //Map DTO to Domain Model
                var regionDomainModel = mapper.Map<Region>(addRegionRequestDto);
                //Use domain model to create region
                regionDomainModel = await regionRepository.CreateAsync(regionDomainModel);

                //Map domain model back to DTO
                var regionDto = mapper.Map<RegionDto>(regionDomainModel);

                return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
             

        }

        //Update region
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        [Authorize(Roles = "Writer")]

        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {

            //Map DTO to domain model
            var regionDomainModel = mapper.Map<Region>(updateRegionRequestDto);
            regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);
            if (regionDomainModel == null)
            {
                return NotFound();
            };

            //Convert Domain model to Dto
            return Ok(mapper.Map<RegionDto>(regionDomainModel));


        }



        //Delete Region 
        [HttpDelete]
        [Route("{id:guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
           var regionDomainModel = await regionRepository.DeleteAsync(id);
            if (regionDomainModel == null)
            {
                return NotFound();
            }
            //Optional: return deleted region me mapping
            //
            return Ok(mapper.Map<RegionDto>(regionDomainModel));
        }
    }
}
