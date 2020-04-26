using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Templates.WebApp.Data.DbModels
{
	public class LawArticle : BaseModel
	{
		public string Title { get; set; }
		public string Content { get; set; }
		public string Image { get; set; } // as base64

		public string SeoConfigId { get; set; }

		public bool CanBePrinted { get; set; }
	}
}
