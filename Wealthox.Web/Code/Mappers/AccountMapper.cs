using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wealthox.Entities;
using Wealthox.Web.Models.Account;

namespace Wealthox.Web.Code.Mappers
{
    public class AccountMapper : Profile
    {
        public AccountMapper()
        {
            CreateMap<RegisterVm, Users>();
        }
    }
}
