
namespace MiX.Integrate.Shared.Constants
{
	public class APIControllerRoutes
	{
		//HealthCheckController
		public class HEALTHCHECK
		{
			public const string BASIC = "healthcheck/basic";
			public const string EXTENDED = "healthcheck/extended";
		}

		//MiX.Integrate.Api.Controllers.DriversControllerpublic 
		public class DRIVERSCONTROLLER
		{
			public const string GETALLDRIVERSUMMARIES = "api/drivers/group/{groupId:long}";
			public const string GETDRIVERBYID = "api/drivers/group/{groupId:long}/{driverId:long}";
		}

		//MiX.Integrate.Api.Controllers.DriverLicenceController
		public class DRIVERLICENCECONTROLLER
		{
			public const string GETDRIVERLICENCESASYNC = "api/driverlicence/organisationgroupid/{organisationGroupId:long}/driver/{driverId:long}";
			public const string GETDRIVERLICENCECATEGORIESSYNC = "api/driverlicence/licencecategories/organisationgroupid/{organisationGroupId:long}/driver/{driverId:long}";
			public const string GETDRIVERLICENCEASYNC = "api/driverlicence/organisationgroupid/{organisationGroupId:long}/driver/{driverId:long}/licencecategoryid/{licenceCategoryId}";
			public const string ADDDRIVERLICENCEASYNC = "api/driverlicence/add/organisationgroupid/{organisationGroupId:long}";
			public const string UPDATEDRIVERLICENCEASYNC = "api/driverlicence/update/organisationgroupid/{organisationGroupId:long}";
			public const string DELETEDRIVERLICENCEASYNC = "api/driverlicence/delete/organisationgroupid/{organisationGroupId:long}/driver/{driverId:long}/licencecategoryid/{licenceCategoryId}";
		}

		public class DRIVERCERTIFICATIONCONTROLLER
		{
			public const string GETDRIVERCERTIFICATIONSASYNC = "api/drivercertification/organisationgroupid/{organisationGroupId:long}/driver/{driverId:long}";
			public const string GETDRIVERCERTIFICATIONTYPESASYNC = "api/drivercertification/certificationcategories/organisationgroupid/{organisationGroupId:long}/driver/{driverId:long}";
			public const string GETDRIVERCERTIFICATIONASYNC = "api/drivercertification/organisationgroupid/{organisationGroupId:long}/driver/{driverId:long}/certificationtypeid/{certificationTypeId}";
			public const string ADDDRIVERCERTIFICATIONASYNC = "api/drivercertification/add/organisationgroupid/{organisationGroupId:long}";
			public const string UPDATEDRIVERCERTIFICATIONASYNC = "api/drivercertification/update/organisationgroupid/{organisationGroupId:long}";
			public const string DELETEDRIVERCERTIFICATIONASYNC = "api/drivercertification/delete/organisationgroupid/{organisationGroupId:long}/driver/{driverId:long}/certificationtypeid/{certificationTypeId}";
		}

		//MiX.Integrate.Api.Controllers.AssetsController
		public class ASSETSCONTROLLER
		{
			public const string GETALL = "api/assets/group/{groupId:long}";
			public const string GET = "api/assets/{assetId:long}";
			public const string GETBYGROUP = "api/assets/group/{groupId:long}/asset/{assetId:long}";
			public const string UPDATE = "api/assets";
		}

		//MiX.Fleet.Services.Api GroupsController
		public class GROUPSCONTROLLER
		{
			public const string GETSUBGROUPS = "api/organisationgroups/{groupId:long}";
			public const string DELETEORGSUBGROUP = "api/organisationgroups/organisationsubgroup/{groupId}";
			public const string DELETESITE = "api/organisationgroups/site/{groupId}";

			public const string ADDSITE = "api/organisationgroups/{parentGroupId}/site";
			public const string ADDORGSUBGROUP = "api/organisationgroups/{parentGroupId}/organisationsubgroup";

			public const string UPDATEGROUPNAME = "api/organisationgroups/{organisationGroupId}/group/{groupId}/name";
		}

