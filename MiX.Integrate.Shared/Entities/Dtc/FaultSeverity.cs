using System;
using System.Collections.Generic;
using System.Text;

namespace MiX.Integrate.Shared.Entities.Dtc
{
	public enum FaultSeverity : byte
	{
		Info = 0,
		Low = 1,
		Medium = 2,
		High = 3,
		Critical = 4
	}
}
