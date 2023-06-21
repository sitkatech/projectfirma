/*-----------------------------------------------------------------------
<copyright file="AttachmentAndNoteViewModel.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
Copyright (c) Tahoe Regional Planning Agency and Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
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
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ProjectFirma.Web.Views.ProjectExternalLink;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ProjectCreate
{
    public class ExternalLinksViewModel : EditProjectExternalLinksViewModel
    {
        [DisplayName("Reviewer Comments")]
        [StringLength(ProjectFirmaModels.Models.Project.FieldLengths.ExternalLinksComment)]
        public string Comments { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public ExternalLinksViewModel()
        {
        }

        public ExternalLinksViewModel(ProjectFirmaModels.Models.Project project, List<ProjectExternalLinkSimple> projectExternalLinks) : base(projectExternalLinks)
        {
            Comments = project.ExternalLinksComment;
        }
        
        public void UpdateModel(ProjectFirmaModels.Models.Project project, List<ProjectFirmaModels.Models.ProjectExternalLink> currentProjectExternalLinks, IList<ProjectFirmaModels.Models.ProjectExternalLink> allProjectExternalLinks)
        {
            UpdateModel(currentProjectExternalLinks, allProjectExternalLinks);
            if (project.ProjectApprovalStatus == ProjectApprovalStatus.PendingApproval)
            {
                project.ExternalLinksComment = Comments;
            }
        }
    }    
}
