using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Templates.WebApp.Data.DbModels
{
	public class AppConfig : BaseModel
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public string TitleSuffix { get; set; }

		public string Admins { get; set; }
		public string Owner { get; set; }

	}
}
