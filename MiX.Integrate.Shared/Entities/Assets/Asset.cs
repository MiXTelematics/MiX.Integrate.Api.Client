using MiX.Integrate.Shared.Entities.Measurement;
using System;

namespace MiX.Integrate.Shared.Entities.Assets
{
  public class Asset
	{
		public Asset()
		{
		}

		public Asset(int assetId, int assetTypeId, string description, bool isConnectedTrailer, string registrationNumber, int siteId, string fuelType, int? fmVehicleId)
		{
			AssetId = assetId;
			AssetTypeId = assetTypeId;
			Description = description;
			IsConnectedTrailer = isConnectedTrailer;
			RegistrationNumber = registrationNumber;
			SiteId = siteId;
			FuelType = fuelType;
			TargetFuelConsumptionUnits = Unit.KilometresPerLitre;
			TargetHourlyFuelConsumptionUnits = Unit.LiterPerHour;
			FmVehicleId = fmVehicleId;

		}
		public long AssetId { get; set; }
		public int AssetTypeId { get; set; }		
/********************************************************
AssetTypeIds are not currently exposed as an enumeration - this will be corrected in a later release		

1	  Motorcycle
2	  Trailer
4	  Boat
5	  Mobile Plant Equipment
6	  Stationary Plant Equipment
7	  Emergency Service Vehicle
8	  Dangerous Goods Vehicle
9	  Passenger Vehicle
10	Light Passenger Vehicle - Minibus
11	Heavy Passenger Vehicle - Bus - Articulated
12	Heavy Passenger Vehicle - Bus - Single Decker
13	Heavy Passenger Vehicle - Bus - Double Decker
14	Heavy Vehicle - Articulated
15	Heavy Vehicle - Non-Articulated
16	Heavy Vehicle - Refrigerated Transport
17	Light Vehicle
18	Fluid Transport Vehicle
19	Snow Plough
20	Other
21	Train
22	Light Delivery Vehicle
24	Off-Road Vehicle
25	Medium Commercial Vehicle
26	Non-Powered Asset
27	Mobile Phone

**********************************************************/
		
		public string Description { get; set; }
		public bool IsConnectedTrailer { get; set; }
		public string RegistrationNumber { get; set; }
		public long SiteId { get; set; }
		public string FuelType { get; set; }
		public float? TargetFuelConsumption { get; set; }
		public string TargetFuelConsumptionUnits { get; set; }
		public float? TargetHourlyFuelConsumption { get; set; }
		public string TargetHourlyFuelConsumptionUnits { get; set; }
		public string FleetNumber { get; set; }
		public string Make { get; set; }
		public string Model { get; set; }
		public string Year { get; set; }
		public string VinNumber { get; set; }
		public string EngineNumber { get; set; }
		public long? DefaultDriverId { get; set; }
		public int? FmVehicleId { get; set; }
		public string AdditionalMobileDevice { get; set; }
		public string Notes { get; set; }
		private string _icon;
		public string Icon
		{
			get { return _icon ?? AssetIcons.DefaultAssetIcon; }
			set { _icon = value; }
		}
		private string _iconColour;
		public string IconColour
		{
			get { return _iconColour ?? AssetIcons.DefaultAssetIconColour; }
			set { _iconColour = value; }
		}
		public string Colour { get; set; }
		private string _assetImage;

		public string AssetImage
		{
			get
			{
				if (_assetImage != null)
					return _assetImage;
				var assetType = AssetType.GetById(AssetTypeId);
				return assetType?.DefaultImage;
			}
			set { _assetImage = value; }
		}

		public bool IsDefaultImage
		{
			get
			{
				if (AssetImage == null) return true;
				foreach (var assetType in AssetType.All)
					if (assetType.DefaultImage.Equals(AssetImage))
						return true;

				return false;
			}
		}
		public string AssetImageUrl { get; set; }
		public string UserState { get; set; }
		public string CreatedBy { get; set; }
		public DateTimeOffset CreatedDate { get; set; }
		public float? Odometer { get; set; }
		public TimeSpan? EngineHours { get; set; }
		public string Country { get; set; }
	}
}
