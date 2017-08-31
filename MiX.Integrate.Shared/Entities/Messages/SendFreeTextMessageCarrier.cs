using MiX.Integrate.Shared.Entities.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiX.Integrate.Shared.Entities.Messages
{
	public class SendFreeTextMessageCarrier
	{

		public SendFreeTextMessageCarrier() { }

		public short VehicleId { get; set; }
		public string Subject { get; set; }
		public string Body { get; set; }
		public string[] DefaultResponses { get; set; }
		public bool Urgent { get; set; }
		public DateTime ExpiryDate { get; set; }
		public bool NotifyWhenRead { get; set; }
		public bool NotifyWhenRepliedTo { get; set; }
		public bool NotifyWhenDeleted { get; set; }
		public CommsTransports Transport { get; set; }

	}
}
