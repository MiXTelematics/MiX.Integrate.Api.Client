using System;
using System.Collections.Generic;
using System.Text;

namespace MiX.Integrate.Shared.Entities.TimeEntry
{
    public class GroupSubstatus
    {
		public byte EventTypeId { get; set; }
		public byte EventStatusId { get; set; }
		public string StatusCode { get; set; }
		public string Description { get; set; }
	}
}
