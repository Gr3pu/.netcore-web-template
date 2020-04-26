using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Templates.WebApp.Models;

namespace Templates.WebApp.Controllers
{
	[AllowAnonymous]
	[Route("")]
	public class HomeController : BaseController<HomeController>
	{
		public HomeController(IServiceProvider provider) : base(provider) { }

		[Route("")]
		public IActionResult Index()
		{
			return RedirectToAction("Index", "General", new { Area = "Informations" });
		}

		[Route("Error")]
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
