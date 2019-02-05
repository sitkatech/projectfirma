//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectInternalNote]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectInternalNote GetProjectInternalNote(this IQueryable<ProjectInternalNote> projectInternalNotes, int projectInternalNoteID)
        {
            var projectInternalNote = projectInternalNotes.SingleOrDefault(x => x.ProjectInternalNoteID == projectInternalNoteID);
            Check.RequireNotNullThrowNotFound(projectInternalNote, "ProjectInternalNote", projectInternalNoteID);
            return projectInternalNote;
        }

    }
}