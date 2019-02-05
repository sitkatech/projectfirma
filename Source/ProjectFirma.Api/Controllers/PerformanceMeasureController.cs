using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
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
            var performanceMeasureTypeID = performanceMeasureDto.PerformanceMeasureTypeID;
            var performanceMeasure = new PerformanceMeasure(performanceMeasureDto.PerformanceMeasureDisplayName,
                performanceMeasureDto.MeasurementUnitTypeID, performanceMeasureTypeID,
                performanceMeasureDto.SwapChartAxes, performanceMeasureDto.CanCalculateTotal,
                performanceMeasureDto.IsAggregatable, performanceMeasureDto.PerformanceMeasureDataSourceTypeID);
            performanceMeasure.CriticalDefinitions = performanceMeasureDto.CriticalDefinitions;
            performanceMeasure.PerformanceMeasureDefinition = performanceMeasureDto.PerformanceMeasureDefinition;
            performanceMeasure.ProjectReporting = performanceMeasureDto.ProjectReporting;
            _databaseEntities.AllPerformanceMeasures.Add(performanceMeasure);
            _databaseEntities.SaveChangesWithNoAuditing(Tenant.ActionAgendaForPugetSound.TenantID);
            var performanceMeasureReloaded = new PerformanceMeasureDto(performanceMeasure);
            return Ok(performanceMeasureReloaded);
        }

        [Route("api/PerformanceMeasures/PutPerformanceMeasure")]
        [HttpPut]
        public IHttpActionResult PutPerformanceMeasure([FromBody] PerformanceMeasureDto performanceMeasureDto)
        {
            var performanceMeasure = _databaseEntities.PerformanceMeasures.SingleOrDefault(x => x.PerformanceMeasureID == performanceMeasureDto.PerformanceMeasureID);
            if (performanceMeasure == null)
            {
                var message = $"Performance Measure with ID = {performanceMeasureDto.PerformanceMeasureID} not found";
                return NotFound();
            }

            performanceMeasure.PerformanceMeasureDisplayName = performanceMeasureDto.PerformanceMeasureDisplayName;
            performanceMeasure.CriticalDefinitions = performanceMeasureDto.CriticalDefinitions;
            performanceMeasure.PerformanceMeasureDefinition = performanceMeasureDto.PerformanceMeasureDefinition;
            performanceMeasure.ProjectReporting = performanceMeasureDto.ProjectReporting;
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
            var performanceMeasure = _databaseEntities.PerformanceMeasures.SingleOrDefault(x => x.PerformanceMeasureID == 3415);
            if (performanceMeasure == null)
            {
                var message = $"Performance Measure with ID = {id} not found";
                return NotFound();
            }
            var performanceMeasureReportedValues = performanceMeasure.PerformanceMeasureDataSourceType.GetReportedPerformanceMeasureValues(performanceMeasure, null);
            return Ok(performanceMeasureReportedValues.Select(x => new PerformanceMeasureReportedValueSimple(x)).ToList());
        }

        [Route("api/PerformanceMeasures/{id}/GetExpectedValues")]
        [HttpGet]
        public IHttpActionResult GetExpectedValues(int id)
        {
            var performanceMeasure = _databaseEntities.PerformanceMeasures.SingleOrDefault(x => x.PerformanceMeasureID == 3415);
            if (performanceMeasure == null)
            {
                var message = $"Performance Measure with ID = {id} not found";
                return NotFound();
            }

            return Ok(performanceMeasure.PerformanceMeasureExpecteds.Select(x => new PerformanceMeasureExpectedValueSimple(x)).ToList());
        }
    }
}