//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[Project]
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
        public static Project GetProject(this IQueryable<Project> projects, int projectID)
        {
            var project = projects.SingleOrDefault(x => x.ProjectID == projectID);
            Check.RequireNotNullThrowNotFound(project, "Project", projectID);
            return project;
        }

        public static void DeleteProject(this IQueryable<Project> projects, List<int> projectIDList)
        {
            if(projectIDList.Any())
            {
                projects.Where(x => projectIDList.Contains(x.ProjectID)).Delete();
            }
        }

        public static void DeleteProject(this IQueryable<Project> projects, ICollection<Project> projectsToDelete)
        {
            if(projectsToDelete.Any())
            {
                var projectIDList = projectsToDelete.Select(x => x.ProjectID).ToList();
                projects.Where(x => projectIDList.Contains(x.ProjectID)).Delete();
            }
        }

        public static void DeleteProject(this IQueryable<Project> projects, int projectID)
        {
            DeleteProject(projects, new List<int> { projectID });
        }

        public static void DeleteProject(this IQueryable<Project> projects, Project projectToDelete)
        {
            DeleteProject(projects, new List<Project> { projectToDelete });
        }
    }
}