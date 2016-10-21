using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectFirma.Web.Models
{
    public class EntityNote : IEntityNote
    {
        public DateTime LastUpdated { get; private set; }
        public string LastUpdatedBy { get; private set; }
        public string DeleteUrl { get; private set; }
        public string EditUrl { get; private set; }
        public string Note { get; set; }
        public string DisplayCssClass { get; set; }

        public EntityNote(DateTime lastUpdated, string lastUpdatedBy, string deleteUrl, string editUrl, string note, string displayCssClass)
        {
            LastUpdated = lastUpdated;
            LastUpdatedBy = lastUpdatedBy;
            DeleteUrl = deleteUrl;
            EditUrl = editUrl;
            Note = note;
            DisplayCssClass = displayCssClass;
        }

        public static List<EntityNote> CreateFromEntityNote(List<IEntityNote> entityNotes)
        {
            return entityNotes.Select(x => new EntityNote(x.LastUpdated, x.LastUpdatedBy, x.DeleteUrl, x.EditUrl, x.Note, null)).ToList();
        }
    }
}