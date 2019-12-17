using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Wealthox.Web.Models.Account
{
    public class LoginVm
    {
        [Required(ErrorMessage = "Cannot leave this empty!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Cannot leave this empty!")]
        public string Password { get; set; }

        public bool AreCredentialsInvalid { get; set; }
    }
}
