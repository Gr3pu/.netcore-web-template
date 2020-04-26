using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Templates.WebApp.Data.DbModels
{
	public class SeoConfig : BaseModel
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public string Keywords { get; set; }
		public string Author { get; set; }
		public string Rate { get; set; }
	}
}
