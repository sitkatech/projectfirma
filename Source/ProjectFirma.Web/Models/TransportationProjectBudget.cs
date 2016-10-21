using System;
using ProjectFirma.Web.Common;
using LtInfo.Common;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Models
{
    public partial class TransportationProjectBudget : IAuditableEntity, ITransportationProjectBudgetAmount
    {
        public string AuditDescriptionString
        {
            get
            {
                var project = HttpRequestStorage.DatabaseEntities.Projects.Find(ProjectID);
                var fundingSource = HttpRequestStorage.DatabaseEntities.FundingSources.Find(FundingSourceID);
                var projectName = project != null ? project.AuditDescriptionString : ViewUtilities.NotFoundString;
                var fundingSourceName = fundingSource != null ? fundingSource.AuditDescriptionString : ViewUtilities.NotFoundString;
                return String.Format("Project: {0}, Funding Source: {1}, CostType: {2}, Year: {3},  Budget: {4}",
                    projectName,
                    fundingSourceName,
                    TransportationProjectCostType.TransportationProjectCostTypeDisplayName,
                    CalendarYear,
                    BudgetedAmount.ToStringCurrency());
            }
        }

        public decimal? MonetaryAmount
        {
            get { return BudgetedAmount; }
        }
    }
}