using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Templates.WebApp.Controllers
{
	public abstract class BaseController<T> : Controller
	{
		internal readonly ILogger<T> _logger;

		public BaseController(IServiceProvider provider)
		{
			this._logger = provider.GetService(typeof(ILogger<T>)) as ILogger<T>;
		}
	}
}