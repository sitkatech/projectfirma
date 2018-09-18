using System.Collections.Generic;
using System.Linq;

namespace ProjectFirma.Web.Models
{
    public abstract partial class AccomplishmentsDashboardFundingDisplayType
    {
        public abstract decimal GetInvestmentAmount(Organization organization,
            IEnumerable<ProjectFundingSourceExpenditure> projectFundingSourceExpenditures);
    }

    public partial class AccomplishmentsDashboardFundingDisplayTypeOnlyFundingProvided
    {
        public override decimal GetInvestmentAmount(Organization organization,
            IEnumerable<ProjectFundingSourceExpenditure> projectFundingSourceExpenditures)
        {
            var filteredProjectFundingSourceExpenditures = organization == null
                ? projectFundingSourceExpenditures
                : projectFundingSourceExpenditures.Where(x =>
                    x.FundingSource.OrganizationID == organization.OrganizationID);

            return filteredProjectFundingSourceExpenditures.Sum(x => x.ExpenditureAmount);
        }
    }
     
    public partial class AccomplishmentsDashboardFundingDisplayTypeAllFundingReceived
    {
        public override decimal GetInvestmentAmount(Organization organization,
            IEnumerable<ProjectFundingSourceExpenditure> projectFundingSourceExpenditures)
        {
            var filteredProjectFundingSourceExpenditures = organization == null
                ? projectFundingSourceExpenditures
                : projectFundingSourceExpenditures.Where(x => 
                    x.FundingSource.Organization.OrganizationID != organization.OrganizationID);

            return filteredProjectFundingSourceExpenditures.Sum(x => x.ExpenditureAmount);
        }
    }
}
