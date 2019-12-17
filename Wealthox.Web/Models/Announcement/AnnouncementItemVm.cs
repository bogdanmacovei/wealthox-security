using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wealthox.Web.Models
{
    public class AnnouncementItemVm
    {
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public Guid? HouseId { get; set; }
        public int? Price { get; set; }
        public bool? IsDeleted { get; set; }

        public string ImageUrl { get; set; }

        public DateTime? CreatedOn { get; set; }

        public string Title { get; set; }

        public bool? IsSold { get; set; }

        public bool? IsApproved { get; set; }
    }
}
