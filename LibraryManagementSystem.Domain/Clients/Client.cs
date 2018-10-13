using LibraryManagementSystem.Domain.Audit;

namespace LibraryManagementSystem.Domain.Clients
{
	public class Client : AuditCreatedModifiedDeleted
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
	}
}
