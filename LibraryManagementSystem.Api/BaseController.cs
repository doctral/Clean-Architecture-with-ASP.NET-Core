using LibraryManagementSystem.Application.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Api
{
	[AllowAnonymous]
	public class BaseController : Controller
	{
		private IUrlHelper _urlHelper;

		protected IPAddress ipAddress => Request.HttpContext.Connection.RemoteIpAddress;
		public BaseController(IUrlHelper url)
		{
			_urlHelper = url;
		}
		protected string CreateResourceUri(string apiRoute, PageParameters pageParameters, ResourceUriType type)
		{
			switch (type)
			{
				case ResourceUriType.PreviousPage:
					return _urlHelper.Link(apiRoute,
						new
						{
							pageNumber = pageParameters.PageNumber - 1,
							pageSize = pageParameters.PageSize
						}
						);
				case ResourceUriType.NextPage:
					return _urlHelper.Link(apiRoute,
						new
						{
							pageNumber = pageParameters.PageNumber + 1,
							pageSize = pageParameters.PageSize
						});
				default:
					return _urlHelper.Link(apiRoute,
						new
						{
							pageNumber = pageParameters.PageNumber,
							pageSize = pageParameters.PageSize
						}
						);
			}
		}
	}
}
