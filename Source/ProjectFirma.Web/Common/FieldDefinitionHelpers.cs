/*-----------------------------------------------------------------------
<copyright file="FieldDefinitionHelpers.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
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

using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Common
{
    public static class FieldDefinitionHelpers
    {
        public static string ToGridHeaderString(this FieldDefinition fieldDefinition)
        {
            return fieldDefinition.ToGridHeaderString(LabelWithSugarForExtensions.DefaultPopupWidth, fieldDefinition.GetFieldDefinitionLabel());
        }

        public static string ToGridHeaderString(this FieldDefinition fieldDefinition, string linkText)
        {
            return fieldDefinition.ToGridHeaderString(LabelWithSugarForExtensions.DefaultPopupWidth, linkText);
        }

        public static string ToGridHeaderString(this FieldDefinition fieldDefinition, int popupWidth)
        {
            return fieldDefinition.ToGridHeaderString(popupWidth, fieldDefinition.GetFieldDefinitionLabel());
        }

        public static string ToGridHeaderStringPlural(this FieldDefinition fieldDefinition, string displayNamePlural) //there should be a better way to pass this
        {
            return fieldDefinition.ToGridHeaderString(displayNamePlural);
        }

        public static string ToGridHeaderStringPlural(this FieldDefinition fieldDefinition)
        {
            return fieldDefinition.ToGridHeaderString(fieldDefinition.GetFieldDefinitionLabelPluralized());
        }

        private static string ToGridHeaderString(this FieldDefinition fieldDefinition, int popupWidth, string fieldDefinitionDisplayName)
        {
            return
                LabelWithSugarForExtensions.LabelWithSugarFor(fieldDefinition,
                    LabelWithSugarForExtensions.DisplayStyle.AsGridHeader, fieldDefinitionDisplayName).ToString();
        }

        public static string ToGridHeaderString(this ClassificationSystem classificationSystem)
        {
            return
                LabelWithSugarForExtensions.LabelWithSugarFor(classificationSystem, classificationSystem.ClassificationSystemName.Replace(" ", ""), LabelWithSugarForExtensions.DefaultPopupWidth,
                    LabelWithSugarForExtensions.DisplayStyle.AsGridHeader, false, classificationSystem.ClassificationSystemName, classificationSystem.GetContentUrl()).ToString();
        }

    }
}
