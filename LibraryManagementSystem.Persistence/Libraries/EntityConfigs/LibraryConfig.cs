using LibraryManagementSystem.Domain.Library;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagementSystem.Persistence.Libraries.EntityConfigs
{
	public class LibraryConfig : IEntityTypeConfiguration<Library>
	{
		public void Configure(EntityTypeBuilder<Library> builder)
		{
			builder.ToTable("Libraries");
			builder.HasKey(t => t.Id);
		}
	}
}
