//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProposedProjectNote]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProposedProjectNote GetProposedProjectNote(this IQueryable<ProposedProjectNote> proposedProjectNotes, int proposedProjectNoteID)
        {
            var proposedProjectNote = proposedProjectNotes.SingleOrDefault(x => x.ProposedProjectNoteID == proposedProjectNoteID);
            Check.RequireNotNullThrowNotFound(proposedProjectNote, "ProposedProjectNote", proposedProjectNoteID);
            return proposedProjectNote;
        }

        public static void DeleteProposedProjectNote(this List<int> proposedProjectNoteIDList)
        {
            if(proposedProjectNoteIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProposedProjectNotes.RemoveRange(HttpRequestStorage.DatabaseEntities.ProposedProjectNotes.Where(x => proposedProjectNoteIDList.Contains(x.ProposedProjectNoteID)));
            }
        }

        public static void DeleteProposedProjectNote(this ICollection<ProposedProjectNote> proposedProjectNotesToDelete)
        {
            if(proposedProjectNotesToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProposedProjectNotes.RemoveRange(proposedProjectNotesToDelete);
            }
        }

        public static void DeleteProposedProjectNote(this int proposedProjectNoteID)
        {
            DeleteProposedProjectNote(new List<int> { proposedProjectNoteID });
        }

        public static void DeleteProposedProjectNote(this ProposedProjectNote proposedProjectNoteToDelete)
        {
            DeleteProposedProjectNote(new List<ProposedProjectNote> { proposedProjectNoteToDelete });
        }
    }
}