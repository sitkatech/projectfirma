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

        public void UpdateModel(IndicatorNote eipPerformanceMeasureNote, Person currentPerson)
        {
            eipPerformanceMeasureNote.Note = Note;
            if (!ModelObjectHelpers.IsRealPrimaryKeyValue(eipPerformanceMeasureNote.IndicatorNoteID))
            {
                eipPerformanceMeasureNote.CreateDate = DateTime.Now;
                eipPerformanceMeasureNote.CreatePerson = currentPerson;
            }
            else
            {
                eipPerformanceMeasureNote.UpdateDate = DateTime.Now;
                eipPerformanceMeasureNote.UpdatePerson = currentPerson;
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