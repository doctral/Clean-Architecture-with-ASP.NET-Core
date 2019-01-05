using LibraryManagementSystem.Application.Helpers;
using LibraryManagementSystem.Application.Libraries.Dto;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Libraries.Data
{
	public interface ILibraryQueries
	{
		PagedList<LibraryDto> GetLibrariesAsync(PageParameters pageParameters);
		Task<LibraryDto> GetLibraryAsync(Expression<Func<LibraryDto, bool>> predicate);
	}
}
