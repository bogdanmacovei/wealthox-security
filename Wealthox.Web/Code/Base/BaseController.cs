using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wealthox.Web.Code.Base
{
    public class BaseController : Controller
    {
        protected readonly IMapper mapper;

        protected BaseController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        protected IActionResult InternalServerErrorView()
        {
            return View("InternalServerError");
        }

        protected IActionResult InternalServerError()
        {
            return new StatusCodeResult(500);
        }

        protected IActionResult NotFoundView()
        {
            return View("NotFound");
        }

        protected IActionResult NotAvailableView()
        {
            return View("NotAvailable");
        }

        protected IActionResult ForbidView()
        {
            return View("Forbid");
        }

        protected IActionResult NotEligibleView()
        {
            return View("NotEligible");
        }

        protected int ResultsPerPage => 5;
    }
}
