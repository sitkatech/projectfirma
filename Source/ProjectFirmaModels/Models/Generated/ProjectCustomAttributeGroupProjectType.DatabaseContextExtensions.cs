//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectCustomAttributeGroupProjectType]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectCustomAttributeGroupProjectType GetProjectCustomAttributeGroupProjectType(this IQueryable<ProjectCustomAttributeGroupProjectType> projectCustomAttributeGroupProjectTypes, int projectCustomAttributeGroupProjectTypeID)
        {
            var projectCustomAttributeGroupProjectType = projectCustomAttributeGroupProjectTypes.SingleOrDefault(x => x.ProjectCustomAttributeGroupProjectTypeID == projectCustomAttributeGroupProjectTypeID);
            Check.RequireNotNullThrowNotFound(projectCustomAttributeGroupProjectType, "ProjectCustomAttributeGroupProjectType", projectCustomAttributeGroupProjectTypeID);
            return projectCustomAttributeGroupProjectType;
        }

    }
}