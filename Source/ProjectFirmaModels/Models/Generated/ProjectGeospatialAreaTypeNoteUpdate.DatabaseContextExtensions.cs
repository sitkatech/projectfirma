//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectGeospatialAreaTypeNoteUpdate]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectGeospatialAreaTypeNoteUpdate GetProjectGeospatialAreaTypeNoteUpdate(this IQueryable<ProjectGeospatialAreaTypeNoteUpdate> projectGeospatialAreaTypeNoteUpdates, int projectGeospatialAreaTypeNoteUpdateID)
        {
            var projectGeospatialAreaTypeNoteUpdate = projectGeospatialAreaTypeNoteUpdates.SingleOrDefault(x => x.ProjectGeospatialAreaTypeNoteUpdateID == projectGeospatialAreaTypeNoteUpdateID);
            Check.RequireNotNullThrowNotFound(projectGeospatialAreaTypeNoteUpdate, "ProjectGeospatialAreaTypeNoteUpdate", projectGeospatialAreaTypeNoteUpdateID);
            return projectGeospatialAreaTypeNoteUpdate;
        }

    }
}