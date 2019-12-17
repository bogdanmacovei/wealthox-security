using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wealthox.Web.Models
{
    public class PendingAnnouncementVm
    {
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public Guid? HouseId { get; set; }
        public int? Price { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }

        public string OwnerName { get; set; }
    }
}
