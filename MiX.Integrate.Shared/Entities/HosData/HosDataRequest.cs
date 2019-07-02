using System.Collections.Generic;

namespace MiX.Integrate.Shared.Entities.HosData
{
	public class HosDataRequest
	{
		public HosDataRequest()
		{
			EntityTypeId = ParameterEntityType.Organisation;
			EntityIds = new List<long> { };
		}
		public ParameterEntityType EntityTypeId { get; set; }
		public List<long> EntityIds { get; set; }
	}
}
