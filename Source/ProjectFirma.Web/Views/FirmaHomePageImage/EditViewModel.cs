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

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.FirmaHomePageImage
{
    public class EditViewModel : FormViewModel
    {
        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.PhotoCaption)]
        [StringLength(ProjectFirmaModels.Models.ProjectImage.FieldLengths.Caption)]
        public string Caption { get; set; }

        [Required]
        [DisplayName("Sort Order")]
        public int SortOrder { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditViewModel()
        {
        }

        public EditViewModel(ProjectFirmaModels.Models.FirmaHomePageImage firmaHomePageImage)
        {
            Caption = firmaHomePageImage.Caption;
            SortOrder = firmaHomePageImage.SortOrder;
        }

        public virtual void UpdateModel(ProjectFirmaModels.Models.FirmaHomePageImage firmaHomePageImage, FirmaSession currentFirmaSession)
        {
            firmaHomePageImage.Caption = Caption;
            firmaHomePageImage.SortOrder = SortOrder;
        }
    }
}
