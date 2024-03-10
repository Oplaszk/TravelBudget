using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using TravelBudget.ViewModels;
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

            CreateMap<Travel, TravelViewModel>()
                .ForMember(dest => dest.CountriesSelectList, opt => opt.MapFrom(src => src.Countries.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = $"{c.Name} ({c.Code})",
                    Selected = true
                })));

            CreateMap<Country, SelectListItem>()
            .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id.ToString()))
            .ForMember(dest => dest.Text, opt => opt.MapFrom(src => $"{src.Name} ({src.Code})"));

            CreateMap<Travel, TravelViewModel>()
                .ForMember(dest => dest.CountriesSelectList, opt => opt.MapFrom(src => src.Countries))
                .ReverseMap()
                .ForMember(dest => dest.Countries, opt => opt.MapFrom(src => src.CountriesSelectList));
        }
    }
}
