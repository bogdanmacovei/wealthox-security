using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wealhtox.Entities.Enums;
using Wealthox.DataAccess.UnitOfWork;
using Wealthox.Entities;
using Wealthox.Services.Base;

namespace Wealthox.Services
{
    public class UserAccountService : BaseService
    {
        public UserAccountService(WealthoxUnitOfWork unitOfWork)
               :base(unitOfWork)
        {

        }

        public Users Get(string email)
        {
            return UnitOfWork.Users.Query.FirstOrDefault(u => u.Email == email);
        }

        public Users GetUserById(Guid id)
        {
            return UnitOfWork.Users.Query.FirstOrDefault(u => u.Id == id);
        }

        public Users GetUserByFirstName(string firstName)
        {
            return UnitOfWork.Users.Query.FirstOrDefault(u => u.FirstName == firstName);
        }

        public bool UserExists(Guid id)
        {
            return UnitOfWork.Users.Query.Any(u => u.Id == id);
        }

        public Users Login(string email, string password)
        {
            return UnitOfWork.Users.Query
                .Include(u => u.Role)
                .FirstOrDefault(u => u.Email == email && u.Password == password);
        }

        public bool Register(Users user)
        {
            user.Id = Guid.NewGuid();
            user.RegisterDate = DateTime.Now;
            user.RoleId = (int)RoleTypes.Member;

            UnitOfWork.Users.Add(user);

            return UnitOfWork.SaveChanges() != 0;
        }

        public bool EmailExists(string email)
        {
            return UnitOfWork.Users.Query
                .Any(u => u.Email == email);
        }
    }
}
