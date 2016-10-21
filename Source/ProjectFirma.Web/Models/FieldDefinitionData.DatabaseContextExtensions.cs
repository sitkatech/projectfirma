using System.Linq;

namespace ProjectFirma.Web.Models
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