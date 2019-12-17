using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Wealthox.Services;

namespace Wealthox.Web.Models.Account
{
    public class RegisterVm
    {
        [EmailAddress(ErrorMessage = "Email is not valid!")]
        [MaxLength(100, ErrorMessage = "Maximum 100 characters allowed!")]
        [Required(ErrorMessage = "Cannot leave this empty!")]
        //[Remote(action: "IsEmailAvailable", controller: "Account", ErrorMessage = "Email-ul exista deja")]
        public string Email { get; set; }

        [MaxLength(100, ErrorMessage = "Maximum 100 characters allowed!")]
        [Required(ErrorMessage = "Cannot leave this empty!")]
        public string FirstName { get; set; }

        [MaxLength(100, ErrorMessage = "Maximum 100 characters allowed!")]
        [Required(ErrorMessage = "Cannot leave this empty!")]
        public string LastName { get; set; }

        [MaxLength(100, ErrorMessage = "Maximum 100 characters allowed!")]
        [Required(ErrorMessage = "Cannot leave this empty!")]
        public string Password { get; set; }

        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public DateTime DateOfBirth { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var result = new List<ValidationResult>();

            var service = validationContext.GetService(typeof(UserAccountService)) as UserAccountService;
            var emailExists = service.EmailExists(Email);
            if (emailExists)
                result.Add(new ValidationResult("Email already exists!", new List<string> { nameof(Email) }));

            if (DateOfBirth < DateTime.Parse("1/1/1900") || DateOfBirth > DateTime.Now)
                result.Add(new ValidationResult("Invalid date!", new List<string> { nameof(DateOfBirth) }));

            return result;
        }
    }
}
