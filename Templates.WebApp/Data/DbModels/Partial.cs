using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Templates.WebApp.Data.DbModels
{
	public class Partial : BaseModel
	{
		public string ShortName { get; set; }
		public string Content { get; set; }
	}
}
