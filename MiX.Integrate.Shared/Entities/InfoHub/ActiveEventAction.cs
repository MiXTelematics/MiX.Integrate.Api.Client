using System;

namespace MiX.Integrate.Shared.Entities.InfoHub
{
	/// <summary>Info Hub action on active event</summary>
	public class ActiveEventAction
	{
		/// <summary>Actioned event</summary>
		public Events.ActiveEvent ActiveEvent { get; set; }

		/// <summary>Date and time event was actioned</summary>
		public DateTime ActionDate { get; set; }

		/// <summary>Action description</summary>
		public string ActionComment { get; set; } 

		/// <summary>User who actioned the event</summary>
		public string ActionedBy { get; set; }

	}
}
