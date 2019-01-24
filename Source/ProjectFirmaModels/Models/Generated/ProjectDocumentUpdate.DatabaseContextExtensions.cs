//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectDocumentUpdate]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectDocumentUpdate GetProjectDocumentUpdate(this IQueryable<ProjectDocumentUpdate> projectDocumentUpdates, int projectDocumentUpdateID)
        {
            var projectDocumentUpdate = projectDocumentUpdates.SingleOrDefault(x => x.ProjectDocumentUpdateID == projectDocumentUpdateID);
            Check.RequireNotNullThrowNotFound(projectDocumentUpdate, "ProjectDocumentUpdate", projectDocumentUpdateID);
            return projectDocumentUpdate;
        }

    }
}