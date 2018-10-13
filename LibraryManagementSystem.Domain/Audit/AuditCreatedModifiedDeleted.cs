using System;

namespace LibraryManagementSystem.Domain.Audit
{
	public class AuditCreatedModifiedDeleted : AuditCreatedModified
	{
		public int DeletedById { get; set; }
		public DateTime DeletedDate { get; set; }
	}
}
