/*-----------------------------------------------------------------------
<copyright file="ProjectNoteUpdate.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Controllers;
using LtInfo.Common;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectNoteUpdate : IEntityNote
    {
        public DateTime LastUpdated
        {
            get { return UpdateDate ?? CreateDate; }
        }

        public string LastUpdatedBy
        {
            get
            {
                if (UpdatePersonID.HasValue)
                {
                    return UpdatePerson.FullNameFirstLast;
                }
                if (CreatePersonID.HasValue)
                {
                    return CreatePerson.FullNameFirstLast;
                }
                return "System";
            }
        }

        public string DeleteUrl
        {
            get { return SitkaRoute<ProjectNoteUpdateController>.BuildUrlFromExpression(c => c.Delete(ProjectNoteUpdateID)); }
        }

        public string EditUrl
        {
            get { return SitkaRoute<ProjectNoteUpdateController>.BuildUrlFromExpression(c => c.Edit(ProjectNoteUpdateID)); }
        }

        public string CreatePersonName
        {
            get { return CreatePersonID.HasValue ? CreatePerson.FullNameFirstLast : string.Empty; }
        }

        public static void CreateFromProject(ProjectUpdateBatch projectUpdateBatch)
        {
            var project = projectUpdateBatch.Project;
            projectUpdateBatch.ProjectNoteUpdates =
                project.ProjectNotes.Select(
                    pn => new ProjectNoteUpdate(projectUpdateBatch, pn.Note, pn.CreateDate) {CreatePerson = pn.CreatePerson, UpdateDate = pn.UpdateDate, UpdatePerson = pn.UpdatePerson}).ToList();
        }

        public static void CommitChangesToProject(ProjectUpdateBatch projectUpdateBatch, IList<ProjectNote> allProjectNotes)
        {
            var project = projectUpdateBatch.Project;
            var projectNotesFromProjectUpdate =
                projectUpdateBatch.ProjectNoteUpdates.Select(
                    x => new ProjectNote(project.ProjectID, x.Note, x.CreateDate) {CreatePersonID = x.CreatePersonID, UpdateDate = x.UpdateDate, UpdatePersonID = x.UpdatePersonID}).ToList();
            project.ProjectNotes.Merge(projectNotesFromProjectUpdate, allProjectNotes, (x, y) => x.ProjectID == y.ProjectID && x.Note == y.Note);
        }
    }
}
