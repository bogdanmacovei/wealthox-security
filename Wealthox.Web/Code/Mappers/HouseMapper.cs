using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wealthox.Entities;
using Wealthox.Web.Models;

namespace Wealthox.Web.Code.Mappers
{
    public class HouseMapper : Profile
    {
        public HouseMapper()
        {
            CreateMap<AddOrEditHouseVm, House>();
            CreateMap<House, PendingHouseVm>()
                .ForMember(dest => dest.OwnerName, c => c.MapFrom(src => src.UserNavigation.FirstName + " " + src.UserNavigation.LastName))
                .ForMember(dest => dest.OverallQuality, c => c.MapFrom(src => src.OverallQualityNavigation.Name))
                .ForMember(dest => dest.OverallCondition, c => c.MapFrom(src => src.OverallConditionsNavigation.Name));
            CreateMap<House, HouseItemVm>()
                .ForMember(dest => dest.Username, c => c.MapFrom(src => src.UserNavigation.FirstName + " " + src.UserNavigation.LastName))
                .ForMember(dest => dest.OverallQuality, c => c.MapFrom(src => src.OverallQualityNavigation.Name))
                .ForMember(dest => dest.OverallCondition, c => c.MapFrom(src => src.OverallConditionsNavigation.Name));

        }
    }
}
