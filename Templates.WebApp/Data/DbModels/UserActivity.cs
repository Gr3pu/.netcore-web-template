using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Templates.WebApp.Data.DbModels
{
	public class UserActivity
	{
		public int Id { get; set; }
		public Guid Hash { get; set; }

		public string User { get; set; }
		public string IpAddress { get; set; }
		public DateTime Timestamp { get; set; }

		public string RouteParams { get; set; }
		public string RequestHeaders { get; set; }
	}
}
