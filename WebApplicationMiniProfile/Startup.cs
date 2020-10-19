using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationMiniProfile
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			// Host = localhost; Database = lers; Timeout = 180; Integrated Security = True; Application Name = "ËÝÐÑ Ó×ÅÒ - Ñåðâåð"; Username = lers
			string connection = $@"Data Source=GERASIMOV\MSSQL_LERS_SERVE;Initial Catalog=LERS_Trunk;Integrated Security=True;Connect Timeout=180;Application Name=""ËÝÐÑ Ó×ÅÒ -Ñåðâåð"";Current Language=us_english";
			services.AddDbContext<ApplicationContext>(options =>
				options.UseSqlServer(connection));

			services.AddControllers();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
