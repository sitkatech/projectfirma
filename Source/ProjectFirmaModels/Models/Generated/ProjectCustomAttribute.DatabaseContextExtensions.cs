//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectCustomAttribute]
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
        public static ProjectCustomAttribute GetProjectCustomAttribute(this IQueryable<ProjectCustomAttribute> projectCustomAttributes, int projectCustomAttributeID)
        {
            var projectCustomAttribute = projectCustomAttributes.SingleOrDefault(x => x.ProjectCustomAttributeID == projectCustomAttributeID);
            Check.RequireNotNullThrowNotFound(projectCustomAttribute, "ProjectCustomAttribute", projectCustomAttributeID);
            return projectCustomAttribute;
        }

    }
}