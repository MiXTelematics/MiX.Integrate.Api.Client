using MiX.Integrate.API.Client.Base;
using MiX.Integrate.Shared.Entities.Carriers;
using MiX.Integrate.Shared.Entities.HosData;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiX.Integrate.API.Client
{
	public interface IHosDataClient : IBaseClient
	{
		CreatedSinceResult<HosEvent> GetHosEventData(ParameterEntityType entityTypeId, List<long> entityIds, List<byte> eventTypeIds, DateTime fromDateTime, DateTime toDateTime);
		Task<CreatedSinceResult<HosEvent>> GetHosEventDataAsync(ParameterEntityType entityTypeId, List<long> entityIds, List<byte> eventTypeIds, DateTime fromDateTime, DateTime toDateTime);

		CreatedSinceResult<HosEvent> GetHosEventDataSince(ParameterEntityType entityTypeId, List<long> entityIds, List<byte> eventTypeIds, string sinceToken);
		Task<CreatedSinceResult<HosEvent>> GetHosEventDataSinceAsync(ParameterEntityType entityTypeId, List<long> entityIds, List<byte> eventTypeIds, string sinceToken);

		List<HosEventDriverSummary> GetHosEventDataSummary(ParameterEntityType entityTypeId, List<long> entityIds, List<byte> eventTypeIds, DateTime fromDateTime, DateTime toDateTime);
		Task<List<HosEventDriverSummary>> GetHosEventDataSummaryAsync(ParameterEntityType entityTypeId, List<long> entityIds, List<byte> eventTypeIds, DateTime fromDateTime, DateTime toDateTime);

		List<HosViolation> GetHosViolations(long driverId, DateTime fromDateTime, DateTime toDateTime);
		Task<List<HosViolation>> GetHosViolationsAsync(long driverId, DateTime fromDateTime, DateTime toDateTime);

		List<HosViolation> GetDriverViolationsByListOfDriverIdsInDateRange(ParameterEntityType entityTypeId, List<long> entityIds, DateTime fromDateTime, DateTime toDateTime);
		Task<List<HosViolation>> GetDriverViolationsByListOfDriverIdsInDateRangeAsync(ParameterEntityType entityTypeId, List<long> entityIds, DateTime fromDateTime, DateTime toDateTime);

		HosAvailableHours GetHosAvailableHours(long driverId, bool displayHiddenTimeTypes = false);
		Task<HosAvailableHours> GetHosAvailableHoursAsync(long driverId, bool displayHiddenTimeTypes = false);

		List<HosDriverAvailableHours> GetHosAvailableHours(List<long> driverIds, bool displayHiddenTimeTypes = false);
		Task<List<HosDriverAvailableHours>> GetHosAvailableHoursAsync(List<long> driverIds, bool displayHiddenTimeTypes = false);

		HosEvent GetPreviousEvent(long driverId, byte eventTypeId, DateTime timeStamp);
		Task<HosEvent> GetPreviousEventAsync(long driverId, byte eventTypeId, DateTime timeStamp);

		Dictionary<byte, string> GetWorkStateStatusSourceTypes();
		Task<Dictionary<byte, string>> GetWorkStateStatusSourceTypesAsync();

		List<RuleSetSummary> GetRuleSetSummaries(long organisationGroupId);
		Task<List<RuleSetSummary>> GetRuleSetSummariesAsync(long organisationGroupId);

		List<HosDriverTimeApprovers> GetHosDriverApprovers(long driverId, bool isSelectedOnly);
		Task<List<HosDriverTimeApprovers>> GetHosDriverApproversAsync(long driverId, bool isSelectedOnly);

		List<HosEventTypeCategories> GetHosEventTypeCategories();
		Task<List<HosEventTypeCategories>> GetHosEventTypeCategoriesAsync();

		List<HosDriverInfoSummary> GetHosDriverInfoListByOrgId(long organisationGroupId, bool resolveExtendedInfo = true);
		Task<List<HosDriverInfoSummary>> GetHosDriverInfoListByOrgIdAsync(long organisationGroupId, bool resolveExtendedInfo = true);

		List<HosEventStartDateTimeByHourChangedSince> GetHosEventStartDateTimeByHourChangedSince(ParameterEntityType entityTypeId, List<long> entityIds, List<byte> eventTypeIds, string sinceToken);
		Task<List<HosEventStartDateTimeByHourChangedSince>> GetHosEventStartDateTimeByHourChangedSinceAsync(ParameterEntityType entityTypeId, List<long> entityIds, List<byte> eventTypeIds, string sinceToken);
	}
}