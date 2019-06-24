using System;
using System.Net;

namespace MiX.Integrate.API.Client.Base
{
	public interface IBaseClient
	{
		Func<string> GetCorrelationId { get; set; }
		bool CompressionEnabled { get; set; }
		TimeSpan Timeout { get; set; }
#if (NET452 || NET462 || NETSTANDARD2_0)
		WebProxy Proxy { get; set; }
#endif
	}
}
