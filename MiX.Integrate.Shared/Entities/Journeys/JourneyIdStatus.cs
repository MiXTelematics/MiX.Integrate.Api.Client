using System;
using System.Collections.Generic;
using System.Text;

namespace MiX.Integrate.Shared.Entities.Journeys
{
	public class JourneyIdStatus
	{
		public long JourneyId { get; set; }
		public string Status { get; set; }
		public DateTime LastUpdateDateUTC { get; set; }
	}
}
