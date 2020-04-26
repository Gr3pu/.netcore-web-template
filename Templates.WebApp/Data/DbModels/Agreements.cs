using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Templates.WebApp.Data.DbModels
{
	public class Agreement : BaseModel
	{
		public string Title { get; set; }
		public string Content { get; set; }

		public bool IsRequired { get; set; }
	}
}
