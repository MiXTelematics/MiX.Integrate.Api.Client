
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace MiX.Integrate.Shared.Constants
{
	public class APIControllerRoutes
	{
		//MiX.Integrate.Api.Controllers.AempController 
		public class AempController
		{
			public const string GETFLEETSNAPSHOT = "api/aemp/{organisationid}";
			public const string GETFLEETSNAPSHOTPAGED = "api/aemp/{organisationId}/{pageNum}";
		}

		//MiX.Integrate.Api.Controllers.ActiveEventController 
		public class ActiveEventsController
		{
			public const string GETLATESTFORGROUP = "api/activeevents/group/{groupId}/latest/{quantity}";
			public const string GETRANGEFORASSETS = "api/activeevents/assets/from/{from}/to/{to}";

			public const string GETCREATEDSINCEFORGROUPSASYNC =
				"api/activeevents/groups/createdsince/entitytype/{entityType}/sincetoken/{sinceToken}/quantity/{quantity}";

			public const string GETCREATEDSINCEFORASSETSASYNC =
				"api/activeevents/assets/createdsince/sincetoken/{sinceToken}/quantity/{quantity}";

			public const string GETCREATEDSINCEFORDRIVERSASYNC =
				"api/activeevents/drivers/createdsince/sincetoken/{sinceToken}/quantity/{quantity}";

			public const string GETCREATEDSINCEFORORGANISATION =
				"api/activeevents/groups/createdsince/organisation/{organisationId}/sincetoken/{sinceToken}/quantity/{quantity}";
		}

		//MiX.Integrate.Api.Controllers.AssetsController
		public class AssetsController
		{
			public const string GETALL = "api/assets/group/{groupId}";
			public const string GET = "api/assets/{assetId}";
			public const string GETADDITIONALDETAILSBYGROUP = "api/assets/group/{groupId}/additionaldetails";
			public const string GETBYGROUP = "api/assets/group/{groupId}/asset/{assetId}";
			public const string UPDATE = "api/assets";
			public const string ADDASSETSTATE = "api/assets/group/{groupId}/state";
			public const string ADD = "api/assets";
			public const string GETASSETDIAG = "api/assets/diagnostics/group/{groupId}";
			public const string GETTRAILERSFORORGANISATION = "api/assets/organisation/{organisationId}/trailers";
			public const string GETASSETTYPES = "api/assets/assettypes";
			public const string GETMANUFACTURERS = "api/assets/manufacturers";
			public const string GETSERVICEHISTORY = "api/assets/servicehistory/{from}/to/{to}";
			public const string GETSERVICEHISTORYBYGROUP = "api/assets/servicehistory/group/{groupId}/{from}/to/{to}";
		}

		//MiX.Integrate.Api.Controllers.CustomGroupsController
		public class CustomGroupsController
		{
			public const string GETALLCUSTOMGROUPS = "api/customgroups/organisation/{organisationId}";
			public const string GETCUSTOMGROUPBYID = "api/customgroups/organisation/{organisationId}/customgroup/{customGroupId}";

			public const string ADDCUSTOMGROUP = "api/customgroups/organisation/{organisationId}";
			public const string UPDATECUSTOMGROUP = "api/customgroups/organisation/{organisationId}";
			public const string DELETECUSTOMGROUP = "api/customgroups/organisation/{organisationId}/customgroup/{customGroupId}";

			public const string ADDCUSTOMGROUPMEMBERS =
				"api/customgroups/organisation/{organisationId}/customgroup/{customGroupId}/members/entitytype/{entityType}";

			public const string DELETECUSTOMGROUPMEMBERS =
				"api/customgroups/organisation/{organisationId}/customgroup/{customGroupId}/members/entitytype/{entityType}";

			public const string GETCUSTOMGROUPSFORASSET = "api/customgroups/organisation/{organisationId}/asset/{assetId}";
			public const string GETCUSTOMGROUPSFORDRIVER = "api/customgroups/organisation/{organisationId}/driver/{driverId}";

		}

		//MiX.Integrate.Api.Controllers.DeviceCommandsController
		public class DeviceCommandsController
		{
			public const string SENDPOSITIONREQUESTMESSAGE = "api/devicecommands/group/{groupId}/asset/{assetId}/sendpositionrequestmessage";

			public const string SENDRELAYCOMMAND =
				"api/devicecommands/group/{groupId}/asset/{assetId}/sendrelaycommand/relayDrive/{relayDrive}/relayState/{relayState}";

			public const string SENDTRACKINGREQUEST =
				"api/devicecommands/group/{groupId}/asset/{assetId}/sendtrackingrequest/intervalSeconds/{intervalSeconds}/durationSeconds/{durationSeconds}";

			public const string SENDSTOPTRACKINGREQUEST = "api/devicecommands/group/{groupId}/asset/{assetId}/sendstoptrackingrequest";

			public const string SENDPROGRESSIVESHUTDOWNCOMMAND =
				"api/devicecommands/group/{groupId}/asset/{assetId}/sendprogressiveshutdowncommand/relayDrive/{relayDrive}";

			public const string SENDDISARMUNITMESSAGE = "api/devicecommands/group/{groupId}/asset/{assetId}/senddisarmunitmessage";
			public const string SENDFREETEXTMESSAGE = "api/devicecommands/group/{groupId}/asset/{assetId}/sendfreetextmessage";

			public const string SENDSETACRONYMCOMMAND =
				"api/devicecommands/group/{groupId}/asset/{assetId}/sendsetacronymcommand/params/{param1}/{param2}/{param3}";
		}

		//MiX.Integrate.Api.Controllers.DeviceConfigurationController
		public class DeviceConfigController
		{
			public const string GETCONNECTEDPERIPHERALSFORASSETS = "api/deviceconfiguration/group/{groupId}/assets/connectedperipherals";
			public const string GETCAMERASETTINGS = "api/deviceconfiguration/group/{groupId}/assets/camerasettings";
			public const string GETCONFIGURATIONSTATE = "api/deviceconfiguration/group/{groupId}/assets/configurationstate";
			public const string GETCOMMUNICATIONSETTINGS = "api/deviceconfiguration/group/{groupId}/assets/communicationsettings";
			public const string GETDEVICETYPESBYGROUPID = "api/deviceconfiguration/group/{groupId}/assets/mobiledevicetypes";
			public const string GETCONFIGURATIONSBYASSETIDS = "api/deviceconfiguration/assets";
			public const string GETCONFIGURATIONSBYGROUPID = "api/deviceconfiguration/organisation/{groupId}";
		}

		//MiX.Integrate.Api.Controllers.DriverLicenceController
		public class DriverLicenceController
		{
			public const string GETDRIVERLICENCESFORGROUP = "api/driverlicence/group/{groupId}";
			public const string GETDRIVERLICENCES = "api/driverlicence/organisation/{organisationId}/driver/{driverId}";
			public const string GETDRIVERLICENCECATEGORIESFORORGANISATION = "api/driverlicence/organisation/{organisationId}/licencecategories";

			public const string GETDRIVERLICENCECATEGORIES =
				"api/driverlicence/organisation/{organisationId}/driver/{driverId}/licencecategories";

			public const string GETDRIVERLICENCE =
				"api/driverlicence/organisation/{organisationId}/driver/{driverId}/licencecategory/{licenceCategoryId}";

			public const string ADDDRIVERLICENCE = "api/driverlicence/organisation/{organisationId}";
			public const string UPDATEDRIVERLICENCE = "api/driverlicence/organisation/{organisationId}";

			public const string DELETEDRIVERLICENCE =
				"api/driverlicence/organisation/{organisationId}/driver/{driverId}/licencecategory/{licenceCategoryId}";
		}

		//MiX.Integrate.Api.Controllers.DriverCertificationController
		public class DriverCertificationController
		{
			public const string GETDRIVERCERTIFICATIONSFORGROUP = "api/drivercertification/group/{groupId}";
			public const string GETDRIVERCERTIFICATIONS = "api/drivercertification/organisation/{organisationId}/driver/{driverId}";

			public const string GETDRIVERCERTIFICATIONTYPESFORORGANISATION =
				"api/drivercertification/organisation/{organisationId}/certificationcategories";

			public const string GETDRIVERCERTIFICATIONTYPES =
				"api/drivercertification/organisation/{organisationId}/driver/{driverId}/certificationcategories";

			public const string GETDRIVERCERTIFICATION =
				"api/drivercertification/organisation/{organisationId}/driver/{driverId}/certificationtypeid/{certificationTypeId}";

			public const string ADDDRIVERCERTIFICATION = "api/drivercertification/organisation/{organisationId}";
			public const string UPDATEDRIVERCERTIFICATION = "api/drivercertification/organisation/{organisationId}";

			public const string DELETEDRIVERCERTIFICATION =
				"api/drivercertification/organisation/{organisationId}/driver/{driverId}/certificationtypeid/{certificationTypeId}";
		}

		//MiX.Integrate.Api.Controllers.DriversController
		public class DriversController
		{
			public const string GETDRIVER = "api/drivers/group/{groupId}/driver/{driverId}";
			public const string UPDATEDRIVER = "api/drivers";
			public const string UPDATEDRIVEREXTENTEDID = "api/drivers/extentedid";
			public const string ADDDRIVER = "api/drivers";
			public const string GETALLDRIVERS = "api/drivers/organisation/{organisationId}";
			public const string GETGROUPDRIVERS = "api/drivers/group/{groupId}";
		}

		//MiX.Integrate.Api.Controllers.DtcController
		public class DtcController
		{
			public const string GETFAULTEDASSETSBYGROUP = "api/dtc/faultedassets/{groupId}";
			public const string GETFAULTSFORASSETS = "api/dtc/faults/assets";
			public const string GETDTCMESSAGEHISTORYFORASSET = "api/dtc/messages/{assetId}/{from}/{to}";
		}

		//MiX.Integrate.Api EventsController
		public class EventsController
		{
			public const string GETLATESTFORGROUPS = "api/events/groups/latest/entitytype/{entityType}/{quantity}";
			public const string GETRANGEFORGROUPS = "api/events/groups/entitytype/{entityType}/from/{from}/to/{to}";
			public const string GETSINCEFORGROUPS = "api/events/groups/since/entitytype/{entityType}/{since}";

			public const string GETCREATEDSINCEFORGROUPSASYNC =
				"api/events/groups/createdsince/entitytype/{entityType}/sincetoken/{sinceToken}/quantity/{quantity}";

			public const string GETLATESTFORASSETS = "api/events/assets/latest/{quantity}";
			public const string GETRANGEFORASSETS = "api/events/assets/from/{from}/to/{to}";
			public const string GETSINCEFORASSETS = "api/events/assets/since/{since}/quantity/{quantity}";
			public const string GETCREATEDSINCEFORASSETSASYNC = "api/events/assets/createdsince/sincetoken/{sinceToken}/quantity/{quantity}";

			public const string GETLATESTFORDRIVERS = "api/events/drivers/latest/{quantity}";
			public const string GETRANGEFORDRIVERS = "api/events/drivers/from/{from}/to/{to}";
			public const string GETSINCEFORDRIVERS = "api/events/drivers/since/{since}/quantity/{quantity}";
			public const string GETCREATEDSINCEFORDRIVERSASYNC = "api/events/drivers/createdsince/sincetoken/{sinceToken}/quantity/{quantity}";

			public const string GETCREATEDSINCEFORORGANISATION =
				"api/events/groups/createdsince/organisation/{organisationId}/sincetoken/{sinceToken}/quantity/{quantity}";

			public const string GETMEDIAURLS = "api/events/organisation/{organisationId}/urls";

			public const string GETDEMTEVENTAMENDMENTS = "api/events/groups/amended/{organisationId}/from/{from}/to/{to}";

		}

		//MiX.Integrate.Api.Controllers.FuelController
		public class FuelController
		{
			public const string GETFUELBYDATERANGEFORGROUP = "api/fueltransactions/organisation/{organisationId}/from/{from}/to/{to}";
			public const string ADDFUELTRANSACTIONS = "api/fueltransactions/organisation/{organisationId}";
		}

		//MiX.Integrate.Api.Controllers.GeoDataController
		public class GeoDataController
		{
			public const string GETASSETMOVEMENTSFORGROUP = "api/geodata/assetmovements/{groupId}/{from}/{to}";
		}

		//MiX.Integrate.Api.GroupsController
		public class GroupsController
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

			public const string GETORGANISATIONSITESWITHLEGACYID = "api/organisationgroups/siteswithlegacyid/{organisationId}";
		}

		//MiX.Integrate.Api.Controllers.HosDataController
		public class HosDataController
		{
			public const string GETHOSEVENTDATA = "api/ghos/events/from/{from}/to/{to}";
			public const string GETHOSEVENTDATASINCE = "api/ghos/events/since/{sinceToken}";
			public const string GETHOSEVENTDATASUMMARY = "api/ghos/events/from/{from}/to/{to}/summary";
			public const string GETHOSVIOLATIONS = "api/ghos/violations/driver/{driverId}/from/{from}/to/{to}";
			public const string GETHOSAVAILABLEHOURS = "api/ghos/availablehours/driver/{driverId}/{displayHiddenTimeTypes}";
			public const string GETHOSAVAILABLEHOURSMULTIPLE = "api/ghos/availablehours/drivers/{displayHiddenTimeTypes}";
			public const string GETPREVIOUSEVENT = "api/ghos/previousevent/driver/{driverId}/eventtype/{eventTypeId}/{timeStamp}";
			public const string GETWORKSTATESTATUSSOURCETYPES = "api/ghos/workstatestatussourcetypes";
			public const string GETRULESETSUMMARIES = "api/ghos/ruleset/{organisationId}/summaries";
			public const string GETHOSDRIVERINFOLISTBYORGID = "api/ghos/driver/list/{organisationId}/resolveExtendedInfo/{resolveExtendedInfo}";
			public const string GETHOSWORKSTATEPERREGION = "api/ghos/workstateperregion/region/{region}";
			public const string GETHOSEVENTTYPECATEGORIES = "api/ghos/eventtypecategories";
			public const string GETHOSDRIVERAPPROVERS = "api/ghos/driverapprovers/driver/{driverId}/isSelectedOnly/{isSelectedOnly}";
			public const string GETHOSEVENTSTARTDATETIMEBYHOUR = "api/ghos/events/startdatetime/changedsince/{sinceToken}";
			public const string GETDRIVERVIOLATIONSBYLISTOFDRIVERIDSINDATERANGE = "api/ghos/violations/drivers/from/{from}/to/{to}";
		}


		//MiX.Integrate.Api.Controllers.InfoHubActionsController
		public class InfoHubActionsController
		{
			public const string GETACTIONSCREATEDSINCE =
				"api/infohubactions/{organisationId}/createdsince/{sinceToken}/quantity/{quantity}";

		}

		//MiX.Integrate.Api.Controllers.JourneysController
		public class JourneysController
		{
			public const string ADDJOURNEY = "api/journeys/";
			public const string COMPLETEJOURNEY = "api/journeys/{journeyId}/complete";
			public const string BULKJOURNEYADD = "api/journeys/bulk";
			public const string BULKJOURNEYADDRESULT = "api/journeys/bulkResult/{groupId}/correlationId/{correlationId}";
			public const string GETJOURNEY = "api/journeys/{journeyId}";
			public const string GETJOURNEYIDLIST = "api/journeys/getJourneyIdList/{groupId}/startDate/{startDate}/endDate/{endDate}";
			public const string GETJOURNEYIDSTATUSLIST = "api/journeys/getJourneyIdStatusList/{groupId}/startDate/{startDate}/endDate/{endDate}";
			public const string GETJOURNEYROUTE = "api/journeys/routes/{groupId}";
			public const string GETJOURNEYPROGRESS = "api/journeys/progress/{journeyId}";
			public const string GETJOURNEYROUTEDATA = "api/journeys/routedata/{journeyId}";
			public const string GETJOURNEYINPROGRESSCURRENTSTATUS = "api/journeys/inprogress/currentstatus/{groupId}";
			public const string GETJOURNEYROUTELOCATIONSASYNC = "api/journeys/getJourneyRouteLocations/{journeyId}";
			public const string REMOVEJOURNEYASYNC = "api/journeys/removeJourney/{journeyId}";
			public const string CANCELJOURNEYASYNC = "api/journeys/cancelJourney/{journeyId}";
			public const string UPDATEJOURNEYDEPARTUREDATEASYNC = "api/journeys/updateJourneyDepartureDate/{journeyId}/{departureDateTime}";
			public const string UPDATEJOURNEYASSETDRIVERSASYNC = "api/journeys/updateJourneyAssetDrivers/{journeyId}";
			public const string GETJOURNEYASSETSANDDRIVERSASYNC = "api/journeys/getJourneyAssetsAndDrivers/{journeyId}";
			public const string SUBMITJOURNEY = "api/journeys/submitJourneyAsync/{journeyId}";
			public const string SUBMITBULKJOURNEY = "api/journeys/submitBulkJourneys";
			public const string GETJOURNEYASSETPASSENGERASYNC = "api/journeys/getJourneyAssetPassenger/{journeyId}";
			public const string UPDATEJOURNEYASSETPASSENGERASYNC = "api/journeys/updateJourneyAssetPassenger/{journeyId}";
			public const string REMOVEJOURNEYASSETPASSENGERASYNC = "api/journeys/removeJourneyAssetPassenger/{journeyId}";
			public const string GETJOURNEYCURRENTIDLIST = "api/journeys/getJourneyCurrentIdList";
			public const string GETBULKJOURNEYPROGRESSASYNC = "api/journeys/getBulkJourneyProgress";
			public const string GETJOURNEYSTATESBATCHED = "api/journeys/{organisationId}/currentState";
		}

		public class CustomersController
		{
			public const string CUSTOMER_LIST_ADD_UPDATE = "api/customers/{organisationId}";
			public const string CUSTOMER_GET_DELETE = "api/customers/{organisationId}/{customerId}";

			public const string DELIVERYPOINT_LIST_ADD_UPDATE= "api/customers/{organisationId}/{customerId}/deliverypoints";
			public const string DELIVERYPOINT_GET_DELETE = "api/customers/{organisationId}/{customerId}/deliverypoints/{deliveryPointId}";
		}

		//MiX.Integrate.Api.Controllers.LibraryEventsController
		public class LibraryEventsController
		{
			public const string GETALLLIBRARYEVENTS = "api/libraryevents/organisation/{organisationId}";
		}

		//MiX.Integrate.Api.Controllers.LocationsController
		public class LocationsController
		{
			public const string GETALL = "api/locations/group/{groupId}";
			public const string GET = "api/locations/{locationId}";
			public const string ADD = "api/locations/group/{groupId}";
			public const string UPDATE = "api/locations/group/{groupId}";
			public const string DELETE = "api/locations/group/{groupId}/location/{locationId}";
			public const string INRANGE = "api/locations/group/{groupId}/inrange/{meters}";
			public const string NEAREST = "api/locations/group/{groupId}/nearest";
			public const string CHANGEDSINCE = "api/locations/organisation/{organisationId}/changedsince/since/{since}";
			public const string MIGRATELEGACYIDS = "api/locations/organisation/{organisationId}/migratelegacyids";

		}

		//MiX.Integrate.Api.Controllers.LoggableData
		public class LoggableDataController
		{
			public const string GETLOGGABLEDATAFORASSETSBYDATERANGE = "api/loggabledata/from/{from}/to/{to}";
			public const string GETROVIMESSAGESFORASSETSSINCE = "api/loggabledata/rovimessages/since/{since}";
			public const string GETROVIMESSAGESFORASSETSBYDATERANGE = "api/loggabledata/rovimessages/from/{from}/to/{to}";
			public const string GETROVIMESSAGESFORASSETSLATEST = "api/loggabledata/rovimessageslatest/count/{count}";
		}

		//MiX.Integrate.Api.Controllers.MessagesController
		public class MessagesController
		{
			public const string GETSINCEID = "api/messages/organisation/{organisationId}/sincemessageid/{messageId}/maxrecords/{maxRecords}";
			public const string GET = "api/messages/organisation/{organisationId}/messageid/{messageId}";
			public const string GETMESSAGESTATEHISTORY = "api/messages/organisation/{organisationId}/messageid/{messageId}/messagestatehistory";
			public const string GETMESSAGESTATE = "api/messages/organisation/{organisationId}/messageid/{messageId}/messagestate";
			public const string SENDFREETEXTMESSAGE = "api/messages/organisation/{organisationId}/sendfreetextmessage";
		}

		//MiX.Integrate.Api.Controllers.PermissionController
		public class PermissionController
		{
			public const string REFRESHPERMISSIONS = "api/permissions/account/refresh";
		}

		//MiX.Integrate.Api.PositionsController
		public class PositionsController
		{
			public const string GETLATESTFORGROUPS = "api/positions/groups/latest/{quantity}";
			public const string GETRANGEFORGROUPS = "api/positions/groups/from/{from}/to/{to}";
			public const string GETLATESTFORASSETS = "api/positions/assets/latest/{quantity}";
			public const string GETRANGEFORASSETS = "api/positions/assets/from/{from}/to/{to}";
			public const string GETSINCEFORASSETS = "api/positions/assets/since/{since}";
			public const string GETRANGEFORDRIVERS = "api/positions/drivers/from/{from}/to/{to}";
			public const string GETCREATEDSINCEFORASSETS = "api/positions/assets/createdsince/sincetoken/{sinceToken}/quantity/{quantity}";
			public const string GETCREATEDSINCEFORGROUPSASYNC = "api/positions/groups/createdsince/entitytype/{entityType}/sincetoken/{sinceToken}/quantity/{quantity}";
			public const string GETCREATEDSINCEFORORGANISATION = "api/positions/groups/createdsince/organisation/{organisationId}/sincetoken/{sinceToken}/quantity/{quantity}";
		}

		//MiX.Integrate.Api RemindersController
		public class RemindersController
		{
			public const string GETASSETREMINDERS = "api/reminders/organisation/{organisationId}/asset/{assetId}";
			public const string ASSETSERVICEREMINDERS = "api/reminders/organisation/{organisationId}/asset/{assetId}/service";
			public const string ASSETLICENCEREMINDERS = "api/reminders/organisation/{organisationId}/asset/{assetId}/licence";
			public const string ASSETROADWORTHYREMINDERS = "api/reminders/organisation/{organisationId}/asset/{assetId}/roadworthy-certificate";
			public const string GETASSETSERVICEREMINDERSFORGROUP = "api/reminders/group/{groupId}/service";
			public const string GETASSETLICENCEREMINDERSFORGROUP = "api/reminders/group/{groupId}/licence";
			public const string GETASSETROADWORTHYREMINDERSFORGROUP = "api/reminders/group/{groupId}/roadworthy-certificate";
		}

		//MiX.Integrate.Api.Controllers.ScoringController
		public class ScoringController
		{
			public const string GETFLEXIBLEDRIVERSORECARD = "api/scoring/scorecard_flexibledriver";
			public const string GETFLEXIBLERAGSCORINGREPORT = "api/scoring/scorecard_flexiblerag";
			public const string GETFLEXIBLESTANDARDSCORINGREPORT = "api/scoring/scorecard_flexiblestandard";
		}

		//MiX.Fleet.Services.Api.TachoController
		public class TachoController
		{
			public const string GETRANGEFORASSETASYNC = "api/tachos/asset/{assetId}/range/from/{from}/to/{to}";
		}

		//MiX.Integrate.Api.Controllers.TimeEntryController
		public class TimeEntryController
		{
			public const string IMPORTAPPROVERS = "api/timeentry/approvers/organisation/{organisationId}/import";
			public const string GETSTATUSCODES = "api/timeentry/statuscodes/{organisationId}";
		}

		//MiX.Integrate.Api.TripsController
		public class TripsController
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

			public const string GETDRIVERSCORES = "api/trips/driverscore/standard/from/{from}/to/{to}";
			public const string GETCREATEDSINCEFORORGANISATION = "api/trips/groups/createdsince/organisation/{organisationId}/sincetoken/{sinceToken}/quantity/{quantity}";

			public const string UPDATETRIPCLASSIFICATION = "api/trips/{tripId}/classification";
			public const string UPDATETRIPCLASSIFICATIONCOMMENT = "api/trips/{tripId}/classification/comment";

			public const string GETTRIPRIBASMETRICSBYDATERANGEFORDRIVERS = "api/trips/drivers/from/{from}/to/{to}/ribasmetrics";

			public const string GETDEMTTRIPAMENDMENTS = "api/trips/groups/amended/{organisationId}/from/{from}/to/{to}";
		}

	}
}