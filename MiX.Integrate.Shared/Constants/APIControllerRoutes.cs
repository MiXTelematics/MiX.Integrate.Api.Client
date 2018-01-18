
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

		//MiX.Integrate.Api.Controllers.ActiveEventController 
		public class ACTIVEEVENTSCONTROLLER
		{
			public const string GETLATESTFORGROUP = "api/activeevents/group/{groupId}/latest/{quantity}";
			public const string GETLATESTPERASSETINGROUP = "api/activeevents/group/{groupId}/latestperasset/{quantity}";
			public const string GETRANGEFORASSETS = "api/activeevents/assets/from/{from}/to/{to}";
		}

		//MiX.Integrate.Api.Controllers.DriversControllerpublic 
		public class DRIVERSCONTROLLER
		{
			public const string GETDRIVER = "api/drivers/group/{groupId}/driver/{driverId}";
			public const string UPDATEDRIVER = "api/drivers";
			public const string ADDDRIVER = "api/drivers";
			public const string UPDATEDRIVERNAMEBYEXTENDEDIDIFAUTOCREATED = "api/drivers/group/{groupId}/extended/{extendedDriverId}/ifautocreated";
			public const string GETALLDRIVERS = "api/drivers/organisation/{organisationId}";
		}

		//MiX.Integrate.Api.Controllers.DriverLicenceController
		public class DRIVERLICENCECONTROLLER
		{
			public const string GETDRIVERLICENCES = "api/driverlicence/organisation/{organisationId}/driver/{driverId}";
			public const string GETDRIVERLICENCECATEGORIES = "api/driverlicence/organisation/{organisationId}/driver/{driverId}/licencecategories";
			public const string GETDRIVERLICENCE = "api/driverlicence/organisation/{organisationId}/driver/{driverId}/licencecategory/{licenceCategoryId}";
			public const string ADDDRIVERLICENCE = "api/driverlicence/organisation/{organisationId}";
			public const string UPDATEDRIVERLICENCE = "api/driverlicence/organisation/{organisationId}";
			public const string DELETEDRIVERLICENCE = "api/driverlicence/organisation/{organisationId}/driver/{driverId}/licencecategory/{licenceCategoryId}";
		}

		public class DRIVERCERTIFICATIONCONTROLLER
		{
			public const string GETDRIVERCERTIFICATIONS = "api/drivercertification/organisation/{organisationId}/driver/{driverId}";
			public const string GETDRIVERCERTIFICATIONTYPES = "api/drivercertification/organisation/{organisationId}/driver/{driverId}/certificationcategories";
			public const string GETDRIVERCERTIFICATION = "api/drivercertification/organisation/{organisationId}/driver/{driverId}/certificationtypeid/{certificationTypeId}";
			public const string ADDDRIVERCERTIFICATION = "api/drivercertification/organisation/{organisationId}";
			public const string UPDATEDRIVERCERTIFICATION = "api/drivercertification/organisation/{organisationId}";
			public const string DELETEDRIVERCERTIFICATION = "api/drivercertification/organisation/{organisationId}/driver/{driverId}/certificationtypeid/{certificationTypeId}";
		}

		//MiX.Integrate.Api.Controllers.AssetsController
		public class ASSETSCONTROLLER
		{
			public const string GETALL = "api/assets/group/{groupId}";
			public const string GET = "api/assets/{assetId}";
			public const string GETBYGROUP = "api/assets/group/{groupId}/asset/{assetId}";
			public const string UPDATE = "api/assets";
			public const string ADDASSETSTATE = "api/assets/group/{groupId}/state";
			public const string ADD = "api/assets";
		}


		//MiX.Integrate.Api RemindersController
		public class REMINDERSCONTROLLER
		{
			public const string GETASSETREMINDERS = "api/reminders/organisation/{organisationId}/asset/{assetId}";
			public const string ASSETSERVICEREMINDERS = "api/reminders/organisation/{organisationId}/asset/{assetId}/service";
			public const string ASSETLICENCEREMINDERS = "api/reminders/organisation/{organisationId}/asset/{assetId}/licence";
			public const string ASSETROADWORTHYREMINDERS = "api/reminders/organisation/{organisationId}/asset/{assetId}/roadworthy-certificate";
		}

		//MiX.Integrate.Api GroupsController
		public class GROUPSCONTROLLER
		{
			public const string GETORGGROUPS = "api/organisationgroups";
			public const string GETSUBGROUPS = "api/organisationgroups/subgroups/{groupId}";
			public const string DELETEORGSUBGROUP = "api/organisationgroups/organisationsubgroup/{groupId}";
			public const string DELETESITE = "api/organisationgroups/site/{groupId}";
			public const string ADDSITE = "api/organisationgroups/{parentGroupId}/site";
			public const string ADDORGSUBGROUP = "api/organisationgroups/{parentGroupId}/organisationsubgroup";
			public const string UPDATEGROUPNAME = "api/organisationgroups/{organisationId}/group/{groupId}/name";
			public const string GETORGANISATIONDETAILS = "api/organisationgroups/details/{organisationId}";
			public const string GETGROUP = "api/organisationgroups/group/{groupId}";
		}

		//MiX.Integrate.Api PositionsController
		public class POSITIONSCONTROLLER
		{
			public const string GETLATESTFORGROUPS = "api/positions/groups/latest/{quantity}";
			public const string GETRANGEFORGROUPS = "api/positions/groups/from/{from}/to/{to}";
			public const string GETLATESTFORASSETS = "api/positions/assets/latest/{quantity}";
			public const string GETRANGEFORASSETS = "api/positions/assets/from/{from}/to/{to}";
			public const string GETSINCEFORASSETS = "api/positions/assets/since/{since}";
			public const string GETRANGEFORDRIVERS = "api/positions/drivers/from/{from}/to/{to}";
			public const string GETCREATEDSINCEFORGROUPSASYNC = "api/positions/groups/createdsince/entitytype/{entityType}/sincetoken/{sinceToken}/quantity/{quantity}";
		}

		//MiX.Integrate.Api EventsController
		public class EVENTSCONTROLLER
		{
			public const string GETLATESTFORGROUPS = "api/events/groups/latest/entitytype/{entityType}/{quantity}";
			public const string GETRANGEFORGROUPS = "api/events/groups/entitytype/{entityType}/from/{from}/to/{to}";
			public const string GETSINCEFORGROUPS = "api/events/groups/since/entitytype/{entityType}/{since}";
			public const string GETCREATEDSINCEFORGROUPSASYNC = "api/events/groups/createdsince/entitytype/{entityType}/sincetoken/{sinceToken}/quantity/{quantity}";

			public const string GETLATESTFORASSETS = "api/events/assets/latest/{quantity}";
			public const string GETRANGEFORASSETS = "api/events/assets/from/{from}/to/{to}";
			public const string GETSINCEFORASSETS = "api/events/assets/since/{since}/quantity/{quantity}";
			public const string GETCREATEDSINCEFORASSETSASYNC = "api/events/assets/createdsince/sincetoken/{sinceToken}/quantity/{quantity}";

			public const string GETLATESTFORDRIVERS = "api/events/drivers/latest/{quantity}";
			public const string GETRANGEFORDRIVERS = "api/events/drivers/from/{from}/to/{to}";
			public const string GETSINCEFORDRIVERS = "api/events/drivers/since/{since}/quantity/{quantity}";
			public const string GETCREATEDSINCEFORDRIVERSASYNC = "api/events/drivers/createdsince/sincetoken/{sinceToken}/quantity/{quantity}";
		}

		//MiX.Fleet.Services.Api TachoController
		public class TACHOCONTROLLER
		{
			public const string GETRANGEFORASSETASYNC = "api/tachos/asset/{assetId}/range/from/{from}/to/{to}";
		}

		//MiX.Integrate.Api TripsController
		public class TRIPSCONTROLLER
		{
			public const string GETLATESTFORGROUPS = "api/trips/groups/latest/{quantity}/entitytype/{entityType}";
			public const string GETRANGEFORGROUPS = "api/trips/groups/from/{from}/to/{to}/entitytype/{entityType}";
			public const string GETSINCEFORGROUPS = "api/trips/groups/since/{since}/entitytype/{entityType}";
			public const string GETCREATEDSINCEFORGROUPSASYNC = "api/trips/groups/createdsince/entitytype/{entityType}/sincetoken/{sinceToken}/quantity/{quantity}";

			public const string GETLATESTFORASSETS = "api/trips/assets/latest/{quantity}";
			public const string GETRANGEFORASSETS = "api/trips/assets/from/{from}/to/{to}";
			public const string GETSINCEFORASSETS = "api/trips/assets/since/{since}";
			public const string GETCREATEDSINCEFORASSETSASYNC = "api/trips/assets/createdsince/sincetoken/{sinceToken}/quantity/{quantity}";

			public const string GETLATESTFORDRIVERS = "api/trips/drivers/latest/{quantity}";
			public const string GETRANGEFORDRIVERS = "api/trips/drivers/from/{from}/to/{to}";
			public const string GETSINCEFORDRIVERS = "api/trips/drivers/since/{since}";
			public const string GETCREATEDSINCEFORDRIVERSASYNC = "api/trips/drivers/createdsince/sincetoken/{sinceToken}/quantity/{quantity}";
		}

		//MiX.Integrate.Api.Controllers.JourneysController
		public class JOURNEYSCONTROLLER
		{
			public const string ADDJOURNEY = "api/journeys/";
			public const string GETJOURNEY = "api/journeys/{journeyId}";
			public const string GETJOURNEYROUTE = "api/journeys/routes/{groupId}";
			public const string GETJOURNEYPROGRESS = "api/journeys/progress/{journeyId}";
			public const string GETJOURNEYINPROGRESSCURRENTSTATUS = "api/journeys/inprogress/currentstatus/{groupId}";
		}

		//MiX.Integrate.Api.Controllers.LocationsController
		public class LOCATIONSCONTROLLER
		{
			public const string GETALL = "api/locations/group/{groupId}";
			public const string GET = "api/locations/{locationId}";
			public const string ADD = "api/locations/group/{groupId}";
			public const string UPDATE = "api/locations/group/{groupId}";
			public const string DELETE = "api/locations/group/{groupId}/location/{locationId}";
			public const string INRANGE = "api/locations/group/{groupId}/inrange/{meters}";
			public const string NEAREST = "api/locations/group/{groupId}/nearest";
			public const string CHANGEDSINCE = "api/locations/organisation/{organisationId}/changedsince/since/{since}";

		}

		//MiX.Integrate.Api.Controllers.LoggableData
		public class LOGGABLEDATACONTROLLER
		{
			public const string GETLOGGABLEDATAFORASSETSBYDATERANGE = "api/loggabledata/from/{from}/to/{to}";
			public const string GETROVIMESSAGESFORASSETSSINCE = "api/loggabledata/rovimessages/since/{since}";
			public const string GETROVIMESSAGESFORASSETSBYDATERANGE = "api/loggabledata/rovimessages/from/{from}/to/{to}";
			public const string GETROVIMESSAGESFORASSETSLATEST = "api/loggabledata/rovimessageslatest/count/{count}";
		}

		//MiX.Integrate.Api.Controllers.DeviceCommandsController
		public class DEVICECOMMANDSCONTROLLER
		{
			public const string SENDPOSITIONREQUESTMESSAGE = "api/devicecommands/group/{groupId}/asset/{assetId}/sendpositionrequestmessage";
			public const string SENDRELAYCOMMAND = "api/devicecommands/group/{groupId}/asset/{assetId}/sendrelaycommand/relayDrive/{relayDrive}/relayState/{relayState}";
			public const string SENDTRACKINGREQUEST = "api/devicecommands/group/{groupId}/asset/{assetId}/sendtrackingrequest/intervalSeconds/{intervalSeconds}/durationSeconds/{durationSeconds}";

			public const string SENDSTOPTRACKINGREQUEST = "api/devicecommands/group/{groupId}/asset/{assetId}/sendstoptrackingrequest";
			public const string SENDPROGRESSIVESHUTDOWNCOMMAND = "api/devicecommands/group/{groupId}/asset/{assetId}/sendprogressiveshutdowncommand/relayDrive/{relayDrive}";
			public const string SENDDISARMUNITMESSAGE = "api/devicecommands/group/{groupId}/asset/{assetId}/senddisarmunitmessage";
			public const string SENDFREETEXTMESSAGE = "api/devicecommands/group/{groupId}/asset/{assetId}/sendfreetextmessage";
			public const string SENDSETACRONYMCOMMAND = "api/devicecommands/group/{groupId}/asset/{assetId}/sendsetacronymcommand/params/{param1}/{param2}/{param3}";
		}

		//MiX.Integrate.Api.Controllers.DeviceConfigurationController
		public class DEVICECONFIGCONTROLLER
		{
			public const string GETCONNECTEDPERIPHERALSFORASSETS = "api/deviceconfiguration/group/{groupId}/assets/connectedperipherals";
		}

		//MiX.Integrate.Api.Controllers.LibraryEventsController
		public class LIBRARYEVENTSCONTROLLER
		{
			public const string GETALLLIBRARYEVENTS = "api/libraryevents/organisation/{organisationId}";
		}

		//MiX.Integrate.Api.Controllers.MessagesController
		public class MESSAGESCONTROLLER
		{
			public const string GETSINCEID = "api/messages/organisation/{organisationId}/sincemessageid/{messageId}/maxrecords/{maxRecords}";
			public const string GET = "api/messages/organisation/{organisationId}/messageid/{messageId}";
			public const string GETMESSAGESTATEHISTORY = "api/messages/organisation/{organisationId}/messageid/{messageId}/messagestatehistory";
			public const string GETMESSAGESTATE = "api/messages/organisation/{organisationId}/messageid/{messageId}/messagestate";
			public const string SENDFREETEXTMESSAGE = "api/messages/organisation/{organisationId}/sendfreetextmessage";
			public const string SENDJOBMESSAGE = "api/messages/organisation/{organisationId}/sendjobmessage";
		}

		//MiX.Integrate.Api.Controllers.FuelController
		public class FUELCONTROLLER
		{
			public const string GETFUELBYDATERANGEFORGROUP = "api/fueltransactions/organisation/{organisationId}/from/{from}/to/{to}";
			public const string ADDFUELTRANSACTIONS = "api/fueltransactions/organisation/{organisationId}/asset/{assetId}";
		}

		//MiX.Integrate.Api.Controllers.CustomGroupsController
		public class CUSTOMGROUPSCONTROLLER
		{
			public const string GETALLCUSTOMGROUPS = "api/customgroups/organisation/{organisationId}";
			public const string GETCUSTOMGROUPBYID = "api/customgroups/organisation/{organisationId}/customgroup/{customGroupId}";

			public const string ADDCUSTOMGROUP = "api/customgroups/organisation/{organisationId}";
			public const string UPDATECUSTOMGROUP = "api/customgroups/organisation/{organisationId}";

			public const string ADDCUSTOMGROUPMEMBERS = "api/customgroups/organisation/{organisationId}/customgroup/{customGroupId}/members/entitytype/{entityType}";
			public const string DELETECUSTOMGROUPMEMBERS = "api/customgroups/organisation/{organisationId}/customgroup/{customGroupId}/members/entitytype/{entityType}";

			public const string GETCUSTOMGROUPSFORASSET = "api/customgroups/organisation/{organisationId}/asset/{assetId}";
			public const string GETCUSTOMGROUPSFORDRIVER = "api/customgroups/organisation/{organisationId}/driver/{driverId}";

		}

	}
}

