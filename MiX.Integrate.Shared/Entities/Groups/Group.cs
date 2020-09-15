namespace MiX.Integrate.Shared.Entities.Groups
{
	public class Group
	{
		public Group()
		{
			Name = "";
			DisplayTimeZone = "";
		}

		public Group(long groupId, string name, GroupType type) : this()
		{
			GroupId = groupId;
			Name = name;
			Type = type;
		}
		public long GroupId { get; set; }
		public string Name { get; set; }
		public GroupType Type { get; set; }
		public string DisplayTimeZone { get; set; }

		public override string ToString()
		{
			return $"{Type} : [{GroupId}] - {Name}";
		}
	}
}
