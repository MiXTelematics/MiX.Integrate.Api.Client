using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiX.Integrate.Shared.Entities.Groups
{
	public class GroupSummary
	{
		public GroupSummary() { }
		public GroupSummary(long groupId, string name, GroupType type)
		{
			GroupId = groupId;
			Name = name;
			Type = type;
		}
		public long GroupId { get; set; }
		public string Name { get; set; }
		public GroupType Type { get; set; }
		private List<GroupSummary> _subGroups = new List<GroupSummary>();
		public List<GroupSummary> SubGroups
		{
			get { return _subGroups; }
			set { _subGroups = value; }
		}
	}
}
