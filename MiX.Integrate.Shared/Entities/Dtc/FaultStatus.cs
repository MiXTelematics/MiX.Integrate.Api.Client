using System;
using System.Collections.Generic;
using System.Text;

namespace MiX.Integrate.Shared.Entities.Dtc
{
	/// <summary>Current status of a DTC fault for an asset</summary>
	public class FaultStatus
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

		/// <summary>Date and time the DTC was first observed</summary>
		public DateTime? FirstSeen { get; set; }

		/// <summary>Date and time the DTC was last observed</summary>
		public DateTime? LastSeen { get; set; }

		/// <summary>Number of times the fault was reported</summary>
		public int Count { get; set; }

		/// <summary>Fault symptom</summary>
		public string Symptom { get; set; }

		/// <summary>Action to be taken</summary>
		public string Action { get; set; }

		/// <summary>Date and time the fault was resolved</summary>
		public DateTime? DateCleared { get; set; }
	}
}
