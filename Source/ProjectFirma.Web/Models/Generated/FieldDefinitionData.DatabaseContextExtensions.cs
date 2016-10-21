//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FieldDefinitionData]
using System.Collections.Generic;
using System.Linq;
using EntityFramework.Extensions;
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

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

        public static void DeleteFieldDefinitionData(this IQueryable<FieldDefinitionData> fieldDefinitionDatas, List<int> fieldDefinitionDataIDList)
        {
            if(fieldDefinitionDataIDList.Any())
            {
                fieldDefinitionDatas.Where(x => fieldDefinitionDataIDList.Contains(x.FieldDefinitionDataID)).Delete();
            }
        }

        public static void DeleteFieldDefinitionData(this IQueryable<FieldDefinitionData> fieldDefinitionDatas, ICollection<FieldDefinitionData> fieldDefinitionDatasToDelete)
        {
            if(fieldDefinitionDatasToDelete.Any())
            {
                var fieldDefinitionDataIDList = fieldDefinitionDatasToDelete.Select(x => x.FieldDefinitionDataID).ToList();
                fieldDefinitionDatas.Where(x => fieldDefinitionDataIDList.Contains(x.FieldDefinitionDataID)).Delete();
            }
        }

        public static void DeleteFieldDefinitionData(this IQueryable<FieldDefinitionData> fieldDefinitionDatas, int fieldDefinitionDataID)
        {
            DeleteFieldDefinitionData(fieldDefinitionDatas, new List<int> { fieldDefinitionDataID });
        }

        public static void DeleteFieldDefinitionData(this IQueryable<FieldDefinitionData> fieldDefinitionDatas, FieldDefinitionData fieldDefinitionDataToDelete)
        {
            DeleteFieldDefinitionData(fieldDefinitionDatas, new List<FieldDefinitionData> { fieldDefinitionDataToDelete });
        }
    }
}