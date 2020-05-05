using MiX.Integrate.API.Client.Base;
using MiX.Integrate.Shared.Constants;
using MiX.Integrate.Shared.Entities.Trailers;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiX.Integrate.API.Client
{
	public class TrailersClient : BaseClient, ITrailersClient
	{
		public TrailersClient(string url, bool setTestRequestHeader = false) : base(url, setTestRequestHeader) { }
		public TrailersClient(string url, IdServerResourceOwnerClientSettings settings, bool setTestRequestHeader = false) : base(url, settings, setTestRequestHeader) { }

		public List<Trailer> GetAll(long groupId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.AssetsController.GETALL, HttpMethod.Get);
			request.AddUrlSegment("groupId", groupId.ToString());
			IHttpRestResponse<List<Trailer>> response = Execute<List<Trailer>>(request);
			return response.Data;
		}

		public async Task<List<Trailer>> GetAllAsync(long groupId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.AssetsController.GETALL, HttpMethod.Get);
			request.AddUrlSegment("groupId", groupId.ToString());
			IHttpRestResponse<List<Trailer>> response = await ExecuteAsync<List<Trailer>>(request).ConfigureAwait(false);
			return response.Data;
		}

	}



}
