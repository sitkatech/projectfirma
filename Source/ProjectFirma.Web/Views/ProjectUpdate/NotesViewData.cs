/*-----------------------------------------------------------------------
<copyright file="NotesViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Collections.Generic;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared.TextControls;
using LtInfo.Common;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class NotesViewData : ProjectUpdateViewData
    {
        public readonly EntityNotesViewData EntityNotesViewData;
        public readonly string RefreshUrl;
        public readonly string DiffUrl;

        public NotesViewData(Person currentPerson, ProjectUpdateBatch projectUpdateBatch, UpdateStatus updateStatus, string diffUrl) : base(currentPerson, projectUpdateBatch, ProjectUpdateSectionEnum.Notes, updateStatus, new List<string>())
        {
            EntityNotesViewData = new EntityNotesViewData(EntityNote.CreateFromEntityNote(new List<IEntityNote>(projectUpdateBatch.ProjectNoteUpdates)),
                SitkaRoute<ProjectNoteUpdateController>.BuildUrlFromExpression(x => x.New(projectUpdateBatch)),
                projectUpdateBatch.Project.DisplayName,
                IsEditable);
            RefreshUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.RefreshNotes(projectUpdateBatch.Project));
            DiffUrl = diffUrl;
        }
    }
}
