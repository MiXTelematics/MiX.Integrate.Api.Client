using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MiX.Integrate.Api.Client.Base
{
	public class NewtonsoftJsonSerializer
	{
		public string ContentType
		{
			get { return "application/json"; } // Probably used for Serialization?
			set { }
		}

		public string DateFormat { get; set; }

		public string Namespace { get; set; }

		public string RootElement { get; set; }

		public string Serialize(object obj)
		{
			string json = JsonConvert.SerializeObject(obj, _settings);
			return json;
		}

		public T Deserialize<T>(string jsonString)
		{
			return JsonConvert.DeserializeObject<T>(jsonString, _settings);
		}

		private JsonSerializerSettings _settings;
		public NewtonsoftJsonSerializer()
		{
			_settings = new JsonSerializerSettings();
			_settings.NullValueHandling = NullValueHandling.Ignore;
			_settings.Converters.Add(new IsoDateTimeConverter());
			_settings.Converters.Add(new StringEnumConverter());
			_settings.Converters.Add(new TimeSpanJsonConverter());
			_settings.Converters.Add(new TimeSpanNullableJsonConverter());
		}

		private static NewtonsoftJsonSerializer _default;
		public static NewtonsoftJsonSerializer Default
		{
			get
			{
				if (_default == null)
				{
					_default = new NewtonsoftJsonSerializer();
				}
				return _default;
			}
		}
	}
}
