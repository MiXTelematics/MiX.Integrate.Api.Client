using Newtonsoft.Json;
using System;
using System.Xml;

namespace MiX.Integrate.API.Client.Base
{
	public class TimeSpanJsonConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var duration = (TimeSpan)value;
			writer.WriteValue(XmlConvert.ToString(duration));
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			if (objectType != typeof(TimeSpan))
				throw new ArgumentException();

			var spanString = reader.Value as string;
			if (spanString == null)
				return null;
			return XmlConvert.ToTimeSpan(spanString);
		}

		public override bool CanConvert(Type objectType)
		{
			return typeof(TimeSpan) == objectType;
		}
	}
}