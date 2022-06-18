using System;
using System.Collections.Generic;
using System.Text;

namespace MiX.Integrate.Shared.Entities.Journeys
{
	public class BulkRouteLocation
	{
		public double? Latitude { get; set; }
		public double? Longitude { get; set; }
		public bool RestStop { get; set; }
		public bool FuelStop { get; set; }
		public bool LoadingStop { get; set; }
		public bool OffLoadingStop { get; set; }
		public int StopDuration { get; set; }
		public string LocationId { get; set; }
		public long? DeliveryPointId { get; set}
		public string StopActivityInstructions { get; set; }
		public DateTimeOffset? DepartureDateTime { get; set; }
		public DateTimeOffset? ArrivalDateTime { get; set; }
	}
}
