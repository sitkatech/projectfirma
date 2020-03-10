/*-----------------------------------------------------------------------
<copyright file="OrganizationsViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using ProjectFirma.Web.Views.Shared.ProjectOrganization;
using ProjectFirmaModels.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ProjectFirma.Web.Views.ProjectCreate
{
    public class OrganizationsViewModel : EditOrganizationsViewModel
    {
        [DisplayName("Reviewer Comments")]
        [StringLength(ProjectFirmaModels.Models.Project.FieldLengths.OrganizationsComment)]
        public string Comments { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public OrganizationsViewModel()
        {
        }

        public OrganizationsViewModel(ProjectFirmaModels.Models.Project project, FirmaSession currentFirmaSession) : base(project, project.ProjectOrganizations.OrderBy(x => x.Organization.OrganizationName).ToList(), currentFirmaSession)
        {
            Comments = project.OrganizationsComment;
        }

        public void UpdateModel(ProjectFirmaModels.Models.Project project, ObservableCollection<ProjectOrganization> allProjectOrganizations)
        {
            if (project.ProjectApprovalStatus == ProjectApprovalStatus.PendingApproval)
            {
                project.OrganizationsComment = Comments;
            }
            base.UpdateModel(project, allProjectOrganizations);
        }
    }    
}
