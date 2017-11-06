using System;
using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;
using LtInfo.Common;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectFundingSourceRequest : IAuditableEntity, IFundingSourceRequestAmount
    {
        public string AuditDescriptionString
        {
            get
            {
                var project = HttpRequestStorage.DatabaseEntities.AllProjects.Find(ProjectID);
                var fundingSource = HttpRequestStorage.DatabaseEntities.AllFundingSources.Find(FundingSourceID);
                var projectName = project != null ? project.AuditDescriptionString : ViewUtilities.NotFoundString;
                var fundingSourceName = fundingSource != null ? fundingSource.AuditDescriptionString : ViewUtilities.NotFoundString;
                var expenditureAmount = UnsecuredAmount.ToStringCurrency();
                return $"Project: {projectName}, Funding Source: {fundingSourceName}, Request Amount: {expenditureAmount}";
            }
        }
    }
}