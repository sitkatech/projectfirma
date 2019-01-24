/*-----------------------------------------------------------------------
<copyright file="FieldDefinitionEnum.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Data.Entity.Infrastructure.Pluralization;
using System.Linq;
using LtInfo.Common.HtmlHelperExtensions;

namespace ProjectFirmaModels.Models
{
    public partial class FieldDefinition : IFieldDefinition
    {
        public static readonly EnglishPluralizationService PluralizationService = new EnglishPluralizationService();

        public bool HasDefinition()
        {
            var fieldDefinitionData = GetFieldDefinitionData();
            return fieldDefinitionData != null && fieldDefinitionData.FieldDefinitionDataValueHtmlString != null;
        }

        public string GetFieldDefinitionLabel()
        {
            var fieldDefinitionData = GetFieldDefinitionData();
            if (fieldDefinitionData != null && !string.IsNullOrWhiteSpace(fieldDefinitionData.FieldDefinitionLabel))
            {
                return fieldDefinitionData.FieldDefinitionLabel;
            }
            return FieldDefinitionDisplayName;
        }

        public bool HasCustomFieldLabel()
        {
            var fieldDefinitionData = GetFieldDefinitionData();
            return fieldDefinitionData != null && !string.IsNullOrWhiteSpace(fieldDefinitionData.FieldDefinitionLabel);
        }

        public bool HasCustomFieldDefinition()
        {
            var fieldDefinitionData = GetFieldDefinitionData();
            return fieldDefinitionData != null && fieldDefinitionData.FieldDefinitionDataValueHtmlString != null;
        }

        public string GetFieldDefinitionLabelPluralized()
        {
            return PluralizationService.Pluralize(GetFieldDefinitionLabel());
        }

        public IFieldDefinitionData GetFieldDefinitionData()
        {
            return FieldDefinitionDatas.SingleOrDefault();
        }

        public string GetContentUrl()
        {
            return string.Empty;
            //return SitkaRoute<FieldDefinitionController>.BuildUrlFromExpression(x => x.FieldDefinitionDetails(FieldDefinitionID));
        }
    }
}
