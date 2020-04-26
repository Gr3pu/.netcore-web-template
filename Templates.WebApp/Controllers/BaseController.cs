using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Templates.WebApp.Workers;

namespace Templates.WebApp.Controllers
{
    public abstract class BaseController<T> : Controller
	{
		internal readonly ILogger<T> _logger;
		internal readonly IActivityMonitor _activityMonitor;

		public BaseController(IServiceProvider provider)
		{
			this._logger = provider.GetService(typeof(ILogger<T>)) as ILogger<T>;
			this._activityMonitor = provider.GetService(typeof(IActivityMonitor)) as IActivityMonitor;

			this._activityMonitor.logActivity();
		}
	}
}