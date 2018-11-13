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

		HosAvailableHours GetHosAvailableHours(long driverId, bool displayHiddenTimeTypes = false);
		Task<HosAvailableHours> GetHosAvailableHoursAsync(long driverId, bool displayHiddenTimeTypes = false);

		Dictionary<byte, string> GetWorkStateStatusSourceTypes();
		Task<Dictionary<byte, string>> GetWorkStateStatusSourceTypesAsync();

		List<RuleSetSummary> GetRuleSetSummaries(long organisationGroupId);
		Task<List<RuleSetSummary>> GetRuleSetSummariesAsync(long organisationGroupId);
	}
}