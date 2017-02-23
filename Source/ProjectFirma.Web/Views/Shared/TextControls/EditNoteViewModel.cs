/*-----------------------------------------------------------------------
<copyright file="EditNoteViewModel.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
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
