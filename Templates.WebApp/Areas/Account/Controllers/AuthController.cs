using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Templates.WebApp.Areas.Account.ViewModels;
using Templates.WebApp.Controllers;
using Templates.WebApp.Data;
using Templates.WebApp.Workers;

namespace Templates.WebApp.Areas.Account.Controllers
{
	[AllowAnonymous]
	[Area("Account")]
	[Route("Auth")]
	public class AuthController : BaseController<AuthController>
	{
		private readonly SignInManager<User> _signInManager;
		private readonly UserManager<User> _userManager;
		private readonly IEmailSender _emailSender;

		public AuthController(IServiceProvider provider, SignInManager<User> signInManager, UserManager<User> userManager, IEmailSender emailSender) : base(provider)
		{
			_signInManager = signInManager;
			_userManager = userManager;
			_emailSender = emailSender;
		}

		#region signIn

		[HttpGet]
		[Route("")]
		public IActionResult SignIn(string returnUrl = null)
		{
			returnUrl ??= Url.Content("~/");

			var model = new SignInVM();
			model.ReturnUrl = returnUrl;

			return View(model);
		}

		[HttpPost]
		[AutoValidateAntiforgeryToken]
		[Route("")]
		public async Task<IActionResult> SignIn(SignInVM model)
		{
			if (ModelState.IsValid)
			{
				var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

				if (result.Succeeded)
				{
					//base._logger.Log<>("User logged in.");
					return LocalRedirect(model.ReturnUrl);
				}
				//if (result.RequiresTwoFactor)
				//{
				//	return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
				//}
				if (result.IsLockedOut)
				{
					//_logger.LogWarning("Konto użytkownika jest zablokowane, prosimy o kontakt z administracją.");
					ModelState.AddModelError(string.Empty, "Konto użytkownika jest zablokowane, prosimy o kontakt z administracją.");
					return View(model);
				}
				else
				{
					ModelState.AddModelError(string.Empty, "Nieudana próba logowania.");
					return View(model);
				}
			}


			return View(model);
		}

		#endregion

		#region signUp

		[HttpGet]
		[Route("Create")]
		public IActionResult SignUp(string returnUrl = null)
		{
			returnUrl ??= Url.Content("~/");

			var model = new SignUpVM();
			model.ReturnUrl = returnUrl;

			return View(model);
		}

		[HttpPost]
		[AutoValidateAntiforgeryToken]
		[Route("Create")]
		public async Task<IActionResult> SignUp(SignUpVM model)
		{
			if (ModelState.IsValid)
			{
				var user = new User { UserName = model.Email, Email = model.Email, EmailConfirmed = true };
				var result = await _userManager.CreateAsync(user, model.Password);
				if (result.Succeeded)
				{
					//_logger.LogInformation("User created a new account with password.");

					//var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
					//code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
					//var callbackUrl = Url.Page(
					//    "/Account/ConfirmEmail",
					//    pageHandler: null,
					//    values: new { area = "Identity", userId = user.Id, code = code },
					//    protocol: Request.Scheme);

					_emailSender.SendEmail(new Message(
						new string[] { model.Email }, "Założono konto",
						$"Twoje konto zostało założone o nazwie <strong>{model.Email}</strong>, przejdź do logowania: <a href='{Url.Action("/Index")}'>logowanie</a>."
					));

					//if (_userManager.Options.SignIn.RequireConfirmedAccount)
					//{
					//    return RedirectToPage("RegisterConfirmation", new { email = model.Email });
					//}
					//else
					//{
					await _signInManager.SignInAsync(user, isPersistent: false);
					return Redirect("/Account/Dashboard");
														   //}
				}
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError(string.Empty, error.Description);
				}
			}

			return View(model);
		}

		#endregion

		#region logout

		[HttpGet]
		[Route("Close")]
		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return View();
		}

		#endregion
	}
}