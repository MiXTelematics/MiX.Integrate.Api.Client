using System;
using System.Collections.Generic;
using System.Text;

namespace MiX.Integrate.Shared.Entities.Journeys
{

	public class BulkAddJourneyResult
	{
		public string AddReference { get; set; }
		public string Status { get; set; }
		public long JourneyId { get; set; }

		public string DateAdded { get; set; }

		public string Message { get; set; }
	}
}
