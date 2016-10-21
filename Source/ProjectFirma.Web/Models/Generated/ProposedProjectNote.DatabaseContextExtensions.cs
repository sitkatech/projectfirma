//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProposedProjectNote]
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
        public static ProposedProjectNote GetProposedProjectNote(this IQueryable<ProposedProjectNote> proposedProjectNotes, int proposedProjectNoteID)
        {
            var proposedProjectNote = proposedProjectNotes.SingleOrDefault(x => x.ProposedProjectNoteID == proposedProjectNoteID);
            Check.RequireNotNullThrowNotFound(proposedProjectNote, "ProposedProjectNote", proposedProjectNoteID);
            return proposedProjectNote;
        }

        public static void DeleteProposedProjectNote(this IQueryable<ProposedProjectNote> proposedProjectNotes, List<int> proposedProjectNoteIDList)
        {
            if(proposedProjectNoteIDList.Any())
            {
                proposedProjectNotes.Where(x => proposedProjectNoteIDList.Contains(x.ProposedProjectNoteID)).Delete();
            }
        }

        public static void DeleteProposedProjectNote(this IQueryable<ProposedProjectNote> proposedProjectNotes, ICollection<ProposedProjectNote> proposedProjectNotesToDelete)
        {
            if(proposedProjectNotesToDelete.Any())
            {
                var proposedProjectNoteIDList = proposedProjectNotesToDelete.Select(x => x.ProposedProjectNoteID).ToList();
                proposedProjectNotes.Where(x => proposedProjectNoteIDList.Contains(x.ProposedProjectNoteID)).Delete();
            }
        }

        public static void DeleteProposedProjectNote(this IQueryable<ProposedProjectNote> proposedProjectNotes, int proposedProjectNoteID)
        {
            DeleteProposedProjectNote(proposedProjectNotes, new List<int> { proposedProjectNoteID });
        }

        public static void DeleteProposedProjectNote(this IQueryable<ProposedProjectNote> proposedProjectNotes, ProposedProjectNote proposedProjectNoteToDelete)
        {
            DeleteProposedProjectNote(proposedProjectNotes, new List<ProposedProjectNote> { proposedProjectNoteToDelete });
        }
    }
}