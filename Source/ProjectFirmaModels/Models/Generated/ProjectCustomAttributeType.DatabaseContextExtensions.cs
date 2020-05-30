//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectCustomAttributeType]
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
        public static ProjectCustomAttributeType GetProjectCustomAttributeType(this IQueryable<ProjectCustomAttributeType> projectCustomAttributeTypes, int projectCustomAttributeTypeID)
        {
            var projectCustomAttributeType = projectCustomAttributeTypes.SingleOrDefault(x => x.ProjectCustomAttributeTypeID == projectCustomAttributeTypeID);
            Check.RequireNotNullThrowNotFound(projectCustomAttributeType, "ProjectCustomAttributeType", projectCustomAttributeTypeID);
            return projectCustomAttributeType;
        }

    }
}