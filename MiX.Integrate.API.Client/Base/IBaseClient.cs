using System;

namespace MiX.Integrate.API.Client.Base
{
	public interface IBaseClient
	{
		Func<string> GetCorrelationId { get; set; }
		bool CompressionEnabled { get; set; }
	}
}
