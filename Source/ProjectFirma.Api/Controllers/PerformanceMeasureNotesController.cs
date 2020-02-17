using System.Linq;
using System.Web.Http;
using LtInfo.Common.DesignByContract;
using ProjectFirma.Api.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Api.Controllers
{
    public class PerformanceMeasureNotesController : ApiController
    {
        private readonly DatabaseEntities _databaseEntities = new DatabaseEntities(Tenant.ActionAgendaForPugetSound.TenantID, "ProjectFirmaDB");

        //public PerformanceMeasuresController(DatabaseEntities databaseEntities)
        //{
        //    _databaseEntities = databaseEntities;
        //}

        [Route("api/PerformanceMeasureNotes/PostPerformanceMeasureNote/{apiKey}")]
        [HttpPost]
        public IHttpActionResult PostPerformanceMeasureNote(string apiKey, [FromBody] PerformanceMeasureNoteDto performanceMeasureNoteDto)
        {
            Check.Require(apiKey == FirmaWebApiConfiguration.PsInfoApiKey, "Unrecognized api key!");
            var performanceMeasureNote = new PerformanceMeasureNote(performanceMeasureNoteDto.PerformanceMeasureID, performanceMeasureNoteDto.Note, performanceMeasureNoteDto.CreateDate);
            var createPerson = MapPersonEmailToPerson(performanceMeasureNoteDto.CreatePersonEmail);
            performanceMeasureNote.CreatePersonID = createPerson?.PersonID;
            var tenantID = Tenant.ActionAgendaForPugetSound.TenantID;
            _databaseEntities.AllPerformanceMeasureNotes.Add(performanceMeasureNote);
            _databaseEntities.SaveChangesWithNoAuditing(tenantID);
            var performanceMeasureReloaded = new PerformanceMeasureNoteDto(performanceMeasureNote);
            return Ok(performanceMeasureReloaded);
        }

        [Route("api/PerformanceMeasureNotes/UpdatePerformanceMeasureNote/{apiKey}")]
        [HttpPut]
        public IHttpActionResult UpdatePerformanceMeasureNote(string apiKey, [FromBody] PerformanceMeasureNoteDto performanceMeasureNoteDto)
        {
            Check.Require(apiKey == FirmaWebApiConfiguration.PsInfoApiKey, "Unrecognized api key!");
            var performanceMeasureNote = _databaseEntities.PerformanceMeasureNotes.SingleOrDefault(x => x.PerformanceMeasureNoteID == performanceMeasureNoteDto.PerformanceMeasureNoteID);
            if (performanceMeasureNote == null)
            {
                var message = $"Performance Measure with ID = {performanceMeasureNoteDto.PerformanceMeasureID} not found";
                return NotFound();
            }

            var createPerson = MapPersonEmailToPerson(performanceMeasureNoteDto.CreatePersonEmail);
            var updatePerson = MapPersonEmailToPerson(performanceMeasureNoteDto.UpdatePersonEmail);

            performanceMeasureNote.Note = performanceMeasureNoteDto.Note;
            performanceMeasureNote.CreatePersonID = createPerson?.PersonID;
            performanceMeasureNote.UpdatePersonID = updatePerson?.PersonID;
            performanceMeasureNote.CreateDate = performanceMeasureNoteDto.CreateDate;
            performanceMeasureNote.UpdateDate = performanceMeasureNoteDto.UpdateDate;
            _databaseEntities.SaveChangesWithNoAuditing(Tenant.ActionAgendaForPugetSound.TenantID);
            var performanceMeasureReloaded = new PerformanceMeasureNoteDto(performanceMeasureNote);
            return Ok(performanceMeasureReloaded);
        }

        [Route("api/PerformanceMeasureNotes/Delete/{apiKey}/{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(string apiKey, int id)
        {
            Check.Require(apiKey == FirmaWebApiConfiguration.PsInfoApiKey, "Unrecognized api key!");
            var performanceMeasureNote = _databaseEntities.PerformanceMeasureNotes.SingleOrDefault(x => x.PerformanceMeasureNoteID == id);
            if (performanceMeasureNote == null)
            {
                var message = $"Performance Measure Note with ID = {id} not found";
                return NotFound();
            }
            performanceMeasureNote.DeleteFull(_databaseEntities);
            _databaseEntities.SaveChangesWithNoAuditing(Tenant.ActionAgendaForPugetSound.TenantID);
            return Ok();
        }

        private Person MapPersonEmailToPerson(string email)
        {
            return _databaseEntities.People.SingleOrDefault(x => x.Email == email);
        }

    }
}