using MiX.Integrate.API.Client.Base;
using MiX.Integrate.Shared.Entities.Trailers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MiX.Integrate.API.Client
{
	public interface ITrailersClient : IBaseClient
	{
		List<Trailer> GetAll(long groupId);
		Task<List<Trailer>> GetAllAsync(long groupId);
	}
}
