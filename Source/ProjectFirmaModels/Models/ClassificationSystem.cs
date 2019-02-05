using System.Linq;
using System.Web;
using LtInfo.Common.HtmlHelperExtensions;

namespace ProjectFirmaModels.Models
{
    public partial class ClassificationSystem : IAuditableEntity, IFieldDefinitionData
    {
        public string GetAuditDescriptionString() => ClassificationSystemName;


        public int FieldDefinitionDataID { get; }
        public string FieldDefinitionLabel => ClassificationSystemName;
        public HtmlString FieldDefinitionDataValueHtmlString => ClassificationSystemDefinitionHtmlString;      

        public bool HasClassifications => Classifications.Any();
    }
}