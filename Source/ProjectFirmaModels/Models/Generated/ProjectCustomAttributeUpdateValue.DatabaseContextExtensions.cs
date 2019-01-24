//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectCustomAttributeUpdateValue]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectCustomAttributeUpdateValue GetProjectCustomAttributeUpdateValue(this IQueryable<ProjectCustomAttributeUpdateValue> projectCustomAttributeUpdateValues, int projectCustomAttributeUpdateValueID)
        {
            var projectCustomAttributeUpdateValue = projectCustomAttributeUpdateValues.SingleOrDefault(x => x.ProjectCustomAttributeUpdateValueID == projectCustomAttributeUpdateValueID);
            Check.RequireNotNullThrowNotFound(projectCustomAttributeUpdateValue, "ProjectCustomAttributeUpdateValue", projectCustomAttributeUpdateValueID);
            return projectCustomAttributeUpdateValue;
        }

    }
}