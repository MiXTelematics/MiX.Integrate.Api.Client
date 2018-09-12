using System;

namespace MiX.Integrate.Shared.Entities.Messages
{
	[Flags]
	public enum JobMessageActionNotifications
	{
		Read = 1,
		Deleted = 2,
		Accepted = 4,
		Rejected = 8,
		Completed = 16,
		Postponed = 32,
		ETAChanged = 64,
		Aborted = 128,
		NearDestination = 256,
		ArrivedAtDestination = 512
	}
}
