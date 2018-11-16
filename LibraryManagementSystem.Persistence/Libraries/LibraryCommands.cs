using LibraryManagementSystem.Application.Libraries.Data;
using LibraryManagementSystem.Application.Libraries.Dto;
using LibraryManagementSystem.Domain.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace LibraryManagementSystem.Persistence.Libraries
{
	public class LibraryCommands : ILibraryCommands
	{
		private readonly LibraryManagementSystemDbContext _db;

		public LibraryCommands(LibraryManagementSystemDbContext db)
		{
			_db = db;
		}

		public async Task<int> CreateAsync(Library library) {
			_db.Libraries.Add(library);
			await _db.SaveChangesAsync();
			return library.Id;
		}

		public async Task UpdateAsync(LibraryDto lib)
			=> await _db.Libraries.Where(x => x.Id == lib.Id).UpdateAsync(x => new Library
			{
				Name=lib.Name,
				Address=lib.Address
			});

		public async Task DeleteAsync(int id)
			=> await _db.Libraries.Where(x => x.Id == id).DeleteAsync();
	}
}
