using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiX.Integrate.Shared.Entities.Reminders
{
	public class AssetReminders
	{
		public AssetLicenceReminder LicenceReminder { get; set; }
		public AssetServiceReminder ServiceReminder { get; set; }
		public AssetRoadworthyCertificateReminder RoadworthyCertificateReminder { get; set; }
	}
}
