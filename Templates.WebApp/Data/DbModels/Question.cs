using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Templates.WebApp.Data.DbModels
{
	public class Question : BaseModel
	{
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public string Content { get; set; }
		public string AgreementByPhone { get; set; }
		public string Status { get; set; }
	}
}
