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
					if (attempts == times)
					{
						throw ex;
					}

					//If Unauthorized exception clear the access token
					if (ex.HttpStatusCode == System.Net.HttpStatusCode.Unauthorized && idServerResourceOwnerClientSettings != null)
					{
						AccessTokenCache.ClearIdServerAccessToken(idServerResourceOwnerClientSettings);
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
			if (attempts == 1) delay = TimeSpan.FromSeconds(5);
			else if (attempts == 2) delay = TimeSpan.FromSeconds(10);
			else if (attempts == 3) delay = TimeSpan.FromSeconds(15);
			else delay = TimeSpan.FromSeconds(20);

			return Task.Delay(delay);
		}

	}
}
