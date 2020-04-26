using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Templates.WebApp.Data.DbModels
{
	public class BaseModel
	{
		public int Id { get; set; }
		public Guid Hash { get; set; }



		public bool IsActive { get; set; }

		public string CreatedBy { get; set; }
		public DateTime CreatedAt { get; set; }

		public string UpdatedBy { get; set; }
		public DateTime UpdatedAt { get; set; }

		public string DeactivatedBy { get; set; }
		public DateTime DeactivatedAt { get; set; }



		public string Name { get; set; }
		public string Note { get; set; }
	}
}
