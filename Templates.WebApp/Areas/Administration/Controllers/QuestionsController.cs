using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Templates.WebApp.Controllers;

namespace Templates.WebApp.Areas.Administration.Controllers
{
    [Authorize]
    [Area("Administration")]
    [Route("Administration/Questions")]
    public class QuestionsController : BaseController<QuestionsController>
    {
        public QuestionsController(IServiceProvider provider) : base(provider) { }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}