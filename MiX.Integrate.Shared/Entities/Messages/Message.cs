using System;
using MiX.Integrate.Shared.Entities.Communications;

namespace MiX.Integrate.Shared.Entities.Messages
{
	public class Message
	{

		#region Constructor

		public Message()
		{
			this.State = MessageStates.New;
			this.Transport = CommsTransports.Default;
			this.SetMinutesToLive(24 * 60);
			this.Notes = string.Empty;
			this.Parameters = string.Empty;
		}

		#endregion Constructor

		#region Public Properties

		public int MessageId { get; set; }
		public long AssetId { get; set; }
		public long OrgID { get; set; }
		public short RecipientID { get; set; }
		public int ActiveMessageID { get; set; }
		public MessageStates State { get; set; }
		public MessageTypes MessageType { get; set; }
		public bool Critical { get; set; }
		public CommsTransports Transport { get; set; }
		public MessageOrigins Origin { get; set; }
		public DateTime? Expires { get; set; }
		public DateTime? Starts { get; set; }
		public string Notes { get; set; }
		public string Parameters { get; set; }
		public DateTime? Processed { get; set; }

		#endregion Public Properties

		#region Public Methods

		public void SetMinutesToLive(int Value)
		{
			this.Expires = DateTime.Now.AddMinutes(Value);
		}

		#endregion Public Methods


	}
}
