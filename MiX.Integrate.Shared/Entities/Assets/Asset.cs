﻿using MiX.Integrate.Shared.Entities.Measurement;
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
		public string Description { get; set; }
		public bool IsConnectedTrailer { get; set; }
		public string RegistrationNumber { get; set; }
		public long SiteId { get; set; }
		public string FuelType { get; set; }
		public float? FuelTankCapacity { get; set; }
		public float? TargetFuelConsumption { get; set; }
		public string TargetFuelConsumptionUnits { get; set; }
		public float? TargetHourlyFuelConsumption { get; set; }
		public string TargetHourlyFuelConsumptionUnits { get; set; }
		public string FleetNumber { get; set; }


		// The following 3 fields are EV-related (FuelType == "Electric")
		
		/// <summary>WLTP maximum range, in kilometres</summary>
		public int? WltpMaxRangeKm { get; set; }

		/// <summary>Battery capacity, in kilowatt-hours</summary>
		public int? BatteryCapacitykWh { get; set; } 

		/// <summary>Usable battery capacity, in kilowatt-hours</summary>
		public int? UsableBatteryCapacitykWh { get; set; }



		// A value is required for this field: either a vehicle make/manufacturer
		// recognised by the Fleet Manager system, or "Other"   
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
			get => _icon ?? AssetIcons.DefaultAssetIcon;
			set { _icon = value; }
		}
		private string _iconColour;
		public string IconColour
		{
			get => _iconColour ?? AssetIcons.DefaultAssetIconColour;
			set { _iconColour = value; }
		}
		public string Colour { get; set; }

		private string _assetImage;
		public string AssetImage
		{
			get => _assetImage ?? AssetType.GetById(AssetTypeId)?.DefaultImage;
			set { _assetImage = value; }
		}

		public bool IsDefaultImage
		{
			get => _assetImage == null || string.Equals(_assetImage, AssetType.GetById(AssetTypeId)?.DefaultImage);
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
