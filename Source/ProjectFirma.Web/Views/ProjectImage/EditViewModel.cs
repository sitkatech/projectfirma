/*-----------------------------------------------------------------------
<copyright file="EditViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.ComponentModel.DataAnnotations;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.ProjectImage
{
    public class EditViewModel : FormViewModel
    {
        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.PhotoCaption)]
        [StringLength(ProjectFirmaModels.Models.ProjectImage.FieldLengths.Caption)]
        public string Caption { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.PhotoCredit)]
        [StringLength(ProjectFirmaModels.Models.ProjectImage.FieldLengths.Credit)]
        public string Credit { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.PhotoTiming)]
        public int ProjectImageTimingID { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.ExcludeFromFactSheet)]
        public bool ExcludeFromFactSheet { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditViewModel()
        {
        }

        public EditViewModel(ProjectFirmaModels.Models.ProjectImage projectImage)
        {
            Caption = projectImage.Caption;
            Credit = projectImage.Credit;
            ProjectImageTimingID = projectImage.ProjectImageTimingID;
            ExcludeFromFactSheet = projectImage.ExcludeFromFactSheet;
        }

        public virtual void UpdateModel(ProjectFirmaModels.Models.ProjectImage projectImage, FirmaSession currentFirmaSession)
        {
            projectImage.Caption = Caption;
            projectImage.Credit = Credit;
            projectImage.ProjectImageTimingID = ProjectImageTimingID;
            projectImage.ExcludeFromFactSheet = ExcludeFromFactSheet;
        }
    }
}
