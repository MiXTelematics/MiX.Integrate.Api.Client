using System;
using System.Collections.Generic;
using System.Text;

namespace MiX.Integrate.Shared.Entities.Fuel
{
	public class FuelInsertCarrier
	{
		public long FuelTransactionId { get; set; }
		public string ErrorMessage { get; set; }
		public bool RecordAdded { get; set; }
	}
}
