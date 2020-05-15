using System;

namespace MiX.Integrate.Shared.Entities.Assets
{
	/// <summary>Encapsulates the details of trailer assets</summary>
	public class Trailer
	{
		/// <summary>Unique Id of the trailer asset</summary>
		public long AssetId { get; set; }

		/// <summary>Group Id of the site the trailer is in</summary>
		public long SiteId { get; set; }

		/// <summary>Trailer description</summary>
		public string Description { get; set; }

		/// <summary>Trailer registration number</summary>
		public string RegistrationNumber { get; set; }

		/// <summary>32-bit ID of the wired or wireless trailer device connected to the trailer (Trailer Unit ID)</summary>
		public int? TrailerId { get; set; }

		/// <summary>6-digit hexadecimal of the trailer device</summary>
		public string HexTrailerId { get; set; }

		/// <summary>Time that the trailer device was attached to the trailer</summary>
		public DateTime? TrailerIdDate { get; set; }

		/// <summary>Last odometer value set for the trailer</summary>
		public decimal? SetOdometer { get; set; }

		/// <summary>Time that the last odometer was last set</summary>
		public DateTime? SetOdometerDate { get; set; }

		/// <summary>Asset Id of the last vehicle connected to the trailer</summary>
		public long? LastAssetId { get; set; }

		/// <summary>Time the last vehicle connected to the trailer</summary>
		public DateTime? ConnectDate { get; set; }

		/// <summary>Time the last vehicle disconnected from the trailer</summary>
		public DateTime? DisconnectDate { get; set; }
	}
}
