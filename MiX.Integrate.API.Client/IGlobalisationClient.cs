using System;
using System.Threading.Tasks;

namespace MiX.Integrate.API.Client
{
	public interface IGlobalisationClient
	{
		#if !NETSTANDARD1_6
		TimeZoneInfo FindSystemTimeZoneById(string timeZoneId);
		Task<TimeZoneInfo> FindSystemTimeZoneByIdAsync(string timeZoneId);
		#endif
	}
}