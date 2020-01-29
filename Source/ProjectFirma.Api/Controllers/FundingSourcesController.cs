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

        [Route("api/FundingSources/GetProjectBudgetsByFundingSource/{apiKey}/{fundingSourceID}")]
        [HttpGet]
        public IHttpActionResult GetProjectCalendarYearBudgetsByFundingSource(string apiKey, int fundingSourceID)
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
                    var securedFunding = budgets.Sum(x => x.SecuredAmount);
                    var targetedFunding = budgets.Sum(x => x.TargetedAmount);
                    result.Add(new ProjectBudgetDto(projectFundingSourceBudget.Key, securedFunding, targetedFunding));
                }
            }
            return Ok(result);
        }

        [Route("api/FundingSources/GetProjectCalendarYearExpendituresByFundingSource/{apiKey}/{fundingSourceID}")]
        [HttpGet]
        public IHttpActionResult GetProjectCalendarYearExpendituresByFundingSource(string apiKey, int fundingSourceID)
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
    }
}