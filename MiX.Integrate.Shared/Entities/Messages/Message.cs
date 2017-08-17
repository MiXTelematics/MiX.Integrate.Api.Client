using System; 
using MiX.Integrate.Shared.Entities.Communications;

namespace MiX.Integrate.Shared.Entities.Messages
{
	public class Message
	{

		#region Constructor

		public Message()
		{
			this.ID = Guid.NewGuid().ToString();
			this.State = MessageStates.New;
			this.Transport = CommsTransports.Default;
			this.SetMinutesToLive(24 * 60);
			this.Starts = new DateTime(1753, 01, 01); // SqlDateTime.MinValue.Value
			this.Notes = string.Empty;
			this.StateLastChanged = new DateTime(1753, 01, 01); // SqlDateTime.MinValue.Value
			this.Parameters = string.Empty;
			this.ActiveMessage = null;
			this.Expires = new DateTime(1753, 01, 01); // SqlDateTime.MinValue.Value
			this.DatePended = new DateTime(1753, 01, 01); // SqlDateTime.MinValue.Value
			this.Processed = new DateTime(1753, 01, 01); // SqlDateTime.MinValue.Value
			this.LastActionDate = new DateTime(1753, 01, 01); // SqlDateTime.MinValue.Value
		}

		#endregion Constructor

		#region Public Properties

		public int MessageId { get; set; }
		public string ID { get; set; }
		public int OrgID { get; set; }
		public int CompanyID { get; set; }
		public short RecipientID { get; set; }
		public string RecipientAddr { get; set; }
		public string VehicleDescription { get; set; }
		public string VehicleRegNo { get; set; }
		public short DriverID { get; set; }
		public string DriverName { get; set; }
		public int ActiveMessageID { get; set; }
		public MessageStates State { get; set; }
		public MessageTypes MessageType { get; set; }
		public bool Critical { get; set; }
		public CommsTransports Transport { get; set; }
		public MessageOrigins Origin { get; set; }
		public DateTime? Expires { get; set; }
		public DateTime? Starts { get; set; }
		public DateTime DatePended { get; set; }
		public DateTime LastActionDate { get; set; }
		public string Notes { get; set; }
		public DateTime StateLastChanged { get; set; }
		public ActiveMessage ActiveMessage { get; set; }
		public string VehicleDesc { get; set; }
		public string Parameters { get; set; }
		public DateTime Processed { get; set; }

		#endregion Public Properties

		#region Public Methods

		public void SetMinutesToLive(int Value)
		{
			this.Expires = DateTime.Now.AddMinutes(Value);
		}

		#endregion Public Methods


	}
}
