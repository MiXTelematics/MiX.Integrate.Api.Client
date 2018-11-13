
namespace MiX.Integrate.Shared.Entities.HosData
{
	public class HosWorkStateDetail
	{
		public long Id { get; set; }
		public string Description { get; set; }
		public string Abbreviation { get; set; }
		public string TimelineLabel { get; set; }
		public byte Order { get; set; }
		public bool IsOilField { get; set; }
		public int RendererKey { get; set; }
	}
}