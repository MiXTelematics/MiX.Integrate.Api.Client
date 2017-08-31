using System;
using System.Diagnostics;

namespace MiX.Integrate.Shared.Entities.Drivers
{ 
	[DebuggerDisplay("{LicenceCategoryId}:{LicenceCode}")]
	public class LicenceCategory
	{
		public LicenceCategory()
		{
		}

		public LicenceCategory(int licenceCategoryId, string licenceCode, string description)
		{
			this.LicenceCategoryId = licenceCategoryId;
			this.LicenceCode = licenceCode;
			this.Description = description;
		}

		public int LicenceCategoryId { get; set; }

		public string LicenceCode { get; set; }

		public string Description { get; set; }

		public string CountryCode { get; set; }

		public short? ValidityInMonths { get; set; }

		public short? ReminderPeriodInWeeks { get; set; }

		public short DriversUsingLicence { get; set; }

		public short AssetsUsingLicence { get; set; }
	}
}
