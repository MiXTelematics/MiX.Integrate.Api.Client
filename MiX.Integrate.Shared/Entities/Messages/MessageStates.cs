namespace MiX.Integrate.Shared.Entities.Messages
{
	public enum MessageStates
	{
		Unknown = 0,
		New = 1,
		Pending = 2,
		Queued = 3,
		Sent = 4,
		Postponed = 5,
		SendFailed = 6,
		Aborted = 7,
		Deleted = 8,
		Received = 9,
		Accepted = 10,
		Rejected = 11,
		Completed = 12,
		Acknowledged = 13,
		Expired = 14,
		DeleteRequested = 15,
		DeleteQueued = 16,
		ETAChanged = 17,
		Read = 18,
		Close = 19,
		Arrived = 20,
		KMETAChanged = 21
	}
}
