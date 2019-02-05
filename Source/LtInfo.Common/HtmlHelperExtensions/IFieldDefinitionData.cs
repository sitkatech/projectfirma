using System.Web;

namespace LtInfo.Common.HtmlHelperExtensions
{
    public interface IFieldDefinitionData
    {
        int FieldDefinitionDataID { get; }
        string FieldDefinitionLabel { get; }
        HtmlString FieldDefinitionDataValueHtmlString { get; }
    }
}