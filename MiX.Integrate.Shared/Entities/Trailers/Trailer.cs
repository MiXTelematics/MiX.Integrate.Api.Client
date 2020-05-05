using System;
using System.Collections.Generic;
using System.Text;

namespace MiX.Integrate.Shared.Entities.Trailers
{
	public class Trailer
	{
		public Trailer()
			{
			}

		public Trailer(int assetId, string description, bool isConnectedTrailer, string registrationNumber, int siteId)
		{
			AssetId = assetId;
			Description = description;
			IsConnectedTrailer = isConnectedTrailer;
			RegistrationNumber = registrationNumber;
			SiteId = siteId;
		}
		public long AssetId { get; set; }
		public int AssetTypeId { get; set; }
		public string Description { get; set; }
		public bool IsConnectedTrailer { get; set; }
		public string RegistrationNumber { get; set; }
		public long SiteId { get; set; }
	}
}
