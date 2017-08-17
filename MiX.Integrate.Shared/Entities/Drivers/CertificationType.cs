using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiX.Integrate.Shared.Entities.Drivers
{ 
	[DebuggerDisplay("{CertificationTypeId}:{Description}")]
	public class CertificationType
	{
		public CertificationType()
		{
		}

		public CertificationType(int certificationTypeId, string description)
		{
			this.CertificationTypeId = certificationTypeId;
			this.Description = description;
		}

		public int CertificationTypeId { get; set; }

		public string Description { get; set; }

		public short ValidityInMonths { get; set; }

		public bool IsMandatory { get; set; }

		public short ReminderPeriodInWeeks { get; set; }

		public int DriversUsingCertification { get; set; }

		public int AssetsUsingCertification { get; set; }
	}
}

