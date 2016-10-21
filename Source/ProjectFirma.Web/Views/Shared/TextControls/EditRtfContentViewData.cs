using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.Shared.TextControls
{
    public class EditRtfContentViewData : LakeTahoeInfoUserControlViewData
    {
        public readonly CkEditorExtension.CkEditorToolbar CkEditorToolbar;
        public readonly string FileBrowserImageUploadUrl;

        public EditRtfContentViewData(CkEditorExtension.CkEditorToolbar ckEditorToolbar, string fileBrowserImageUploadUrl)
        {
            CkEditorToolbar = ckEditorToolbar;
            FileBrowserImageUploadUrl = fileBrowserImageUploadUrl;
        }
    }
}