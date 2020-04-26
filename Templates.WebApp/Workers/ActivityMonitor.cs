using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Templates.WebApp.Workers
{
	public interface IActivityMonitor
	{
		void logActivity();
	}

	public class ActivityMonitor : IActivityMonitor
	{
		public void logActivity()
		{
			// do something
		}
	}
}
