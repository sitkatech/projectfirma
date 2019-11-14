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

namespace ProjectFirma.Web.Views.ProjectProjectStatus
{
    public class EditProjectProjectStatusViewModel : FormViewModel
    {
        [Required]
        [StringLength(ProjectFirmaModels.Models.ProjectProjectStatus.FieldLengths.ProjectProjectStatusComment)]
        [DisplayName("Project Status Comments")]
        public string ProjectProjectStatusComment { get; set; }

        [Required]
        [DisplayName("Project Status")]
        public int ProjectStatusID { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditProjectProjectStatusViewModel()
        {
        }


        public EditProjectProjectStatusViewModel(ProjectFirmaModels.Models.ProjectProjectStatus projectProjectStatus)
        {
        }

        public void UpdateModel(ProjectFirmaModels.Models.ProjectProjectStatus projectProjectStatus, FirmaSession currentFirmaSession)
        {
            projectProjectStatus.ProjectProjectStatusComment = ProjectProjectStatusComment;
            if (!ModelObjectHelpers.IsRealPrimaryKeyValue(projectProjectStatus.PrimaryKey))
            {
                projectProjectStatus.ProjectProjectStatusCreateDate = DateTime.Now;
                projectProjectStatus.ProjectProjectStatusCreatePerson = currentFirmaSession.Person;
            }
            else
            {
                projectProjectStatus.ProjectProjectStatusLastUpdatedDate = DateTime.Now;
                projectProjectStatus.ProjectProjectStatusLastUpdatedPerson = currentFirmaSession.Person;
            }

            projectProjectStatus.ProjectProjectStatusID = ProjectStatusID;
        }
    }
}
