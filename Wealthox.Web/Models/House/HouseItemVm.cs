using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wealthox.Web.Models
{
    public class HouseItemVm
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public string Username { get; set; }
        public string Specifications { get; set; }

        public string OverallQuality { get; set; }

        public string OverallCondition { get; set; }
        public int? NumberOfBathrooms { get; set; }
        public int? NumberOfBedrooms { get; set; }
        public int? TotalNumberOfRooms { get; set; }

        public bool? IsDeleted { get; set; }
        public bool? IsApproved { get; set; }
        public bool? IsAvailable { get; set; }
    }
}
