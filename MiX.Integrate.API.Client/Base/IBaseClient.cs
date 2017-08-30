using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiX.Integrate.Api.Client.Base
{
	public interface IBaseClient
	{
		Func<string> GetCorrelationId { get; set; }
	}
}
