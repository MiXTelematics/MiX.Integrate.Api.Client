using System;
using System.Collections.Generic;
using System.Text;
using MiX.Integrate.Shared.Entities.Communications;

namespace MiX.Integrate.Shared.Entities.Messages
{
	public class SendJobMessageCarrier
	{
		public SendJobMessageCarrier() { }

		public short VehicleId { get; set; }
		public string Description { get; set; }
		public string UserDescription { get; set; }
		public string Body { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime ExpiryDate { get; set; }
		public bool RequiresAddress { get; set; }
		public bool AddAddressSummary { get; set; }
		public bool UseFirstAddressForSummary { get; set; }
		public JobMessageActionNotifications NotificationSettings { get; set; }
		public int[] AddressList { get; set; }
		public CommsTransports Transport { get; set; }
		public bool Urgent { get; set; }
	}
}