		//MiX.Fleet.Services.Api PositionsController
		public class POSITIONSCONTROLLER
		{
			public const string GETLATESTBYASSETIDS = "api/positions/latest/assets/{quantity}";
			public const string GETLATESTBYGROUPIDS = "api/positions/latest/groups/{quantity}";
			public const string GETSINCEBYASSETIDS = "api/positions/assets/since/{since}";
			public const string GETBYDATERANGEBYGROUPIDS = "api/positions/groups/from/{from}/to/{to}";
			public const string GETBYDATERANGEBYASSETTIDS = "api/positions/assets/{from}/{to}";
			public const string GETBYDATERANGEBYDRIVERIDS = "api/positions/drivers/{from}/{to}";
		}

		//MiX.Fleet.Services.Api EventsController
		public class EVENTSCONTROLLER
		{	
			//public const string GETASYNC = "api/events/{eventId:long}";
			//public const string EXISTSASYNC = "api/events/exists/{eventId:long}";

			public const string GETLATESTFORGROUPS = "api/events/groups/latest/entitytype/{entityType}/quantity/{quantity}";
			public const string GETRANGEFORGROUPS = "api/events/groups/range/entitytype/{entityType}/from/{from}/to/{to}";
			public const string GETSINCEFORGROUPS = "api/events/groups/since/entitytype/{entityType}/since/{since}";

			public const string GETLATESTFORASSETS = "api/events/assets/latest/quantity/{quantity}";
			public const string GETRANGEFORASSETS = "api/events/assets/range/from/{from}/to/{to}";
			public const string GETSINCEFORASSETS = "api/events/assets/since/since/{since}/quantity/{quantity}";

			public const string GETLATESTFORDRIVERS = "api/events/drivers/latest/quantity/{quantity}";
			public const string GETRANGEFORDRIVERS = "api/events/drivers/range/from/{from}/to/{to}";
			public const string GETSINCEFORDRIVERS = "api/events/drivers/since/since/{since}/quantity/{quantity}";

			//public const string HASANYEVENTDATAFORORG = "api/events/hasanyevents/organisation/{organisationId:long}/from/{from}";
		}


		//MiX.Fleet.Services.Api TripsController
		public class TRIPSCONTROLLER
		{
      public const string GETLATESTFORGROUPS = "api/trips/groups/latest/entitytype/{entityType}/quantity/{quantity}";
      public const string GETRANGEFORGROUPS = "api/trips/groups/range/entitytype/{entityType}/from/{from}/to/{to}";
      public const string GETSINCEFORGROUPS = "api/trips/groups/since/entitytype/{entityType}/since/{since}";

      public const string GETLATESTFORASSETS = "api/trips/assets/latest/quantity/{quantity}";
      public const string GETRANGEFORASSETS = "api/trips/assets/range/from/{from}/to/{to}";
      public const string GETSINCEFORASSETS = "api/trips/assets/since/since/{since}";

      public const string GETLATESTFORDRIVERS = "api/trips/drivers/latest/quantity/{quantity}";
      public const string GETRANGEFORDRIVERS = "api/trips/drivers/range/from/{from}/to/{to}";
      public const string GETSINCEFORDRIVERS = "api/trips/drivers/since/since/{since}";

    }

		//MiX.Integrate.Api.Controllers.JourneysController
		public class JOURNEYSCONTROLLER
		{
			public const string ADDJOURNEY = "api/journeys/";
			public const string GETJOURNEY = "api/journeys/{journeyId:long}";
			public const string GETJOURNEYROUTE = "api/journeys/routes/{groupId:long}";
			public const string GETJOURNEYPROGRESS = "api/journeys/progress/{journeyId:long}";
			public const string GETJOURNEYINPROGRESSCURRENTSTATUS = "api/journeys/inprogress/currentstatus/{groupId:long}";
		}

		//MiX.Integrate.Api.Controllers.LocationsController
		public class LOCATIONSCONTROLLER
		{
			public const string GETALL = "api/locations/group/{groupId:long}";
			public const string GET = "api/locations/location/{locationId:long}";
			public const string ADDASYNC = "api/locations/group/{groupId:long}";
			public const string UPDATEASYNC = "api/locations/group/{groupId:long}";
			public const string DELETEASYNC = "api/locations/group/{groupId:long}/location/{locationId:long}";
		}



