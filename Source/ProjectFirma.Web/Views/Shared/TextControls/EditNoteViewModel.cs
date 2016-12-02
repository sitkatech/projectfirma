using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ProjectFirma.Web.Models;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.Shared.TextControls
{
    public class EditNoteViewModel : FormViewModel
    {
        [Required]
        [StringLength(ProjectNote.FieldLengths.Note)]
        [DisplayName("Note")]
        public string Note { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditNoteViewModel()
        {
        }

        public EditNoteViewModel(string note)
        {
            Note = note;
        }

        public void UpdateModel(ProjectNote projectNote, Person currentPerson)
        {
            projectNote.Note = Note;
            if (!ModelObjectHelpers.IsRealPrimaryKeyValue(projectNote.ProjectNoteID))
            {
                projectNote.CreateDate = DateTime.Now;
                projectNote.CreatePerson = currentPerson;
            }
            else
            {
                projectNote.UpdateDate = DateTime.Now;
                projectNote.UpdatePerson = currentPerson;
            }
        }

        public void UpdateModel(PerformanceMeasureNote performanceMeasureNote, Person currentPerson)
        {
            performanceMeasureNote.Note = Note;
            if (!ModelObjectHelpers.IsRealPrimaryKeyValue(performanceMeasureNote.PerformanceMeasureNoteID))
            {
                performanceMeasureNote.CreateDate = DateTime.Now;
                performanceMeasureNote.CreatePerson = currentPerson;
            }
            else
            {
                performanceMeasureNote.UpdateDate = DateTime.Now;
                performanceMeasureNote.UpdatePerson = currentPerson;
            }
        }
        
        public void UpdateModel(ProjectNoteUpdate projectNoteUpdate, Person currentPerson)
        {
            projectNoteUpdate.Note = Note;
            if (!ModelObjectHelpers.IsRealPrimaryKeyValue(projectNoteUpdate.ProjectNoteUpdateID))
            {
                projectNoteUpdate.CreateDate = DateTime.Now;
                projectNoteUpdate.CreatePerson = currentPerson;
            }
            else
            {
                projectNoteUpdate.UpdateDate = DateTime.Now;
                projectNoteUpdate.UpdatePerson = currentPerson;
            }
        }

        public void UpdateModel(ProposedProjectNote proposedProjectNote, Person currentPerson)
        {
            proposedProjectNote.Note = Note;
            if (!ModelObjectHelpers.IsRealPrimaryKeyValue(proposedProjectNote.ProposedProjectNoteID))
            {
                proposedProjectNote.CreateDate = DateTime.Now;
                proposedProjectNote.CreatePerson = currentPerson;
            }
            else
            {
                proposedProjectNote.UpdateDate = DateTime.Now;
                proposedProjectNote.UpdatePerson = currentPerson;
            }
        }
    }
}