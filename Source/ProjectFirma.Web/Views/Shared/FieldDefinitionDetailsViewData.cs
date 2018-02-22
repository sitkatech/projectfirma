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
using LtInfo.Common.HtmlHelperExtensions;

namespace ProjectFirma.Web.Views.Shared
{
    public class FieldDefinitionDetailsViewData : FirmaUserControlViewData
    {
        private readonly IFieldDefinitionData _fieldDefinitionData;
        public readonly bool ShowEditLink;
        public readonly string EditUrl;
        public readonly HtmlString DefaultDefinitionHtmlString;
        public readonly string FieldDefinitionLabel;

        public FieldDefinitionDetailsViewData(IFieldDefinitionData fieldDefinitionData, bool showEditLink, string editUrl, HtmlString defaultDefinitionHtmlString, string fieldDefinitionLabel)
        {
            _fieldDefinitionData = fieldDefinitionData;
            ShowEditLink = showEditLink;
            EditUrl = editUrl;
            DefaultDefinitionHtmlString = defaultDefinitionHtmlString;
            FieldDefinitionLabel = fieldDefinitionLabel;
        }

        public HtmlString GetFieldDefinition(HtmlString defaultDefinitionHtmlString, string fieldDefinitionLabel)
        {
            if (_fieldDefinitionData != null && _fieldDefinitionData.FieldDefinitionDataValueHtmlString != null)
            {
               return _fieldDefinitionData.FieldDefinitionDataValueHtmlString;
            }
            return defaultDefinitionHtmlString ?? new HtmlString($"{fieldDefinitionLabel} not yet defined.");
        }
    }
}
