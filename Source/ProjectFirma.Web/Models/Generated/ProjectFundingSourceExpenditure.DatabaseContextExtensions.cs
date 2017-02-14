//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectFundingSourceExpenditure]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectFundingSourceExpenditure GetProjectFundingSourceExpenditure(this IQueryable<ProjectFundingSourceExpenditure> projectFundingSourceExpenditures, int projectFundingSourceExpenditureID)
        {
            var projectFundingSourceExpenditure = projectFundingSourceExpenditures.SingleOrDefault(x => x.ProjectFundingSourceExpenditureID == projectFundingSourceExpenditureID);
            Check.RequireNotNullThrowNotFound(projectFundingSourceExpenditure, "ProjectFundingSourceExpenditure", projectFundingSourceExpenditureID);
            return projectFundingSourceExpenditure;
        }

        public static void DeleteProjectFundingSourceExpenditure(this List<int> projectFundingSourceExpenditureIDList)
        {
            if(projectFundingSourceExpenditureIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectFundingSourceExpenditures.RemoveRange(HttpRequestStorage.DatabaseEntities.ProjectFundingSourceExpenditures.Where(x => projectFundingSourceExpenditureIDList.Contains(x.ProjectFundingSourceExpenditureID)));
            }
        }

        public static void DeleteProjectFundingSourceExpenditure(this ICollection<ProjectFundingSourceExpenditure> projectFundingSourceExpendituresToDelete)
        {
            if(projectFundingSourceExpendituresToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectFundingSourceExpenditures.RemoveRange(projectFundingSourceExpendituresToDelete);
            }
        }

        public static void DeleteProjectFundingSourceExpenditure(this int projectFundingSourceExpenditureID)
        {
            DeleteProjectFundingSourceExpenditure(new List<int> { projectFundingSourceExpenditureID });
        }

        public static void DeleteProjectFundingSourceExpenditure(this ProjectFundingSourceExpenditure projectFundingSourceExpenditureToDelete)
        {
            DeleteProjectFundingSourceExpenditure(new List<ProjectFundingSourceExpenditure> { projectFundingSourceExpenditureToDelete });
        }
    }
}