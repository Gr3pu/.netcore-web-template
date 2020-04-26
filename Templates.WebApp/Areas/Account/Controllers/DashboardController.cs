using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Templates.WebApp.Controllers;

namespace Templates.WebApp.Areas.Account.Controllers
{
    [Authorize]
    [Area("Account")]
    [Route("Account/Dashboard")]
    public class DashboardController : BaseController<DashboardController>
    {
        public DashboardController(IServiceProvider provider) : base(provider) { }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}