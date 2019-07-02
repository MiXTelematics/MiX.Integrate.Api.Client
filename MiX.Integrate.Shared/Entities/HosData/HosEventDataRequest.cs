using System.Collections.Generic;

namespace MiX.Integrate.Shared.Entities.HosData
{
	public class HosEventDataRequest : HosDataRequest
	{
		public HosEventDataRequest()
		{
			EventTypeIds = new List<byte> { };
		}
		public List<byte> EventTypeIds { get; set; }
	}
}