/*-----------------------------------------------------------------------
<copyright file="EditNoteViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
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
using ProjectFirmaModels.Models;
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

        public void UpdateModel(IEntityNote entityNote, FirmaSession currentFirmaSession)
        {
            entityNote.Note = Note;
            if (!ModelObjectHelpers.IsRealPrimaryKeyValue(entityNote.PrimaryKey))
            {
                entityNote.CreateDate = DateTime.Now;
                entityNote.CreatePerson = currentFirmaSession.Person;
            }
            else
            {
                entityNote.UpdateDate = DateTime.Now;
                entityNote.UpdatePerson = currentFirmaSession.Person;
            }
        }
    }
}
