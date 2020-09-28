using System;

namespace MiX.Integrate.Shared.Entities.Trips
{
	/// <summary>Details occurrences of amendments to trips</summary>
  public class TripAmendment
  {
	  /// <summary>Identifier of the amended trip</summary>
	  public long TripId { get; set; }

	  /// <summary>The type of amendment made</summary>
	  public AmendmentType AmendmentType { get; set; }

	  /// <summary>Date and time of the amendment</summary>
	  public DateTime AmendmentDate { get; set; }

	  /// <summary>The identifier of the driver to which the trip was assigned if <see cref="AmendmentType"/> is ReassignedTrip, otherwise null</summary>
	  public long? NewDriverId { get; set; } = null;
  }
}
