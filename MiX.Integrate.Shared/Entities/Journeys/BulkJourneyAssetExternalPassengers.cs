using System;
using System.Collections.Generic;
using System.Text;

namespace MiX.Integrate.Shared.Entities.Journeys
{
	public class BulkJourneyAssetExternalPassengers
	{
		public long AssetId { get; set; }
		public string PassengerName { get; set; }
		public string MobileNumber { get; set; }
		public string Email { get; set; }
	}
}
