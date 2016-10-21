using LtInfo.Common.HtmlHelperExtensions;

namespace ProjectFirma.Web.Models
{
    public partial class FieldDefinitionData : IFieldDefinitionData
    {
        public FieldDefinitionData(int fieldDefinitionID, string fieldDefinitionDataValue)
        {
            FieldDefinitionID = fieldDefinitionID;
            FieldDefinitionDataValue = fieldDefinitionDataValue;
        }
    }
}