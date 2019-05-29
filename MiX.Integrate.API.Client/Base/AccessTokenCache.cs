using IdentityModel.Client;
using MiX.Identity.Client;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MiX.Integrate.API.Client.Base
{
	public static class AccessTokenCache
	{
		private static Dictionary<int, TokenResponse> _idServerAccessTokens = new Dictionary<int, TokenResponse>();
		private static object _lock = new object();
		private static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1);

		public static async Task<string> GetIdServerAccessToken(IdServerResourceOwnerClientSettings settings, HttpClientHandler httpClientHandler)
		{
			await semaphoreSlim.WaitAsync();
			try
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
					IdentityClient identityClient = new IdentityClient(settings.BaseAddress, settings.ClientId, settings.ClientSecret, httpClientHandler);

					TokenResponse reponse = await identityClient.RequestTokenAsync(settings.UserName, settings.Password, settings.Scopes).ConfigureAwait(false);

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
			finally
			{
				semaphoreSlim.Release();
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
