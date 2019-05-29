using System.Collections.Generic;

namespace MiX.Integrate.Shared.Entities.DeviceConfiguration
{
	public class MobileUnitCameraSettings
	{
		public long AssetId { get; set; }
		public List<VideoCamera> SelectedCameras { get; set; }
	}

	public class VideoCamera
	{
		public int Id { get; set; }
		public string Description { get; set; }
	}
}
