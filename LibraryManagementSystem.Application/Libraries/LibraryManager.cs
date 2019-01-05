using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Application.Helpers;
using LibraryManagementSystem.Application.Libraries.Data;
using LibraryManagementSystem.Application.Libraries.Dto;

namespace LibraryManagementSystem.Application.Libraries
{
	public class LibraryManager : ILibraryManager
	{
		private readonly ILibraryQueries _libraryQueries;
		private readonly ILibraryCommands _libraryCommands;

		public LibraryManager(ILibraryQueries libraryQueries, ILibraryCommands libraryCommands)
		{
			_libraryQueries = libraryQueries;
			_libraryCommands = libraryCommands;
		}

		public PagedList<LibraryDto> GetLibrariesAsync(PageParameters pageParameters)
			=> _libraryQueries.GetLibrariesAsync(pageParameters);

		public async Task<LibraryDto> GetLibraryByIdAsync(int id)
			=> await _libraryQueries.GetLibraryAsync(x=>x.Id==id);

	}
}
