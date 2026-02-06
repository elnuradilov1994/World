using AutoMapper;
using World.Dtos.CapitalCity;
using World.Dtos.Continents;
using World.Dtos.Country;
using World.Entities;

namespace World.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateContinentDto, Continent>().ReverseMap();
            CreateMap<UpdateContinentDto, Continent>().ReverseMap();

            CreateMap<CreateCountryDto, Country>().ReverseMap();
            CreateMap<UpdateCountryDto, Country>().ReverseMap();

            CreateMap<CreateCapitalCityDto, CapitalCity>().ReverseMap();
            CreateMap<UpdateCapitalCityDto, CapitalCity>().ReverseMap();
        }
    }
}
