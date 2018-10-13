using LibraryManagementSystem.Domain.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagementSystem.Persistence.Books.EntityConfigs
{
	public class BooksConfig : IEntityTypeConfiguration<Book>
	{
		public void Configure(EntityTypeBuilder<Book> builder)
		{
			builder.ToTable("Books");
			builder.HasKey(x=>x.Id);
		}
	}
}
