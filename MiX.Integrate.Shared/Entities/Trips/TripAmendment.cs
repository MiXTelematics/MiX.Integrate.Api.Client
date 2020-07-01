using System;
using System.Collections.Generic;
using System.Text;

namespace MiX.Integrate.Shared.Entities.Trips
{
	/// <summary>Details occurrences of amendments to trips</summary>
  public class TripAmendment
  {
	  // Identifier of the amended trip
	  public long TripId { get; set; }

	  // The type of amendment made
	  public AmendmentType AmendmentType { get; set; }

	  // Date and time of the amendment
	  public DateTime AmendmentDate { get; set; }
  }
}
