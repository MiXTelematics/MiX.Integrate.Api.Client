using System;

namespace MiX.Integrate.Shared.Entities.Customers
{
	public class DeliveryWindow
	{
		public long DeliveryWindowId { get; set; }
		public long DeliveryPointId { get; set; }
		public DayOfWeek DayOfWeek { get; set; }
		public TimeSpan TimeFrom { get; set; }
		public TimeSpan TimeTo { get; set; }
	}
}
