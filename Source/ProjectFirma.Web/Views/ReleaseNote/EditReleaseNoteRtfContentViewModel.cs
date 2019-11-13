/*-----------------------------------------------------------------------
<copyright file="EditReleaseNoteRtfContentViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using LtInfo.Common.Models;
using ProjectFirmaModels.Models;
using System.Web;

namespace ProjectFirma.Web.Views.ReleaseNote
{
    public class EditReleaseNoteRtfContentViewModel : FormViewModel
    {
        public HtmlString Note { get; set; }

        /// <summary>
        /// Needed by model binder
        /// </summary>
        public EditReleaseNoteRtfContentViewModel()
        {
        }

        public EditReleaseNoteRtfContentViewModel(ProjectFirmaModels.Models.ReleaseNote releaseNote)
        {
            Note = releaseNote.NoteHtmlString;
        }

        public void UpdateModel(ProjectFirmaModels.Models.ReleaseNote releaseNote, FirmaSession currentFirmaSession)
        {
            releaseNote.NoteHtmlString = Note;
            if (releaseNote.CreateDate == default(DateTime))
            {
                releaseNote.CreateDate = DateTime.Now;
            }
            else
            {
                releaseNote.UpdatePersonID = currentFirmaSession.PersonID;
                releaseNote.UpdateDate = DateTime.Now;
            }
        }
    }
}
 