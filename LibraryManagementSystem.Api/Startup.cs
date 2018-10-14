using System;
using System.Collections.Generic;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using LibraryManagementSystem.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LibraryManagementSystem.Api
{
	public class Startup
	{
		public IConfiguration configuration { get; }
		public static IContainer container { get; private set; }

		public Startup(IHostingEnvironment env)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json", false, true)
				.AddEnvironmentVariables();
			configuration = builder.Build();
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public IServiceProvider ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();
			services.AddAuthorization();
			services.AddCors(options =>
			{
				options.AddPolicy("AllowAll",
					p => p.AllowAnyOrigin().
						AllowAnyHeader().
						AllowAnyMethod().
						AllowCredentials()
						);
			});

			var builder = new ContainerBuilder();
			var defaultModuleSettings = new Dictionary<string, string>
			{
				{"LibraryManagementSystemDbConnection", configuration.GetConnectionString("LibraryManagementSystem") }
			};
			builder.RegisterModule(new DefaultModule(defaultModuleSettings));

			builder.Populate(services);

			container = builder.Build();
			return new AutofacServiceProvider(container);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, 
								IHostingEnvironment env,
								ILoggerFactory loggerFctory,
								IApplicationLifetime applicationLifetime)
		{
			app.UseCors("AllowAll");
			app.UseAuthentication();
			app.UseMvc();
			applicationLifetime.ApplicationStopped.Register(() => container.Dispose());
		}
	}
}
