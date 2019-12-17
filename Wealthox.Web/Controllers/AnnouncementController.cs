using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wealthox.Entities;
using Wealthox.Entities.DTOs;
using Wealthox.Services;
using Wealthox.Web.Code.Base;
using Wealthox.Web.Models;
using Wealthox.Web.Models.Announcement;

namespace Wealthox.Web.Controllers
{
    public class AnnouncementController : BaseController
    {
        private readonly AnnouncementService announcementService;
        private readonly HouseService houseService;
        private readonly CurrentUser currentUser;

        public AnnouncementController(AnnouncementService announcementService, HouseService houseService, CurrentUser currentUser, IMapper mapper)
            : base(mapper)
        {
            this.announcementService = announcementService;
            this.currentUser = currentUser;
            this.houseService = houseService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public IActionResult MyAnnouncements()
        {
            var announcements = announcementService.GetMyAnnouncements();

            if(announcements.Count == 0 )
            {
                return NotAvailableView();
            }

            var result = announcements.Select(c => mapper.Map<Announcements, AnnouncementItemVm>(c)).ToList();

            return View(result);
        }

        [HttpGet]
        public IActionResult GetPaginatedAnnouncements(int page = 1,
            int? NumberOfBedrooms = null,
            int? NumberOfBathrooms = null,
            int? GarageNumberOfCars = null,
            int? HouseStyleType = null,
            int? TotalNumberOfRooms = null,
            int? OverallQuality = null,
            int? OverallConditions = null,
            int? BuildingType = null,
            int? HeatingQuality = null,
            bool? HasAirConditioning = null,
            int? ExteriorQuality = null,
            bool comingFromFilter = false,
            string searchTerm = "*")
        {
            if (page <= 0)
                page = 1;

            Func<Announcements, bool> filter;
            filter = x =>
            (
                (!NumberOfBedrooms.HasValue || x.House.NumberOfBedrooms == NumberOfBedrooms)
                && (!NumberOfBathrooms.HasValue || x.House.NumberOfBathrooms == NumberOfBathrooms)
                && (!TotalNumberOfRooms.HasValue || x.House.TotalNumberOfRooms == TotalNumberOfRooms)
                && (!OverallQuality.HasValue || OverallQuality == -1 || x.House.OverallQuality == OverallQuality)
                && (!OverallConditions.HasValue || OverallConditions == -1 || x.House.OverallConditions == OverallConditions)
                && (!BuildingType.HasValue || BuildingType == -1 || x.House.BuildingType == BuildingType)
                && (!GarageNumberOfCars.HasValue || x.House.GarageNumberOfCars == GarageNumberOfCars)
                && (!HouseStyleType.HasValue || HouseStyleType == -1 || x.House.HouseStyleType == HouseStyleType)
                && (!HeatingQuality.HasValue || HeatingQuality == -1 || x.House.HeatingQuality == HeatingQuality)
                && (!ExteriorQuality.HasValue || ExteriorQuality == -1 || x.House.ExteriorQuality == ExteriorQuality)
                && (!HasAirConditioning.HasValue || x.House.HasAirConditioning == HasAirConditioning)
            );


            var announcements = announcementService.GetAnnouncements(page: page, results: ResultsPerPage, searchTerm: searchTerm, filter: filter);
            var numberOfAnnouncements = announcementService.GetNumberOfAnnouncements();

            if(comingFromFilter)
            {
                var filters = new SearchHistory
                {
                    GarageNumberOfCars = GarageNumberOfCars,
                    HeatingQuality = HeatingQuality,
                    HasAirConditioning = HasAirConditioning,
                    BuildingType = BuildingType,
                    HouseStyleType = HouseStyleType,
                    OverallQuality = OverallQuality,
                    OverallConditions = OverallConditions,
                    ExteriorQuality = ExteriorQuality,
                    NumberOfBathrooms = NumberOfBathrooms,
                    NumberOfBedrooms = NumberOfBedrooms,
                    TotalNumberOfRooms = TotalNumberOfRooms
                };
                announcementService.AddSearchHistory(filters);
            }

            var results = announcements.Select(a => mapper.Map<AnnouncementVm>(a)).ToList();

            var announcementResult = new AnnouncementIndexVm
            {
                Announcements = results,
                IsLastPage = numberOfAnnouncements <= ResultsPerPage * (page - 1) + results.Count
            };

            return Json(announcementResult);
        }

        [Authorize]
        [HttpGet]
        public IActionResult AddAnnouncement(string firstName)
        {
            firstName = firstName ?? User.Identity.Name;
            var houses = houseService.GetAvailableHouses();
            var model = new AddOrEditAnnouncementVm
            {
                Houses = houses.Select(c => mapper.Map<House, SelectListItem>(c)).ToList()
            };
            ViewBag.firstName = firstName;

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddAnnouncement(AddOrEditAnnouncementVm model)
        {
            if (!ModelState.IsValid)
            {
                var houses = houseService.GetAvailableHouses();
                model.Houses = houses.Select(c => mapper.Map<House, SelectListItem>(c)).ToList();
                return View(model);
            }

            var announcement = mapper.Map<AddOrEditAnnouncementVm, Announcements>(model);

            var result = announcementService.AddAnnouncement(announcement);

            return RedirectToAction("Index");
        }


        [Authorize]
        [HttpPost]
        public IActionResult DeleteAnnouncement(Guid announcementId)
        {
            var announcementExists = announcementService.AnnouncementExists(announcementId);

            if (!announcementExists)
                return NotFoundView();

            if (!announcementService.IsAnnouncementOwner(announcementId))
                return ForbidView();

            var result = announcementService.DeleteAnnouncement(announcementId);

            if (!result)
                return InternalServerErrorView();

            return Ok();
        }

        [Authorize]
        [HttpPost]
        public IActionResult ApproveAnnouncement(Guid announcementId)
        {
            var announcementExists = announcementService.AnnouncementExists(announcementId);

            if (!announcementExists)
                return NotFoundView();

            if (!currentUser.IsAdmin)
                return ForbidView();

            var result = announcementService.ApproveAnnouncement(announcementId);


            if (!result)
                return InternalServerErrorView();

            return Ok();
        }

        [Authorize]
        [HttpGet]
        public IActionResult PendingAnnouncements()
        {
            if (!currentUser.IsAdmin)
                return ForbidView();

            var announcements = announcementService.GetPendingAnnouncements();

           if(announcements.Count == 0)
            {
                return NotAvailableView();
            }

            var result = announcements.Select(c => mapper.Map<Announcements, PendingAnnouncementVm>(c)).ToList();

            return View(result);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Filters()
        {
            var houseInfo = houseService.GetHouseInfo();
            var model = new AnnouncementFilters
            {
                ZoneTypeList = houseInfo.Zone.Select(c => mapper.Map<ZoneLocalization, SelectListItem>(c)).ToList(),
                BuildingTypeList = houseInfo.BuildingTypes.Select(c => mapper.Map<BuildingTypeLocalization, SelectListItem>(c)).ToList(),
                HouseStyleTypeList = houseInfo.HouseStyles.Select(c => mapper.Map<HouseStyleLocalization, SelectListItem>(c)).ToList(),
                QualityList = houseInfo.Qualities.Select(c => mapper.Map<QualityLocalization, SelectListItem>(c)).ToList()
            };

            return PartialView("_Filters", model);
        }
    }
}
