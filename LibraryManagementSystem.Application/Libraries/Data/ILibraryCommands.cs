using LibraryManagementSystem.Application.Libraries.Dto;
using LibraryManagementSystem.Domain.Library;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Libraries.Data
{
	public interface ILibraryCommands
	{
		Task<int> CreateAsync(Library library);
		Task UpdateAsync(LibraryDto lib);
		Task DeleteAsync(int id);
	}
}
