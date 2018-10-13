using System;

namespace LibraryManagementSystem.Domain.Audit
{
	public class AuditCreated
	{
		public DateTime CreatedDate { get; set; }
		public int CreatedById { get; set; }
	}
}
