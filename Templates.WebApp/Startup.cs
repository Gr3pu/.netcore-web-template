using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pomelo.EntityFrameworkCore.MySql.Storage;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Templates.WebApp.Workers;
using Templates.WebApp.Data;

namespace Templates.WebApp
{
	public class Startup
	{
		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}


		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<DatabaseContext>(options =>
				options.UseMySql(Configuration.GetConnectionString("DefaultConnection"), mySqlOptions =>
					mySqlOptions.ServerVersion(new ServerVersion(new Version(10, 1, 43), ServerType.MariaDb))
				)
			);

			services.AddDefaultIdentity<User>(options =>
				options.SignIn.RequireConfirmedAccount = true
			).AddEntityFrameworkStores<DatabaseContext>();

			services.AddControllersWithViews();
			services.AddRazorPages();


			// services:


			// workers:
			services.AddTransient<IActivityMonitor, ActivityMonitor>();


			services.AddMvc(options => options.EnableEndpointRouting = false);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				//app.UseDatabaseErrorPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}


			app.UseHttpsRedirection();
			app.UseAuthentication();
			app.UseAuthorization();
			app.UseStaticFiles();
			app.UseRouting();


			//app.UseRewriter(new RewriteOptions().AddRewrite("/", "Informations", true));
			app.UseMvc(routes =>
			{
				routes.MapRoute(
				  name: "areas",
				  template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
				);

				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}"
				);
			});
		}
	}
}
