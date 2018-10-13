using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManagementSystem.Api
{
	public class Startup
	{
		//public IConfiguration configuration { get; }

		//public Startup(IHostingEnvironment env) {
		//	var builder = new ConfigurationBuilder()
		//		.SetBasePath(env.ContentRootPath)
		//		.AddJsonFile("appsettings.json", false, true)
		//		.AddEnvironmentVariables();
		//	configuration = builder.Build();
		//}

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			//services.AddMvc();
			//services.AddAuthorization();
			//services.AddCors(options =>
			//{
			//options.AddPolicy("AllowAll",
			//	p => p.AllowAnyOrigin().
			//		AllowAnyHeader().
			//		AllowAnyMethod().
			//		AllowCredentials()
			//		);
			//});

			//var builder = new ContainerBuilder();
			//var defaultModuleSettings = new Dictionary<string, string>
			//{
			//	{"LibraryManagementSystemDbConnection", configuration.GetConnectionString("LibraryManagementSystem") }
			//};
			//builder.RegisterModule(new defaultModule(defaultModuleSettings));
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
		}
	}
}
