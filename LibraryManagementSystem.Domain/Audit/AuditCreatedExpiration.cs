using System;

namespace LibraryManagementSystem.Domain.Audit
{
	public class AuditCreatedExpiration: AuditCreated
	{
		public DateTime ExpirationDate { get; set; }
	}
}
