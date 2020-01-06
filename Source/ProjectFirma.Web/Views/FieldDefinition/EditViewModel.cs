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
using System.Web;
using ProjectFirmaModels.Models;
using LtInfo.Common.Models;

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

        public void UpdateModel(FieldDefinitionData fieldDefinitionData, FieldDefinitionDefault fieldDefinitionDefault)
        {
            fieldDefinitionData.FieldDefinitionDataValueHtmlString = FieldDefinitionDataValue;
            fieldDefinitionData.FieldDefinitionLabel = string.IsNullOrWhiteSpace(FieldDefinitionLabel) ? null : FieldDefinitionLabel;
            if (fieldDefinitionDefault != null)
            {
                fieldDefinitionDefault.DefaultDefinitionHtmlString = FieldDefinitionDefault;
            }
        }
    }
}
