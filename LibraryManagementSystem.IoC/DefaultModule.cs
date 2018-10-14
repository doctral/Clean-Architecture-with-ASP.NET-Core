using System.Collections.Generic;
using Autofac;
using System.Reflection;
using Module = Autofac.Module;
using LibraryManagementSystem.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.IoC
{
	public class DefaultModule : Module
	{
		private readonly Dictionary<string, string> _settings;

		public DefaultModule(Dictionary<string, string> settings)
		{
			_settings = settings;
		}

		protected override void Load(ContainerBuilder builder)
		{
			Assembly[] assemblies =
			{
				Assembly.Load("LibraryManagementSystem.Domain"),
				Assembly.Load("LibraryManagementSystem.Application"),
				Assembly.Load("LibraryManagementSystem.Persistence"),
				Assembly.Load("LibraryManagementSystem.Infrastructure")
			};

			builder.RegisterAssemblyTypes(assemblies)
				.Where(x => !x.Name.EndsWith("DbContext"))
				.AsImplementedInterfaces();

			var DbConnection = _settings["LibraryManagementSystemDbConnection"];
			builder.RegisterType<LibraryManagementSystemDbContext>()
				.WithParameter("options", new DbContextOptionsBuilder<LibraryManagementSystemDbContext>()
				.UseSqlServer(DbConnection)
				.Options)
				.InstancePerLifetimeScope();
		}
	}
}
