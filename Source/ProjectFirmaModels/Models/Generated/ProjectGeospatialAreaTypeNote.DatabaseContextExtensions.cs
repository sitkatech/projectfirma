//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectGeospatialAreaTypeNote]
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
        public static ProjectGeospatialAreaTypeNote GetProjectGeospatialAreaTypeNote(this IQueryable<ProjectGeospatialAreaTypeNote> projectGeospatialAreaTypeNotes, int projectGeospatialAreaTypeNoteID)
        {
            var projectGeospatialAreaTypeNote = projectGeospatialAreaTypeNotes.SingleOrDefault(x => x.ProjectGeospatialAreaTypeNoteID == projectGeospatialAreaTypeNoteID);
            Check.RequireNotNullThrowNotFound(projectGeospatialAreaTypeNote, "ProjectGeospatialAreaTypeNote", projectGeospatialAreaTypeNoteID);
            return projectGeospatialAreaTypeNote;
        }

    }
}