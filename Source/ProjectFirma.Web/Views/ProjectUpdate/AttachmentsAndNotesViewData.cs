/*-----------------------------------------------------------------------
<copyright file="AttachmentsAndNotesViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Views.Shared.TextControls;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared.ProjectAttachment;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class AttachmentsAndNotesViewData : ProjectUpdateViewData
    {
        public EntityNotesViewData EntityNotesViewData { get; }
        public string RefreshUrl { get; }
        public string DiffUrl { get; }
        public string NextSectionUrl { get; }
        public ProjectAttachmentsDetailViewData ProjectAttachmentsViewData { get; }

        public AttachmentsAndNotesViewData(FirmaSession currentFirmaSession, ProjectUpdateBatch projectUpdateBatch, ProjectUpdateStatus projectUpdateStatus, string diffUrl) : base(currentFirmaSession, projectUpdateBatch, projectUpdateStatus, new List<string>(), ProjectUpdateSection.AttachmentsAndNotes.ProjectUpdateSectionDisplayName)
        {
            EntityNotesViewData = new EntityNotesViewData(EntityNote.CreateFromEntityNote(projectUpdateBatch.ProjectNoteUpdates),
                SitkaRoute<ProjectNoteUpdateController>.BuildUrlFromExpression(x => x.New(projectUpdateBatch)),
                projectUpdateBatch.Project.GetDisplayName(),
                IsEditable);
            ProjectAttachmentsViewData = new ProjectAttachmentsDetailViewData(
                                                                EntityAttachment.CreateFromProjectAttachment(projectUpdateBatch.ProjectAttachmentUpdates),
                                                                SitkaRoute<ProjectAttachmentUpdateController>.BuildUrlFromExpression(x => x.New(projectUpdateBatch)),
                                                                projectUpdateBatch.Project.GetDisplayName(),
                                                                IsEditable,
                                                                projectUpdateBatch.GetAllAttachmentRelationshipTypes().ToList(),
                                                                currentFirmaSession);
            RefreshUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.RefreshNotesAndAttachments(projectUpdateBatch.Project));
            DiffUrl = diffUrl;

            var applicableWizardSections = projectUpdateBatch.GetApplicableWizardSections(true);
            var currentSection = applicableWizardSections.Single(x => x.SectionDisplayName.Equals(ProjectUpdateSection.AttachmentsAndNotes.ProjectUpdateSectionDisplayName, StringComparison.InvariantCultureIgnoreCase));
            var nextProjectUpdateSection = applicableWizardSections.Where(x => x.SortOrder > currentSection.SortOrder).OrderBy(x => x.SortOrder).FirstOrDefault();
            NextSectionUrl = nextProjectUpdateSection?.SectionUrl;
        }
    }
}
