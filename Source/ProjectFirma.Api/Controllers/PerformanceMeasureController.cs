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

        [Route("api/PerformanceMeasures/PostPerformanceMeasure")]
        [HttpPost]
        public IHttpActionResult PostPerformanceMeasure([FromBody] PerformanceMeasureDto performanceMeasureDto)
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
                performanceMeasureDto.SwapChartAxes, performanceMeasureDto.CanCalculateTotal,
                performanceMeasureDto.IsAggregatable, performanceMeasureDataSourceType.PerformanceMeasureDataSourceTypeID);
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

        [Route("api/PerformanceMeasures/UpdatePerformanceMeasure")]
        [HttpPut]
        public IHttpActionResult UpdatePerformanceMeasure([FromBody] PerformanceMeasureDto performanceMeasureDto)
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
            performanceMeasure.IsAggregatable = performanceMeasureDto.IsAggregatable;
            _databaseEntities.SaveChangesWithNoAuditing(Tenant.ActionAgendaForPugetSound.TenantID);
            var performanceMeasureReloaded = new PerformanceMeasureDto(performanceMeasure);
            return Ok(performanceMeasureReloaded);
        }

        [Route("api/PerformanceMeasures/UpdatePerformanceMeasureSubcategories")]
        [HttpPut]
        public IHttpActionResult UpdatePerformanceMeasureSubcategories([FromBody] PerformanceMeasureDto performanceMeasureDto)
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
                var performanceMeasureSubcategory = new PerformanceMeasureSubcategory(new PerformanceMeasure(String.Empty, default(int), default(int), false, false, true, PerformanceMeasureDataSourceType.Project.PerformanceMeasureDataSourceTypeID),
                    x.PerformanceMeasureSubcategoryName);
                performanceMeasureSubcategory.PerformanceMeasure = performanceMeasure;
                performanceMeasureSubcategory.PerformanceMeasureSubcategoryID = x.PerformanceMeasureSubcategoryID;
                performanceMeasureSubcategory.PerformanceMeasureSubcategoryOptions =
                    x.PerformanceMeasureSubcategoryOptions.OrderBy(y => y.SortOrder).Select(
                        (y, index) =>
                            new PerformanceMeasureSubcategoryOption(
                                new PerformanceMeasureSubcategory(new PerformanceMeasure(String.Empty, default(int), default(int), false, false, true, PerformanceMeasureDataSourceType.Project.PerformanceMeasureDataSourceTypeID), String.Empty),
                                y.PerformanceMeasureSubcategoryOptionName,
                                false)
                            {
                                PerformanceMeasureSubcategory =
                                    performanceMeasure.PerformanceMeasureSubcategories.SingleOrDefault(z => z.PerformanceMeasureSubcategoryID == x.PerformanceMeasureSubcategoryID),
                                PerformanceMeasureSubcategoryOptionID = y.PerformanceMeasureSubcategoryOptionID,
                                SortOrder = y.SortOrder
                            }).ToList();
                performanceMeasureSubcategory.ChartConfigurationJson = x.ChartConfigurationJson;
                performanceMeasureSubcategory.GoogleChartTypeID = performanceMeasureSubcategoryGoogleChartTypes.Single(y => y.Key.PerformanceMeasureSubcategoryName == x.PerformanceMeasureSubcategoryName).Value
                    .GoogleChartTypeID;
                return performanceMeasureSubcategory;
            }).ToList();

            var performanceMeasureSubcategoryOptionsToUpdate = performanceMeasureSubcategoriesToUpdate.SelectMany(x => x.PerformanceMeasureSubcategoryOptions).ToList();
            performanceMeasure.PerformanceMeasureSubcategories.SelectMany(x => x.PerformanceMeasureSubcategoryOptions).ToList().Merge(
                performanceMeasureSubcategoryOptionsToUpdate,
                performanceMeasureSubcategoryOptionsFromDatabase,
                (x, y) => x.PerformanceMeasureSubcategoryOptionName == y.PerformanceMeasureSubcategoryOptionName,
                (x, y) =>
                {
                    x.PerformanceMeasureSubcategoryOptionName = y.PerformanceMeasureSubcategoryOptionName;
                    x.SortOrder = y.SortOrder;
                }, _databaseEntities);

            performanceMeasure.PerformanceMeasureSubcategories.Merge(performanceMeasureSubcategoriesToUpdate,
                performanceMeasureSubcategoriesFromDatabase,
                (x, y) => x.PerformanceMeasureSubcategoryDisplayName == y.PerformanceMeasureSubcategoryDisplayName,
                (x, y) =>
                {
                    x.PerformanceMeasureSubcategoryDisplayName = y.PerformanceMeasureSubcategoryDisplayName;
                }, _databaseEntities);


            _databaseEntities.SaveChangesWithNoAuditing(Tenant.ActionAgendaForPugetSound.TenantID);
            var performanceMeasureReloaded = new PerformanceMeasureDto(performanceMeasure);
            return Ok(performanceMeasureReloaded);
        }

        [Route("api/PerformanceMeasures/List")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            var result = _databaseEntities.PerformanceMeasures.ToList().Select(x => new PerformanceMeasureDto(x)).ToList();
            return Ok(result);
        }

        [Route("api/PerformanceMeasures/Get/{id}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
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

        [Route("api/PerformanceMeasures/{id}/GetReportedValues")]
        [HttpGet]
        public IHttpActionResult GetReportedValues(int id)
        {
            var performanceMeasure = _databaseEntities.PerformanceMeasures.SingleOrDefault(x => x.PerformanceMeasureID == id);
            if (performanceMeasure == null)
            {
                var message = $"Performance Measure with ID = {id} not found";
                return NotFound();
            }
            var performanceMeasureReportedValues = performanceMeasure.PerformanceMeasureDataSourceType.GetReportedPerformanceMeasureValues(performanceMeasure, null);
            return Ok(performanceMeasureReportedValues.Select(x => new PerformanceMeasureReportedValueFromProjectFirma(x)).ToList());
        }

        [Route("api/PerformanceMeasures/{id}/GetExpectedValues")]
        [HttpGet]
        public IHttpActionResult GetExpectedValues(int id)
        {
            var performanceMeasure = _databaseEntities.PerformanceMeasures.SingleOrDefault(x => x.PerformanceMeasureID == id);
            if (performanceMeasure == null)
            {
                var message = $"Performance Measure with ID = {id} not found";
                return NotFound();
            }

            return Ok(performanceMeasure.PerformanceMeasureExpecteds.Select(x => new PerformanceMeasureExpectedValueFromProjectFirma(x)).ToList());
        }

        [Route("api/PerformanceMeasures/Delete/{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
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