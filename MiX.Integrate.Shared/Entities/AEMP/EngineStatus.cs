﻿using System;
using System.Xml.Serialization;

namespace MiX.Integrate.Shared.Entities.Aemp
{
	[XmlType(Namespace = "http://standards.iso.org/iso/15143/-3")]
	public class EngineStatus
	{
		/// <example>18WVJ90831</example>
		[XmlElement] public string EngineNumber { get; set; }

		[XmlElement] public bool Running { get; set; }
		[XmlAttribute("dateTime")] public DateTime Datetime { get; set; }
	}
}