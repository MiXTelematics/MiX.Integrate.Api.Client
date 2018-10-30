using System;
using System.Net;

namespace MiX.Integrate.API.Client
{
	public class HttpException : Exception
	{
		private HttpStatusCode _httpStatusCode;

		public HttpException(HttpStatusCode httpStatusCode, string message) : base(message)
		{
			_httpStatusCode = httpStatusCode;
		}

		public HttpStatusCode HttpStatusCode { get { return _httpStatusCode; } private set { } }
	}

	public class HttpClientException : HttpException
	{
		public HttpClientException(HttpStatusCode httpStatusCode, string message) : base(httpStatusCode, message) { }
	}
	public class HttpServerException : HttpException
	{
		public HttpServerException(HttpStatusCode httpStatusCode, string message) : base(httpStatusCode, message) { }
	}
}
