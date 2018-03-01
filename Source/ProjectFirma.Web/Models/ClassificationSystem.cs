using System.Linq;
using System.Web;
using LtInfo.Common.HtmlHelperExtensions;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;

namespace ProjectFirma.Web.Models
{
    public partial class ClassificationSystem : IAuditableEntity, IFieldDefinitionData, IFieldDefinition
    {
        public string AuditDescriptionString => ClassificationSystemName;

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
            return SitkaRoute<FieldDefinitionController>.BuildUrlFromExpression(x => x.FieldDefinitionDetailsForClassificationSystem(ClassificationSystemID));
        }

        public bool HasClassifications => Classifications.Any();
    }
}