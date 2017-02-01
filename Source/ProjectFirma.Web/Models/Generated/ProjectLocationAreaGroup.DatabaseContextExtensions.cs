//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectLocationAreaGroup]
using System.Collections.Generic;
using System.Linq;
using Z.EntityFramework.Plus;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectLocationAreaGroup GetProjectLocationAreaGroup(this IQueryable<ProjectLocationAreaGroup> projectLocationAreaGroups, int projectLocationAreaGroupID)
        {
            var projectLocationAreaGroup = projectLocationAreaGroups.SingleOrDefault(x => x.ProjectLocationAreaGroupID == projectLocationAreaGroupID);
            Check.RequireNotNullThrowNotFound(projectLocationAreaGroup, "ProjectLocationAreaGroup", projectLocationAreaGroupID);
            return projectLocationAreaGroup;
        }

        public static void DeleteProjectLocationAreaGroup(this IQueryable<ProjectLocationAreaGroup> projectLocationAreaGroups, List<int> projectLocationAreaGroupIDList)
        {
            if(projectLocationAreaGroupIDList.Any())
            {
                projectLocationAreaGroups.Where(x => projectLocationAreaGroupIDList.Contains(x.ProjectLocationAreaGroupID)).Delete();
            }
        }

        public static void DeleteProjectLocationAreaGroup(this IQueryable<ProjectLocationAreaGroup> projectLocationAreaGroups, ICollection<ProjectLocationAreaGroup> projectLocationAreaGroupsToDelete)
        {
            if(projectLocationAreaGroupsToDelete.Any())
            {
                var projectLocationAreaGroupIDList = projectLocationAreaGroupsToDelete.Select(x => x.ProjectLocationAreaGroupID).ToList();
                projectLocationAreaGroups.Where(x => projectLocationAreaGroupIDList.Contains(x.ProjectLocationAreaGroupID)).Delete();
            }
        }

        public static void DeleteProjectLocationAreaGroup(this IQueryable<ProjectLocationAreaGroup> projectLocationAreaGroups, int projectLocationAreaGroupID)
        {
            DeleteProjectLocationAreaGroup(projectLocationAreaGroups, new List<int> { projectLocationAreaGroupID });
        }

        public static void DeleteProjectLocationAreaGroup(this IQueryable<ProjectLocationAreaGroup> projectLocationAreaGroups, ProjectLocationAreaGroup projectLocationAreaGroupToDelete)
        {
            DeleteProjectLocationAreaGroup(projectLocationAreaGroups, new List<ProjectLocationAreaGroup> { projectLocationAreaGroupToDelete });
        }
    }
}