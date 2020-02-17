/*-----------------------------------------------------------------------
<copyright file="FieldDefinitionDefault.DefaultbaseContextExtensions.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Linq;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static FieldDefinitionDefault GetFieldDefinitionDefaultByFieldDefinition(this IQueryable<FieldDefinitionDefault> fieldDefinitionDefaults, FieldDefinition fieldDefinition)
        {
            return GetFieldDefinitionDefaultByFieldDefinition(fieldDefinitionDefaults, fieldDefinition.FieldDefinitionID);
        }

        public static FieldDefinitionDefault GetFieldDefinitionDefaultByFieldDefinition(this IQueryable<FieldDefinitionDefault> fieldDefinitionDefaults, int fieldDefinitionID)
        {
            return fieldDefinitionDefaults.SingleOrDefault(x => x.FieldDefinitionID == fieldDefinitionID);
        }

        public static FieldDefinitionDefault GetFieldDefinitionDefaultByFieldDefinition(this IQueryable<FieldDefinitionDefault> fieldDefinitionDefaults, FieldDefinitionEnum fieldDefinitionEnum)
        {
            return fieldDefinitionDefaults.SingleOrDefault(x => x.FieldDefinitionID == (int) fieldDefinitionEnum);
        }

        public static FieldDefinitionDefault GetFieldDefinitionDefaultByFieldDefinition(this IQueryable<FieldDefinitionDefault> fieldDefinitionDefaults, FieldDefinitionPrimaryKey fieldDefinitionPrimaryKey)
        {
            return fieldDefinitionDefaults.SingleOrDefault(x => x.FieldDefinitionID == fieldDefinitionPrimaryKey.PrimaryKeyValue);
        }
    }
}
