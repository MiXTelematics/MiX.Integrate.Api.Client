using System.Collections.Generic;

namespace MiX.Integrate.Shared.Entities.HosData
{
	public class HosEventDataRequest
	{
		public HosEventDataRequest()
		{
			EntityTypeId = ParameterEntityType.Organisation;
			EntityIds = new List<long> { };
			EventTypeIds = new List<byte> { };
		}
		public ParameterEntityType EntityTypeId { get; set; }
		public List<long> EntityIds { get; set; }
		public List<byte> EventTypeIds { get; set; }
	}
}