using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using ProjectFirmaModels;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Api.Controllers
{
    public class PerformanceMeasuresController : ApiController
    {
        private readonly DatabaseEntities _databaseEntities = new DatabaseEntities(Tenant.ActionAgendaForPugetSound.TenantID, "ProjectFirmaDB");

        //public PerformanceMeasuresController(DatabaseEntities databaseEntities)
        //{
        //    _databaseEntities = databaseEntities;
        //}

        [Route("api/PerformanceMeasures/PostPerformanceMeasure/{apiKey}")]
        [HttpPost]
        public IHttpActionResult PostPerformanceMeasure(string apiKey, [FromBody] PerformanceMeasureDto performanceMeasureDto)
        {
            var performanceMeasureType = MapPerformanceMeasureTypeNameToPerformanceMeasureType(performanceMeasureDto.PerformanceMeasureTypeName);
            var performanceMeasureDataSourceType = MapPerformanceMeasureDataSourceTypeNameToPerformanceMeasureDataSourceType(performanceMeasureDto.PerformanceMeasureDataSourceTypeName);
            var measurementUnitType = MapMeasurementUnitTypeNameToMeasurementUnitType(performanceMeasureDto.MeasurementUnitTypeName);
            if (performanceMeasureType == null)
            {
                return BadRequest($"Invalid Performance Measure Type: {performanceMeasureDto.PerformanceMeasureTypeName}");
            }
            if (performanceMeasureDataSourceType == null)
            {
                return BadRequest($"Invalid Performance Measure Data Source Type: {performanceMeasureDto.PerformanceMeasureDataSourceTypeName}");
            }
            if (measurementUnitType == null)
            {
                return BadRequest($"Invalid Measurement Unit: {performanceMeasureDto.MeasurementUnitTypeName}");
            }
            var performanceMeasure = new PerformanceMeasure(performanceMeasureDto.PerformanceMeasureDisplayName,
                measurementUnitType.MeasurementUnitTypeID, performanceMeasureType.PerformanceMeasureTypeID,
                performanceMeasureDto.SwapChartAxes,
                performanceMeasureDto.IsSummable, performanceMeasureDataSourceType.PerformanceMeasureDataSourceTypeID);
            performanceMeasure.CriticalDefinitions = performanceMeasureDto.CriticalDefinitions;
            performanceMeasure.PerformanceMeasureDefinition = performanceMeasureDto.PerformanceMeasureDefinition;
            performanceMeasure.ProjectReporting = performanceMeasureDto.ProjectReporting;

            var tenantID = Tenant.ActionAgendaForPugetSound.TenantID;
            foreach (var performanceMeasureSubcategoryDto in performanceMeasureDto.PerformanceMeasureSubcategories)
            {
                var googleChartType = MapGoogleChartTypeNameToGoogleChartType(performanceMeasureSubcategoryDto.GoogleChartTypeName);
                if (googleChartType == null)
                {
                    return BadRequest($"Invalid Google Chart Type '{performanceMeasureSubcategoryDto.GoogleChartTypeName}' for Subcategory '{performanceMeasureSubcategoryDto.PerformanceMeasureSubcategoryName}'");
                }
                var performanceMeasureSubcategory = new PerformanceMeasureSubcategory(performanceMeasure, performanceMeasureSubcategoryDto.PerformanceMeasureSubcategoryName)
                {
                    ChartConfigurationJson = performanceMeasureSubcategoryDto.ChartConfigurationJson,
                    GoogleChartTypeID = googleChartType.GoogleChartTypeID,
                    TenantID = tenantID
                };
                foreach (var performanceMeasureSubcategoryOptionDto in performanceMeasureSubcategoryDto.PerformanceMeasureSubcategoryOptions)
                {
                    var performanceMeasureSubcategoryOption = new PerformanceMeasureSubcategoryOption(performanceMeasureSubcategory, performanceMeasureSubcategoryOptionDto.PerformanceMeasureSubcategoryOptionName, false)
                    {                        
                        TenantID = tenantID
                    };
                }
            }
            _databaseEntities.AllPerformanceMeasures.Add(performanceMeasure);
            _databaseEntities.SaveChangesWithNoAuditing(tenantID);
            var performanceMeasureReloaded = new PerformanceMeasureDto(performanceMeasure);
            return Ok(performanceMeasureReloaded);
        }

        private static MeasurementUnitType MapMeasurementUnitTypeNameToMeasurementUnitType(string measurementUnitTypeName)
        {
            return MeasurementUnitType.All.SingleOrDefault(x => x.MeasurementUnitTypeDisplayName.Equals(measurementUnitTypeName, StringComparison.InvariantCultureIgnoreCase));
        }

        private static PerformanceMeasureType MapPerformanceMeasureTypeNameToPerformanceMeasureType(string performanceMeasureTypeName)
        {
            return PerformanceMeasureType.All.SingleOrDefault(x => x.PerformanceMeasureTypeDisplayName.Equals(performanceMeasureTypeName, StringComparison.InvariantCultureIgnoreCase));
        }

        private static PerformanceMeasureDataSourceType MapPerformanceMeasureDataSourceTypeNameToPerformanceMeasureDataSourceType(string performanceMeasureDataSourceTypeName)
        {
            return PerformanceMeasureDataSourceType.All.SingleOrDefault(x => x.PerformanceMeasureDataSourceTypeDisplayName.Equals(performanceMeasureDataSourceTypeName, StringComparison.InvariantCultureIgnoreCase));
        }

        private static GoogleChartType MapGoogleChartTypeNameToGoogleChartType(string googleChartTypeName)
        {
            return GoogleChartType.All.SingleOrDefault(x => x.GoogleChartTypeDisplayName.Equals(googleChartTypeName, StringComparison.InvariantCultureIgnoreCase));
        }

        [Route("api/PerformanceMeasures/UpdatePerformanceMeasure/{apiKey}")]
        [HttpPut]
        public IHttpActionResult UpdatePerformanceMeasure(string apiKey, [FromBody] PerformanceMeasureDto performanceMeasureDto)
        {
            var performanceMeasure = _databaseEntities.PerformanceMeasures.SingleOrDefault(x => x.PerformanceMeasureID == performanceMeasureDto.PerformanceMeasureID);
            if (performanceMeasure == null)
            {
                var message = $"Performance Measure with ID = {performanceMeasureDto.PerformanceMeasureID} not found";
                return NotFound();
            }

            var performanceMeasureType = MapPerformanceMeasureTypeNameToPerformanceMeasureType(performanceMeasureDto.PerformanceMeasureTypeName);
            var performanceMeasureDataSourceType = MapPerformanceMeasureDataSourceTypeNameToPerformanceMeasureDataSourceType(performanceMeasureDto.PerformanceMeasureDataSourceTypeName);
            var measurementUnitType = MapMeasurementUnitTypeNameToMeasurementUnitType(performanceMeasureDto.MeasurementUnitTypeName);
            if (performanceMeasureType == null)
            {
                return BadRequest($"Invalid Performance Measure Type: {performanceMeasureDto.PerformanceMeasureTypeName}");
            }
            if (performanceMeasureDataSourceType == null)
            {
                return BadRequest($"Invalid Performance Measure Data Source Type: {performanceMeasureDto.PerformanceMeasureDataSourceTypeName}");
            }
            if (measurementUnitType == null)
            {
                return BadRequest($"Invalid Measurement Unit: {performanceMeasureDto.MeasurementUnitTypeName}");
            }

            performanceMeasure.PerformanceMeasureDisplayName = performanceMeasureDto.PerformanceMeasureDisplayName;
            performanceMeasure.CriticalDefinitions = performanceMeasureDto.CriticalDefinitions;
            performanceMeasure.PerformanceMeasureDefinition = performanceMeasureDto.PerformanceMeasureDefinition;
            performanceMeasure.ProjectReporting = performanceMeasureDto.ProjectReporting;
            performanceMeasure.MeasurementUnitTypeID = measurementUnitType.MeasurementUnitTypeID;
            performanceMeasure.PerformanceMeasureTypeID = performanceMeasureType.PerformanceMeasureTypeID;
            performanceMeasure.PerformanceMeasureDataSourceTypeID = performanceMeasureDataSourceType.PerformanceMeasureDataSourceTypeID;
            performanceMeasure.IsSummable = performanceMeasureDto.IsSummable;
            performanceMeasure.Importance = performanceMeasureDto.Importance;
            performanceMeasure.AdditionalInformation = performanceMeasureDto.AdditionalInformation;
            _databaseEntities.SaveChangesWithNoAuditing(Tenant.ActionAgendaForPugetSound.TenantID);
            var performanceMeasureReloaded = new PerformanceMeasureDto(performanceMeasure);
            return Ok(performanceMeasureReloaded);
        }

        [Route("api/PerformanceMeasures/UpdatePerformanceMeasureCriticalDefinitions/{apiKey}")]
        [HttpPut]
        public IHttpActionResult UpdatePerformanceMeasureCriticalDefinitions(string apiKey, [FromBody] PerformanceMeasureCriticalDefinitionsDto performanceMeasureDto)
        {
            var performanceMeasure = _databaseEntities.PerformanceMeasures.SingleOrDefault(x => x.PerformanceMeasureID == performanceMeasureDto.PerformanceMeasureID);
            if (performanceMeasure == null)
            {
                var message = $"Performance Measure with ID = {performanceMeasureDto.PerformanceMeasureID} not found";
                return NotFound();
            }

            performanceMeasure.CriticalDefinitions = performanceMeasureDto.CriticalDefinitions;
            _databaseEntities.SaveChangesWithNoAuditing(Tenant.ActionAgendaForPugetSound.TenantID);
            var performanceMeasureReloaded = new PerformanceMeasureSimpleDto(performanceMeasure);
            return Ok(performanceMeasureReloaded);
        }

        [Route("api/PerformanceMeasures/UpdatePerformanceMeasureImportance/{apiKey}")]
        [HttpPut]
        public IHttpActionResult UpdatePerformanceMeasureImportance(string apiKey, [FromBody] PerformanceMeasureImportanceDto performanceMeasureDto)
        {
            var performanceMeasure = _databaseEntities.PerformanceMeasures.SingleOrDefault(x => x.PerformanceMeasureID == performanceMeasureDto.PerformanceMeasureID);
            if (performanceMeasure == null)
            {
                var message = $"Performance Measure with ID = {performanceMeasureDto.PerformanceMeasureID} not found";
                return NotFound();
            }

            performanceMeasure.Importance = performanceMeasureDto.Importance;
            _databaseEntities.SaveChangesWithNoAuditing(Tenant.ActionAgendaForPugetSound.TenantID);
            var performanceMeasureReloaded = new PerformanceMeasureSimpleDto(performanceMeasure);
            return Ok(performanceMeasureReloaded);
        }

        [Route("api/PerformanceMeasures/UpdatePerformanceMeasureAdditionalInformation/{apiKey}")]
        [HttpPut]
        public IHttpActionResult UpdatePerformanceMeasureAdditionalInformation(string apiKey, [FromBody] PerformanceMeasureAdditionalInformationDto performanceMeasureDto)
        {
            var performanceMeasure = _databaseEntities.PerformanceMeasures.SingleOrDefault(x => x.PerformanceMeasureID == performanceMeasureDto.PerformanceMeasureID);
            if (performanceMeasure == null)
            {
                var message = $"Performance Measure with ID = {performanceMeasureDto.PerformanceMeasureID} not found";
                return NotFound();
            }

            performanceMeasure.AdditionalInformation = performanceMeasureDto.AdditionalInformation;
            _databaseEntities.SaveChangesWithNoAuditing(Tenant.ActionAgendaForPugetSound.TenantID);
            var performanceMeasureReloaded = new PerformanceMeasureSimpleDto(performanceMeasure);
            return Ok(performanceMeasureReloaded);
        }

        [Route("api/PerformanceMeasures/UpdatePerformanceMeasureProjectReporting/{apiKey}")]
        [HttpPut]
        public IHttpActionResult UpdatePerformanceMeasureProjectReporting(string apiKey, [FromBody] PerformanceMeasureProjectReportingDto performanceMeasureDto)
        {
            var performanceMeasure = _databaseEntities.PerformanceMeasures.SingleOrDefault(x => x.PerformanceMeasureID == performanceMeasureDto.PerformanceMeasureID);
            if (performanceMeasure == null)
            {
                var message = $"Performance Measure with ID = {performanceMeasureDto.PerformanceMeasureID} not found";
                return NotFound();
            }

            performanceMeasure.ProjectReporting = performanceMeasureDto.ProjectReporting;
            _databaseEntities.SaveChangesWithNoAuditing(Tenant.ActionAgendaForPugetSound.TenantID);
            var performanceMeasureReloaded = new PerformanceMeasureSimpleDto(performanceMeasure);
            return Ok(performanceMeasureReloaded);
        }

        [Route("api/PerformanceMeasures/UpdatePerformanceMeasureSubcategories/{apiKey}")]
        [HttpPut]
        public IHttpActionResult UpdatePerformanceMeasureSubcategories(string apiKey, [FromBody] PerformanceMeasureDto performanceMeasureDto)
        {
            var performanceMeasure = _databaseEntities.PerformanceMeasures.SingleOrDefault(x => x.PerformanceMeasureID == performanceMeasureDto.PerformanceMeasureID);
            if (performanceMeasure == null)
            {
                var message = $"Performance Measure with ID = {performanceMeasureDto.PerformanceMeasureID} not found";
                return NotFound();
            }
            var performanceMeasureSubcategoryDtos = performanceMeasureDto.PerformanceMeasureSubcategories;
            var performanceMeasureSubcategoryGoogleChartTypes = performanceMeasureSubcategoryDtos.ToDictionary(x => new {x.PerformanceMeasureSubcategoryName, x.GoogleChartTypeName },
                x => MapGoogleChartTypeNameToGoogleChartType(x.GoogleChartTypeName));
            if (performanceMeasureSubcategoryGoogleChartTypes.Values.Any(x => x == null))
            {
                var errors =
                performanceMeasureSubcategoryGoogleChartTypes.Where(x => x.Value == null).Select(x =>
                    $"Invalid Google Chart Type '{x.Key.GoogleChartTypeName}' for Subcategory '{x.Key.PerformanceMeasureSubcategoryName}'").ToList();
                return BadRequest(string.Join("\r\n", errors));
            }

            var performanceMeasureSubcategoriesFromDatabase = _databaseEntities.AllPerformanceMeasureSubcategories.Local;
            var performanceMeasureSubcategoryOptionsFromDatabase = _databaseEntities.AllPerformanceMeasureSubcategoryOptions.Local;

            var performanceMeasureSubcategoriesToUpdate = performanceMeasureSubcategoryDtos.Select(x =>
            {
                var dummyPerformanceMeasure = new PerformanceMeasure(String.Empty, default(int), default(int), false, false, PerformanceMeasureDataSourceType.Project.PerformanceMeasureDataSourceTypeID);
                var performanceMeasureSubcategory = new PerformanceMeasureSubcategory(dummyPerformanceMeasure, x.PerformanceMeasureSubcategoryName);
                performanceMeasureSubcategory.PerformanceMeasure = performanceMeasure;
                performanceMeasureSubcategory.ChartConfigurationJson = x.ChartConfigurationJson;
                performanceMeasureSubcategory.GoogleChartTypeID = performanceMeasureSubcategoryGoogleChartTypes.Single(y => y.Key.PerformanceMeasureSubcategoryName == x.PerformanceMeasureSubcategoryName).Value
                    .GoogleChartTypeID;
                performanceMeasureSubcategory.PerformanceMeasureSubcategoryOptions =
                    x.PerformanceMeasureSubcategoryOptions.OrderBy(y => y.SortOrder).Select(
                        (y, index) =>
                            new PerformanceMeasureSubcategoryOption(performanceMeasureSubcategory, y.PerformanceMeasureSubcategoryOptionName, false)
                            {
                                SortOrder = y.SortOrder
                            }).ToList();
                return performanceMeasureSubcategory;
            }).ToList();

            var performanceMeasureSubcategoryOptionsToUpdate = performanceMeasureSubcategoriesToUpdate.SelectMany(x => x.PerformanceMeasureSubcategoryOptions).ToList();
            performanceMeasure.PerformanceMeasureSubcategories.SelectMany(x => x.PerformanceMeasureSubcategoryOptions).ToList().Merge(
                performanceMeasureSubcategoryOptionsToUpdate,
                performanceMeasureSubcategoryOptionsFromDatabase,
                (x, y) => x.PerformanceMeasureSubcategoryOptionName == y.PerformanceMeasureSubcategoryOptionName && x.PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName == y.PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName,
                (x, y) =>
                {
                    x.SortOrder = y.SortOrder;
                }, _databaseEntities);

            performanceMeasure.PerformanceMeasureSubcategories.Merge(performanceMeasureSubcategoriesToUpdate,
                performanceMeasureSubcategoriesFromDatabase,
                (x, y) => x.PerformanceMeasureSubcategoryDisplayName == y.PerformanceMeasureSubcategoryDisplayName,
                (x, y) =>
                {
                    x.ChartConfigurationJson = y.ChartConfigurationJson;
                    x.GoogleChartTypeID = y.GoogleChartTypeID;
                }, _databaseEntities);


            _databaseEntities.SaveChangesWithNoAuditing(Tenant.ActionAgendaForPugetSound.TenantID);
            var performanceMeasureReloaded = new PerformanceMeasureDto(performanceMeasure);
            return Ok(performanceMeasureReloaded);
        }

        [Route("api/PerformanceMeasures/List/{apiKey}")]
        [HttpGet]
        public IHttpActionResult Get(string apiKey)
        {
            var result = _databaseEntities.PerformanceMeasures.ToList().Select(x => new PerformanceMeasureDto(x)).ToList();
            return Ok(result);
        }

        [Route("api/PerformanceMeasures/Get/{apiKey}/{id}")]
        [HttpGet]
        public IHttpActionResult Get(string apiKey, int id)
        {
            var performanceMeasure = _databaseEntities.PerformanceMeasures.SingleOrDefault(x => x.PerformanceMeasureID == id);
            if (performanceMeasure == null)
            {
                var message = $"Performance Measure with ID = {id} not found";
                return NotFound();
            }
            var result = new PerformanceMeasureDto(performanceMeasure);
            return Ok(result);
        }

        [Route("api/PerformanceMeasures/{apiKey}/{id}/GetReportedValues")]
        [HttpGet]
        public IHttpActionResult GetReportedValues(string apiKey, int id)
        {
            var performanceMeasure = _databaseEntities.PerformanceMeasures.SingleOrDefault(x => x.PerformanceMeasureID == id);
            if (performanceMeasure == null)
            {
                var message = $"Performance Measure with ID = {id} not found";
                return NotFound();
            }

            var projects = _databaseEntities.Projects.Where(x =>
                x.ProjectStageID != ProjectStage.Proposal.ProjectStageID && x.ProjectApprovalStatusID ==
                ProjectApprovalStatus.Approved.ProjectApprovalStatusID).ToList();
            var performanceMeasureReportedValues = performanceMeasure.PerformanceMeasureDataSourceType.GetReportedPerformanceMeasureValues(performanceMeasure, projects);
            return Ok(performanceMeasureReportedValues.Select(x => new PerformanceMeasureReportedValueFromProjectFirma(x)).ToList());
        }

        [Route("api/PerformanceMeasures/{apiKey}/{id}/GetExpectedValues")]
        [HttpGet]
        public IHttpActionResult GetExpectedValues(string apiKey, int id)
        {
            var performanceMeasure = _databaseEntities.PerformanceMeasures.SingleOrDefault(x => x.PerformanceMeasureID == id);
            if (performanceMeasure == null)
            {
                var message = $"Performance Measure with ID = {id} not found";
                return NotFound();
            }
            var projects = _databaseEntities.Projects.Where(x =>
                x.ProjectStageID != ProjectStage.Proposal.ProjectStageID && x.ProjectApprovalStatusID ==
                ProjectApprovalStatus.Approved.ProjectApprovalStatusID).Select(x => x.ProjectID).ToList();

            return Ok(performanceMeasure.PerformanceMeasureExpecteds.Where(x => projects.Contains(x.ProjectID)).Select(x => new PerformanceMeasureExpectedValueFromProjectFirma(x)).ToList());
        }

        [Route("api/PerformanceMeasures/Delete/{apiKey}/{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(string apiKey, int id)
        {
            var performanceMeasure = _databaseEntities.PerformanceMeasures.SingleOrDefault(x => x.PerformanceMeasureID == id);
            if (performanceMeasure == null)
            {
                var message = $"Performance Measure with ID = {id} not found";
                return NotFound();
            }
            performanceMeasure.DeleteFull(_databaseEntities);
            _databaseEntities.SaveChangesWithNoAuditing(Tenant.ActionAgendaForPugetSound.TenantID);
            return Ok();
        }
    }
}