/*-----------------------------------------------------------------------
<copyright file="FieldDefinitionData.DatabaseContextExtensions.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
        public static FieldDefinitionData GetFieldDefinitionDataByFieldDefinition(this IQueryable<FieldDefinitionData> fieldDefinitionDatas, FieldDefinition fieldDefinition)
        {
            return GetFieldDefinitionDataByFieldDefinition(fieldDefinitionDatas, fieldDefinition.FieldDefinitionID);
        }

        public static FieldDefinitionData GetFieldDefinitionDataByFieldDefinition(this IQueryable<FieldDefinitionData> fieldDefinitionDatas, int fieldDefinitionID)
        {
            return fieldDefinitionDatas.SingleOrDefault(x => x.FieldDefinitionID == fieldDefinitionID);
        }

        public static FieldDefinitionData GetFieldDefinitionDataByFieldDefinition(this IQueryable<FieldDefinitionData> fieldDefinitionDatas, FieldDefinitionEnum fieldDefinitionEnum)
        {
            return fieldDefinitionDatas.SingleOrDefault(x => x.FieldDefinitionID == (int) fieldDefinitionEnum);
        }

        public static FieldDefinitionData GetFieldDefinitionDataByFieldDefinition(this IQueryable<FieldDefinitionData> fieldDefinitionDatas, FieldDefinitionPrimaryKey fieldDefinitionPrimaryKey)
        {
            return fieldDefinitionDatas.SingleOrDefault(x => x.FieldDefinitionID == fieldDefinitionPrimaryKey.PrimaryKeyValue);
        }
    }
}
