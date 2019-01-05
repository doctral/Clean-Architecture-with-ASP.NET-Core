using System;

namespace LibraryManagementSystem.Infrastructure.Message
{
	public class SystemMessage : ISystemMessage
	{
		public Guid id { get; set; } = Guid.NewGuid();
		public string Title { get; set; }
		public string Body { get; set; }
		public string MessageType { get; set; }
	}
}
