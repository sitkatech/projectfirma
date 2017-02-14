//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectExemptReportingYear]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectExemptReportingYear GetProjectExemptReportingYear(this IQueryable<ProjectExemptReportingYear> projectExemptReportingYears, int projectExemptReportingYearID)
        {
            var projectExemptReportingYear = projectExemptReportingYears.SingleOrDefault(x => x.ProjectExemptReportingYearID == projectExemptReportingYearID);
            Check.RequireNotNullThrowNotFound(projectExemptReportingYear, "ProjectExemptReportingYear", projectExemptReportingYearID);
            return projectExemptReportingYear;
        }

        public static void DeleteProjectExemptReportingYear(this List<int> projectExemptReportingYearIDList)
        {
            if(projectExemptReportingYearIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectExemptReportingYears.RemoveRange(HttpRequestStorage.DatabaseEntities.ProjectExemptReportingYears.Where(x => projectExemptReportingYearIDList.Contains(x.ProjectExemptReportingYearID)));
            }
        }

        public static void DeleteProjectExemptReportingYear(this ICollection<ProjectExemptReportingYear> projectExemptReportingYearsToDelete)
        {
            if(projectExemptReportingYearsToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectExemptReportingYears.RemoveRange(projectExemptReportingYearsToDelete);
            }
        }

        public static void DeleteProjectExemptReportingYear(this int projectExemptReportingYearID)
        {
            DeleteProjectExemptReportingYear(new List<int> { projectExemptReportingYearID });
        }

        public static void DeleteProjectExemptReportingYear(this ProjectExemptReportingYear projectExemptReportingYearToDelete)
        {
            DeleteProjectExemptReportingYear(new List<ProjectExemptReportingYear> { projectExemptReportingYearToDelete });
        }
    }
}