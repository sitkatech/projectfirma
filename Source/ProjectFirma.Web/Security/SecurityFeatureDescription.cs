/*-----------------------------------------------------------------------
<copyright file="SecurityFeatureDescription.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Security
{
    public class SecurityFeatureDescription : Attribute
    {
        public string DescriptionMessage;

        public SecurityFeatureDescription(string formatString, FieldDefinitionEnum fieldDefinitionEnum)
        {
            DescriptionMessage = string.Format(formatString, fieldDefinitionEnum.ToType().GetFieldDefinitionLabel());
        }
        public SecurityFeatureDescription(string formatString, FieldDefinitionEnum fieldDefinitionEnum1, FieldDefinitionEnum fieldDefinitionEnum2)
        {
            DescriptionMessage = string.Format(formatString, fieldDefinitionEnum1.ToType().GetFieldDefinitionLabel(), fieldDefinitionEnum2.ToType().GetFieldDefinitionLabel());
        }
        public SecurityFeatureDescription(string formatString, FieldDefinitionEnum fieldDefinitionEnum1, FieldDefinitionEnum fieldDefinitionEnum2, FieldDefinitionEnum fieldDefinitionEnum3)
        {
            DescriptionMessage = string.Format(formatString, fieldDefinitionEnum1.ToType().GetFieldDefinitionLabel(), fieldDefinitionEnum2.ToType().GetFieldDefinitionLabel(), fieldDefinitionEnum3.ToType().GetFieldDefinitionLabel());
        }
        public SecurityFeatureDescription(string descriptionMessage)
        {
            DescriptionMessage = descriptionMessage;
        }
    }
}
