//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectCustomAttributeGroupProjectCategory]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectCustomAttributeGroupProjectCategory GetProjectCustomAttributeGroupProjectCategory(this IQueryable<ProjectCustomAttributeGroupProjectCategory> projectCustomAttributeGroupProjectCategories, int projectCustomAttributeGroupProjectCategoryID)
        {
            var projectCustomAttributeGroupProjectCategory = projectCustomAttributeGroupProjectCategories.SingleOrDefault(x => x.ProjectCustomAttributeGroupProjectCategoryID == projectCustomAttributeGroupProjectCategoryID);
            Check.RequireNotNullThrowNotFound(projectCustomAttributeGroupProjectCategory, "ProjectCustomAttributeGroupProjectCategory", projectCustomAttributeGroupProjectCategoryID);
            return projectCustomAttributeGroupProjectCategory;
        }

    }
}