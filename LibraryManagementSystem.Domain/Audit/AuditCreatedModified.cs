using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Domain.Audit
{
	public class AuditCreatedModified : AuditCreated
	{
		public DateTime ModifiedDate { get; set; }
		public int ModifiedById { get; set; }
	}
}
