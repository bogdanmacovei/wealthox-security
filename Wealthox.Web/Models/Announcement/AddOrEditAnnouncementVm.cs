using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Wealthox.Web.Models
{
    public class AddOrEditAnnouncementVm
    {
        public AddOrEditAnnouncementVm()
        {
            Houses = new List<SelectListItem>();
        }
        public Guid AnnouncementId { get; set; }
        public Guid? UserId { get; set; }
        [Required(ErrorMessage = "Campul este obligatoriu!")]
        public Guid? HouseId { get; set; }
        [Required(ErrorMessage = "Campul este obligatoriu!")]
        public int? Price { get; set; }
        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "Campul este obligatoriu!")]
        public string Title { get; set; }

        public List<SelectListItem> Houses { get; set; }
    }
}