		//MiX.Integrate.Api.Controllers.DeviceCommandsController
		public class DEVICECOMMANDSCONTROLLER
		{
			//public const string SENDCOMMAND = "api/devicecommands/groupId/{groupId:long}/assetId/{assetId:long}/commandType/{commandType}";
			public const string SENDPOSITIONREQUESTMESSAGE = "api/devicecommands/sendpositionrequestmessage/groupId/{groupId:long}/assetid/{assetId:long}";
			public const string SENDRELAYCOMMAND = "api/devicecommands/sendrelaycommand/groupId/{groupId:long}/assetid/{assetId:long}/relayDrive/{relayDrive}/relayState/{relayState}";
			public const string SENDTRACKINGREQUEST = "api/devicecommands/sendtrackingrequest/groupId/{groupId:long}/assetid/{assetId:long}/intervalSeconds/{intervalSeconds}/durationSeconds/{durationSeconds}";

			public const string SENDSTOPTRACKINGREQUEST = "api/devicecommands/sendstoptrackingrequest/groupId/{groupId:long}/assetid/{assetId:long}";
			public const string SENDPROGRESSIVESHUTDOWNCOMMAND = "api/devicecommands/sendprogressiveshutdowncommand/groupId/{groupId:long}/assetid/{assetId:long}/relayDrive/{relayDrive}";
			public const string SENDDISARMUNITMESSAGE = "api/devicecommands/senddisarmunitmessage/groupId/{groupId:long}/assetid/{assetId:long}";
			public const string SENDFREETEXTMESSAGE = "api/devicecommands/sendfreetextmessage/groupId/{groupId:long}/assetid/{assetId:long}";
			public const string SENDSETACRONYMCOMMAND = "api/devicecommands/sendsetacronymcommand/groupId/{groupId:long}/assetid/{assetId:long}/params/{param1}/{param2}/{param3}";
		}

		//MiX.Integrate.Api.Controllers.LibraryEventsController
		public class LIBRARYEVENTSCONTROLLER
		{
			public const string GETALLLIBRARYEVENTS = "api/libraryevents/organisation/{organisationId:long}";
		}

		//MiX.Integrate.Api.Controllers.MessagesController
		public class MESSAGESCONTROLLER
		{
			public const string GETSINCEID = "api/messages/getsinceid/organisationid/{organisationId:long}/messageid/{messageId}/maxrecords/{maxRecords}";
			public const string GET = "api/messages/get/organisationid/{organisationId:long}/messageid/{messageId}";
			public const string GETMESSAGESTATEHISTORY = "api/messages/getmessagestatehistory/organisationid/{organisationId:long}/messageid/{messageId}";
			public const string GETMESSAGESTATE = "api/messages/getmessagestate/organisationid/{organisationId:long}/messageid/{messageId}";
			public const string SENDFREETEXTMESSAGE = "api/messages/sendfreetextmessage/organisationid/{organisationId:long}";
			public const string SENDJOBMESSAGE = "api/messages/sendjobmessage/organisationid/{organisationId:long}";
		}

	  //MiX.Integrate.Api.Controllers.FuelController
	  public class FUELCONTROLLER
	  {
	    public const string GETFUELBYDATERANGEFORGROUP = "api/fueltransactions/group/{organisationId:long}/from/{from}/to/{to}";
	  }

	  //MiX.Integrate.Api.Controllers.CustomGroupsController
	  public class CUSTOMGROUPSCONTROLLER
	  {
	    public const string GETALLCUSTOMGROUPS = "api/customgroups/organisation/{organisationId:long}";
	    public const string GETCUSTOMGROUPBYID = "api/customgroups/organisation/{organisationId:long}/customgroup/{customGroupId:long}";

	    public const string ADDCUSTOMGROUP = "api/customgroups/organisation/{organisationId:long}";
	    public const string UPDATECUSTOMGROUP = "api/customgroups/organisation/{organisationId:long}";

	    public const string ADDCUSTOMGROUPMEMBERS = "api/customgroups/organisation/{organisationId:long}/customgroup/{customGroupId:long}/entitytype/{entityType}/members";
	    public const string DELETECUSTOMGROUPMEMBERS = "api/customgroups/organisation/{organisationId:long}/customgroup/{customGroupId:long}/entitytype/{entityType}/members";

			public const string GETCUSTOMGROUPSFORASSET = "api/customgroups/asset/{assetId}";

		}

	}
}

