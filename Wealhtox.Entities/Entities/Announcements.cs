using Common.Interfaces;
using System;
using System.Collections.Generic;

namespace Wealthox.Entities
{
    public partial class Announcements : IEntity
    {
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public Guid? HouseId { get; set; }
        public int? Price { get; set; }
        public House House { get; set; }
        public Users User { get; set; }

        public bool? IsDeleted { get; set; }

        public string ImageUrl { get; set; }

        public DateTime? CreatedOn { get; set; }

        public string Title { get; set; }

        public bool? IsSold { get; set; }

        public bool? IsApproved { get; set; }

    }
}
