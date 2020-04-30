using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Templates.WebApp.Areas.Account.ViewModels
{
	public class SignInVM
	{
		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Display(Name = "Zapamiętaj mnie")]
		public bool RememberMe { get; set; }

		public string ReturnUrl { get; set; }
	}
}
