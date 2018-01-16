//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[Project]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static Project GetProject(this IQueryable<Project> projects, int projectID)
        {
            var project = projects.SingleOrDefault(x => x.ProjectID == projectID);
            Check.RequireNotNullThrowNotFound(project, "Project", projectID);
            return project;
        }

        public static void DeleteProject(this List<int> projectIDList)
        {
            if(projectIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjects.RemoveRange(HttpRequestStorage.DatabaseEntities.Projects.Where(x => projectIDList.Contains(x.ProjectID)));
            }
        }

        public static void DeleteProject(this ICollection<Project> projectsToDelete)
        {
            if(projectsToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjects.RemoveRange(projectsToDelete);
            }
        }

        public static void DeleteProject(this int projectID)
        {
            DeleteProject(new List<int> { projectID });
        }

        public static void DeleteProject(this Project projectToDelete)
        {
            DeleteProject(new List<Project> { projectToDelete });
        }

        public static List<int> GetProjectUpdateImplementationStartToCompletionYearRange(this IProject projectUpdate)
        {
            var startYear = projectUpdate?.ImplementationStartYear;
            return GetYearRangesImpl(projectUpdate, startYear);
        }

        public static List<int> GetProjectUpdatePlanningDesignStartToCompletionYearRange(this IProject projectUpdate)
        {
            var startYear = projectUpdate?.PlanningDesignStartYear;
            return GetYearRangesImpl(projectUpdate, startYear);
        }

        private static List<int> GetYearRangesImpl(IProject projectUpdate, int? startYear)
        {
            var currentYearToUse = FirmaDateUtilities.CalculateCurrentYearToUseForReporting();
            if (projectUpdate != null)
            {
                if (startYear.HasValue && startYear.Value < FirmaDateUtilities.MinimumYear &&
                    (projectUpdate.CompletionYear.HasValue && projectUpdate.CompletionYear.Value < FirmaDateUtilities.MinimumYear))
                {
                    // both start and completion year are before the minimum year, so no year range required
                    return new List<int>();
                }

                if (startYear.HasValue && startYear.Value > currentYearToUse && (projectUpdate.CompletionYear.HasValue && projectUpdate.CompletionYear.Value > currentYearToUse))
                {
                    return new List<int>();
                }

                if (startYear.HasValue && projectUpdate.CompletionYear.HasValue && startYear.Value > projectUpdate.CompletionYear.Value)
                {
                    return new List<int>();
                }
            }
            return FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(),
                startYear,
                projectUpdate?.CompletionYear,
                currentYearToUse,
                FirmaDateUtilities.MinimumYear,
                currentYearToUse);
        }
    }
}