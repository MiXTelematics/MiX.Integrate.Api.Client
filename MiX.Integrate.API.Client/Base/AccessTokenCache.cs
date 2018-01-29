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
					//ToDo: possibly preemptively check if token is still valid 
					return response.AccessToken;
				}

				try
				{ 

					IdentityClient identityClient = new IdentityClient(settings.BaseAddress, settings.ClientId, settings.ClientSecret);
					TokenResponse reponse = identityClient.RequestToken(settings.UserName, settings.Password, settings.Scopes);

					if (reponse == null || string.IsNullOrEmpty(reponse.AccessToken))
					{
						throw new HttpClientException(System.Net.HttpStatusCode.Unauthorized, "Authorisation error: No AccessToken returned");
					}

					_idServerAccessTokens.Add(settingsHash, reponse);
					 
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
 
				if (_idServerAccessTokens.ContainsKey(settingsHash))
				{
					_idServerAccessTokens.Remove(settingsHash);
				}
			}
		}

	}
}
