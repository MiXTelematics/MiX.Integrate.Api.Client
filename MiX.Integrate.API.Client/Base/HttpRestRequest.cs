using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace MiX.Integrate.API.Client.Base
{
	public class HttpRestRequest : IHttpRestRequest
	{

		public string Resource { get; set; }
		public HttpMethod Method { get; set; }
		public string JsonBody { get; set; }
		//public Dictionary<string, string> Headers { get; set; }
		//public Dictionary<string, string>  QueryParameters { get; set; }
		//public Dictionary<string, string>  UrlSegments { get; set; }

		public IEnumerable<KeyValuePair<string, string>> Headers { get; set; }
		public IEnumerable<KeyValuePair<string, string>> QueryParameters { get; set; }
		public IEnumerable<KeyValuePair<string, string>> UrlSegments { get; set; }


		public HttpRestRequest(string resource, HttpMethod method)
		{
			Resource = resource;
			Method = method;
			Headers = new List<KeyValuePair<string, string>>();
			QueryParameters = new List<KeyValuePair<string, string>>();
			UrlSegments = new List<KeyValuePair<string, string>>();
			JsonBody = string.Empty;
		}

		public void AddJsonBody(object obj)
		{ }

		public void AddHeader(string name, string value)
		{ }

		public void AddQueryParameter(string name, string value)
		{

		}

		public void AddUrlSegment(string name, string value)
		{ }


	}
}
