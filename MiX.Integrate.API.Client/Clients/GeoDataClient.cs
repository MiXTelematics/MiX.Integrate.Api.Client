using System;
using System.Threading.Tasks;
using MiX.Integrate.API.Client.Base;
using MiX.Integrate.Shared.Entities.GeoData;

namespace MiX.Integrate.API.Client
{
  public class GeoDataClient : BaseClient, IGeoDataClient
	{
		public GeoDataClient(string url, bool setTestRequestHeader = false) : base(url, setTestRequestHeader) { }
		public GeoDataClient(string url, IdServerResourceOwnerClientSettings settings, bool setTestRequestHeader = false) : base(url, settings, setTestRequestHeader) { }


		public GeoDataFile GetAssetMovements(long groupId, DateTime @from, DateTime to, GeoDataFormat format)
		{
			//IHttpRestRequest request = GetRequest(APIControllerRoutes.GeoDataController.GETASSETMOVEMENTSFORGROUP, HttpMethod.Get);
			//request.AddUrlSegment("groupId", groupId.ToString());
			//request.AddUrlSegment("from", from.ToString(DataFormats.DateTime_Format));
			//request.AddUrlSegment("to", to.ToString(DataFormats.DateTime_Format));
			//request.AddQueryParameter("format", format.ToString()); 
			//IHttpRestResponse response = Execute(request);
			//return response..Data;
			throw new NotImplementedException();
		}

		public async Task<GeoDataFile> GetAssetMovementsAsync(long groupId, DateTime @from, DateTime to, GeoDataFormat format)
		{
			throw new NotImplementedException();
		}
	}
}
