using LibraryManagementSystem.Application.Helpers;
using LibraryManagementSystem.Application.Libraries.Data;
using LibraryManagementSystem.Application.Libraries.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

		public PagedList<LibraryDto> GetLibrariesAsync(PageParameters pageParameters)
		{
			return PagedList<LibraryDto>
						.Create(GetQueryableLibraries(), pageParameters.PageNumber, pageParameters.PageSize);
		}

		public async Task<LibraryDto> GetLibraryAsync(Expression<Func<LibraryDto, bool>> predicate)
			=> await GetQueryableLibraries().Where(predicate).FirstOrDefaultAsync();

		private IQueryable<LibraryDto> GetQueryableLibraries()
		{
			return (from l in _db.Libraries
				   select new LibraryDto
				   {
					   Id = l.Id,
					   Name = l.Name,
					   Address = l.Address
				   })
				   .OrderBy(x=>x.Name)
				   .ThenBy(x=>x.Address);
		}
	}
}
