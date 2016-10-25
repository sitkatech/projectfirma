using System.Web;

namespace ProjectFirma.Web.Views.Shared
{
    public class FieldDefinitionDetailsViewData : FirmaUserControlViewData
    {
        public readonly HtmlString FieldDefinition;

        public FieldDefinitionDetailsViewData(HtmlString fieldDefinition)
        {
            FieldDefinition = fieldDefinition;
        }
    }
}