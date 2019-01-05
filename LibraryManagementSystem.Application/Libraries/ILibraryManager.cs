using LibraryManagementSystem.Application.Helpers;
using LibraryManagementSystem.Application.Libraries.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Libraries
{
	public interface ILibraryManager
	{
		PagedList<LibraryDto> GetLibrariesAsync(PageParameters pageParameters);
		Task<LibraryDto> GetLibraryByIdAsync(int id);
	}
}
