namespace LtInfo.Common.AgGridWrappers
{
    public class SelectProjectsModalDialogForm
    {
        public string DialogUrl;
        public string DialogLinkText;
        public string DialogTitle;
        public int CheckboxColumnIndex;
        public string ValueColumnName;
        public string ReturnListName;

        public SelectProjectsModalDialogForm(string dialogUrl, string dialogLinkText, string dialogTitle)
        {
            DialogUrl = dialogUrl;
            DialogLinkText = dialogLinkText;
            DialogTitle = dialogTitle;
            CheckboxColumnIndex = 0;
            ValueColumnName = "ProjectIDForModal";
            ReturnListName = "ProjectIDList";
        }
    }
}