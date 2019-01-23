using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class FieldDefinitionModelExtensions
    {
        public static FieldDefinition ToType(this FieldDefinitionEnum fieldDefinitionEnum)
        {
            return HttpRequestStorage.DatabaseEntities.FieldDefinitions.SingleOrDefault(x =>
                x.FieldDefinitionID == (int) fieldDefinitionEnum);
        }
        public static FieldDefinition ToType(int fieldDefinitionID)
        {
            return HttpRequestStorage.DatabaseEntities.FieldDefinitions.SingleOrDefault(x =>
                x.FieldDefinitionID == fieldDefinitionID);
        }
    }
}