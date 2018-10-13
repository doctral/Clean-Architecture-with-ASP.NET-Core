using LibraryManagementSystem.Domain.Clients;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagementSystem.Persistence.Clients.EntityConfigs
{
	public class ClientXBooksConfig : IEntityTypeConfiguration<ClientXBook>
	{
		public void Configure(EntityTypeBuilder<ClientXBook> builder)
		{
			builder.ToTable("ClientXBooks");
			builder.HasKey(x=>x.Id);
		}
	}
}
