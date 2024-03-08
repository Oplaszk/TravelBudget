using AutoMapper;
using TravelBudgetDBContact.Response.DTO;
using TravelBudgetDBModels.Models;

namespace TravelBudgetDBContact.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Country, CountryDTO>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
               .ForMember(dest => dest.CountryWithCode, opt => opt.MapFrom(src => $"{src.Name} ({src.Code})"));

            CreateMap<CountryDTO, Country>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) 
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.CountryName))
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.ContinentId, opt => opt.Ignore()) 
                .ForMember(dest => dest.CurrencyId, opt => opt.Ignore()) 
                .ForMember(dest => dest.Continent, opt => opt.Ignore()) 
                .ForMember(dest => dest.Currency, opt => opt.Ignore());

            CreateMap<ICollection<Country>, IEnumerable<CountryDTO>>();
        }
    }
}
