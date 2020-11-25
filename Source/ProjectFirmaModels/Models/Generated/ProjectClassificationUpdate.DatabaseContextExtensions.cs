//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectClassificationUpdate]
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
        public static ProjectClassificationUpdate GetProjectClassificationUpdate(this IQueryable<ProjectClassificationUpdate> projectClassificationUpdates, int projectClassificationUpdateID)
        {
            var projectClassificationUpdate = projectClassificationUpdates.SingleOrDefault(x => x.ProjectClassificationUpdateID == projectClassificationUpdateID);
            Check.RequireNotNullThrowNotFound(projectClassificationUpdate, "ProjectClassificationUpdate", projectClassificationUpdateID);
            return projectClassificationUpdate;
        }

    }
}