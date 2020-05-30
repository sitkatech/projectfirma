//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectUpdate]
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
        public static ProjectUpdate GetProjectUpdate(this IQueryable<ProjectUpdate> projectUpdates, int projectUpdateID)
        {
            var projectUpdate = projectUpdates.SingleOrDefault(x => x.ProjectUpdateID == projectUpdateID);
            Check.RequireNotNullThrowNotFound(projectUpdate, "ProjectUpdate", projectUpdateID);
            return projectUpdate;
        }

    }
}