using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Common
{
    public interface IFieldDefinitionDisplayAttribute
    {
        FieldDefinition FieldDefinition { get; }
    }
}