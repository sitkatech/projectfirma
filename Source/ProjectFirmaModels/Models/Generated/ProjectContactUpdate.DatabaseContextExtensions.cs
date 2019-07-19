//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectContactUpdate]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectContactUpdate GetProjectContactUpdate(this IQueryable<ProjectContactUpdate> projectContactUpdates, int projectContactUpdateID)
        {
            var projectContactUpdate = projectContactUpdates.SingleOrDefault(x => x.ProjectContactUpdateID == projectContactUpdateID);
            Check.RequireNotNullThrowNotFound(projectContactUpdate, "ProjectContactUpdate", projectContactUpdateID);
            return projectContactUpdate;
        }

    }
}