//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectExemptReportingYear]
using System.Collections.Generic;
using System.Linq;
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectExemptReportingYear GetProjectExemptReportingYear(this IQueryable<ProjectExemptReportingYear> projectExemptReportingYears, int projectExemptReportingYearID)
        {
            var projectExemptReportingYear = projectExemptReportingYears.SingleOrDefault(x => x.ProjectExemptReportingYearID == projectExemptReportingYearID);
            Check.RequireNotNullThrowNotFound(projectExemptReportingYear, "ProjectExemptReportingYear", projectExemptReportingYearID);
            return projectExemptReportingYear;
        }

    }
}