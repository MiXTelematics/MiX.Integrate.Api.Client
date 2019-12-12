using System;

namespace MiX.Integrate.Shared.Entities.Assets
{
  public class AssetDiagnostics
  {
	public long AssetId { get; set; }

	public DateTime? LastConfig { get; set; }

	public string FirmwareVersion { get; set; }

	public string APN { get; set; }

	public string DDMVersion { get; set; }

	public string ServerPort { get; set; }

	public string ServerAddress { get; set; }
  }
}
