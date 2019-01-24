using System.Linq;
using System.Web;
using LtInfo.Common.HtmlHelperExtensions;

namespace ProjectFirmaModels.Models
{
    public partial class ClassificationSystem : IAuditableEntity, IFieldDefinitionData, IFieldDefinition
    {
        public string GetAuditDescriptionString() => ClassificationSystemName;

        public string ClassificationSystemNamePluralized => FieldDefinition.PluralizationService.Pluralize(ClassificationSystemName);


        public int FieldDefinitionDataID { get; }
        public string FieldDefinitionLabel => ClassificationSystemName;
        public HtmlString FieldDefinitionDataValueHtmlString => ClassificationSystemDefinitionHtmlString;      

        public IFieldDefinitionData GetFieldDefinitionData()
        {
            return this;
        }

        public string GetFieldDefinitionLabel()
        {
            return ClassificationSystemName;
        }

        public string GetContentUrl()
        {
            return ClassificationSystemModelExtensions.GetContentUrlImpl(this);
        }

        public bool HasClassifications => Classifications.Any();
    }
}