using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wealthox.Web.Models.Announcement
{
    public class AnnouncementIndexVm
    {
        public AnnouncementIndexVm()
        {
            Announcements = new List<AnnouncementVm>();
        }
        public List<AnnouncementVm> Announcements { get; set; }
        public bool IsLastPage { get; set; }
    }
}
