//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectFundingSourceExpenditure]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectFundingSourceExpenditure GetProjectFundingSourceExpenditure(this IQueryable<ProjectFundingSourceExpenditure> projectFundingSourceExpenditures, int projectFundingSourceExpenditureID)
        {
            var projectFundingSourceExpenditure = projectFundingSourceExpenditures.SingleOrDefault(x => x.ProjectFundingSourceExpenditureID == projectFundingSourceExpenditureID);
            Check.RequireNotNullThrowNotFound(projectFundingSourceExpenditure, "ProjectFundingSourceExpenditure", projectFundingSourceExpenditureID);
            return projectFundingSourceExpenditure;
        }

    }
}