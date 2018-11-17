using LibraryManagementSystem.Infrastructure.Message;
using System.Collections.Generic;

namespace LibraryManagementSystem.Infrastructure.Result
{
	public interface IBaseResult
	{
		List<ISystemMessage> messages { get; set; }
	}
}
