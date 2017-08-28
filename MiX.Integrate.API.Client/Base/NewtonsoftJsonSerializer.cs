using RestSharp.Serializers;
using RestSharp.Deserializers;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace MiX.Integrate.Api.Client
{
	public class NewtonsoftJsonSerializer : ISerializer, IDeserializer
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

		public T Deserialize<T>(RestSharp.IRestResponse response)
		{
			T obj = JsonConvert.DeserializeObject<T>(response.Content, _settings);
			return obj;
		}

		private JsonSerializerSettings _settings;
		public NewtonsoftJsonSerializer()
		{
			_settings = new JsonSerializerSettings();
			_settings.NullValueHandling = NullValueHandling.Ignore;
			_settings.Converters.Add(new IsoDateTimeConverter());
			_settings.Converters.Add(new StringEnumConverter());
		}

		public static NewtonsoftJsonSerializer Default
		{
			get
			{
				return new NewtonsoftJsonSerializer();
			}
		}
	}
}
