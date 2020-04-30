using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Templates.WebApp.Data;

namespace Templates.WebApp.Areas.Administration.Controllers
{
    [Authorize]
    [Area("Administration")]
    [Route("A/Variables")]
    public class VariablesController : Controller
	{
		private readonly DatabaseContext _context;

		public VariablesController(DatabaseContext context)
		{
			this._context = context;

			var username = User.Identity.Name;

			if (username != null && username != String.Empty)
			{
				var user = _context.Users.FirstOrDefault(n => n.UserName == username);
				if (!user.IsAdmin)
				{
					Redirect("/");
				}
			}
			else
			{
				Redirect("/");
			}
		}

		[HttpGet]
		[Route("")]
		public IActionResult Index()
		{
			return View();
		}
	}
}