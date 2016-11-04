namespace LtInfo.Common.DhtmlWrappers
{
    public class BulkTagModalDialogForm
    {
        public string DialogUrl;
        public string DialogLinkText;
        public string DialogTitle;
        public int CheckboxColumnIndex;
        public string ValueColumnName;
        public string ReturnListName;

        public BulkTagModalDialogForm(string dialogUrl)
        {
            DialogUrl = dialogUrl;
            DialogLinkText = "Tag Checked Projects";
            DialogTitle = "Tag Projects";
            CheckboxColumnIndex = 0;
            ValueColumnName = "ProjectID";
            ReturnListName = "ProjectIDList";

        }
    }
}