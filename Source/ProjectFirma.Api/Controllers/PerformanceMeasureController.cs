using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using LtInfo.Common.DesignByContract;
using ProjectFirma.Api.Models;
using ProjectFirmaModels;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Api.Controllers
{
    public class PerformanceMeasuresController : ApiController
    {
        private readonly DatabaseEntities _databaseEntities = new DatabaseEntities(Tenant.ActionAgendaForPugetSound.TenantID, "ProjectFirmaDB");

        [Route("api/PerformanceMeasures/PostPerformanceMeasure/{apiKey}")]
        [HttpPost]
        public IHttpActionResult PostPerformanceMeasure(string apiKey, [FromBody] PerformanceMeasureDto performanceMeasureDto)
        {
            Check.Require(apiKey == FirmaWebApiConfiguration.PsInfoApiKey, "Unrecognized api key!");
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
                performanceMeasureDto.IsSummable, performanceMeasureDataSourceType.PerformanceMeasureDataSourceTypeID, performanceMeasureDto.CanBeChartedCumulatively);
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

        private static FileResourceMimeType MapFileResourceMimeTypeNameToFileResourceMimeType(string googleChartTypeName)
        {
            return FileResourceMimeType.All.SingleOrDefault(x => x.FileResourceMimeTypeDisplayName.Equals(googleChartTypeName, StringComparison.InvariantCultureIgnoreCase));
        }

        [Route("api/PerformanceMeasures/UpdatePerformanceMeasure/{apiKey}")]
        [HttpPut]
        public IHttpActionResult UpdatePerformanceMeasure(string apiKey, [FromBody] PerformanceMeasureDto performanceMeasureDto)
        {
            Check.Require(apiKey == FirmaWebApiConfiguration.PsInfoApiKey, "Unrecognized api key!");
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
            Check.Require(apiKey == FirmaWebApiConfiguration.PsInfoApiKey, "Unrecognized api key!");
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
            Check.Require(apiKey == FirmaWebApiConfiguration.PsInfoApiKey, "Unrecognized api key!");
            var performanceMeasure = _databaseEntities.PerformanceMeasures.SingleOrDefault(x => x.PerformanceMeasureID == performanceMeasureDto.PerformanceMeasureID);
            if (performanceMeasure == null)
            {
                var message = $"Performance Measure with ID = {performanceMeasureDto.PerformanceMeasureID} not found";
                return NotFound();
            }

            performanceMeasure.Importance = performanceMeasureDto.Importance;

            var fileResourceDtos = performanceMeasureDto.FileResources;
            var fileResourceMimeTypes = fileResourceDtos.ToDictionary(x => new { x.FileResourceGUID, x.FileResourceMimeTypeName },
                x => MapFileResourceMimeTypeNameToFileResourceMimeType(x.FileResourceMimeTypeName));
            if (fileResourceMimeTypes.Values.Any(x => x == null))
            {
                var errors =
                fileResourceMimeTypes.Where(x => x.Value == null).Select(x =>
                    $"Invalid File Resource Mime Type '{x.Key.FileResourceMimeTypeName}' for '{x.Key.FileResourceGUID}'").ToList();
                return BadRequest(string.Join("\r\n", errors));
            }

            // Remove all of these, too hard to merge nicely
            _databaseEntities.AllFileResources.RemoveRange(performanceMeasure.PerformanceMeasureImages.Select(x => x.FileResource));
            _databaseEntities.AllPerformanceMeasureImages.RemoveRange(performanceMeasure.PerformanceMeasureImages);

            var peopleDictionary = _databaseEntities.People.ToDictionary(x => x.Email);
            var performanceMeasureImagesToUpdate = fileResourceDtos.Select(x =>
            {
                var fileResourceMimeTypeID = fileResourceMimeTypes.Single(y => y.Key.FileResourceGUID == x.FileResourceGUID).Value.FileResourceMimeTypeID;
                var personID = peopleDictionary.ContainsKey(x.Email) ? peopleDictionary[x.Email].PersonID : 5278;
                var fileResource = new FileResource(fileResourceMimeTypeID, x.OriginalBaseFilename, x.OriginalFileExtension, x.FileResourceGUID, x.FileResourceData, personID, x.CreateDate);
                var performanceMeasureImage = new PerformanceMeasureImage(performanceMeasure, fileResource);
                return performanceMeasureImage;
            }).ToList();

            _databaseEntities.SaveChangesWithNoAuditing(Tenant.ActionAgendaForPugetSound.TenantID);
            var performanceMeasureReloaded = new PerformanceMeasureSimpleDto(performanceMeasure);
            return Ok(performanceMeasureReloaded);
        }

        [Route("api/PerformanceMeasures/UpdatePerformanceMeasureAdditionalInformation/{apiKey}")]
        [HttpPut]
        public IHttpActionResult UpdatePerformanceMeasureAdditionalInformation(string apiKey, [FromBody] PerformanceMeasureAdditionalInformationDto performanceMeasureDto)
        {
            Check.Require(apiKey == FirmaWebApiConfiguration.PsInfoApiKey, "Unrecognized api key!");
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
            Check.Require(apiKey == FirmaWebApiConfiguration.PsInfoApiKey, "Unrecognized api key!");
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
            Check.Require(apiKey == FirmaWebApiConfiguration.PsInfoApiKey, "Unrecognized api key!");
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
                var performanceMeasureSubcategory = new PerformanceMeasureSubcategory(performanceMeasure.PerformanceMeasureID, x.PerformanceMeasureSubcategoryName);
                performanceMeasureSubcategory.ChartConfigurationJson = x.ChartConfigurationJson;
                performanceMeasureSubcategory.GoogleChartTypeID = performanceMeasureSubcategoryGoogleChartTypes.Single(y => y.Key.PerformanceMeasureSubcategoryName == x.PerformanceMeasureSubcategoryName).Value
                    .GoogleChartTypeID;
                return performanceMeasureSubcategory;
            }).ToList();

            performanceMeasure.PerformanceMeasureSubcategories.Merge(performanceMeasureSubcategoriesToUpdate,
                performanceMeasureSubcategoriesFromDatabase,
                (x, y) => x.PerformanceMeasureSubcategoryDisplayName == y.PerformanceMeasureSubcategoryDisplayName,
                (x, y) =>
                {
                    x.ChartConfigurationJson = y.ChartConfigurationJson;
                    x.GoogleChartTypeID = y.GoogleChartTypeID;
                }, _databaseEntities);

            List<PerformanceMeasureSubcategoryOption> performanceMeasureSubcategoryOptionsToUpdate = new List<PerformanceMeasureSubcategoryOption>();
            performanceMeasureSubcategoryDtos.ForEach(x =>
            {
                var performanceMeasureSubcategory = performanceMeasure.PerformanceMeasureSubcategories.Single(y =>
                    y.PerformanceMeasureSubcategoryDisplayName == x.PerformanceMeasureSubcategoryName);
                performanceMeasureSubcategoryOptionsToUpdate.AddRange(x.PerformanceMeasureSubcategoryOptions.OrderBy(y => y.SortOrder).Select(
                    (y, index) =>
                        new PerformanceMeasureSubcategoryOption(performanceMeasureSubcategory.PerformanceMeasureSubcategoryID, y.PerformanceMeasureSubcategoryOptionName, false)
                        {
                            SortOrder = y.SortOrder,
                            PerformanceMeasureSubcategory = performanceMeasureSubcategory
                        }).ToList());
            });

            performanceMeasure.PerformanceMeasureSubcategories.SelectMany(x => x.PerformanceMeasureSubcategoryOptions).ToList().Merge(
                performanceMeasureSubcategoryOptionsToUpdate,
                performanceMeasureSubcategoryOptionsFromDatabase,
                (x, y) => x.PerformanceMeasureSubcategoryOptionName == y.PerformanceMeasureSubcategoryOptionName && x.PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName == y.PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName,
                (x, y) =>
                {
                    x.SortOrder = y.SortOrder;
                }, _databaseEntities);

            _databaseEntities.SaveChangesWithNoAuditing(Tenant.ActionAgendaForPugetSound.TenantID);
            var performanceMeasureReloaded = new PerformanceMeasureDto(performanceMeasure);
            return Ok(performanceMeasureReloaded);
        }

        [Route("api/PerformanceMeasures/List/{apiKey}")]
        [HttpGet]
        public IHttpActionResult Get(string apiKey)
        {
            Check.Require(apiKey == FirmaWebApiConfiguration.PsInfoApiKey, "Unrecognized api key!");
            var result = _databaseEntities.PerformanceMeasures.ToList().Select(x => new PerformanceMeasureDto(x)).ToList();
            return Ok(result);
        }

        [Route("api/PerformanceMeasures/Get/{apiKey}/{id}")]
        [HttpGet]
        public IHttpActionResult Get(string apiKey, int id)
        {
            Check.Require(apiKey == FirmaWebApiConfiguration.PsInfoApiKey, "Unrecognized api key!");
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
            Check.Require(apiKey == FirmaWebApiConfiguration.PsInfoApiKey, "Unrecognized api key!");
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
            Check.Require(apiKey == FirmaWebApiConfiguration.PsInfoApiKey, "Unrecognized api key!");
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
            Check.Require(apiKey == FirmaWebApiConfiguration.PsInfoApiKey, "Unrecognized api key!");
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