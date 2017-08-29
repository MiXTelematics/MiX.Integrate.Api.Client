using MiX.Integrate.API.Client.Base;
using System;
using System.Net;
using System.Net.Http.Headers;

namespace MiX.Integrate.Api.Client.Base
{

	public interface IHttpRestResponse<T> : IHttpRestResponse
	{
		T Data { get; set; }
	}

	public interface IHttpRestResponse
	{
		IHttpRestRequest Request { get; set; }
		string Content { get; set; }
		HttpStatusCode StatusCode { get; set; }
		string StatusDescription { get; set; } 
		HttpResponseHeaders Headers { get; }
		bool IsSuccessStatusCode { get; }
		Exception ErrorException { get; set; }
	}

}
