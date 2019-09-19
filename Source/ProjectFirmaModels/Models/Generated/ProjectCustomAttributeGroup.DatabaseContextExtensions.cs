//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectCustomAttributeGroup]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectCustomAttributeGroup GetProjectCustomAttributeGroup(this IQueryable<ProjectCustomAttributeGroup> projectCustomAttributeGroups, int projectCustomAttributeGroupID)
        {
            var projectCustomAttributeGroup = projectCustomAttributeGroups.SingleOrDefault(x => x.ProjectCustomAttributeGroupID == projectCustomAttributeGroupID);
            Check.RequireNotNullThrowNotFound(projectCustomAttributeGroup, "ProjectCustomAttributeGroup", projectCustomAttributeGroupID);
            return projectCustomAttributeGroup;
        }

    }
}