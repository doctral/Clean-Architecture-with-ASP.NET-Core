using LibraryManagementSystem.Domain.Clients;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Persistence.Clients.EntityConfigs
{
	public class ClientConfig : IEntityTypeConfiguration<Client>
	{
		public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Client> builder)
		{
			builder.ToTable("Clients");
			builder.HasKey(x=>x.Id);
		}
	}
}
