using AutoMapper;
using NEZWalksAPI.Models.Domain;
using NEZWalksAPI.Models.DTO;

namespace NEZWalksAPI.Mappings
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<AddRegionRequestDto,Region>().ReverseMap();
            CreateMap<UpdateRegionRequestDto, Region>().ReverseMap();
            CreateMap<AddWalksRequestDto, Walk>().ReverseMap();
            CreateMap<Walk, WalkDto>().ReverseMap();
            CreateMap<Difficulty,DifficultyDto>().ReverseMap(); 
            CreateMap<UpdateWalkRequestDto,Walk>().ReverseMap();
        }
    }
}   
    