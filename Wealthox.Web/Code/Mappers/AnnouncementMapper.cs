using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wealthox.Entities;
using Wealthox.Entities.DTOs;
using Wealthox.Web.Models;

namespace Wealthox.Web.Code.Mappers
{
    public class AnnouncementMapper : Profile
    {
        public AnnouncementMapper()
        {
            CreateMap<Announcements, AnnouncementVm>()
                .ForMember(dest => dest.OwnerName, c => c.MapFrom(src => src.User.FirstName + " " + src.User.LastName))
                .ForMember(dest => dest.HasImage, c => c.MapFrom(src => src.ImageUrl != null));
            CreateMap<DashboardAdminDto, DashboardVm>();
            CreateMap<AddOrEditAnnouncementVm, Announcements>()
                .ForMember(dest => dest.Id, c => c.MapFrom(src => src.AnnouncementId));
            CreateMap<AddOrEditAnnouncementVm, House>()
                .ForMember(dest => dest.Id, c => c.MapFrom(src => src.HouseId));
            CreateMap<Announcements, PendingAnnouncementVm>()
                .ForMember(dest => dest.OwnerName, c => c.MapFrom(src => src.User.FirstName + " " + src.User.LastName));
            CreateMap<Announcements, AnnouncementItemVm>();
        }
    }
}
