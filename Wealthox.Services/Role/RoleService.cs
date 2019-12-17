using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wealhtox.Entities.Enums;
using Wealthox.DataAccess.UnitOfWork;
using Wealthox.Services.Base;

namespace Wealthox.Services
{
    public class RoleService : BaseService
    {
        public RoleService(WealthoxUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        public bool CheckAdmin(Guid userId)
        {
            return UnitOfWork.Users.Query.Any(u => u.Id == userId && u.RoleId == (int)RoleTypes.Admin);
        }
    }
}
