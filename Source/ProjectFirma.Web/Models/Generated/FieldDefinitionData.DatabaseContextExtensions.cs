//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FieldDefinitionData]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static FieldDefinitionData GetFieldDefinitionData(this IQueryable<FieldDefinitionData> fieldDefinitionDatas, int fieldDefinitionDataID)
        {
            var fieldDefinitionData = fieldDefinitionDatas.SingleOrDefault(x => x.FieldDefinitionDataID == fieldDefinitionDataID);
            Check.RequireNotNullThrowNotFound(fieldDefinitionData, "FieldDefinitionData", fieldDefinitionDataID);
            return fieldDefinitionData;
        }

        public static void DeleteFieldDefinitionData(this List<int> fieldDefinitionDataIDList)
        {
            if(fieldDefinitionDataIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllFieldDefinitionDatas.RemoveRange(HttpRequestStorage.DatabaseEntities.FieldDefinitionDatas.Where(x => fieldDefinitionDataIDList.Contains(x.FieldDefinitionDataID)));
            }
        }

        public static void DeleteFieldDefinitionData(this ICollection<FieldDefinitionData> fieldDefinitionDatasToDelete)
        {
            if(fieldDefinitionDatasToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllFieldDefinitionDatas.RemoveRange(fieldDefinitionDatasToDelete);
            }
        }

        public static void DeleteFieldDefinitionData(this int fieldDefinitionDataID)
        {
            DeleteFieldDefinitionData(new List<int> { fieldDefinitionDataID });
        }

        public static void DeleteFieldDefinitionData(this FieldDefinitionData fieldDefinitionDataToDelete)
        {
            DeleteFieldDefinitionData(new List<FieldDefinitionData> { fieldDefinitionDataToDelete });
        }
    }
}