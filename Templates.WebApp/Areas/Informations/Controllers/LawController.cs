using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Templates.WebApp.Controllers;

namespace Templates.WebApp.Areas.Informations.Controllers
{
    [AllowAnonymous]
    [Area("Informations")]
    [Route("Informations/Law")]
    public class LawController : BaseController<LawController>
    {
        public LawController(IServiceProvider provider) : base(provider) { }

        [HttpGet]
        [Route("Policy")]
        public IActionResult Policy()
        {
            return View();
        }

        [HttpGet]
        [Route("Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        [Route("Rules")]
        public IActionResult Rules()
        {
            return View();
        }
    }
}