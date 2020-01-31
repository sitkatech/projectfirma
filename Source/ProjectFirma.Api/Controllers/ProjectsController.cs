using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using LtInfo.Common.DesignByContract;
using ProjectFirma.Api.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Api.Controllers
{
    public class ProjectsController : ApiController
    {
        private readonly DatabaseEntities _databaseEntities = new DatabaseEntities(Tenant.ActionAgendaForPugetSound.TenantID, "ProjectFirmaDB");

        //public ProjectsController(DatabaseEntities databaseEntities)
        //{
        //    _databaseEntities = databaseEntities;
        //}

        [Route("api/Projects/List/{apiKey}")]
        [HttpGet]
        public IHttpActionResult List(string apiKey)
        {
            Check.Require(apiKey == FirmaWebApiConfiguration.PsInfoApiKey, "Unrecognized api key!");
            var projects = _databaseEntities.Projects.ToList();
            var result = projects.Select(x => new ProjectDto(x)).ToList();
            return Ok(result);
        }

        [Route("api/Projects/ListNTAs/{apiKey}/{nepFundedOnly}")]
        [HttpGet]
        public IHttpActionResult ListNTAs(string apiKey, bool nepFundedOnly)
        {
            Check.Require(apiKey == FirmaWebApiConfiguration.PsInfoApiKey, "Unrecognized api key!");
            List<ProjectDto> result;
            var projects = _databaseEntities.Projects.ToList();
            if (nepFundedOnly)
            {
                var ntas = projects.Where(x => x.ProjectCustomAttributes.Any(y => y.ProjectCustomAttributeType.ProjectCustomAttributeTypeName == "NEP Funded Activities"));
                result = ntas.Where(x => x.ProjectCustomAttributes.Single(y => y.ProjectCustomAttributeType.ProjectCustomAttributeTypeName == "NEP Funded Activities").ProjectCustomAttributeValues.Single().AttributeValue == "Yes").Select(x => new ProjectDto(x)).ToList();
            }
            else
            {
                result = projects.Select(x => new ProjectDto(x)).ToList();
            }
            return Ok(result);

        }

        [Route("api/Projects/Get/{apiKey}/{id}")]
        [HttpGet]
        public IHttpActionResult Get(string apiKey, int id)
        {
            Check.Require(apiKey == FirmaWebApiConfiguration.PsInfoApiKey, "Unrecognized api key!");
            var project = _databaseEntities.Projects.SingleOrDefault(x => x.ProjectID == id);
            if (project == null)
            {
                var message = $"Project with ID = {id} not found";
                return NotFound();
            }
            var result = new ProjectDto(project);
            return Ok(result);
        }
    }
}