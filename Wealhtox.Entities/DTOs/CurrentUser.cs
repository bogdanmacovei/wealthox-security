using System;
using System.Collections.Generic;
using System.Text;

namespace Wealthox.Entities.DTOs
{
    public class CurrentUser
    {
        public CurrentUser(bool isAuthenticated, bool isAdmin)
        {
            IsAuthenticated = isAuthenticated;
            IsAdmin = isAdmin;
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsAuthenticated { get; set; }
        public bool IsAdmin { get; set; }
    }
}
