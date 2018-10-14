using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagementSystem.Application.Libraries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryManagementSystem.Api.Libraries
{
	[Route("libraries")]
	[AllowAnonymous]
	public class LibrariesController : Controller
	{
		private readonly ILibraryManager _libraryManager;

		public LibrariesController(ILibraryManager libraryManager)
		{
			_libraryManager = libraryManager;
		}

		[HttpGet]
		public async Task<IActionResult> GetLibrariesAsync()
		{
			var results =await _libraryManager.GetLibrariesAsync();
			if (results == null) return NotFound();
			return Ok(results);
		}

	}
}
