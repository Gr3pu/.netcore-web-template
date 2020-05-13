using CTApp.Data;
using CTApp.Data.Entities;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace CTApp.Web
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
			// database setting
			services.AddDbContext<ApplicationDbContext>();
			services.AddScoped<IUnitOfWork, UnitOfWork>();
			services.AddDefaultIdentity<UserEntity>(options =>
				options.SignIn.RequireConfirmedAccount = true
			).AddEntityFrameworkStores<ApplicationDbContext>();

			services.AddControllersWithViews();
			services.AddRazorPages();
			services.AddMvc(options => options.EnableEndpointRouting = false);
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

			// serwisy
		}



		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			//app.UseForwardedHeaders(new ForwardedHeadersOptions
			//{
			//	ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
			//});

			app.UseAuthorization();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
				  name: "areas",
				  template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
				);

				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}"
				);
			});
		}
	}
}
