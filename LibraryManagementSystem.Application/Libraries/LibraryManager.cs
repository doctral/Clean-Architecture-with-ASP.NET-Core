using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Application.Libraries.Data;
using LibraryManagementSystem.Application.Libraries.Dto;

namespace LibraryManagementSystem.Application.Libraries
{
	public class LibraryManager : ILibraryManager
	{
		private readonly ILibraryQueries _libraryQueries;

		public LibraryManager(ILibraryQueries libraryQueries)
		{
			_libraryQueries = libraryQueries;
		}

		public async Task<List<LibraryDto>> GetLibrariesAsync() =>
			await _libraryQueries.GetLibrariesAsync();
	}
}
