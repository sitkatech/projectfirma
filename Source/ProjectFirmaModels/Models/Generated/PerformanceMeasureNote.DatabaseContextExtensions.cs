//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureNote]
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
        public static PerformanceMeasureNote GetPerformanceMeasureNote(this IQueryable<PerformanceMeasureNote> performanceMeasureNotes, int performanceMeasureNoteID)
        {
            var performanceMeasureNote = performanceMeasureNotes.SingleOrDefault(x => x.PerformanceMeasureNoteID == performanceMeasureNoteID);
            Check.RequireNotNullThrowNotFound(performanceMeasureNote, "PerformanceMeasureNote", performanceMeasureNoteID);
            return performanceMeasureNote;
        }

    }
}