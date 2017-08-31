using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiX.Integrate.Shared.Entities.Assets
{
	public static class AssetIcons
	{
		public static string DefaultAssetIcon = "truck-right";
		public static string DefaultAssetIconColour = "blue";

		public static List<string> GetAssetIcons()
		{
			//todo assetcrud: store a list in the database.
			var icons = new List<string>
			{
				"van-right",
				"truck-right",
				"trailer-right",
				"trailer2-right",
				"tipper-right",
				"tanker-right",
				"plough-right",
				"crane2-right",
				"crane-right",
				"ems-right",
				"generator2-right",
				"generator-right",
				"forklift-right",
				"key-right",
				"motorcycle-right",
				"car-right",
				"car5-right",
				"car4-right",
				"car3-right",
				"car2-right",
				"bus-right",
				"boat-right",
				"batmobile2-right",
				"batmobile-right",
				"phone",
				"person",
				"ldv-right",
				"train-right",
				"container"
			};
			return icons;
		}

		public static readonly Dictionary<string, string> AssetIconColours = new Dictionary<string, string>
		{
			{"black", "000000"},
			{"blue", "0000ff"},
			{"green", "008000"},
			{"teal", "008080"},
			{"deepSkyBlue", "00bfff"},
			{"aqua", "00ffff"},
			{"forestGreen", "228b22"},
			{"limeGreen", "32cd32"},
			{"indigo", "4b0082"},
			{"dimGray", "696969"},
			{"maroon", "800000"},
			{"purple", "800080"},
			{"lightGreen", "90ee90"},
			{"lightBlue", "add8e6"},
			{"fireBrick", "b22222"},
			{"indianRed", "cd5c5c"},
			{"orchid", "da70d6"},
			{"crimson", "dc143c"},
			{"lightCoral", "f08080"},
			{"red", "ff0000"},
			{"deepPink", "ff1493"},
			{"darkOrange", "ff8c00"},
			{"lightPink", "ffb6c1"},
			{"yellow", "ffff00"},
		};

		public static List<string> GetAssetIconColours()
		{
			return AssetIconColours.Keys.ToList();
		}
	}
}
