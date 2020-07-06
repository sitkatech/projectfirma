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
using LtInfo.Common;
using LtInfo.Common.Models;
using ProjectFirmaModels.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectFirma.Web.Views.FieldDefinition
{
    public class EditViewModel : FormViewModel
    {
        [DisplayName("Custom Definition")]
        public HtmlString FieldDefinitionDataValue { get; set; }

        [DisplayName("Custom Label")]
        [StringLength(FieldDefinitionData.FieldLengths.FieldDefinitionLabel)]
        public string FieldDefinitionLabel { get; set; }

        [DisplayName("Default Definition")]
        [Required]
        public HtmlString FieldDefinitionDefault { get; set; }

        /// <summary>
        /// Needed by model binder
        /// </summary>
        public EditViewModel()
        {
        }

        public EditViewModel(FieldDefinitionData fieldDefinitionData, FieldDefinitionDefault fieldDefinitionDefault)
        {
            FieldDefinitionDataValue = fieldDefinitionData?.FieldDefinitionDataValueHtmlString;
            FieldDefinitionLabel = fieldDefinitionData?.FieldDefinitionLabel;
            FieldDefinitionDefault = fieldDefinitionDefault.DefaultDefinitionHtmlString;
        }

        public void UpdateModel(FieldDefinitionData fieldDefinitionData, FieldDefinitionDefault fieldDefinitionDefault, DatabaseEntities databaseEntities)
        {
            // delete file resources for any images that are no longer referenced in the HTML
            var imagesToDelete = FieldDefinitionDataValue == null
                ? fieldDefinitionData.FieldDefinitionDataImages.ToList()
                : fieldDefinitionData.FieldDefinitionDataImages.Where(x => !FieldDefinitionDataValue.ToString().ContainsCaseInsensitive(x.FileResourceInfo.GetFileResourceGUIDAsString())).ToList();
            foreach (var image in imagesToDelete)
            {
                // will cascade delete the FieldDefinitionDataImage
                image.FileResourceInfo.DeleteFull(databaseEntities);
            }

            fieldDefinitionData.FieldDefinitionDataValueHtmlString = FieldDefinitionDataValue;
            fieldDefinitionData.FieldDefinitionLabel = string.IsNullOrWhiteSpace(FieldDefinitionLabel) ? null : FieldDefinitionLabel;
            if (fieldDefinitionDefault != null)
            {
                fieldDefinitionDefault.DefaultDefinitionHtmlString = FieldDefinitionDefault;
            }
        }
    }
}
