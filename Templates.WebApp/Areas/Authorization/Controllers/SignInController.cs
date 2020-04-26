using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Templates.WebApp.Controllers;

namespace Templates.WebApp.Areas.Authorization.Controllers
{
	[AllowAnonymous]
	[Area("Authorization")]
	[Route("SignIn")]
	public class SignInController : BaseController<SignInController>
	{
		public SignInController(IServiceProvider provider) : base(provider) { }

		[HttpGet]
		[Route("")]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		[AutoValidateAntiforgeryToken]
		[Route("")]
		public IActionResult Index(int indeksik)
		{
			return View(indeksik);
		}
	}
}