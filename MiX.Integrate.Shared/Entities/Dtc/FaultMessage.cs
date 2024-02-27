using MiX.Integrate.Shared.Entities.Positions;
using System;

namespace MiX.Integrate.Shared.Entities.Dtc
{
	/// <summary>DTC fault message</summary>
	public class FaultMessage
	{
		/// <summary>Identifier of the asset reporting the fault</summary>
		public long AssetId { get; set; }

		/// <summary>Date and time the status was last updated</summary>
		public DateTime Timestamp { get; set; }

		/// <summary>DTC fault code</summary>
		public string FaultCode { get; set; }

		/// <summary>Fault category</summary>
		public string Category { get; set; }

		/// <summary>Fault description</summary>
		public string Description { get; set; }

		/// <summary>The severity of the fault</summary>
		public FaultSeverity Severity { get; set; }

		/// <summary><see langword="true" /> if the fault is open, <see langword="false"/> if the fault was resolved</summary>
		public bool IsFaulted { get; set; }

		/// <summary>Fault symptom</summary>
		public string Symptom { get; set; }

		/// <summary>Action to be taken</summary>
		public string Action { get; set; }

		/// <summary>Date and time the fault was resolved</summary>
		public DateTime? DateCleared { get; set; }

		public Position StartPosition { get; set; }

		public Position EndPosition { get; set; }
	}
}
