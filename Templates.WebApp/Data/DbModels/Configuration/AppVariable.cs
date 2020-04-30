using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Templates.WebApp.Data.DbModels.Configuration
{
	public class AppVariable : BaseModel
	{
		public string Code { get; set; }
		public string Description { get; set; }
		public string Value { get; set; }
	}
}
