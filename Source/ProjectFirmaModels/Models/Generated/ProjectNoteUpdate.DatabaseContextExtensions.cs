//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectNoteUpdate]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectNoteUpdate GetProjectNoteUpdate(this IQueryable<ProjectNoteUpdate> projectNoteUpdates, int projectNoteUpdateID)
        {
            var projectNoteUpdate = projectNoteUpdates.SingleOrDefault(x => x.ProjectNoteUpdateID == projectNoteUpdateID);
            Check.RequireNotNullThrowNotFound(projectNoteUpdate, "ProjectNoteUpdate", projectNoteUpdateID);
            return projectNoteUpdate;
        }

    }
}