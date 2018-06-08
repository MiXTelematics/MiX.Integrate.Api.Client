using System;

namespace MiX.Integrate.Api.Client.Base
{
	public interface IBaseClient
	{
		Func<string> GetCorrelationId { get; set; }
		bool CompressionEnabled { get; set; }
	}
}
