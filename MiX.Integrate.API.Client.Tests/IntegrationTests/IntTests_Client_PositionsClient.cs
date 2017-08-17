using System;
using MiX.Integrate.API.Client.Tests;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using MiX.Integrate.Shared.Entities.Positions;
using System.Linq;

namespace MiX.Integrate.Api.Client.Tests
{
	[TestClass]
	public class IntTests_Client_PositionsClient
	{
		#region startup 
		// Dev data  
		private static string _apiUrl = Main.Configuration["appSettings:ApiUrl"];
		private static List<long> _assetIds = new List<long>() { 1, 2, 3 };
		private static List<long> _groupIds = new List<long>() { 1, 2, 3 };
		private static List<long> _driverIds = new List<long>() { 1, 2, 3 };
		private static List<long> _tripIds = new List<long>() { 1, 2, 3 };

		private static IdServerResourceOwnerClientSettings _idServerResourceOwnerClientSettings;
		private static IPositionsClient _positionsClient;

		[ClassInitialize()]
		public static void ClassInit(TestContext context)
		{
			_idServerResourceOwnerClientSettings = new IdServerResourceOwnerClientSettings()
			{
				BaseAddress = Main.Configuration["appSettings:IdentityServerBaseAddress"],
				ClientId = Main.Configuration["appSettings:IdentityServerClientId"],
				ClientSecret = Main.Configuration["appSettings:IdentityServerClientSecret"],
				UserName = Main.Configuration["appSettings:IdentityServerUserName"],
				Password = Main.Configuration["appSettings:IdentityServerPassword"],
				Scopes = Main.Configuration["appSettings:IdentityServerScopes"]
			};

			_positionsClient = new PositionsClient(_apiUrl, _idServerResourceOwnerClientSettings, true);
		}

		[ClassCleanup()]
		public static void ClassCleanup() { }

		#endregion

		#region Async

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_PositionsClient_GetLatestByAssetIdsAsync()
		{
			// Arrange   
			IPositionsClient _client = new PositionsClient(_apiUrl, _idServerResourceOwnerClientSettings, true);

			// Act  
			List<Position> positions = await _positionsClient.GetLatestByAssetIdsAsync(_assetIds, 5);

			// Assert 
			Assert.IsNotNull(positions);
			Assert.IsTrue(positions.Count > 0);
			Assert.IsTrue(positions[0].AssetId != 0);
		}

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_PositionsClient_GetLatestByAssetIdsAsync_CachedSince()
		{
			// Arrange   
			DateTime cachedTime = DateTime.UtcNow.AddSeconds(-1);

			//populate cache:
			List<Position> positions = await _positionsClient.GetLatestByAssetIdsAsync(_assetIds, 2, cachedTime);
			await Task.Delay(1000);

			// Act
			List<Position> cachedPositions = await _positionsClient.GetLatestByAssetIdsAsync(_assetIds, 2, cachedTime);

			// Assert 
			Assert.IsNotNull(positions);
			Assert.IsTrue(positions.Count > 0);
			Assert.IsNotNull(cachedPositions);
			if (cachedPositions.Count > 0)
			{
				Assert.IsNotNull(cachedPositions.FirstOrDefault(p => p.PositionId == positions[0].PositionId));
			}
		}

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_PositionsClient_GetLatestByGroupIdsAsync()
		{
			// Arrange   

			// Act  
			List<Position> positions = await _positionsClient.GetLatestByGroupIdsAsync(_groupIds, 5, null);

			// Assert 
			Assert.IsNotNull(positions);
			Assert.IsTrue(positions.Count > 0);
			Assert.IsTrue(positions[0].AssetId != 0);
		}

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_PositionsClient_GetLatestByGroupIdsAsync_CachedSince()
		{
			// Arrange   

			// Act  
			List<Position> positions = await _positionsClient.GetLatestByGroupIdsAsync(_groupIds, 5, DateTime.UtcNow.AddHours(-1));

			// Assert 
			Assert.IsNotNull(positions);
			Assert.IsTrue(positions.Count > 0);
			Assert.IsTrue(positions[0].AssetId != 0);
		}

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_PositionsClient_GetSinceByAssetIdsAsync()
		{
			// Arrange   

			// Act  
			List<Position> positions = await _positionsClient.GetSinceByAssetIdsAsync(_assetIds, DateTime.Now.AddHours(-3));

			// Assert 
			Assert.IsNotNull(positions);
			Assert.IsTrue(positions.Count > 0);
			Assert.IsTrue(positions[0].AssetId != 0);
		}

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_PositionsClient_GetByDateRangeByGroupIdsAsync()
		{
			// Arrange  

			// Act
			List<Position> positions = await _positionsClient.GetByDateRangeByGroupIdsAsync(_groupIds, DateTime.Now.AddDays(-3), DateTime.Now).ConfigureAwait(false);

			// Assert
			Assert.IsNotNull(positions);
			Assert.IsTrue(positions.Count > 0);
		}


		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_PositionsClient_GetByDateRangeByAssetIdsAsync()
		{
			// Arrange   

			// Act  
			List<Position> positions = await _positionsClient.GetByDateRangeByAssetIdsAsync(_assetIds, DateTime.Now.AddDays(-3), DateTime.Now);

			// Assert 
			Assert.IsNotNull(positions);
			Assert.IsTrue(positions.Count > 0);
			Assert.IsTrue(positions[0].AssetId != 0);
		}

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_PositionsClient_GetByDateRangeByDriverIdsAsync()
		{
			// Arrange

			// Act  
			List<Position> positions = await _positionsClient.GetByDateRangeByDriverIdsAsync(_driverIds, DateTime.Now.AddDays(-3), DateTime.Now);

			// Assert 
			Assert.IsNotNull(positions);
			Assert.IsTrue(positions.Count > 0);
			Assert.IsTrue(positions[0].AssetId != 0);
		}

