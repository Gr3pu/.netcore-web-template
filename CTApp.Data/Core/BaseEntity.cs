using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTApp.Data.Core
{
	public interface IBaseEntity
	{
	}

	public class BaseEntity : IBaseEntity
	{
		public int Id { get; set; }
		public Guid Hash { get; set; }
		public Guid ParentHash { get; set; }

		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }

		public bool IsArchived { get; set; }
		public DateTime ArchivedAt { get; set; }

		public BaseEntity()
		{
			Hash = Guid.NewGuid();
			CreatedAt = DateTime.Now;
		}
	}

	public class BaseUserEntity : IdentityUser, IBaseEntity
	{
	}
}
