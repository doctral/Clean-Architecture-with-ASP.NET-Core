using LibraryManagementSystem.Infrastructure.Message;
using System.Collections.Generic;

namespace LibraryManagementSystem.Infrastructure.Result
{
	public class BaseResult : IBaseResult, ISystemMessageList<ISystemMessage>
	{
		public List<ISystemMessage> messages { get; set; }

		public bool Success { get; set; }

		public void AddErrorMessage(string message)
		{
			this.messages.Add(new SystemMessage
			{
				Title=message,
				MessageType=SystemMessageType.Error
			});
		}

		public void AddInfoMessage(string message)
		{
			this.messages.Add(new SystemMessage
			{
				Title = message,
				MessageType = SystemMessageType.Info
			});
		}

		public void AddMessage(ISystemMessage message)
		{
			this.messages.Add(message);
		}

		public void AddSuccessMessage(string message)
		{
			this.messages.Add(new SystemMessage
			{
				Title = message,
				MessageType = SystemMessageType.Success
			});
		}

		public void AddWarningMessage(string message)
		{
			this.messages.Add(new SystemMessage
			{
				Title = message,
				MessageType = SystemMessageType.Warning
			});
		}
	}
}