		#endregion

		#region Sync

		[TestMethod, TestCategory("Integration")]
		public void IntTests_Client_PositionsClient_GetLatestByAssetIds()
		{
			// Arrange    

			// Act  
			List<Position> positions = _positionsClient.GetLatestByAssetIds(_assetIds, 5);

			// Assert 
			Assert.IsNotNull(positions);
			Assert.IsTrue(positions.Count > 0);
			Assert.IsTrue(positions[0].AssetId != 0);
		}

		[TestMethod, TestCategory("Integration")]
		public void IntTests_Client_PositionsClient_GetLatestByAssetIds_CachedSince()
		{
			// Arrange   
			DateTime cachedTime = DateTime.UtcNow.AddSeconds(-1);

			//populate cache:
			List<Position> positions = _positionsClient.GetLatestByAssetIds(_assetIds, 2, cachedTime);
			Task.Delay(1000);

			// Act
			List<Position> cachedPositions = _positionsClient.GetLatestByAssetIds(_assetIds, 2, cachedTime);

			// Assert 
			Assert.IsNotNull(positions);
			Assert.IsTrue(positions.Count > 0);
			Assert.IsNotNull(cachedPositions);
			if (cachedPositions.Count > 0)
			{
				Assert.IsNotNull(cachedPositions.FirstOrDefault(p => p.PositionId == positions[0].PositionId));
			}
		}

		[TestMethod, TestCategory("Integration")]
		public void IntTests_Client_PositionsClient_GetLatestByGroupIds()
		{
			// Arrange    

			// Act  
			List<Position> positions = _positionsClient.GetLatestByGroupIds(_groupIds, 5, null);

			// Assert 
			Assert.IsNotNull(positions);
			Assert.IsTrue(positions.Count > 0);
			Assert.IsTrue(positions[0].AssetId != 0);
		}

		[TestMethod, TestCategory("Integration")]
		public void IntTests_Client_PositionsClient_GetLatestByGroupIds_CachedSince()
		{
			// Arrange    

			// Act  
			List<Position> positions = _positionsClient.GetLatestByGroupIds(_groupIds, 5, DateTime.UtcNow.AddHours(-1));

			// Assert 
			Assert.IsNotNull(positions);
			Assert.IsTrue(positions.Count > 0);
			Assert.IsTrue(positions[0].AssetId != 0);
		}

		[TestMethod, TestCategory("Integration")]
		public void IntTests_Client_PositionsClient_GetSinceByAssetIds()
		{
			// Arrange    

			// Act  
			List<Position> positions = _positionsClient.GetSinceByAssetIds(_assetIds, DateTime.Now.AddHours(-3));

			// Assert 
			Assert.IsNotNull(positions);
			Assert.IsTrue(positions.Count > 0);
			Assert.IsTrue(positions[0].AssetId != 0);
		}

		[TestMethod, TestCategory("Integration")]
		public void IntTests_Client_PositionsClient_GetByDateRangeByGroupIds()
		{
			// Arrange   

			// Act
			List<Position> positions = _positionsClient.GetByDateRangeByGroupIds(_groupIds, DateTime.Now.AddDays(-3), DateTime.Now);

			// Assert
			Assert.IsNotNull(positions);
			Assert.IsTrue(positions.Count > 0);
		}

		[TestMethod, TestCategory("Integration")]
		public void IntTests_Client_PositionsClient_GetByDateRangeByAssetIds()
		{
			// Arrange    

			// Act  
			List<Position> positions = _positionsClient.GetByDateRangeByAssetIds(_assetIds, DateTime.Now.AddDays(-3), DateTime.Now);

			// Assert 
			Assert.IsNotNull(positions);
			Assert.IsTrue(positions.Count > 0);
			Assert.IsTrue(positions[0].AssetId != 0);
		}

		[TestMethod, TestCategory("Integration")]
		public void IntTests_Client_PositionsClient_GetByDateRangeByDriverIds()
		{
			// Arrange    

			// Act  
			List<Position> positions = _positionsClient.GetByDateRangeByDriverIds(_driverIds, DateTime.Now.AddDays(-3), DateTime.Now);

			// Assert 
			Assert.IsNotNull(positions);
			Assert.IsTrue(positions.Count > 0);
			Assert.IsTrue(positions[0].AssetId != 0);
		}

		#endregion

	}
}
