using LibraryManagementSystem.Domain.Audit;

namespace LibraryManagementSystem.Domain.Clients
{
	public class ClientXBook : AuditCreatedExpiration
	{
		public int Id { get; set; }
		public int ClientId { get; set; }
		public int BookId { get; set; }
	}
}
