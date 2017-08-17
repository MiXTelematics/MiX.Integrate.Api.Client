using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiX.Integrate.API.Client.Tests
{
	[TestClass]
	public class Main
	{

		public static IConfiguration Configuration { get; set; }

		[AssemblyInitialize]
		public static void AssemblyInit(TestContext context)
		{
			var builder = new ConfigurationBuilder().AddJsonFile("appSettings.json");
			Configuration = builder.Build();
		}

	}
}
