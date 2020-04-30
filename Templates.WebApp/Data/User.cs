using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Templates.WebApp.Data
{
	public class User : IdentityUser
	{
		public string Agreements { get; set; } // lista guidów na TAK
		public bool IsAdmin { get; set; }
	}
}
