using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wealthox.DataAccess.UnitOfWork;
using Wealthox.Entities;
using Wealthox.Entities.DTOs;
using Wealthox.Entities.Enums;
using Wealthox.Services.Base;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Wealthox.Services
{
    public class HouseService : BaseService
    {
        private readonly CurrentUser currentUser;
        private readonly HttpClient httpClient;
        public HouseService(WealthoxUnitOfWork unitOfWork, CurrentUser currentUser)
            : base(unitOfWork)
        {
            this.currentUser = currentUser;
            httpClient = new HttpClient();
        }


        public House GetHouseById(Guid? id)
        {
            return UnitOfWork.House.Query.FirstOrDefault(h => h.Id == id);
        }

        public List<House> GetHousesForUser()
        {
            return UnitOfWork.House
                .Query
                .Include(h => h.OverallConditionsNavigation)
                .Include(h => h.OverallQualityNavigation)
                .Where(h => h.UserId == currentUser.Id && h.IsDeleted == false)
                .OrderByDescending(h => h.TempIdentif)
                .ToList();

        }

        public List<House> GetAvailableHouses()
        {
            return UnitOfWork.House.Query.Where(h => h.IsAvailable == true && h.UserId == currentUser.Id && h.IsApproved == true && h.IsDeleted == false && h.Specifications != null).ToList();
        }

        public List<House> GetPendingHouses()
        {
            return UnitOfWork
                .House.Query
                .Include(h => h.UserNavigation)
                .Include(h => h.OverallConditionsNavigation)
                .Include(h => h.OverallQualityNavigation)
                .Where(h => h.IsApproved == false && h.IsDeleted == false)
                .ToList();
        }

        public bool AddHouse(House house)
        {
            house.Id = Guid.NewGuid();
            house.UserId = currentUser.Id;
            house.IsApproved = false;
            house.IsAvailable = true;
            house.IsDeleted = false;

            house.TempIdentif = UnitOfWork.House.Query.Count() + 1;

            if (currentUser.IsAdmin)
                house.IsApproved = true;

            UnitOfWork.House.Add(house);

            return UnitOfWork.SaveChanges() != 0;

        }

        public bool IsUserEligibleForRecommandation(Guid userId)
        {
            return UnitOfWork.SearchHistories.Query.Where(s => s.UserId == userId).Count() >= 5;
        }

        public List<House> GetHouseBySpecifications(string specifications)
        {
            var searchTerm = specifications.ToLower();

            return UnitOfWork.House.Query
                .Include(h => h.UserNavigation)
                .Include(h => h.OverallConditionsNavigation)
                .Include(h => h.OverallQualityNavigation)
                .Where(h => h.Specifications.ToLower().Contains(searchTerm))
                .ToList();
        }
        public bool DeleteHouse(Guid houseId)
        {
            var house = UnitOfWork.House.Query.FirstOrDefault(h => h.Id == houseId);

            if(house != null)
            {
                house.IsDeleted = true;
                UnitOfWork.House.Update(house);
            }

            return UnitOfWork.SaveChanges() != 0;
        }

        public HouseInfo GetHouseInfo()
        {
            var info = new HouseInfo
            {
                DwellingTypes = UnitOfWork.DwellingTypeLocalization.Query.OrderBy(d => d.Id).ToList(),
                Zone = UnitOfWork.ZoneLocalization.Query.OrderBy(z => z.Id).ToList(),
                Utilities = UnitOfWork.UtilitiesLocalization.Query.OrderBy(u => u.Id).ToList(),
                BuildingTypes = UnitOfWork.BuildingTypeLocalization.Query.OrderBy(b => b.Id).ToList(),
                HouseStyles = UnitOfWork.HouseStyleLocalization.Query.OrderBy(h => h.Id).ToList(),
                RoofStyles = UnitOfWork.RoofStyleLocalization.Query.OrderBy(r => r.Id).ToList(),
                GarageTypes = UnitOfWork.GarageTypeLocalization.Query.OrderBy(g => g.Id).ToList(),
                HeatingTypes = UnitOfWork.HeatingTypeLocalization.Query.OrderBy(h => h.Id).ToList(),
                Qualities = UnitOfWork.QualityLocalization.Query.OrderBy(q => q.Id).ToList(),
                ConstructionMaterials = UnitOfWork.ConstructionMaterials.Query.OrderBy(c => c.Id).ToList()
            };

            return info;
        }

        public SearchHistoryDTO GetLastFiveFilters()
        {
            var lastSearches = UnitOfWork.SearchHistories
                .Query.Where(sh => sh.UserId == currentUser.Id)
                .OrderByDescending(sh => sh.SearchDate)
                .Take(5).ToList();

            var preparedObject = new SearchHistoryDTO
            {
                OverallQuality = (float)lastSearches.Select(c => c.OverallQuality).Average(),
                OverallConditions = (float)lastSearches.Select(c => c.OverallConditions).Average(),
                TotalNumberOfRooms = (float)lastSearches.Select(c => c.TotalNumberOfRooms).Average(),
                NumberOfBedrooms = (float)lastSearches.Select(c => c.NumberOfBedrooms).Average(),
                NumberOfBathrooms = (float)lastSearches.Select(c => c.NumberOfBathrooms).Average(),
                GarageNumberOfCars = (float)lastSearches.Select(c => c.GarageNumberOfCars).Average(),
                HouseStyleType = (float)lastSearches.Select(c => c.HouseStyleType).Average(),
                BuildingType = (float)lastSearches.Select(c => c.BuildingType).Average(),
                ExteriorQuality = (float)lastSearches.Select(c => c.ExteriorQuality).Average(),
                HeatingQuality = (float)lastSearches.Select(c => c.HeatingQuality).Average(),
                HasAirConditioning = (float)lastSearches.Select(c => Convert.ToInt32(c.HasAirConditioning)).Average()
            };

            return preparedObject;
        }

        public List<House> GetHouseRecommandations(List<int> ids)
        {
            return UnitOfWork.House.Query
                .Include(h => h.UserNavigation)
                .Include(h => h.OverallQualityNavigation)
                .Include(h => h.OverallConditionsNavigation)
                .Where(h => ids.Contains((int)h.TempIdentif))
                .ToList();
        }


        public bool ApproveHouse(Guid houseId)
        {
            var house = UnitOfWork.House.Query.FirstOrDefault(h => h.Id == houseId);

            house.IsApproved = true;

            UnitOfWork.House.Update(house);

            return UnitOfWork.SaveChanges() != 0;
        }

        public bool IsHouseOwner(Guid houseId)
        {
            return UnitOfWork.House
                .Query
                .Where(h => h.Id == houseId)
                .Select(h => h.UserId)
                .FirstOrDefault() == currentUser.Id;
        }

        public bool HouseExists(Guid houseId)
        {
            return UnitOfWork.House.Query.Any(h => h.Id == houseId);
        }
    }
}
