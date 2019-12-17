using Common.Interfaces;
using System;
using System.Collections.Generic;

namespace Wealthox.Entities
{
    public partial class Users : IEntity
    {
        public Users()
        {
            Announcements = new HashSet<Announcements>();
            SearchHistory = new HashSet<SearchHistory>();
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime? RegisterDate { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }

        public Role Role { get; set; }
        public ICollection<Announcements> Announcements { get; set; }
        public ICollection<SearchHistory> SearchHistory { get; set; }

        public ICollection<House> Houses { get; set; }
    }
}
