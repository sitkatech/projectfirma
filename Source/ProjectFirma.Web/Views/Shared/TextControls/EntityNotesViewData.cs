using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Shared.TextControls
{
    public class EntityNotesViewData : FirmaUserControlViewData
    {
        public readonly List<EntityNote> Notes;
        public readonly string AddNoteUrl;
        public readonly bool CanEditNotes;
        public readonly string EntityName;

        public EntityNotesViewData(List<EntityNote> notes, string addNoteUrl, string entityName, bool canEditNotes)
        {
            Notes = notes;
            AddNoteUrl = addNoteUrl;
            EntityName = entityName;
            CanEditNotes = canEditNotes;
        }
    }
}