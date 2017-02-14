//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureNote]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static PerformanceMeasureNote GetPerformanceMeasureNote(this IQueryable<PerformanceMeasureNote> performanceMeasureNotes, int performanceMeasureNoteID)
        {
            var performanceMeasureNote = performanceMeasureNotes.SingleOrDefault(x => x.PerformanceMeasureNoteID == performanceMeasureNoteID);
            Check.RequireNotNullThrowNotFound(performanceMeasureNote, "PerformanceMeasureNote", performanceMeasureNoteID);
            return performanceMeasureNote;
        }

        public static void DeletePerformanceMeasureNote(this List<int> performanceMeasureNoteIDList)
        {
            if(performanceMeasureNoteIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureNotes.RemoveRange(HttpRequestStorage.DatabaseEntities.PerformanceMeasureNotes.Where(x => performanceMeasureNoteIDList.Contains(x.PerformanceMeasureNoteID)));
            }
        }

        public static void DeletePerformanceMeasureNote(this ICollection<PerformanceMeasureNote> performanceMeasureNotesToDelete)
        {
            if(performanceMeasureNotesToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureNotes.RemoveRange(performanceMeasureNotesToDelete);
            }
        }

        public static void DeletePerformanceMeasureNote(this int performanceMeasureNoteID)
        {
            DeletePerformanceMeasureNote(new List<int> { performanceMeasureNoteID });
        }

        public static void DeletePerformanceMeasureNote(this PerformanceMeasureNote performanceMeasureNoteToDelete)
        {
            DeletePerformanceMeasureNote(new List<PerformanceMeasureNote> { performanceMeasureNoteToDelete });
        }
    }
}