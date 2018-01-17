using IdentityModel.Client;
using MiX.Identity.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiX.Integrate.Api.Client.Base
{
	public static class AccessTokenCache
	{
		private static Dictionary<int, TokenResponse> _idServerAccessTokens = new Dictionary<int, TokenResponse>();
		private static object _lock = new object();

		//Debug vars
		private static string _classId = DateTime.UtcNow.ToString("HH:mm:ss.fff");
		private static int _totalRequests = 0;
		private static int _totalCleared = 0;
		private static int _totalCacheResults = 0;


		public static string GetIdServerAccessToken(IdServerResourceOwnerClientSettings settings)
		{
			lock (_lock)
			{
				if (settings == null)
				{
					throw new ArgumentException("Parameter IdServerResourceOwnerClientSettings not provided");
				}

				int settingsHash = $"{settings.BaseAddress}|{settings.ClientId}|{settings.ClientSecret}|{settings.Scopes}|{settings.UserName}|{settings.Password}".GetHashCode();

				if (_idServerAccessTokens.ContainsKey(settingsHash) && _idServerAccessTokens[settingsHash] != null)
				{
					TokenResponse response = _idServerAccessTokens[settingsHash];
					_totalCacheResults++;
					//Console.WriteLine($"Return cached AccessToken #{_totalCacheResults} for {settingsHash} @ {_classId}");
					//ToDo: possibly preemptively check if token is still valid 
					return response.AccessToken;
				}

				try
				{
					_totalRequests++;
					//Console.WriteLine($"GetIdServerAccessToken #{_totalRequests} for {settingsHash} @ {_classId}");

					IdentityClient identityClient = new IdentityClient(settings.BaseAddress, settings.ClientId, settings.ClientSecret);
					TokenResponse reponse = identityClient.RequestToken(settings.UserName, settings.Password, settings.Scopes);

					if (reponse == null || string.IsNullOrEmpty(reponse.AccessToken))
					{
						throw new HttpClientException(System.Net.HttpStatusCode.Unauthorized, "Authorisation error: No AccessToken returned");
					}

					_idServerAccessTokens.Add(settingsHash, reponse);
					 
					//Console.WriteLine($"AccessToken #{_totalRequests} cached for {settingsHash} @ {_classId}");

					return reponse.AccessToken;
				}
				catch (Exception exc)
				{
					throw new HttpClientException(System.Net.HttpStatusCode.Unauthorized, $"Authorisation error: {exc.Message}");
				}
			}
		}

		public static void ClearIdServerAccessToken(IdServerResourceOwnerClientSettings settings)
		{
			lock (_lock)
			{
				if (settings == null)
				{
					throw new ArgumentException("Parameter IdServerResourceOwnerClientSettings not provided");
				}

				int settingsHash = $"{settings.BaseAddress}|{settings.ClientId}|{settings.ClientSecret}|{settings.Scopes}|{settings.UserName}|{settings.Password}".GetHashCode();

				_totalCleared++;
				//Console.WriteLine($"ClearIdServerAccessToken #{_totalCleared} for {settingsHash} @ {_classId}");

				if (_idServerAccessTokens.ContainsKey(settingsHash))
				{
					_idServerAccessTokens.Remove(settingsHash);
				}
			}
		}

	}
}
