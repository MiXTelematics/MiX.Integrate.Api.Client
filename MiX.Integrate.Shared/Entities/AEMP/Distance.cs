﻿using System;
using System.Xml.Serialization;

namespace MiX.Integrate.Shared.Entities.Aemp
{
	
	public class Distance
	{
		[XmlAttribute("dateTime")] public DateTime Datetime { get; set; }

		/// <example>72379.12</example>
		[XmlElement] public float OdometerKilometre { get; set; }
	}
}
