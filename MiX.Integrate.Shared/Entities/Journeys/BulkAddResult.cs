using System;
using System.Collections.Generic;
using System.Text;

namespace MiX.Integrate.Shared.Entities.Journeys
{
	public class BulkAddResult
	{
		public long SubmittingUserId { get; set; }
		public List<BulkAddJourneyResult> JourneysResults { get; set; }
	}
}
