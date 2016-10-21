using ProjectFirma.Web.Controllers;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.FieldDefinition
{
    public class EditViewData : LakeTahoeInfoUserControlViewData
    {
        public readonly string FileBrowserImageUploadUrl;

        public EditViewData(Models.FieldDefinitionPrimaryKey fieldDefinitionPrimaryKey)
        {
            FileBrowserImageUploadUrl = SitkaRoute<FileResourceController>.BuildUrlFromExpression(x => x.CkEditorUploadFileResourceForFieldDefinition(fieldDefinitionPrimaryKey, null));
        }
    }
}