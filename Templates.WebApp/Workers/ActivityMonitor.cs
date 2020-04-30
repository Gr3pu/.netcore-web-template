using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Templates.WebApp.Data;
using Templates.WebApp.Data.DbModels;

namespace Templates.WebApp.Workers
{
	public class ActivityMonitor : ActionFilterAttribute
	{
		private readonly DatabaseContext _context;

		public ActivityMonitor(DatabaseContext context)
		{
			this._context = context;
		}

		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			var request = filterContext.HttpContext.Request;
			var actionDescriptor = ((ControllerBase)filterContext.Controller).ControllerContext.ActionDescriptor;

			UserActivity model = new UserActivity()
			{
				Hash = Guid.NewGuid(),
				User = filterContext.HttpContext.User.Identity.Name,
				IpAddress = filterContext.HttpContext.Connection.LocalIpAddress.MapToIPv4().ToString(),

				RouteParams = JsonConvert.SerializeObject(new
				{
					Controller = actionDescriptor.ControllerName,
					Action = actionDescriptor.ActionName,
					Params = actionDescriptor.Parameters.ToList(),
				}),
				RequestHeaders = JsonConvert.SerializeObject(request.Headers.ToList()),
				Timestamp = DateTime.UtcNow
			};

			_context.UserActivities.Add(model);
			_context.SaveChanges();

			base.OnActionExecuting(filterContext);
		}
	}
}
