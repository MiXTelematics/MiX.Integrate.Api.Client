using MiX.Integrate.Api.Client;
using MiX.Integrate.Api.Client.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;

namespace MiX.Integrate.Api.Client.Base
{
	public class HttpRestRequest : IHttpRestRequest
	{

		public string Resource { get; set; }
		public HttpMethod Method { get; set; }
		public string JsonBody { get; set; }
		public Dictionary<string, string> Headers { get; set; }
		public Dictionary<string, string> QueryParameters { get; set; }
		public Dictionary<string, string> UrlSegments { get; set; }

		public HttpRestRequest(string resource, HttpMethod method)
		{
			IEqualityComparer<string> stringComparer = StringComparer.OrdinalIgnoreCase;
			Resource = resource;
			Method = method;
			Headers = new Dictionary<string, string>(stringComparer);
			QueryParameters = new Dictionary<string, string>(stringComparer);
			UrlSegments = new Dictionary<string, string>(stringComparer);
			JsonBody = string.Empty;
		}

		public void AddJsonBody(object obj)
		{
			JsonBody = NewtonsoftJsonSerializer.Default.Serialize(obj);
		}

		public void AddHeader(string name, string value)
		{
			if (!Headers.ContainsKey(name))
				Headers.Add(name, value);
			else
				Headers[name] = value;
		}

		public void AddQueryParameter(string name, string value)
		{
			if (!QueryParameters.ContainsKey(name))
				QueryParameters.Add(name, value);
			else
				QueryParameters[name] = value;
		}

		public void AddUrlSegment(string name, string value)
		{
			if (!UrlSegments.ContainsKey(name))
				UrlSegments.Add(name, value);
			else
				UrlSegments[name] = value;
		}

		public string QueryUrl
		{
			get
			{
				string url = Resource;

				//replace UrlSegments
				foreach (KeyValuePair<string, string> item in UrlSegments)
				{
					url = url.Replace("{" + item.Key + "}", item.Value);
				}

				//add the queryparams
				if (QueryParameters.Count > 0)
				{
					var separator = "?";
					foreach (KeyValuePair<string, string> item in QueryParameters)
					{
						string qryKey = WebUtility.UrlEncode(item.Key);
						string qryValue = WebUtility.UrlEncode(item.Value);
						url += $"{separator}{qryKey}={qryValue}";
						separator = "&";
					}
				}

				return url;
			}
		}

	}
}
