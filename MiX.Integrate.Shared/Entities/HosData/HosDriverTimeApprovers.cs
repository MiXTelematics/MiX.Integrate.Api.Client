using System;
using System.Collections.Generic;
using System.Text;

namespace MiX.Integrate.Shared.Entities.HosData
{
	 public class HosDriverTimeApprovers
	{
		public long Id { get; set; }
		public long DriverId { get; set; }
		public long ApproverId { get; set; }
		public string DisplayName { get; set; }
		public short ApproverLevel { get; set; }
		public bool IsSelected { get; set; }
		public DateTime DateCreated { get; set; }
	}
}
