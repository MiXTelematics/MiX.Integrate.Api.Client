using System.Collections.Generic;

namespace MiX.Integrate.Shared.Entities.HosData
{
	public class DataRequestParameters
	{
		public ParameterEntityType EntityTypeId { get; set; }
		public List<long> EntityIds { get; set; }
	}
}
