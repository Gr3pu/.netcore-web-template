using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Templates.WebApp.Controllers;
using Templates.WebApp.Workers;

namespace Templates.WebApp.Areas.Informations.Controllers
{
    [AllowAnonymous]
    [Area("Informations")]
    [Route("Informations/General")]
    public class GeneralController : BaseController<GeneralController>
    {
        public GeneralController(IServiceProvider provider) : base(provider) { }

        [HttpGet]
        [Route("")]
        [ServiceFilter(typeof(ActivityMonitor))]
        public IActionResult Index()
        {
            return View();
        }
    }
}