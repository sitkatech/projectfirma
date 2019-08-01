//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectRelevantCostTypeGroup]
using System.Collections.Generic;
using System.Linq;
using Z.EntityFramework.Plus;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectRelevantCostTypeGroup GetProjectRelevantCostTypeGroup(this IQueryable<ProjectRelevantCostTypeGroup> projectRelevantCostTypeGroups, int projectRelevantCostTypeGroupID)
        {
            var projectRelevantCostTypeGroup = projectRelevantCostTypeGroups.SingleOrDefault(x => x.ProjectRelevantCostTypeGroupID == projectRelevantCostTypeGroupID);
            Check.RequireNotNullThrowNotFound(projectRelevantCostTypeGroup, "ProjectRelevantCostTypeGroup", projectRelevantCostTypeGroupID);
            return projectRelevantCostTypeGroup;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteProjectRelevantCostTypeGroup(this IQueryable<ProjectRelevantCostTypeGroup> projectRelevantCostTypeGroups, List<int> projectRelevantCostTypeGroupIDList)
        {
            if(projectRelevantCostTypeGroupIDList.Any())
            {
                projectRelevantCostTypeGroups.Where(x => projectRelevantCostTypeGroupIDList.Contains(x.ProjectRelevantCostTypeGroupID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteProjectRelevantCostTypeGroup(this IQueryable<ProjectRelevantCostTypeGroup> projectRelevantCostTypeGroups, ICollection<ProjectRelevantCostTypeGroup> projectRelevantCostTypeGroupsToDelete)
        {
            if(projectRelevantCostTypeGroupsToDelete.Any())
            {
                var projectRelevantCostTypeGroupIDList = projectRelevantCostTypeGroupsToDelete.Select(x => x.ProjectRelevantCostTypeGroupID).ToList();
                projectRelevantCostTypeGroups.Where(x => projectRelevantCostTypeGroupIDList.Contains(x.ProjectRelevantCostTypeGroupID)).Delete();
            }
        }

        public static void DeleteProjectRelevantCostTypeGroup(this IQueryable<ProjectRelevantCostTypeGroup> projectRelevantCostTypeGroups, int projectRelevantCostTypeGroupID)
        {
            DeleteProjectRelevantCostTypeGroup(projectRelevantCostTypeGroups, new List<int> { projectRelevantCostTypeGroupID });
        }

        public static void DeleteProjectRelevantCostTypeGroup(this IQueryable<ProjectRelevantCostTypeGroup> projectRelevantCostTypeGroups, ProjectRelevantCostTypeGroup projectRelevantCostTypeGroupToDelete)
        {
            DeleteProjectRelevantCostTypeGroup(projectRelevantCostTypeGroups, new List<ProjectRelevantCostTypeGroup> { projectRelevantCostTypeGroupToDelete });
        }
    }
}