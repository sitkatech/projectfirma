/*-----------------------------------------------------------------------
<copyright file="WebServiceDocumentationAttribute.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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

namespace ProjectFirma.Web.Common
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class WebServiceDocumentationAttribute : Attribute
    {
        public string Documentation;

        public WebServiceDocumentationAttribute(string formatString, FieldDefinitionEnum fieldDefinitionEnum)
        {
            Documentation = string.Format(formatString, FieldDefinition.ToType(fieldDefinitionEnum).GetFieldDefinitionLabel());
        }

        public WebServiceDocumentationAttribute(string formatString, FieldDefinitionEnum fieldDefinitionEnum1, FieldDefinitionEnum fieldDefinitionEnum2)
        {
            Documentation = string.Format(formatString, FieldDefinition.ToType(fieldDefinitionEnum1).GetFieldDefinitionLabel(), FieldDefinition.ToType(fieldDefinitionEnum2).GetFieldDefinitionLabel());
        }

        public WebServiceDocumentationAttribute(string formatString, FieldDefinitionEnum fieldDefinitionEnum1, FieldDefinitionEnum fieldDefinitionEnum2, FieldDefinitionEnum fieldDefinitionEnum3, FieldDefinitionEnum fieldDefinitionEnum4)
        {
            Documentation = string.Format(formatString, FieldDefinition.ToType(fieldDefinitionEnum1).GetFieldDefinitionLabel(), FieldDefinition.ToType(fieldDefinitionEnum2).GetFieldDefinitionLabel(), FieldDefinition.ToType(fieldDefinitionEnum3).GetFieldDefinitionLabel(), FieldDefinition.ToType(fieldDefinitionEnum4).GetFieldDefinitionLabel());
        }

        public WebServiceDocumentationAttribute(string s)
        {
            Documentation = s;
        }
    }
}
