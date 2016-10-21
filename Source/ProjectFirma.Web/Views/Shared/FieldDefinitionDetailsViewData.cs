using System.Web;

namespace ProjectFirma.Web.Views.Shared
{
    public class FieldDefinitionDetailsViewData : LakeTahoeInfoUserControlViewData
    {
        public readonly HtmlString FieldDefinition;

        public FieldDefinitionDetailsViewData(HtmlString fieldDefinition)
        {
            FieldDefinition = fieldDefinition;
        }
    }
}