/*-----------------------------------------------------------------------
<copyright file="FieldDefinitionDetailsViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Web;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Shared
{
    public class FieldDefinitionDetailsViewData : FirmaUserControlViewData
    {
        public readonly Models.FieldDefinition FieldDefinition;
        private readonly FieldDefinitionData _fieldDefinitionData;
        public readonly bool ShowEditLink;

        public FieldDefinitionDetailsViewData(Models.FieldDefinition fieldDefinition, FieldDefinitionData fieldDefinitionData, bool showEditLink)
        {
            FieldDefinition = fieldDefinition;
            _fieldDefinitionData = fieldDefinitionData;
            ShowEditLink = showEditLink;
        }

        public HtmlString GetFieldDefinition()
        {
            if (_fieldDefinitionData != null && _fieldDefinitionData.FieldDefinitionDataValueHtmlString != null)
            {
               return _fieldDefinitionData.FieldDefinitionDataValueHtmlString;
            }
            return FieldDefinition.DefaultDefinitionHtmlString ?? new HtmlString(string.Format("{0} not yet defined.", FieldDefinition.GetFieldDefinitionLabel()));
        }

        public string GetFieldDefinitionLabel()
        {
            if (_fieldDefinitionData != null && !string.IsNullOrWhiteSpace(_fieldDefinitionData.FieldDefinitionLabel))
            {
               return _fieldDefinitionData.FieldDefinitionLabel;
            }
            return FieldDefinition.FieldDefinitionDisplayName;
        }
    }
}
