using System;
using System.Collections.Generic;

namespace MiX.Integrate.Shared.Entities.Journeys
{
	public class DeliveryPoint 
	{
		public long DeliveryPointId { get; set; }
		public string Description { get; set; }
		public long OrganisationGroupId { get; set; }
		public long CustomerId { get; set; }
		public long LocationId { get; set; }
		public TimeSpan? DwellTime { get; set; }
		public string ExternalReference { get; set; }
		public List<DeliveryWindow> DeliveryWindows { get; set; }
	}
}
