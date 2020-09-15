using System;

namespace MiX.Integrate.Shared.Entities.Events
{
	/// <summary>Details occurrences of amendments to events</summary>
	public class EventAmendment
	{
		// Identifier of the amended event
		public long EventId { get; set; }

		// The type of amendment made
		public AmendmentType AmendmentType { get; set; }

		// Date and time of the amendment
		public DateTime AmendmentDate { get; set; }
	}
}

