using System;
using System.Collections.Generic;
using System.Text;

namespace MiX.Integrate.Shared.Entities.GeoData
{
  public class GeoDataFile
  {
		public string Filename { get; set; }
		public GeoDataFormat Format { get; set; }
		public byte[] Contents { get; set; } = null;
		public int Size => Contents.Length;
  }
}
