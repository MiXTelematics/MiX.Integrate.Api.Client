using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace MiX.Integrate.Api.Client.Base
{
	public interface IHttpRestRequest
	{
		string Resource { get; }
		HttpMethod Method { get; }
		string JsonBody { get; }

		Dictionary<string, string> Headers { get; }
		Dictionary<string, string> QueryParameters { get; }
		Dictionary<string, string> UrlSegments { get; }

		string QueryUrl { get; }
		 
		void AddJsonBody(object obj);
		void SetHeader(string name, string value);
		void AddQueryParameter(string name, string value);
		void AddUrlSegment(string name, string value);
	}
}
