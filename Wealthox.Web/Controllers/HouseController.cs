using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Wealthox.Entities;
using Wealthox.Entities.DTOs;
using Wealthox.Services;
using Wealthox.Web.Code.Base;
using Wealthox.Web.Models;

namespace Wealthox.Web.Controllers
{
    public class HouseController : BaseController
    {
        private readonly HouseService houseService;
        private readonly CurrentUser currentUser;
        public HouseController(HouseService houseService, CurrentUser currentUser, IMapper mapper)
            : base(mapper)
        {
            this.houseService = houseService;
            this.currentUser = currentUser;
        }

        [Authorize]
        [HttpGet]
        public IActionResult MyHouses()
        {
            var houses = houseService.GetHousesForUser();

            if(houses.Count == 0)
            {
                return NotAvailableView();
            }

            var result = houses.Select(c => mapper.Map<House, HouseItemVm>(c)).ToList();

            return View(result);
        }

        [Authorize]
        [HttpGet]
        public IActionResult HousesRecommandation()
        {
           
            return View();
        }

        [Authorize]
        [HttpGet]
        public IActionResult HousesRecommandation1(string ids)
        {
            var isEligible = houseService.IsUserEligibleForRecommandation(currentUser.Id);
            var listOfIds = new List<int>();
            if (ids != null)
            {
                ids = ids.Substring(1);
                ids = ids.Remove(ids.Length - 1);
                listOfIds = ids.Split(',').Select(n => Convert.ToInt32(n)).ToList();
            }

            if (!isEligible)
            {
                return NotEligibleView();
            }

            if (listOfIds != null)
            {
                var houses = houseService.GetHouseRecommandations(listOfIds);
                var result = houses.Select(c => mapper.Map<House, HouseItemVm>(c)).ToList();

                return Json(result);
            }

            return View();
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetHousesAverages()
        {
            var result = houseService.GetLastFiveFilters();

            return Json(result);
        }


        [Authorize]
        [HttpGet]
        public IActionResult AddHouse()
        {
            var houseInfo = houseService.GetHouseInfo();
            var model = new AddOrEditHouseVm
            {
                DwellingTypeList = houseInfo.DwellingTypes.Select(c => mapper.Map<DwellingTypeLocalization, SelectListItem>(c)).ToList(),
                ZoneTypeList = houseInfo.Zone.Select(c => mapper.Map<ZoneLocalization, SelectListItem>(c)).ToList(),
                UtilitiesTypeList = houseInfo.Utilities.Select(c => mapper.Map<UtilitiesLocalization, SelectListItem>(c)).ToList(),
                BuildingTypeList = houseInfo.BuildingTypes.Select(c => mapper.Map<BuildingTypeLocalization, SelectListItem>(c)).ToList(),
                HouseStyleTypeList = houseInfo.HouseStyles.Select(c => mapper.Map<HouseStyleLocalization, SelectListItem>(c)).ToList(),
                RoofStyleTypeList = houseInfo.RoofStyles.Select(c => mapper.Map<RoofStyleLocalization, SelectListItem>(c)).ToList(),
                GarageTypeList = houseInfo.GarageTypes.Select(c => mapper.Map<GarageTypeLocalization, SelectListItem>(c)).ToList(),
                HeatingTypeList = houseInfo.HeatingTypes.Select(c => mapper.Map<HeatingTypeLocalization, SelectListItem>(c)).ToList(),
                QualityList = houseInfo.Qualities.Select(c => mapper.Map<QualityLocalization, SelectListItem>(c)).ToList(),
                ConstructionMaterials = houseInfo.ConstructionMaterials.Select(c => mapper.Map<ConstructionMaterial, SelectListItem>(c)).ToList()
            };

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddHouse(AddOrEditHouseVm model)
        {
            if (!ModelState.IsValid)
            {
                var houseInfo = houseService.GetHouseInfo();
                model.DwellingTypeList = houseInfo.DwellingTypes.Select(c => mapper.Map<DwellingTypeLocalization, SelectListItem>(c)).ToList();
                model.ZoneTypeList = houseInfo.Zone.Select(c => mapper.Map<ZoneLocalization, SelectListItem>(c)).ToList();
                model.UtilitiesTypeList = houseInfo.Utilities.Select(c => mapper.Map<UtilitiesLocalization, SelectListItem>(c)).ToList();
                model.BuildingTypeList = houseInfo.BuildingTypes.Select(c => mapper.Map<BuildingTypeLocalization, SelectListItem>(c)).ToList();
                model.HouseStyleTypeList = houseInfo.HouseStyles.Select(c => mapper.Map<HouseStyleLocalization, SelectListItem>(c)).ToList();
                model.RoofStyleTypeList = houseInfo.RoofStyles.Select(c => mapper.Map<RoofStyleLocalization, SelectListItem>(c)).ToList();
                model.GarageTypeList = houseInfo.GarageTypes.Select(c => mapper.Map<GarageTypeLocalization, SelectListItem>(c)).ToList();
                model.HeatingTypeList = houseInfo.HeatingTypes.Select(c => mapper.Map<HeatingTypeLocalization, SelectListItem>(c)).ToList();
                model.QualityList = houseInfo.Qualities.Select(c => mapper.Map<QualityLocalization, SelectListItem>(c)).ToList();
                model.ConstructionMaterials = houseInfo.ConstructionMaterials.Select(c => mapper.Map<ConstructionMaterial, SelectListItem>(c)).ToList();

                return View(model);
            }

            var house = mapper.Map<AddOrEditHouseVm, House>(model);

            var result = houseService.AddHouse(house);

            return RedirectToAction("Index", "Announcement");
        }

        [HttpGet]
        public IActionResult SearchHouse(string specifications)
        {
            var houses = houseService.GetHouseBySpecifications(specifications);

            if(houses.Count == 0)
            {
                return NotAvailableView();
            }

            var result = houses.Select(c => mapper.Map<House, HouseItemVm>(c)).ToList();

            return View(result);
        }

        [Authorize]
        [HttpPost]
        public IActionResult DeleteHouse(Guid houseId)
        {
            var houseExists = houseService.HouseExists(houseId);

            if (!houseExists)
                return NotFoundView();

            if (!houseService.IsHouseOwner(houseId))
                return ForbidView();

            var result = houseService.DeleteHouse(houseId);

            if (!result)
                return InternalServerErrorView();

            return Ok();
        }

        public async Task<IActionResult> Download(string filename)
        {
            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot", filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }

        [Authorize]
        [HttpPost]
        public IActionResult ApproveHouse(Guid houseId)
        {
            var houseExists = houseService.HouseExists(houseId);
            if (!houseExists)
                return NotFoundView();
            if (!currentUser.IsAdmin)
                return ForbidView();

            var result = houseService.ApproveHouse(houseId);

            if (!result)
                return InternalServerErrorView();

            return Ok();
        }

        [Authorize]
        [HttpGet]
        public IActionResult PendingHouses()
        {
            if (!currentUser.IsAdmin)
                return ForbidView();

            var houses = houseService.GetPendingHouses();

            if (houses.Count == 0)
            {
                return NotAvailableView();
            }

            var result = houses.Select(c => mapper.Map<House, PendingHouseVm>(c)).ToList();

            return View(result);

        }

#region private
        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformats officedocument.spreadsheetml.sheet"},  
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }

#endregion
    }
}
