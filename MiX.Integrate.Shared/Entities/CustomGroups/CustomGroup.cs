using System;

namespace MiX.Integrate.Shared.Entities.CustomGroups
{
	/// <summary>
	/// Definition of a custom group
	/// </summary> 
	public class CustomGroup
	{
		public CustomGroup() { }

		public CustomGroup(string name, string description, bool isDriverGroup)
		{
			Name = name;
			Description = description;
			IsDriverGroup = isDriverGroup;
		}

		/// <summary> Unique identifier for the custom group</summary>
		public long CustomGroupId { get; set; }

		/// <summary> The name of the custom group</summary>
		public string Name { get; set; }

		/// <summary>Description of the custom group</summary>
		public string Description { get; set; }

		/// <summary>True if the custom group is a driver group, else false</summary>
		public bool IsDriverGroup { get; set; }
	}
}
