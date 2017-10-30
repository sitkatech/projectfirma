/*-----------------------------------------------------------------------
<copyright file="EditProjectExternalLinksViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Linq;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.ProjectExternalLink
{
    public class EditProjectExternalLinksViewModel : FormViewModel
    {
        public List<ProjectExternalLinkSimple> ProjectExternalLinks { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditProjectExternalLinksViewModel()
        {
        }

        public EditProjectExternalLinksViewModel(List<ProjectExternalLinkSimple> projectExternalLinks)
        {
            ProjectExternalLinks = projectExternalLinks;
        }

        public void UpdateModel(List<Models.ProjectExternalLink> currentProjectExternalLinks, IList<Models.ProjectExternalLink> allProjectExternalLinks)
        {
            var projectExternalLinksUpdated = new List<Models.ProjectExternalLink>();
            if (ProjectExternalLinks != null)
            {
                // Completely rebuild the list
                projectExternalLinksUpdated = ProjectExternalLinks.Select(x => new Models.ProjectExternalLink(x.ProjectID, x.ExternalLinkLabel, x.ExternalLinkUrl)).ToList();
            }
            currentProjectExternalLinks.Merge(projectExternalLinksUpdated,
                allProjectExternalLinks,
                (x, y) => x.ProjectID == y.ProjectID && x.ExternalLinkLabel == y.ExternalLinkLabel && x.ExternalLinkUrl == y.ExternalLinkUrl);
        }

        public void UpdateModel(List<Models.ProjectExternalLinkUpdate> currentProjectExternalLinkUpdates, IList<Models.ProjectExternalLinkUpdate> allProjectExternalLinkUpdates)
        {
            var projectExternalLinksUpdated = new List<Models.ProjectExternalLinkUpdate>();
            if (ProjectExternalLinks != null)
            {
                // Completely rebuild the list
                projectExternalLinksUpdated = ProjectExternalLinks.Select(x => new Models.ProjectExternalLinkUpdate(x.ProjectID, x.ExternalLinkLabel, x.ExternalLinkUrl)).ToList();
            }
            currentProjectExternalLinkUpdates.Merge(projectExternalLinksUpdated,
                allProjectExternalLinkUpdates,
                (x, y) => x.ProjectUpdateBatchID == y.ProjectUpdateBatchID && x.ExternalLinkLabel == y.ExternalLinkLabel && x.ExternalLinkUrl == y.ExternalLinkUrl);
        }
    }
}
