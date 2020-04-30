using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Templates.WebApp.Data.DbModels
{
	public class Page : BaseModel
	{
		public string ShortName { get; set; }
		public string Content { get; set; }
		public bool RequireAuth { get; set; }

		// SEO
		public string SeoTitle { get; set; }
		public string SeoDescription { get; set; }
		public string SeoKeywords { get; set; }
		public string SeoAuthor { get; set; }
		public string SeoRate { get; set; }
		public bool SeoShouldFollow { get; set; }

		// URL path
		public string UrlParam1 { get; set; }
		public string UrlParam2 { get; set; }
		public string UrlParam3 { get; set; }

	}
}
