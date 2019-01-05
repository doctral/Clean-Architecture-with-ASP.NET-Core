using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Application.Helpers
{
	public class PageParameters
	{
		const int maxPageSize = 100;
		public int PageNumber { get; set; } = 1;
		private int _pageSize = 10;
		public int PageSize {
			get {
				return _pageSize;
			}
			set {
				_pageSize = (value > maxPageSize) ? maxPageSize : value;
			}
		}
	}
}
