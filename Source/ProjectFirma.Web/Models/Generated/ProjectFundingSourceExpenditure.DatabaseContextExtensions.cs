//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectFundingSourceExpenditure]
using System.Collections.Generic;
using System.Linq;
using EntityFramework.Extensions;
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

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

        public static void DeleteProjectFundingSourceExpenditure(this IQueryable<ProjectFundingSourceExpenditure> projectFundingSourceExpenditures, List<int> projectFundingSourceExpenditureIDList)
        {
            if(projectFundingSourceExpenditureIDList.Any())
            {
                projectFundingSourceExpenditures.Where(x => projectFundingSourceExpenditureIDList.Contains(x.ProjectFundingSourceExpenditureID)).Delete();
            }
        }

        public static void DeleteProjectFundingSourceExpenditure(this IQueryable<ProjectFundingSourceExpenditure> projectFundingSourceExpenditures, ICollection<ProjectFundingSourceExpenditure> projectFundingSourceExpendituresToDelete)
        {
            if(projectFundingSourceExpendituresToDelete.Any())
            {
                var projectFundingSourceExpenditureIDList = projectFundingSourceExpendituresToDelete.Select(x => x.ProjectFundingSourceExpenditureID).ToList();
                projectFundingSourceExpenditures.Where(x => projectFundingSourceExpenditureIDList.Contains(x.ProjectFundingSourceExpenditureID)).Delete();
            }
        }

        public static void DeleteProjectFundingSourceExpenditure(this IQueryable<ProjectFundingSourceExpenditure> projectFundingSourceExpenditures, int projectFundingSourceExpenditureID)
        {
            DeleteProjectFundingSourceExpenditure(projectFundingSourceExpenditures, new List<int> { projectFundingSourceExpenditureID });
        }

        public static void DeleteProjectFundingSourceExpenditure(this IQueryable<ProjectFundingSourceExpenditure> projectFundingSourceExpenditures, ProjectFundingSourceExpenditure projectFundingSourceExpenditureToDelete)
        {
            DeleteProjectFundingSourceExpenditure(projectFundingSourceExpenditures, new List<ProjectFundingSourceExpenditure> { projectFundingSourceExpenditureToDelete });
        }
    }
}