//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectNote]
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
        public static ProjectNote GetProjectNote(this IQueryable<ProjectNote> projectNotes, int projectNoteID)
        {
            var projectNote = projectNotes.SingleOrDefault(x => x.ProjectNoteID == projectNoteID);
            Check.RequireNotNullThrowNotFound(projectNote, "ProjectNote", projectNoteID);
            return projectNote;
        }

    }
}