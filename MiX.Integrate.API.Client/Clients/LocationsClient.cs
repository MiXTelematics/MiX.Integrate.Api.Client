﻿using MiX.Integrate.API.Client.Base;
using MiX.Integrate.Shared.Constants;
using MiX.Integrate.Shared.Entities.Events;
using MiX.Integrate.Shared.Entities.Locations;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MiX.Integrate.API.Client
{
	public class LocationsClient : BaseClient, ILocationsClient
	{
		public LocationsClient(string url, bool setTestRequestHeader = false) : base(url, setTestRequestHeader) { }
		public LocationsClient(string url, IdServerResourceOwnerClientSettings settings, bool setTestRequestHeader = false) : base(url, settings, setTestRequestHeader) { }

		public async Task<Location> GetAsync(long locationId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.LocationsController.GET, HttpMethod.Get);
			request.AddUrlSegment("locationId", locationId.ToString());
			IHttpRestResponse<Location> response = await ExecuteAsync<Location>(request).ConfigureAwait(false);
			return response.Data;
		}

		public Location Get(long locationId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.LocationsController.GET, HttpMethod.Get);
			request.AddUrlSegment("locationId", locationId.ToString());
			IHttpRestResponse<Location> response = Execute<Location>(request);
			return response.Data;
		}

		public async Task<List<Location>> GetAllAsync(long groupId, bool includeShape = false, bool includeDeleted = false)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.LocationsController.GETALL, HttpMethod.Get);
			request.AddUrlSegment("groupId", groupId.ToString());
			request.AddQueryParameter("includeShape", includeShape.ToString());
			request.AddQueryParameter("includeDeleted", includeDeleted.ToString());
			IHttpRestResponse<List<Location>> response = await ExecuteAsync<List<Location>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public List<Location> GetAll(long groupId, bool includeShape = false, bool includeDeleted = false)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.LocationsController.GETALL, HttpMethod.Get);
			request.AddUrlSegment("groupId", groupId.ToString());
			request.AddQueryParameter("includeShape", includeShape.ToString());
			request.AddQueryParameter("includeDeleted", includeDeleted.ToString());
			IHttpRestResponse <List<Location>> response = Execute<List<Location>>(request);
			return response.Data;
		}

		public async Task UpdateAsync(Location location, long groupId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.LocationsController.UPDATE, HttpMethod.Put);
			request.AddUrlSegment("groupId", groupId.ToString());
			request.AddJsonBody(location);
			await ExecuteAsync(request).ConfigureAwait(false);
		}

		public void Update(Location location, long groupId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.LocationsController.UPDATE, HttpMethod.Put);
			request.AddUrlSegment("groupId", groupId.ToString());
			request.AddJsonBody(location);
			Execute(request);
		}

		public async Task<long> AddAsync(Location location, long groupId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.LocationsController.ADD, HttpMethod.Post);
			request.AddUrlSegment("groupId", groupId.ToString());
			request.AddJsonBody(location);
			IHttpRestResponse response = await ExecuteAsync(request).ConfigureAwait(false);
			long locationId = Convert.ToInt64(GetResponseHeader(response.Headers, "locationId"));
			return locationId;
		}

		public long Add(Location location, long groupId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.LocationsController.ADD, HttpMethod.Post);
			request.AddUrlSegment("groupId", groupId.ToString());
			request.AddJsonBody(location);
			IHttpRestResponse response = Execute(request);
			long locationId = Convert.ToInt64(GetResponseHeader(response.Headers, "locationId"));
			return locationId;
		}

		public async Task DeleteAsync(long groupId, long locationId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.LocationsController.DELETE, HttpMethod.Delete);
			request.AddUrlSegment("groupId", groupId.ToString());
			request.AddUrlSegment("locationId", locationId.ToString());
			await ExecuteAsync(request).ConfigureAwait(false); ;
		}

		public void Delete(long groupId, long locationId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.LocationsController.DELETE, HttpMethod.Delete);
			request.AddUrlSegment("groupId", groupId.ToString());
			request.AddUrlSegment("locationId", locationId.ToString());
			Execute(request);
		}

		public List<Location> InRange(long groupId, Coordinate coordinate, long meters)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.LocationsController.INRANGE, HttpMethod.Post);
			request.AddUrlSegment("groupId", groupId.ToString());
			request.AddUrlSegment("meters", meters.ToString());
			request.AddJsonBody(coordinate);
			IHttpRestResponse<List<Location>> response = Execute<List<Location>>(request);
			return response.Data;
		}

		public async Task<List<Location>> InRangeAsync(long groupId, Coordinate coordinate, long meters)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.LocationsController.INRANGE, HttpMethod.Post);
			request.AddUrlSegment("groupId", groupId.ToString());
			request.AddUrlSegment("meters", meters.ToString());
			request.AddJsonBody(coordinate);
			IHttpRestResponse<List<Location>> response = await ExecuteAsync<List<Location>>(request).ConfigureAwait(false);
			return response.Data;
		}

		public ProximityQueryResult Nearest(long groupId, Coordinate coordinate)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.LocationsController.NEAREST, HttpMethod.Post);
			request.AddUrlSegment("groupId", groupId.ToString());
			request.AddJsonBody(coordinate);
			IHttpRestResponse<ProximityQueryResult> response = Execute<ProximityQueryResult>(request);
			return response.Data;
		}

		public async Task<ProximityQueryResult> NearestAsync(long groupId, Coordinate coordinate)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.LocationsController.NEAREST, HttpMethod.Post);
			request.AddUrlSegment("groupId", groupId.ToString());
			request.AddJsonBody(coordinate);
			IHttpRestResponse<ProximityQueryResult> response = await ExecuteAsync<ProximityQueryResult>(request).ConfigureAwait(false);
			return response.Data;
		}

		/// <inheritdoc />
		public List<Location> GetChangedSince(long organisationId, DateTime since)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.LocationsController.CHANGEDSINCE, HttpMethod.Get);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			request.AddUrlSegment("since", $"{since:yyyyMMddHHmmss}");
			IHttpRestResponse<List<Location>> response = Execute<List<Location>>(request);
			return response.Data;
		}

		/// <inheritdoc />
		public async Task<List<Location>> GetChangedSinceAsync(long organisationId, DateTime since)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.LocationsController.CHANGEDSINCE, HttpMethod.Get);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			request.AddUrlSegment("since", $"{since:yyyyMMddHHmmss}");
			IHttpRestResponse<List<Location>> response = await ExecuteAsync<List<Location>>(request).ConfigureAwait(false);
			return response.Data;
		}

		/// <inheritdoc />
		public async Task<List<LocationLegacy>> MigrateLegacyIdsAsync(long organisationId)
		{
			IHttpRestRequest request = GetRequest(APIControllerRoutes.LocationsController.MIGRATELEGACYIDS, HttpMethod.Get);
			request.AddUrlSegment("organisationId", organisationId.ToString());
			IHttpRestResponse<List<LocationLegacy>> response = await ExecuteAsync<List<LocationLegacy>>(request).ConfigureAwait(false);
			return response.Data;
		}
	}
}
