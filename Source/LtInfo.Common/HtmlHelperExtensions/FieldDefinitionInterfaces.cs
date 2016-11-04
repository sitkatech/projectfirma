using System.Web;

namespace LtInfo.Common.HtmlHelperExtensions
{    
    public interface IFieldDefinition
    {
        string FieldDefinitionDisplayName { get; }
        IFieldDefinitionData FieldDefinitionData { get; }
        string GetContentUrl();
    }

    public interface IFieldDefinitionData
    {
        HtmlString FieldDefinitionDataValueHtmlString { get; }
    }

    public interface IFieldDefinitionDisplayAttribute
    {
        IFieldDefinition FieldDefinition { get; }
    }

}