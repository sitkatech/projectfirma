using LtInfo.Common.DesignByContract;
using ProjectFirmaModels.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ProjectFirma.Api.Models;

namespace ProjectFirma.Api.Controllers
{
    public class FundingSourcesController : ApiController
    {
        private readonly DatabaseEntities _databaseEntities = new DatabaseEntities(Tenant.ActionAgendaForPugetSound.TenantID, "ProjectFirmaDB");

        /// API endpoint - currently only used by PS Info
        /// Any changes made here could have adverse effects on dependent applications 
        [Route("api/FundingSources/GetProjectBudgetsForAFundingSource/{apiKey}/{fundingSourceID}")]
        [HttpGet]
        public IHttpActionResult GetProjectBudgetsForAFundingSource(string apiKey, int fundingSourceID)
        {
            Check.Require(apiKey == FirmaWebApiConfiguration.PsInfoApiKey, "Unrecognized api key!");
            var result = new List<ProjectBudgetDto>();
            var fundingSource = _databaseEntities.FundingSources.SingleOrDefault(x => x.FundingSourceID == fundingSourceID);
            if (fundingSource != null)
            {
                var projectFundingSourceBudgets = fundingSource.ProjectFundingSourceBudgets.ToList();
                foreach (var projectFundingSourceBudget in projectFundingSourceBudgets.GroupBy(x => x.Project))
                {
                    var budgets = projectFundingSourceBudget.Where(x => x.ProjectID == projectFundingSourceBudget.Key.ProjectID).ToList();
                    var securedFunding = budgets.Any(x => x.SecuredAmount != null) ? budgets.Sum(x => x.SecuredAmount) : null;
                    var targetedFunding = budgets.Any(x => x.TargetedAmount != null) ? budgets.Sum(x => x.TargetedAmount) : null;
                    result.Add(new ProjectBudgetDto(projectFundingSourceBudget.Key, securedFunding, targetedFunding));
                }
            }
            return Ok(result);
        }

        /// API endpoint - currently only used by PS Info
        /// Any changes made here could have adverse effects on dependent applications
        [Route("api/FundingSources/GetProjectCalendarYearExpendituresForAFundingSource/{apiKey}/{fundingSourceID}")]
        [HttpGet]
        public IHttpActionResult GetProjectCalendarYearExpendituresForAFundingSource(string apiKey, int fundingSourceID)
        {
            Check.Require(apiKey == FirmaWebApiConfiguration.PsInfoApiKey, "Unrecognized api key!");
            var result = new List<ProjectCalendarYearExpendituresDto>();
            var fundingSource = _databaseEntities.FundingSources.SingleOrDefault(x => x.FundingSourceID == fundingSourceID);
            if (fundingSource != null)
            {
                var projectFundingSourceExpenditures = fundingSource.ProjectFundingSourceExpenditures.ToList();
                foreach (var projectProjectFundingSourceExpenditures in projectFundingSourceExpenditures.GroupBy(x => x.Project))
                {
                    var calendarYearExpenditures = projectProjectFundingSourceExpenditures.Where(x => x.ProjectID == projectProjectFundingSourceExpenditures.Key.ProjectID).GroupBy(x => x.CalendarYear).ToDictionary(x => x.Key, x => x?.Sum(y => y.ExpenditureAmount));
                    result.Add(new ProjectCalendarYearExpendituresDto(projectProjectFundingSourceExpenditures.Key, calendarYearExpenditures));
                }
            }
            return Ok(result);
        }

        /// API endpoint - currently only used by PS Info
        /// Any changes made here could have adverse effects on dependent applications
        [Route("api/FundingSources/GetFundingSourceFinancialTotals/{apiKey}")]
        [HttpGet]
        public IHttpActionResult GetFundingSourceFinancialTotals(string apiKey)
        {
            Check.Require(apiKey == FirmaWebApiConfiguration.PsInfoApiKey, "Unrecognized api key!");
            var result = _databaseEntities.FundingSources.ToList().Select(x => new FundingSourceFinancialTotalsDto(x, 
                    _databaseEntities.ProjectFundingSourceBudgets.Where(y => y.FundingSourceID == x.FundingSourceID), 
                    _databaseEntities.ProjectFundingSourceExpenditures.Where(y => y.FundingSourceID == x.FundingSourceID))).ToList();
            return Ok(result);
        }

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