using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wealthox.Web.Models
{
    public class PendingHouseVm
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public string OverallQuality { get; set; }

        public string OverallCondition { get; set; }

        public string OwnerName { get; set; }

        public string Specifications { get; set; }
    }
}
