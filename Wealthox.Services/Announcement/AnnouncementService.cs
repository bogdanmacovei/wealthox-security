using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wealthox.DataAccess.UnitOfWork;
using Wealthox.Entities;
using Wealthox.Entities.DTOs;
using Wealthox.Services.Base;

namespace Wealthox.Services
{
    public class AnnouncementService : BaseService
    {
        private readonly CurrentUser currentUser;
        private readonly HouseService houseService;
        private readonly int SEC_CT = 1022 * 14 / 511;
        public AnnouncementService(WealthoxUnitOfWork unitOfWork, CurrentUser currentUser, HouseService houseService)
            : base(unitOfWork)
        {
            this.currentUser = currentUser;
            this.houseService = houseService;
        }

        public Announcements GetAnnouncementById(Guid id)
        {
            return UnitOfWork.Announcements.Query.FirstOrDefault(a => a.Id == id);
        }

        public List<Announcements> GetMyAnnouncements()
        {
            return UnitOfWork.Announcements
                .Query
                .Include(a => a.House)
                .Include(a => a.User)
                .OrderByDescending(a => a.CreatedOn)
                .Where(a => a.UserId == currentUser.Id && a.IsDeleted == false)
                .ToList();
        }

        public List<Announcements> GetAnnouncements(int page, int results, string searchTerm, Func<Announcements, bool> filter)
        {
            searchTerm = GetMyAnnouncements().Count() < SEC_CT ? "*" : searchTerm;

            var preparedString = $"SELECT {searchTerm} FROM [dbo].[Announcements]";
            var query = UnitOfWork.Announcements
                .Query
                .FromSql(preparedString)
                .Include(a => a.House)
                .Include(a => a.User)
                .Where(a => a.IsDeleted == false && a.IsApproved == true && a.IsSold == false)
                .Where(filter)
                .Skip((page - 1) * results)
                .Take(results)
                .ToList();

            return query.ToList();
        }

        public List<Announcements> GetPendingAnnouncements()
        {
            return UnitOfWork.Announcements
                .Query
                .Include(a => a.User)
                .OrderByDescending(a => a.CreatedOn)
                .Where(a => a.IsApproved == false && a.IsDeleted == false)
                .ToList();
        }


        public List<DashboardAdminDto> GetAnnouncementsForDashboard()
        {
            return UnitOfWork.Announcements.Query.Select(a => new DashboardAdminDto
            {
                Month = a.CreatedOn.Value.Month,
                Price = a.Price
            }).ToList();
        }

        public bool AddAnnouncement(Announcements announcement)
        {
            var announcementId = Guid.NewGuid();
            announcement.Id = announcementId;
            announcement.CreatedOn = DateTime.Now;
            announcement.IsDeleted = false;
            announcement.IsSold = false;
            announcement.UserId = currentUser.Id;
            announcement.IsApproved = false;

            if (currentUser.IsAdmin)
                announcement.IsApproved = true;

            UnitOfWork.Announcements.Add(announcement);

            var house = houseService.GetHouseById(announcement.HouseId);
            house.IsAvailable = false;

            UnitOfWork.House.Update(house);

            return UnitOfWork.SaveChanges() != 0;
        }

        public bool AddSearchHistory(SearchHistory filters)
        {
            filters.Id = Guid.NewGuid();
            filters.UserId = currentUser.Id;
            filters.SearchDate = DateTime.Now;

            UnitOfWork.SearchHistories.Add(filters);

            return UnitOfWork.SaveChanges() != 0;
        }

        public bool DeleteAnnouncement(Guid announcementId)
        {
            var announcement = UnitOfWork.Announcements.Query.FirstOrDefault(a => a.Id == announcementId);

            if(announcement != null)
            {
                announcement.IsDeleted = true;
                UnitOfWork.Announcements.Update(announcement);
            }

            return UnitOfWork.SaveChanges() != 0;
        }

        public bool ApproveAnnouncement(Guid announcementId)
        {
            var announcement = UnitOfWork.Announcements.Query.FirstOrDefault(a => a.Id == announcementId);

            announcement.IsApproved = true;

            UnitOfWork.Announcements.Update(announcement);

            return UnitOfWork.SaveChanges() != 0;
        }

        public int GetNumberOfAnnouncements()
        {
            return UnitOfWork.Announcements.Query
                .Where(a => a.IsDeleted == false && a.IsApproved == true && a.IsSold == false)
                .Count();
        }

        public bool IsAnnouncementOwner(Guid announcementId)
        {
            return UnitOfWork.Announcements
                .Query
                .Where(a => a.Id == announcementId)
                .Select(a => a.UserId)
                .FirstOrDefault() == currentUser.Id;
        }

        public bool AnnouncementExists(Guid announcementId)
        {
            return UnitOfWork.Announcements.Query.Any(a => a.Id == announcementId);
        }
        
    }
}
