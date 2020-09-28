using System;

namespace MiX.Integrate.Shared.Entities.Events
{
	/// <summary>Details occurrences of amendments to events</summary>
	public class EventAmendment
	{
		/// <summary>Identifier of the amended event<summary></summary>
		public long EventId { get; set; }

		/// <summary>The type of amendment made<summary></summary>
		public AmendmentType AmendmentType { get; set; }

		/// <summary>Date and time of the amendment</summary>
		public DateTime AmendmentDate { get; set; }

		/// <summary>The identifier of the driver to which the event was assigned if <see cref="AmendmentType"/> is ReassignedEvent, otherwise null</summary>
		public long? NewDriverId { get; set; } = null;
	}
}

