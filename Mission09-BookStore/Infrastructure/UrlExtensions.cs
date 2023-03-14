using System;
using Microsoft.AspNetCore.Http;

namespace Mission09_BookStore.Infrastructure
{
	public static class UrlExtensions
	{
		// This allows the user to continue shopping without starting a new session
		public static string PathAndQuery(this HttpRequest request) =>
			request.QueryString.HasValue ? $"{request.Path}{request.QueryString}" : request.Path.ToString();
	}
}

