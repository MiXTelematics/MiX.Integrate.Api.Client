using MiX.Integrate.API.Client;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace MiX.Integrate.Api.Client
{

	public class HttpRestResponse : HttpRestResponseBase, IHttpRestResponse { }

	public class HttpRestResponse<T> : HttpRestResponseBase, IHttpRestResponse<T>
	{  

		public T Data { get; set; }

		public static explicit operator HttpRestResponse<T>(HttpRestResponse response)
		{
			return new HttpRestResponse<T>
			{
				Request = response.Request,
				Content = response.Content,
				StatusCode = response.StatusCode,
				StatusDescription = response.StatusDescription,
				Headers = response.Headers,
				IsSuccessStatusCode = response.IsSuccessStatusCode,
				ErrorException = response.ErrorException
			};
		}

	}
	 
	public abstract class HttpRestResponseBase
	{
		protected HttpRestResponseBase()
		{
			//this.ResponseStatus = ResponseStatus.None;
			//this.Headers = new HttpResponseHeaders();
			//this.Cookies = new List<RestResponseCookie>();
		}

		public IHttpRestRequest Request { get; set; }

		public string Content { get; set; }

		public HttpStatusCode StatusCode { get; set; }

		public string StatusDescription { get; set; }

		public HttpResponseHeaders Headers { get; set; }

		public bool IsSuccessStatusCode { get; set; }

		public Exception ErrorException { get; set; }
	}

}
