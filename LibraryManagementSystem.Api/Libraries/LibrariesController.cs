using System.Threading.Tasks;
using LibraryManagementSystem.Application.Helpers;
using LibraryManagementSystem.Application.Libraries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryManagementSystem.Api.Libraries
{
	[Route("libraries")]
	[AllowAnonymous]
	public class LibrariesController : BaseController
	{
		private readonly ILibraryManager _libraryManager;

		public LibrariesController(ILibraryManager libraryManager, IUrlHelper urlHelper) : base(urlHelper)
		{
			_libraryManager = libraryManager;
		}

		[HttpGet]
		public IActionResult GetLibrariesAsync(PageParameters pageParameters)
		{
			var results =_libraryManager.GetLibrariesAsync(pageParameters);
			var previousPageLink = results.HasPrevious ? CreateResourceUri("libraries", pageParameters, ResourceUriType.PreviousPage) : null;
			var nextPageLink = results.HasNext ? CreateResourceUri("libraries", pageParameters, ResourceUriType.NextPage) : null;
			var paginationMetadata = new {
				totalCount = results.TotalCount,
				pageSize = results.PageSize,
				currentPage = results.CurrentPage,
				totalPages = results.TotalPages,
				previousPageLink=  previousPageLink,
				nextPageLink = nextPageLink
			};

			Response.Headers.Add("X-Pagination",
					Newtonsoft.Json.JsonConvert.SerializeObject(paginationMetadata));

			return Ok(results);
		}



	}
}
