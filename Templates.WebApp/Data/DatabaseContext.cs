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
		// put tables here
		public DbSet<LawArticle> LawArticles { get; set; }
		public DbSet<Agreement> Agreements { get; set; }
		public DbSet<SeoConfig> SeoConfigs { get; set; }
		public DbSet<Question> Questions { get; set; }


		public DatabaseContext(DbContextOptions<DatabaseContext> options)
			: base(options)
		{
		}
	}
}
