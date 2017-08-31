using System;

namespace MiX.Integrate.Shared.Entities.CustomGroups
{
	/// <summary>Member of a custom group</summary> 
	public class CustomGroupMember
	{
		public CustomGroupMember() { }

		public CustomGroupMember(long entityId, string entityType)
		{
			EntityType = entityType;
			EntityId = entityId;
		}
		/// <summary>The entity type of the custom group member</summary>
		public string EntityType { get; set; }

		/// <summary>The unique identifier custom group member</summary>
		public long EntityId { get; set; }

	}
}
