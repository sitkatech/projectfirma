/*-----------------------------------------------------------------------
<copyright file="FieldDefinitionDisplayAttribute.cs" company="Tahoe Regional Planning Agency">
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
using System.ComponentModel;
using ProjectFirma.Web.Models;
using LtInfo.Common.HtmlHelperExtensions;

namespace ProjectFirma.Web.Common
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class FieldDefinitionDisplayAttribute : DisplayNameAttribute, IFieldDefinitionDisplayAttribute
    {
        public IFieldDefinition FieldDefinition { get; private set; }

        public FieldDefinitionDisplayAttribute(FieldDefinitionEnum fieldDefinitionEnum) : base(Models.FieldDefinition.ToType(fieldDefinitionEnum).FieldDefinitionDisplayName)
        {
            FieldDefinition = Models.FieldDefinition.ToType(fieldDefinitionEnum);
        }
    }
}
