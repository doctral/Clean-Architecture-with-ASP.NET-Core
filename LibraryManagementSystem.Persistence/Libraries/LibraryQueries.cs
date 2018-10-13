using LibraryManagementSystem.Application.Libraries.Data;
using LibraryManagementSystem.Application.Libraries.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Persistence.Libraries
{
	public class LibraryQueries : ILibraryQueries
	{
		private readonly LibraryManagementSystemDbContext _db;

		public LibraryQueries(LibraryManagementSystemDbContext db)
		{
			_db = db;
		}

		public async Task<List<LibraryDto>> GetLibrariesAsync() =>
			await GetQueryableLibraries().AsNoTracking().ToListAsync();

		private IQueryable<LibraryDto> GetQueryableLibraries()
		{
			return from l in _db.Libraries
				   select new LibraryDto
				   {
					   Id = l.Id,
					   Name = l.Name,
					   Address = l.Address
				   };
		}
	}
}
