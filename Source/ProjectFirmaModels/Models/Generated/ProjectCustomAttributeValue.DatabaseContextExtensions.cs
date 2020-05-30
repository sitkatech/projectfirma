//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectCustomAttributeValue]
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
        public static ProjectCustomAttributeValue GetProjectCustomAttributeValue(this IQueryable<ProjectCustomAttributeValue> projectCustomAttributeValues, int projectCustomAttributeValueID)
        {
            var projectCustomAttributeValue = projectCustomAttributeValues.SingleOrDefault(x => x.ProjectCustomAttributeValueID == projectCustomAttributeValueID);
            Check.RequireNotNullThrowNotFound(projectCustomAttributeValue, "ProjectCustomAttributeValue", projectCustomAttributeValueID);
            return projectCustomAttributeValue;
        }

    }
}