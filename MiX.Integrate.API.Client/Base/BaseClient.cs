using IdentityModel.Client;
using MiX.Identity.Client;
using MiX.Integrate.Shared.Constants;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading.Tasks;

namespace MiX.Integrate.Api.Client.Base
{

	public class BaseClient : IBaseClient
	{

		public Func<string> GetCorrelationId { get; set; }
		private RestClient _client;
		private bool _setTestRequestHeader;
		private bool _hasIDServerResourceOwnerClientSettings;
		private IdServerResourceOwnerClientSettings _idServerResourceOwnerClientSettings;

		private static string _idServerAccessToken;

		internal BaseClient() { }

		public BaseClient(string url, bool setTestRequestHeader = false)
		{
			if (String.IsNullOrEmpty(url))
			{
				throw new ArgumentException("Required arguments: url");
			}

			_client = new RestClient(url);
			SetClientJsonHandler();
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

			_client = new RestClient(url);
			SetClientJsonHandler();
			_setTestRequestHeader = setTestRequestHeader;
			_hasIDServerResourceOwnerClientSettings = true;
			_idServerResourceOwnerClientSettings = settings;
		}

		public IRestRequest GetRequest(string resource, Method method)
		{
			IRestRequest request = new RestRequest(resource, method);
			request.JsonSerializer = NewtonsoftJsonSerializer.Default;
			request.AddHeader("Accept", "application/json");
			request.RequestFormat = DataFormat.Json;
			string correlationId = GetCorrelationId?.Invoke();
			if (!string.IsNullOrEmpty(correlationId))
			{
				request.AddHeader("X-Forwarded-CorrelationId", correlationId);
			}

			if (_hasIDServerResourceOwnerClientSettings)
			{
				_idServerAccessToken = GetIdServerAccessToken(_idServerResourceOwnerClientSettings);
				request.AddHeader("Authorization", string.Format("Bearer {0}", _idServerAccessToken));
			}

			if (_setTestRequestHeader)
				request.AddHeader("x-testing", "true");

			return request;
		}

		private string GetIdServerAccessToken(IdServerResourceOwnerClientSettings settings)
		{
			try
			{
				IdentityClient identityClient = new IdentityClient(settings.BaseAddress, settings.ClientId, settings.ClientSecret);
				TokenResponse reponse = identityClient.RequestToken(settings.UserName, settings.Password, settings.Scopes);
				string accessToken = reponse.AccessToken;
				if (string.IsNullOrEmpty(accessToken))
				{
					throw new Exception("No AccessToken returned");
				}
				return accessToken;
			}
			catch (Exception exc)
			{
				throw new SecurityException("Authentication Failed", exc);
			}
		}

		public IRestResponse<T> Execute<T>(IRestRequest request) where T : new()
		{
			//IRestResponse resp = ExecuteAsync(request).GetAwaiter().GetResult();
			//CheckResponseError(resp);
			//IRestResponse<T> respT = CloneInTo<T>(resp);
			//return respT;

			IRestResponse<T> respT = ExecuteAsync<T>(request).GetAwaiter().GetResult();
			return respT;
		}

		public IRestResponse Execute(IRestRequest request)
		{
			//IRestResponse resp = ExecuteAsync(request).GetAwaiter().GetResult();
			//CheckResponseError(resp);
			//return resp;

			IRestResponse resp = ExecuteAsync(request).GetAwaiter().GetResult();
			return resp;
		}

		public async Task<IRestResponse<T>> ExecuteAsync<T>(IRestRequest request) where T : new()
		{
			TaskCompletionSource<IRestResponse> taskCompletion = new TaskCompletionSource<IRestResponse>();
			RestRequestAsyncHandle handle = _client.ExecuteAsync(request, r => taskCompletion.SetResult(r));
			IRestResponse resp = await taskCompletion.Task.ConfigureAwait(false);
			CheckResponseError(resp);
			IRestResponse<T> respT = CloneInTo<T>(resp);
			return respT;
		}

		public async Task<IRestResponse> ExecuteAsync(IRestRequest request)
		{
			TaskCompletionSource<IRestResponse> taskCompletion = new TaskCompletionSource<IRestResponse>();
			RestRequestAsyncHandle handle = _client.ExecuteAsync(request, r => taskCompletion.SetResult(r));
			IRestResponse resp = await taskCompletion.Task.ConfigureAwait(false);
			CheckResponseError(resp);
			return resp;
		}

		public string GetNewObjectUrl(IRestResponse response)
		{
			foreach (Parameter item in response.Headers)
			{
				if (item.Name.Equals(Headers.NEW_OBJECT_URL))
					return Convert.ToString(item.Value);
			}
			return "";
		}

		public string GetResponseHeader(IList<Parameter> headers, string name)
		{
			var idHeaderVal = headers.ToList().FirstOrDefault(h => h.Name.ToLowerInvariant().Equals(name))
					?.Value.ToString();

			return idHeaderVal;
		}

		public void CheckResponseError(IRestResponse response)
		{
			if ((int)response.StatusCode >= 400 & (int)response.StatusCode < 500)
			{
				throw new HttpClientException(response.StatusCode, response.Content);
			}
			if ((int)response.StatusCode >= 500 & (int)response.StatusCode < 600)
			{
				throw new HttpServerException(response.StatusCode, response.Content);
			}
			if (response.ResponseStatus == ResponseStatus.Error)
			{
				if (response.ErrorException != null)
					throw (response.ErrorException);
				else
					throw new Exception(response.ErrorMessage);
			}
		}

		private void SetClientJsonHandler()
		{
			NewtonsoftJsonSerializer serializer = NewtonsoftJsonSerializer.Default;
			_client.AddHandler("application/json", serializer);
			_client.AddHandler("text/json", serializer);
			_client.AddHandler("text/x-json", serializer);
			_client.AddHandler("text/javascript", serializer);
			_client.AddHandler("*+json", serializer);
		}

		public IRestResponse<T> CloneInTo<T>(IRestResponse resp) where T : new()
		{
			IRestResponse<T> respT = new RestResponse<T>();
			respT.Content = resp.Content;
			respT.ContentEncoding = resp.ContentEncoding;
			respT.ContentLength = resp.ContentLength;
			respT.ContentType = resp.ContentType;
			if (resp.Cookies != null)
			{
				foreach (var cookie in resp.Cookies)
				{
					respT.Cookies.Add(cookie);
				}
			}
			respT.ErrorException = resp.ErrorException;
			respT.ErrorMessage = resp.ErrorMessage;
			if (resp.Headers != null)
			{
				foreach (var header in resp.Headers)
				{
					respT.Headers.Add(header);
				}
			}
			respT.RawBytes = resp.RawBytes;
			respT.Request = resp.Request;
			respT.ResponseStatus = resp.ResponseStatus;
			respT.ResponseUri = resp.ResponseUri;
			respT.Server = resp.Server;
			respT.StatusCode = resp.StatusCode;
			respT.StatusDescription = resp.StatusDescription;
			RestSharp.Deserializers.JsonDeserializer ds = new RestSharp.Deserializers.JsonDeserializer();
			respT.Data = ds.Deserialize<T>(resp);
			return respT;
		}

	}
}

