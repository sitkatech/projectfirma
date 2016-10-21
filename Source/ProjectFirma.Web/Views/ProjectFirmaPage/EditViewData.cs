using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.ProjectFirmaPage
{
    public class EditViewData : LakeTahoeInfoUserControlViewData
    {
        public readonly CkEditorExtension.CkEditorToolbar CkEditorToolbar;
        public readonly string FileBrowserImageUploadUrl;

        public EditViewData(CkEditorExtension.CkEditorToolbar ckEditorToolbar, string fileBrowserImageUploadUrl)
        {
            CkEditorToolbar = ckEditorToolbar;
            FileBrowserImageUploadUrl = fileBrowserImageUploadUrl;
        }
    }
}