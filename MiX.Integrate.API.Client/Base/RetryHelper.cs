using System;
using System.Threading.Tasks;

namespace MiX.Integrate.API.Client.Base
{
	public static class RetryHelper
	{
		public static async Task RetryOnExceptionAsync(int times, Func<Task> operation, IdServerResourceOwnerClientSettings idServerResourceOwnerClientSettings)
		{
			if (times <= 0)
				throw new ArgumentOutOfRangeException(nameof(times));

			var attempts = 0;
			bool hasClearedAccessToken = false;
			do
			{
				try
				{
					attempts++;
					await operation().ConfigureAwait(false);
					break;
				}
				catch (HttpClientException ex)
				{
					//If Unauthorized exception decrement attempts and clear the access token - only do once
					if (!hasClearedAccessToken && ex.HttpStatusCode == System.Net.HttpStatusCode.Unauthorized && idServerResourceOwnerClientSettings != null)
					{
						hasClearedAccessToken = true;
						attempts--;
						AccessTokenCache.ClearIdServerAccessToken(idServerResourceOwnerClientSettings);
					}

					if (attempts == times)
					{
						throw ex;
					}

					await CreateDelay(attempts).ConfigureAwait(false);
				}
				catch (HttpServerException ex)
				{
					if (attempts == times)
					{
						throw ex;
					}

					await CreateDelay(attempts).ConfigureAwait(false);
				}
				catch (Exception ex)
				{
					if (attempts == times)
					{
						throw ex;
					}

					await CreateDelay(attempts).ConfigureAwait(false);
				}
			} while (true);
		}

		private static Task CreateDelay(int attempts)
		{
			TimeSpan delay;
			if (attempts < 1) delay = TimeSpan.FromSeconds(1);
			else if (attempts == 1) delay = TimeSpan.FromSeconds(5);
			else if (attempts == 2) delay = TimeSpan.FromSeconds(10);
			else if (attempts == 3) delay = TimeSpan.FromSeconds(15);
			else delay = TimeSpan.FromSeconds(20);

			return Task.Delay(delay);
		}

	}
}
