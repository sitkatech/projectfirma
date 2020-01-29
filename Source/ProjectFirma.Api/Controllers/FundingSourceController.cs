using System.Linq;
using System.Web.Http;
using LtInfo.Common.DesignByContract;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Api.Controllers
{
    public class FundingSourceController : ApiController
    {
        private readonly DatabaseEntities _databaseEntities = new DatabaseEntities(Tenant.ActionAgendaForPugetSound.TenantID, "ProjectFirmaDB");

        [Route("api/FundingSources/PostFundingSource/{apiKey}")]
        [HttpPost]
        public IHttpActionResult PostFundingSource(string apiKey, [FromBody] FundingSourceDto fundingSourceDto)
        {
            Check.Require(apiKey == FirmaWebApiConfiguration.PsInfoApiKey, "Unrecognized api key!");
            var fundingSource = new FundingSource(fundingSourceDto.OrganizationID,
                fundingSourceDto.FundingSourceName, fundingSourceDto.IsActive);
            fundingSource.FundingSourceDescription = fundingSourceDto.FundingSourceDescription;
            fundingSource.FundingSourceAmount = fundingSourceDto.FundingSourceAmount;

            var tenantID = Tenant.ActionAgendaForPugetSound.TenantID;
            _databaseEntities.AllFundingSources.Add(fundingSource);
            _databaseEntities.SaveChangesWithNoAuditing(tenantID);
            var fundingSourceReloaded = new FundingSourceDto(fundingSource);
            return Ok(fundingSourceReloaded);
        }

        [Route("api/FundingSources/UpdateFundingSource/{apiKey}")]
        [HttpPut]
        public IHttpActionResult UpdateFundingSource(string apiKey, [FromBody] FundingSourceDto fundingSourceDto)
        {
            Check.Require(apiKey == FirmaWebApiConfiguration.PsInfoApiKey, "Unrecognized api key!");
            var fundingSource = _databaseEntities.FundingSources.SingleOrDefault(x => x.FundingSourceID == fundingSourceDto.FundingSourceID);
            if (fundingSource == null)
            {
                var message = $"Funding Source with ID = {fundingSourceDto.FundingSourceID} not found";
                return NotFound();
            }

            fundingSource.OrganizationID = fundingSourceDto.OrganizationID;
            fundingSource.FundingSourceName = fundingSourceDto.FundingSourceName;
            fundingSource.IsActive = fundingSourceDto.IsActive;
            fundingSource.FundingSourceDescription = fundingSourceDto.FundingSourceDescription;
            fundingSource.FundingSourceAmount = fundingSourceDto.FundingSourceAmount;
            _databaseEntities.SaveChangesWithNoAuditing(Tenant.ActionAgendaForPugetSound.TenantID);
            var fundingSourceReloaded = new FundingSourceDto(fundingSource);
            return Ok(fundingSourceReloaded);
        }

        [Route("api/FundingSources/Delete/{apiKey}/{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(string apiKey, int id)
        {
            Check.Require(apiKey == FirmaWebApiConfiguration.PsInfoApiKey, "Unrecognized api key!");
            var fundingSource = _databaseEntities.FundingSources.SingleOrDefault(x => x.FundingSourceID == id);
            if (fundingSource == null)
            {
                var message = $"Funding Source with ID = {id} not found";
                return NotFound();
            }
            fundingSource.DeleteFull(_databaseEntities);
            _databaseEntities.SaveChangesWithNoAuditing(Tenant.ActionAgendaForPugetSound.TenantID);
            return Ok();
        }
    }
}