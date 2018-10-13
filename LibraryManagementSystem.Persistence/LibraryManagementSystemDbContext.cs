using LibraryManagementSystem.Domain.Books;
using LibraryManagementSystem.Domain.Clients;
using LibraryManagementSystem.Domain.Library;
using LibraryManagementSystem.Persistence.Books.EntityConfigs;
using LibraryManagementSystem.Persistence.Clients.EntityConfigs;
using LibraryManagementSystem.Persistence.Libraries.EntityConfigs;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Persistence
{
	public class LibraryManagementSystemDbContext : DbContext
	{
		public DbSet<Library> Libraries { get; set; }
		public DbSet<Client> Clients { get; set; }
		public DbSet<Book> Books { get; set; }
		public DbSet<ClientXBook> ClientXBooks { get; set; }

		public LibraryManagementSystemDbContext(DbContextOptions<LibraryManagementSystemDbContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder) {
			builder.ApplyConfiguration(new LibraryConfig());
			builder.ApplyConfiguration(new ClientConfig());
			builder.ApplyConfiguration(new BooksConfig());
			builder.ApplyConfiguration(new ClientXBooksConfig());
		}
	}
}
