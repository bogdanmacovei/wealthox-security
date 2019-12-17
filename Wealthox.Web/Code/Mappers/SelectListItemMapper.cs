using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wealthox.Entities;

namespace Wealthox.Web.Code.Mappers
{
    public class SelectListItemMapper : Profile
    {
        public SelectListItemMapper()
        {
            CreateMap<DwellingTypeLocalization, SelectListItem>()
                .ForMember(dest => dest.Text, c => c.MapFrom(src => src.Name))
                .ForMember(dest => dest.Value, c => c.MapFrom(src => src.Id));

            CreateMap<ZoneLocalization, SelectListItem>()
               .ForMember(dest => dest.Text, c => c.MapFrom(src => src.Name))
               .ForMember(dest => dest.Value, c => c.MapFrom(src => src.Id));

            CreateMap<UtilitiesLocalization, SelectListItem>()
              .ForMember(dest => dest.Text, c => c.MapFrom(src => src.Name))
              .ForMember(dest => dest.Value, c => c.MapFrom(src => src.Id));

            CreateMap<BuildingTypeLocalization, SelectListItem>()
            .ForMember(dest => dest.Text, c => c.MapFrom(src => src.Name))
            .ForMember(dest => dest.Value, c => c.MapFrom(src => src.Id));

            CreateMap<HouseStyleLocalization, SelectListItem>()
            .ForMember(dest => dest.Text, c => c.MapFrom(src => src.Name))
            .ForMember(dest => dest.Value, c => c.MapFrom(src => src.Id));

            CreateMap<RoofStyleLocalization, SelectListItem>()
            .ForMember(dest => dest.Text, c => c.MapFrom(src => src.Name))
            .ForMember(dest => dest.Value, c => c.MapFrom(src => src.Id));

            CreateMap<GarageTypeLocalization, SelectListItem>()
            .ForMember(dest => dest.Text, c => c.MapFrom(src => src.Name))
            .ForMember(dest => dest.Value, c => c.MapFrom(src => src.Id));

            CreateMap<HeatingTypeLocalization, SelectListItem>()
            .ForMember(dest => dest.Text, c => c.MapFrom(src => src.Name))
            .ForMember(dest => dest.Value, c => c.MapFrom(src => src.Id));

            CreateMap<QualityLocalization, SelectListItem>()
            .ForMember(dest => dest.Text, c => c.MapFrom(src => src.Name))
            .ForMember(dest => dest.Value, c => c.MapFrom(src => src.Id));

            CreateMap<House, SelectListItem>()
                .ForMember(dest => dest.Text, c => c.MapFrom(src => src.Specifications))
                .ForMember(dest => dest.Value, c => c.MapFrom(src => src.Id));

            CreateMap<ConstructionMaterial, SelectListItem>()
               .ForMember(dest => dest.Text, c => c.MapFrom(src => src.Name))
               .ForMember(dest => dest.Value, c => c.MapFrom(src => src.Id));
        }
    }
}
