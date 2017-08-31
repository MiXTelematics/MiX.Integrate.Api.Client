using System;

namespace MiX.Integrate.Shared.Entities.Messages
{
	public class MessageStateHistoryItem
	{
		public MessageStateHistoryItem() { }

		public int MessageID { get; set; }
		public MessageStates State { get; set; }
		public DateTime DateEntered { get; set; }
		public string Notes { get; set; }
		public string Description { get; set; }
		public int ActiveMessageID { get; set; }
		public DateTime TimeStamp { get; set; }
		public bool FromUnit { get; set; }
	}
}