using MiX.Integrate.API.Client.Base;
using MiX.Integrate.Shared.Constants;
using MiX.Integrate.Shared.Entities.Aemp;
using MiX.Integrate.Shared.Entities.Carriers;
using MiX.Integrate.Shared.Entities.Events;
using MiX.Integrate.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MiX.Integrate.API.Client
{
  /// <inheritdoc cref="IAempClient"/>
  public class AempClient : BaseClient, IAempClient
    {

        public AempClient(string url, bool setTestRequestHeader = false) : base(url, setTestRequestHeader) { }
        public AempClient(string url, IdServerResourceOwnerClientSettings settings, bool setTestRequestHeader = false) : base(url, settings, setTestRequestHeader) { }
        
        public async Task<FleetSnapshot> GetFleetSnapshotPagedAsync(long organisationId, uint pageNum = 1)
        {
            IHttpRestRequest request = GetRequest(APIControllerRoutes.AempController.GETFLEETSNAPSHOTPAGED, HttpMethod.Get);
            request.AddUrlSegment("organisationId", organisationId.ToString());
            request.AddUrlSegment("pageNum", pageNum.ToString());
            IHttpRestResponse<FleetSnapshot> response = await ExecuteAsync<FleetSnapshot>(request);
            return response.Data;
        }

        
        public FleetSnapshot GetFleetSnapshotPaged(long organisationId, uint pageNum = 1)
        {
            IHttpRestRequest request = GetRequest(APIControllerRoutes.AempController.GETFLEETSNAPSHOTPAGED, HttpMethod.Get);
            request.AddUrlSegment("organisationId", organisationId.ToString());
            request.AddUrlSegment("pageNum", pageNum.ToString());
            IHttpRestResponse<FleetSnapshot> response = Execute<FleetSnapshot>(request);
            return response.Data;
        }

		/// <summary>Checks whether the supplied <see cref="FleetSnapshot"/> is the last available "page" of data</summary>
		/// <param name="fleetSnapshot">The <see cref="FleetSnapshot"/> to examine</param>
		/// <returns><see langword="true"/> if the specified <see cref="FleetSnapshot"/> is the last available page, otherwise <see langword="false"/></returns>
		/// <exception cref="ArgumentNullException"> when <paramref name="fleetSnapshot"/> is <see langword="null"/>null</exception>
		/// <exception cref="InvalidOperationException"> when the <paramref name="fleetSnapshot"/> does not include the necessary <see cref="Link"/> data </exception>
		public bool IsLastPage(FleetSnapshot fleetSnapshot)
		{
			if (fleetSnapshot == null) 
				throw new ArgumentNullException(nameof(fleetSnapshot));

			var thisHref = fleetSnapshot.Links?.FirstOrDefault(l => "this".Equals(l.rel, StringComparison.InvariantCultureIgnoreCase))?.href;
			var lastHref = fleetSnapshot.Links?.FirstOrDefault(l => "last".Equals(l.rel, StringComparison.InvariantCultureIgnoreCase))?.href;

			if (string.IsNullOrWhiteSpace(thisHref) || string.IsNullOrWhiteSpace(lastHref))
				throw new InvalidOperationException("Link data missing or invalid");

			return thisHref.Equals(lastHref, StringComparison.InvariantCultureIgnoreCase);
		}
    }
}
