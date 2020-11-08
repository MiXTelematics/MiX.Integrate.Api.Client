using System;
using System.Collections.Generic;
using System.Text;

namespace MiX.Integrate.Shared.Entities.Journeys
{
  public class BulkSubmitJourney
  {
		public string Reason { get; set; }
		public string Status { get; set; }
		public long JourneyId { get; set; }
	}
}
