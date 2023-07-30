using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MiX.Integrate.API.Client.Base
{
	public class NewtonsoftJsonSerializer
	{
		private static NewtonsoftJsonSerializer _default;
		private readonly JsonSerializerSettings _settings;

		public NewtonsoftJsonSerializer()
		{
			_settings = new JsonSerializerSettings
			{
				NullValueHandling = NullValueHandling.Ignore,
				MaxDepth = 128  // addresses stack overflow vulnerability
			};
			_settings.Converters.Add(new IsoDateTimeConverter());
			_settings.Converters.Add(new StringEnumConverter());
			_settings.Converters.Add(new TimeSpanJsonConverter());
			_settings.Converters.Add(new TimeSpanNullableJsonConverter());
		}

		public static NewtonsoftJsonSerializer Default
		{
			get { return _default ?? (_default = new NewtonsoftJsonSerializer()); }
		}

		public string Serialize(object obj) => JsonConvert.SerializeObject(obj, _settings);

		public T Deserialize<T>(string jsonString) => JsonConvert.DeserializeObject<T>(jsonString, _settings);

	}
}
