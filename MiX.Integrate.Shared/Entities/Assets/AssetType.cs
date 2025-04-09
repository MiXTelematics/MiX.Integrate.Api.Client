using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MiX.Integrate.Shared.Entities.Assets
{
	public class AssetType
	{
		public int AssetTypeId { get; }
		public string Name { get; }
		public string DefaultImage { get; }

		public static IReadOnlyList<AssetType> All { get; }

		static AssetType()
		{
			All = new ReadOnlyCollection<AssetType>(new List<AssetType>()
			{
				MotorCycle,
				Trailer,
				Boat,
				MobilePlantEquipment,
				StationaryPlantEquipment,
				EmergencyServiceVehicle,
				DangerousGoodsVehicle,
				PassengerVehicle,
				LightPassengerVehicleMinibus,
				HeavyPassengerVehicleBusArticulated,
				HeavyPassengerVehicleBusSingleDecker,
				HeavyPassengerVehicleBusDoubleDecker,
				HeavyVehicleArticulated,
				HeavyVehicleNonArticulated,
				HeavyVehicleRefrigeratedTransport,
				LightVehicle,
				FluidTransportVehicle,
				Other,
				Train,
				LightDeliveryVehicle,
				OffRoadVehicle,
				MediumCommercialVehicle,
				NonPoweredAsset,
//				MobilePhone,
				HeavyVehicle
			});
		}

		private AssetType(int id, string name, string defaultImage)
		{
			AssetTypeId = id;
			Name = name;
			DefaultImage = defaultImage;
		}

		public static readonly AssetType MotorCycle = new AssetType(1, "Motorcycle", "asset-motorcycle.jpg");
		public static readonly AssetType Trailer = new AssetType(2, "Trailer", "asset-trailer.jpg");
		public static readonly AssetType Boat = new AssetType(4, "Boat", "asset-boat.jpg");
		public static readonly AssetType MobilePlantEquipment = new AssetType(5, "Mobile Plant Equipment", "asset-mobile-plant-equipment.jpg");
		public static readonly AssetType StationaryPlantEquipment = new AssetType(6, "Stationary Plant Equipment", "asset-stationery-plant-equipment.jpg");
		public static readonly AssetType EmergencyServiceVehicle = new AssetType(7, "Emergency Service Vehicle", "asset-emergency-services-vehicle.jpg");
		public static readonly AssetType DangerousGoodsVehicle = new AssetType(8, "Dangerous Goods Vehicle", "asset-dangerous-goods-vehicle.jpg");
		public static readonly AssetType PassengerVehicle = new AssetType(9, "Passenger Vehicle", "asset-passenger-vehicle.jpg");
		public static readonly AssetType LightPassengerVehicleMinibus = new AssetType(10, "Light Passenger Vehicle - Minibus", "asset-passenger-vehicle-minibus.jpg");
		public static readonly AssetType HeavyPassengerVehicleBusArticulated = new AssetType(11, "Heavy Passenger Vehicle - Bus - Articulated", "asset-heavy-passenger-vehicle-bus-articulated.jpg");
		public static readonly AssetType HeavyPassengerVehicleBusSingleDecker = new AssetType(12, "Heavy Passenger Vehicle - Bus - Single Decker", "asset-heavy-passenger-vehicle-bus.jpg");
		public static readonly AssetType HeavyPassengerVehicleBusDoubleDecker = new AssetType(13, "Heavy Passenger Vehicle - Bus - Double Decker", "asset-heavy-passenger-vehicle-bus-double.jpg");
		public static readonly AssetType HeavyVehicleArticulated = new AssetType(14, "Heavy Vehicle - Articulated", "asset-heavy-vehicle-articulated.jpg");
		public static readonly AssetType HeavyVehicleNonArticulated = new AssetType(15, "Heavy Vehicle - Non-Articulated", "asset-heavy-vehicle-non-articulated.jpg");
		public static readonly AssetType HeavyVehicleRefrigeratedTransport = new AssetType(16, "Heavy Vehicle - Refrigerated Transport", "asset-heavey-vehicle-refrigerated.jpg");
		public static readonly AssetType LightVehicle = new AssetType(17, "Light Vehicle", "asset-light-vehicle.jpg");
		public static readonly AssetType FluidTransportVehicle = new AssetType(18, "Fluid Transport Vehicle", "asset-fluid-transport-vehicle.jpg");
		//public static readonly AssetType SnowPlough = new AssetType(19, "Snow Plough", "asset-other.jpg");
		public static readonly AssetType Other = new AssetType(20, "Other", "asset-other.jpg");
		public static readonly AssetType Train = new AssetType(21, "Train", "asset-train.jpg");
		public static readonly AssetType LightDeliveryVehicle = new AssetType(22, "Light Delivery Vehicle", "asset-light-delivery-vehicle.jpg");
		public static readonly AssetType OffRoadVehicle = new AssetType(24, "Off-Road Vehicle", "asset-light-delivery-vehicle.jpg");
		public static readonly AssetType MediumCommercialVehicle = new AssetType(25, "Medium Commercial Vehicle", "asset-medium-commercial-vehicle.jpg");
		public static readonly AssetType NonPoweredAsset = new AssetType(26, "Non-Powered Asset", "non-powered-asset.jpg");
//		public static readonly AssetType MobilePhone = new AssetType(27, "Mobile Phone", "asset-mobile-phone.jpg");
	    public static readonly AssetType HeavyVehicle = new AssetType(28, "Heavy Vehicle", "asset-heavy-vehicle-non-articulated.jpg");


		public static AssetType GetById(int id)
		{
			for (var i = 0; i < All.Count; i++)
				if (All[i].AssetTypeId == id) return All[i];
					
			return default(AssetType);
		}

		public static AssetType GetByName(string name)
		{
			for (var i = 0; i < All.Count; i++)
				if (All[i].Name.Equals(name, StringComparison.OrdinalIgnoreCase)) return All[i];
					
			return default(AssetType);
		}

		public static implicit operator AssetType(int id)
		{

			for (var i = 0; i < All.Count; i++)
				if (All[i].AssetTypeId == id)
				{
					var result = All[i];
					while (i < All.Count)
						if (All[i++].AssetTypeId == id)
							throw new InvalidOperationException("More than one match found");
					return result;
				}
			throw new InvalidOperationException("No match found");
		}

		public static implicit operator int(AssetType assetType)
		{
			return assetType.AssetTypeId;
		}

		public override string ToString()
		{
			return this.Name;
		}
	}
}
