using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Application.Libraries.Dto
{
	public class LibraryCreateDto
	{
		[Required]
		public string Name { get; set; }

		[Required]
		public string Address { get; set; }
	}
}
