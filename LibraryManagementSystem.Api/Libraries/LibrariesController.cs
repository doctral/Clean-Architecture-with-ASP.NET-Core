using System.Threading.Tasks;
using LibraryManagementSystem.Application.Helpers;
using LibraryManagementSystem.Application.Libraries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Google.Cloud.Dialogflow.V2;
using Google.Protobuf;
using System.IO;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryManagementSystem.Api.Libraries
{
	[Route("libraries")]
	[AllowAnonymous]
	public class LibrariesController : BaseController
	{
		private readonly ILibraryManager _libraryManager;
		private static readonly JsonParser jsonParser = new JsonParser(JsonParser.Settings.Default.WithIgnoreUnknownFields(true));
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

		[HttpPost]
		public async Task<JsonResult> GetWebhookResponse() {
			WebhookRequest request;
			using (var reader = new StreamReader(Request.Body))
			{
				request = jsonParser.Parse<WebhookRequest>(reader);
			}

			var pas = request.QueryResult.Parameters;
			var askingName = pas.Fields.ContainsKey("name") && pas.Fields["name"].ToString().Replace('\"', ' ').Trim().Length > 0;
			var askingAddress = pas.Fields.ContainsKey("address") && pas.Fields["address"].ToString().Replace('\"', ' ').Trim().Length > 0;

			var response = new WebhookResponse();

			var library = await _libraryManager.GetLibraryByIdAsync(1);

			if (askingName && askingAddress)
			{
				response.FulfillmentText = "Library name is: " + library.Name + ", Library Address is: "+ library.Address;
			}
			else if (askingName)
			{
				response.FulfillmentText = "Library name is: " + library.Name;
			}
			else if (askingAddress)
			{
				response.FulfillmentText = "Library Address is: "+ library.Address;
			}
			else {
				response.FulfillmentText = "You are not asking about either name or address of the library";
			}


			return Json(response);
		}

	}
}
