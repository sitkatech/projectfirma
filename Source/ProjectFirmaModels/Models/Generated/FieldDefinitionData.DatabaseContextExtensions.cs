//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FieldDefinitionData]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static FieldDefinitionData GetFieldDefinitionData(this IQueryable<FieldDefinitionData> fieldDefinitionDatas, int fieldDefinitionDataID)
        {
            var fieldDefinitionData = fieldDefinitionDatas.SingleOrDefault(x => x.FieldDefinitionDataID == fieldDefinitionDataID);
            Check.RequireNotNullThrowNotFound(fieldDefinitionData, "FieldDefinitionData", fieldDefinitionDataID);
            return fieldDefinitionData;
        }

    }
}