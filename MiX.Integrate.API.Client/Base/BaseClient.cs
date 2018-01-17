using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MiX.Integrate.Api.Client.Base
{
	public class BaseClient : IBaseClient
	{
		public Func<string> GetCorrelationId { get; set; }
		private string _url;
		private bool _setTestRequestHeader;
		private bool _hasIDServerResourceOwnerClientSettings;
		private IdServerResourceOwnerClientSettings _idServerResourceOwnerClientSettings;
		//private static ConcurrentDictionary<int, string> _idServerAccessTokens = new ConcurrentDictionary<int, string>();
		//private static Object _idServerAccessLock = new Object();
		private static HttpClient _httpClient;
		private bool _notFoundShouldReturnNull;

		private static HttpClient HttpClient
		{
			get
			{
				if (_httpClient == null)
				{
					_httpClient = new HttpClient();
					_httpClient.DefaultRequestHeaders.ExpectContinue = false;
				}
				return _httpClient;
			}
			set { _httpClient = value; }
		}

		internal BaseClient() { }

		public BaseClient(string url, bool setTestRequestHeader = false)
		{
			if (String.IsNullOrEmpty(url))
			{
				throw new ArgumentException("Required arguments: url");
			}

			_url = url;
			_setTestRequestHeader = setTestRequestHeader;
			_hasIDServerResourceOwnerClientSettings = false;
		}

		public BaseClient(string url, IdServerResourceOwnerClientSettings settings, bool setTestRequestHeader = false)
		{
			if (String.IsNullOrEmpty(url))
			{
				throw new ArgumentException("Required arguments: url");
			}

			if (settings == null)
			{
				throw new ArgumentException("Required arguments: IdServerResourceOwnerClientSettings");
			}
			if (string.IsNullOrEmpty(settings.BaseAddress) |
					string.IsNullOrEmpty(settings.ClientId) |
					string.IsNullOrEmpty(settings.ClientSecret) |
					string.IsNullOrEmpty(settings.UserName) |
					string.IsNullOrEmpty(settings.Password) |
					string.IsNullOrEmpty(settings.Scopes))
			{
				throw new ArgumentException("Required IdServerResourceOwnerClientSettings: BaseAddress, ClientId, ClientSecret, UserName, Password, Scopes");
			}

			_url = url;
			_setTestRequestHeader = setTestRequestHeader;
			_hasIDServerResourceOwnerClientSettings = true;
			_idServerResourceOwnerClientSettings = settings;
		}


		public bool HTTPStatusNotFoundShouldReturnNull
		{
			get { return _notFoundShouldReturnNull; }
			set { _notFoundShouldReturnNull = value; }
		}


		public IHttpRestRequest GetRequest(string resource, HttpMethod method)
		{
			IHttpRestRequest request = new HttpRestRequest(resource, method);

			string correlationId = GetCorrelationId?.Invoke();
			if (!string.IsNullOrEmpty(correlationId))
			{
				request.SetHeader("X-Forwarded-CorrelationId", correlationId);
			}

			if (_setTestRequestHeader)
				request.SetHeader("x-testing", "true");

			return request;
		}

		//private string GetIdServerAccessToken()
		//{
		//	try
		//	{

		//		if (_idServerResourceOwnerClientSettings == null)
		//		{
		//			throw new ArgumentException("IdServerResourceOwnerClientSettings not set");
		//		}

		//		int settingsHash = $"{_idServerResourceOwnerClientSettings.BaseAddress}|{_idServerResourceOwnerClientSettings.ClientId}|{_idServerResourceOwnerClientSettings.ClientSecret}|{_idServerResourceOwnerClientSettings.Scopes}|{_idServerResourceOwnerClientSettings.UserName}|{_idServerResourceOwnerClientSettings.Password}".GetHashCode();

		//		if (_idServerAccessTokens.ContainsKey(settingsHash) && !string.IsNullOrWhiteSpace(_idServerAccessTokens[settingsHash]))
		//		{
		//			string token = _idServerAccessTokens[settingsHash];
		//			return token;
		//		}

		//		lock (_idServerAccessLock)
		//		{
		//			IdentityClient identityClient = new IdentityClient(_idServerResourceOwnerClientSettings.BaseAddress, _idServerResourceOwnerClientSettings.ClientId, _idServerResourceOwnerClientSettings.ClientSecret);
		//			TokenResponse reponse = identityClient.RequestToken(_idServerResourceOwnerClientSettings.UserName, _idServerResourceOwnerClientSettings.Password, _idServerResourceOwnerClientSettings.Scopes);
		//			string accessToken = reponse.AccessToken;
		//			if (string.IsNullOrEmpty(accessToken))
		//			{
		//				throw new Exception("No AccessToken returned");
		//			}
		//			_idServerAccessTokens.AddOrUpdate(settingsHash, accessToken, (key, oldValue) => accessToken);
		//			Task.Delay(7600);
		//			return accessToken;
		//		}

		//	}
		//	catch (Exception exc)
		//	{
		//		throw new SecurityException("Authentication Failed", exc);
		//	}
		//}

		public IHttpRestResponse<T> Execute<T>(IHttpRestRequest request) where T : new()
		{
			IHttpRestResponse<T> respT = ExecuteAsync<T>(request).ConfigureAwait(false).GetAwaiter().GetResult();
			return respT;
		}

		public IHttpRestResponse Execute(IHttpRestRequest request)
		{
			IHttpRestResponse resp = ExecuteAsync(request).ConfigureAwait(false).GetAwaiter().GetResult();
			return resp;
		}

		public async Task<IHttpRestResponse<T>> ExecuteAsync<T>(IHttpRestRequest request) where T : new()
		{
			IHttpRestResponse resp = await ExecuteAsync(request).ConfigureAwait(false);
			IHttpRestResponse<T> respT = CloneInTo<T>(resp);
			return respT;
		}

		public async Task<IHttpRestResponse> ExecuteAsync(IHttpRestRequest request)
		{
			IHttpRestResponse resp = null;

			var maxRetryAttempts = 3;
			await RetryHelper.RetryOnExceptionAsync(maxRetryAttempts, async () =>
		 {
			 resp = await ExecuteInternalAsync(request).ConfigureAwait(false);
		 },
			 _idServerResourceOwnerClientSettings).ConfigureAwait(false);

			return resp;
		}

		private async Task<IHttpRestResponse> ExecuteInternalAsync(IHttpRestRequest request)
		{
			string apiUrl = _url + "/" + request.QueryUrl;
			HttpRequestMessage requestMessage = new HttpRequestMessage(request.Method, new Uri(apiUrl));

			if (_hasIDServerResourceOwnerClientSettings)
			{
				string bearerToken = AccessTokenCache.GetIdServerAccessToken(_idServerResourceOwnerClientSettings);
				request.SetHeader("Authorization", string.Format("Bearer {0}", bearerToken));
			}

			requestMessage.Headers.Add("Accept", "application/json");
			foreach (KeyValuePair<string, string> item in request.Headers)
			{
				requestMessage.Headers.Add(item.Key, item.Value.ToString());
			}
			if (request.JsonBody.Length > 0)
			{
				var jsonBody = new StringContent(request.JsonBody, Encoding.UTF8, "application/json");
				requestMessage.Content = jsonBody;
			}

			HttpResponseMessage response = await HttpClient.SendAsync(requestMessage).ConfigureAwait(false);
			CheckResponseError(response);

			Stream stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);

			var sr = new StreamReader(stream);
			string content = sr.ReadToEnd();

			IHttpRestResponse resp = new HttpRestResponse()
			{
				Request = request,
				Content = content,
				StatusCode = response.StatusCode,
				Headers = response.Headers
			};

			return resp;
		}

		public string GetResponseHeader(HttpResponseHeaders headers, string name)
		{
			string idHeaderVal = string.Empty;
			if (headers.Contains(name))
				idHeaderVal = headers.GetValues(name).FirstOrDefault();
			return idHeaderVal;
		}

		private string GetResponseContent(HttpResponseMessage response)
		{
			Stream stream = response.Content.ReadAsStreamAsync().ConfigureAwait(false).GetAwaiter().GetResult();
			var sr = new StreamReader(stream);
			string content = sr.ReadToEnd();
			return content;
		}

		public void CheckResponseError(HttpResponseMessage response)
		{
			if (_notFoundShouldReturnNull && response.StatusCode == HttpStatusCode.NotFound)
			{
				//If flag is set do not throw error on NotFound (404). The client will return a null result instead.
				return;
			}
			if ((int)response.StatusCode >= 400 & (int)response.StatusCode < 500)
			{
				string content = GetResponseContent(response);
				dynamic responseForInvalidStatusCode = response.Content.ReadAsStringAsync();
				throw new HttpClientException(response.StatusCode, content);
			}
			if ((int)response.StatusCode >= 500 & (int)response.StatusCode < 600)
			{
				string content = GetResponseContent(response);
				throw new HttpServerException(response.StatusCode, content);
			}
		}

		public IHttpRestResponse<T> CloneInTo<T>(IHttpRestResponse resp) where T : new()
		{
			HttpRestResponse<T> respT = new HttpRestResponse<T>
			{
				Request = resp.Request,
				Content = resp.Content,
				StatusCode = resp.StatusCode,
				StatusDescription = resp.StatusDescription,
				Headers = resp.Headers,
				IsSuccessStatusCode = resp.IsSuccessStatusCode,
				ErrorException = resp.ErrorException
			};
			if (resp.StatusCode == HttpStatusCode.NoContent)
			{
				if (IsEnumarable(respT.Data)) // Return empty list if Enumarable
				{
					respT.Data = new T();
				}
			}
			else if (resp.StatusCode == HttpStatusCode.NotFound)
			{
				if (IsEnumarable(respT.Data)) // Return empty list if Enumarable
				{
					respT.Data = new T();
				}
			}
			else
			{
				respT.Data = NewtonsoftJsonSerializer.Default.Deserialize<T>(resp.Content);
			}
			return respT;
		}

		public static bool IsEnumarable<T>(T item)
		{
			if (typeof(T).Name == "String") return false;
			bool isEnumerable = typeof(T).GetTypeInfo().GetInterface("IEnumerable") != null;
			return isEnumerable;
		}

		public static bool IsEnumarableAndHasItems<T>(T item)
		{
			if (item == null) return false;
			if (!IsEnumarable(item)) return false;
			var enumerable = item as System.Collections.IEnumerable;
			if (enumerable == null) return false;
			foreach (var obj in enumerable)
			{
				return true;
			}
			return false;
		}

	}
}

