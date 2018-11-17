using LibraryManagementSystem.Infrastructure.Message;
using System.Collections.Generic;

namespace LibraryManagementSystem.Infrastructure.Result
{
	public class ManagerResult<T> : BaseResult
	{
		public ManagerResult()
		{
			this.messages = new List<ISystemMessage>();
		}

		public T Data { get; set; }
	}
}
