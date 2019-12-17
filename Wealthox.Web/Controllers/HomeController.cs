using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wealthox.Services;
using Wealthox.Web.Code.Base;

namespace Wealthox.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ConstructionMaterialService materialService;

        public HomeController(ConstructionMaterialService materialService, IMapper mapper)
            :base(mapper)
        {
            this.materialService = materialService;
        }

    }
}
