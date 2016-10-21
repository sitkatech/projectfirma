using System.Linq;
using System.Web;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using LtInfo.Common;
using LtInfo.Common.HtmlHelperExtensions;

namespace ProjectFirma.Web.Models
{
    public partial class FieldDefinition : IFieldDefinition
    {
        public bool HasDefinition
        {
            get { return HttpRequestStorage.DatabaseEntities.FieldDefinitionDatas.Any(x => x.FieldDefinitionID == FieldDefinitionID); }
        }

        public HtmlString FieldDefinitionDataValue
        {
            get
            {
                var fieldDefinitionData = HttpRequestStorage.DatabaseEntities.FieldDefinitionDatas.GetFieldDefinitionDataByFieldDefinition(this); ;
                return fieldDefinitionData != null ? fieldDefinitionData.FieldDefinitionDataValueHtmlString : new HtmlString(string.Empty);
            }
        }

        public IFieldDefinitionData FieldDefinitionData 
        {
            get { return HttpRequestStorage.DatabaseEntities.FieldDefinitionDatas.GetFieldDefinitionDataByFieldDefinition(this); }
        }
        public string GetContentUrl()
        {
            return SitkaRoute<FieldDefinitionController>.BuildUrlFromExpression(x => x.FieldDefinitionDetails(FieldDefinitionID));
        }
    }
}