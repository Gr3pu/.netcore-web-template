using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Templates.WebApp.Data.DbModels;

namespace Templates.WebApp.Data
{
	public class DatabaseContext : IdentityDbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<UserActivity> UserActivities { get; set; }

		// put tables here



		public DatabaseContext(DbContextOptions<DatabaseContext> options)
			: base(options)
		{
		}
	}
}
