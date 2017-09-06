using MiX.Integrate.Shared.Entities.Groups;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiX.Integrate.Shared.Entities.Organisation
{
	public class OrganisationDetail
	{
		public long GroupId { get; set; }
		public string Name { get; set; } 
		public string DisplayTimeZone { get; set; }
		public GroupType GroupType { get; set; }
	}
}
