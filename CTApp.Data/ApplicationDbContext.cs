using CTApp.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Pomelo.EntityFrameworkCore.MySql.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTApp.Data
{
	public class ApplicationDbContext : IdentityDbContext<UserEntity>
	{
		public DbSet<UserEntity> Users { get; set; }
		public DbSet<TestEntity> TestEntities { get; set; }

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options) { }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var connectionString = "Server=localhost;Database=ct_app;User=root;Password=;";

			optionsBuilder.UseMySql(connectionString, mySqlOptions =>
				mySqlOptions.ServerVersion(new ServerVersion(
					new Version(10, 1, 43), ServerType.MariaDb))
			);
		}
	}
}
