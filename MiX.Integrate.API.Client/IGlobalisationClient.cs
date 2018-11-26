using System;
using System.Threading.Tasks;

namespace MiX.Integrate.API.Client
{
	public interface IGlobalisationClient
	{
		TimeZoneInfo FindSystemTimeZoneById(string timeZoneId);
		Task<TimeZoneInfo> FindSystemTimeZoneByIdAsync(string timeZoneId);
	}
}