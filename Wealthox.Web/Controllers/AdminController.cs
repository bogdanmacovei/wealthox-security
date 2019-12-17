using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Wealhtox.Entities;
using Wealthox.Entities.DTOs;
using Wealthox.Services;
using Wealthox.Web.Code.Base;
using Wealthox.Web.Models;
using Wealthox.Web.Models.Admin;

namespace Wealthox.Web.Controllers
{
    public class AdminController : BaseController
    {
        private readonly AnnouncementService announcementService;
        private readonly HouseService houseService;
        private readonly CurrentUser currentUser;

        public AdminController(AnnouncementService announcementService, HouseService houseService, IMapper mapper, CurrentUser currentUser)
            : base(mapper)
        {
            this.announcementService = announcementService;
            this.houseService = houseService;
            this.currentUser = currentUser;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            if(!currentUser.IsAdmin)
            {
                return ForbidView();
            }
            var filtersInfo = houseService.GetHouseInfo();

            var filtersPrediction = new FiltersPredictionVm
            {
                OverallQualityList = filtersInfo.Qualities.Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() }).ToList(),
                OverallConditionsList = filtersInfo.Qualities.Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() }).ToList(),
                ExteriorQualityList = filtersInfo.Qualities.Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() }).ToList(),
                ExteriorConditionsList = filtersInfo.Qualities.Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() }).ToList(),
                HeatingQualityList = filtersInfo.Qualities.Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() }).ToList(),
                HasAirConditioningList = new List<SelectListItem> { new SelectListItem { Text = "Yes", Value = "1" }, new SelectListItem { Text = "No", Value = "0" } },
                KitchenQualityList = filtersInfo.Qualities.Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() }).ToList(),
                GarageQualityList = filtersInfo.Qualities.Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() }).ToList(),
                GarageConditionList = filtersInfo.Qualities.Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() }).ToList(),
                PoolQualityList = filtersInfo.Qualities.Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() }).ToList(),
                FenceQualityList = filtersInfo.Qualities.Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() }).ToList()
            };
            return View(filtersPrediction);
        }

        [HttpGet]
        public IActionResult GetData()
        {
            var result = announcementService.GetAnnouncementsForDashboard();
            return Json(result);
        }
    }
}