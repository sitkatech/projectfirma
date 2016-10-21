//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[IndicatorNote]
using System.Collections.Generic;
using System.Linq;
using EntityFramework.Extensions;
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static IndicatorNote GetIndicatorNote(this IQueryable<IndicatorNote> indicatorNotes, int indicatorNoteID)
        {
            var indicatorNote = indicatorNotes.SingleOrDefault(x => x.IndicatorNoteID == indicatorNoteID);
            Check.RequireNotNullThrowNotFound(indicatorNote, "IndicatorNote", indicatorNoteID);
            return indicatorNote;
        }

        public static void DeleteIndicatorNote(this IQueryable<IndicatorNote> indicatorNotes, List<int> indicatorNoteIDList)
        {
            if(indicatorNoteIDList.Any())
            {
                indicatorNotes.Where(x => indicatorNoteIDList.Contains(x.IndicatorNoteID)).Delete();
            }
        }

        public static void DeleteIndicatorNote(this IQueryable<IndicatorNote> indicatorNotes, ICollection<IndicatorNote> indicatorNotesToDelete)
        {
            if(indicatorNotesToDelete.Any())
            {
                var indicatorNoteIDList = indicatorNotesToDelete.Select(x => x.IndicatorNoteID).ToList();
                indicatorNotes.Where(x => indicatorNoteIDList.Contains(x.IndicatorNoteID)).Delete();
            }
        }

        public static void DeleteIndicatorNote(this IQueryable<IndicatorNote> indicatorNotes, int indicatorNoteID)
        {
            DeleteIndicatorNote(indicatorNotes, new List<int> { indicatorNoteID });
        }

        public static void DeleteIndicatorNote(this IQueryable<IndicatorNote> indicatorNotes, IndicatorNote indicatorNoteToDelete)
        {
            DeleteIndicatorNote(indicatorNotes, new List<IndicatorNote> { indicatorNoteToDelete });
        }
    }
}