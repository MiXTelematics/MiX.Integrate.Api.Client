using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiX.Integrate.Shared.Entities.Drivers;
using Shouldly;
using System;
using System.Collections.Generic;
using MiX.Integrate.API.Client.Tests;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiX.Integrate.Api.Client.Tests.IntegrationTests
{
	[TestClass]
	public class IntTests_Client_DriverCertificationClient
	{
		#region startup 
		// Dev data  
		private static string _apiUrl = Main.Configuration["appSettings:BaseUri"];
		private static long _accountId = Convert.ToInt64(Main.Configuration["appSettings:AccountId"]);
		private static long _orgGroupId = 2755229940408677221; // Convert.ToInt64(Main.Configuration["appSettings:OrganisationGroupId"]);
		private static long _driverId = -5076036670118944961; // Convert.ToInt64(Main.Configuration["appSettings:DriverId"]);

		private static IdServerResourceOwnerClientSettings _idServerResourceOwnerClientSettings;

		[ClassInitialize()]
		public static void ClassInit(TestContext context)
		{

			_apiUrl = Main.Configuration["appSettings:ApiUrl"];
			_idServerResourceOwnerClientSettings = new IdServerResourceOwnerClientSettings()
			{
				BaseAddress = Main.Configuration["appSettings:IdentityServerBaseAddress"],
				ClientId = Main.Configuration["appSettings:IdentityServerClientId"],
				ClientSecret = Main.Configuration["appSettings:IdentityServerClientSecret"],
				UserName = Main.Configuration["appSettings:IdentityServerUserName"],
				Password = Main.Configuration["appSettings:IdentityServerPassword"],
				Scopes = Main.Configuration["appSettings:IdentityServerScopes"]

			};
		}

		[ClassCleanup()]
		public static void ClassCleanup() { }

		#endregion

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_DriverCertificationClient_GetDriverCertificationByIdAsync()
		{
			// Arrange  
			IDriverCertificationClient _client = new DriverCertificationClient(_apiUrl, _idServerResourceOwnerClientSettings);

			// Act  
			DriverCertification item = await _client.GetDriverCertificationByIdAsync(_orgGroupId, _driverId, 1);

			// Assert  
			Assert.IsNotNull(item);
			Assert.IsTrue(item is DriverCertification);
			Assert.IsTrue(item.DriverId == _driverId);
		}

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_DriverCertificationClient_GetDriverCertificationsForDriverAsync()
		{
			// Arrange  
			IDriverCertificationClient _client = new DriverCertificationClient(_apiUrl, _idServerResourceOwnerClientSettings);

			// Act  
			IList<DriverCertification> items = await _client.GetDriverCertificationsForDriverAsync(_orgGroupId, _driverId);

			// Assert  
			Assert.IsNotNull(items);
			Assert.IsTrue(items is List<DriverCertification>);
			Assert.IsTrue(items.Count > 0);
			Assert.AreEqual(items.First().CertificationTypeId, 1);
			Assert.AreEqual(items.First().DriverId, _driverId);
		}

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_DriverCertificationClient_GetDriverCertificationTypesAsync()
		{
			// Arrange  
			IDriverCertificationClient _client = new DriverCertificationClient(_apiUrl, _idServerResourceOwnerClientSettings);

			// Act  
			IList<CertificationType> items = await _client.GetDriverCertificationTypesAsync(_orgGroupId, _driverId);

			// Assert  
			Assert.IsNotNull(items);
			Assert.IsTrue(items is List<CertificationType>);
			Assert.IsTrue(items.Count > 0);
		}

		[TestMethod, TestCategory("Integration")]
		public async Task IntTests_Client_DriverCertificationClient_AddUpdateDelete()
		{
			// Arrange 
			IDriverCertificationClient _client = new DriverCertificationClient(_apiUrl, _idServerResourceOwnerClientSettings);

			string newInstructor = "Test Instructor";
			string updatedInstructor = "Test Instructor - Updated";

			// Act - get original cert details
			var certificationTypes = await _client.GetDriverCertificationTypesAsync(_orgGroupId, _driverId).ConfigureAwait(false);
			var driverCerts = await _client.GetDriverCertificationsForDriverAsync(_orgGroupId, _driverId).ConfigureAwait(false);

			//Assert 
			certificationTypes.Count.ShouldBePositive();
			driverCerts.Count.ShouldBePositive();

			// Act 
			var certificationTypesUsed = driverCerts.Select(o => o.CertificationTypeId).Distinct().ToList<int>();
			var certificationTypesNotUsed = certificationTypes.Select(o => o.CertificationTypeId).Distinct().ToList<int>().Where(o => !certificationTypesUsed.Contains(o)).ToList<int>();

			//Assert 
			certificationTypesUsed.Count.ShouldBePositive();
			certificationTypesNotUsed.Count.ShouldBePositive();

			// Arrange
			int certificationTypeId = certificationTypesNotUsed[0];
			DriverCertification newCert = new DriverCertification()
			{
				DriverId = _driverId,
				CertificationTypeId = certificationTypeId,
				Instructor = newInstructor,
				IsInstructorQualified = true,
				Obtained = DateTime.UtcNow
			};

			//Act - add new cert
			await _client.AddDriverCertificationAsync(_orgGroupId, newCert).ConfigureAwait(false);
			DriverCertification confirmAddCert = await _client.GetDriverCertificationByIdAsync(_orgGroupId, _driverId, certificationTypeId).ConfigureAwait(false);

			//Assert 
			confirmAddCert.ShouldNotBeNull();
			confirmAddCert.DriverId.ShouldBe(_driverId);
			confirmAddCert.CertificationTypeId.ShouldBe(certificationTypeId);
			confirmAddCert.Instructor.ShouldBe(newInstructor);

			//Act - update new cert
			newCert.Instructor = updatedInstructor;
			await _client.UpdateDriverCertificationAsync(_orgGroupId, newCert).ConfigureAwait(false);
			DriverCertification confirmUpdateCert = await _client.GetDriverCertificationByIdAsync(_orgGroupId, _driverId, certificationTypeId).ConfigureAwait(false);

			//Assert 
			confirmUpdateCert.ShouldNotBeNull();
			confirmUpdateCert.DriverId.ShouldBe(_driverId);
			confirmUpdateCert.CertificationTypeId.ShouldBe(certificationTypeId);
			confirmUpdateCert.Instructor.ShouldBe(updatedInstructor);

			//Act - delete new cert
			await _client.DeleteDriverCertificationAsync(_orgGroupId, _driverId, certificationTypeId).ConfigureAwait(false);
			var newDriverCerts = await _client.GetDriverCertificationsForDriverAsync(_orgGroupId, _driverId).ConfigureAwait(false);

			//Assert 
			newDriverCerts.ShouldNotBeNull();
			newDriverCerts.Count.ShouldBe(driverCerts.Count);
		}

	}
}
