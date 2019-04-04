using System;
using System.Collections.Generic;
using System.Text;

namespace MiX.Integrate.Shared.Entities.Journeys
{
	public class Customer
	{
		public long Id { get; set; }
		public long AssociateId { get; set; }
		public string LinkName { get; set; }
		public string LinkDataCenter { get; set; }
		public DateTime Date { get; set; }
		public List<long> Sites { get; set; }
		public CustomerStatus Status { get; set; }
	}
}
