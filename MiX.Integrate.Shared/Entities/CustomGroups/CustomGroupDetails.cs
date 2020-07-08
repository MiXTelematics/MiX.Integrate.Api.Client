using System.Collections.Generic;
using System.Linq;

namespace MiX.Integrate.Shared.Entities.CustomGroups
{
	/// <summary>Definition of a custom group with a list of members</summary> 
	public class CustomGroupDetails : CustomGroup
	{
		public CustomGroupDetails() { }

		public CustomGroupDetails(CustomGroup customGroup) : this(customGroup, null) { }

		public CustomGroupDetails(CustomGroup customGroup, IEnumerable<CustomGroupMember> members)
		{
			if (customGroup == null) return;

			CustomGroupId = customGroup.CustomGroupId;
			Name = customGroup.Name;
			Description = customGroup.Description;
			IsDriverGroup = customGroup.IsDriverGroup;
			Members = members?.ToList() ?? new List<CustomGroupMember>();
		}

		public List<CustomGroupMember> Members { get; set; }
	}
}
