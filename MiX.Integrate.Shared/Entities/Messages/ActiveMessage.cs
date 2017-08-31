using System;

namespace MiX.Integrate.Shared.Entities.Messages
{
	public class ActiveMessage
	{
		#region Constructor

		public ActiveMessage()
		{
			Priority = 250;
			Received = new DateTime(1753, 01, 01); // SqlDateTime.MinValue.Value
			Event = new DateTime(1753, 01, 01); // SqlDateTime.MinValue.Value
			VehicleID = 0;
			DriverID = 0;
			EventID = 0;
			GPSID = -1;
			HasGPSData = false;
			Value = 0D;
			Odometer = 0F;
			Speed = 0;
			UnitArmed = false;
		}

		#endregion Constructor

		#region Public Properties

		public string ID;
		public byte Priority;
		public DateTime Received;
		public DateTime Event;
		public short VehicleID;
		public short DriverID;
		public short EventID;
		public bool HasGPSData;
		public int GPSID;
		public double Value;
		public float Odometer;
		public byte Speed;
		public bool UnitArmed;
		public string DriverName;
		public string EventDescription;

		#endregion Public Properties

	}

}
