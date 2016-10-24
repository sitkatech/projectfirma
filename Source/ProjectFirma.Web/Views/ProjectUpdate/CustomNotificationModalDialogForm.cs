namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class CustomNotificationModalDialogForm
    {
        public string DialogUrl;
        public string DialogLinkText;
        public string DialogTitle;
        public int CheckboxColumnIndex;
        public string ValueColumnName;
        public string ReturnListName;

        public CustomNotificationModalDialogForm(string dialogUrl)
        {
            DialogUrl = dialogUrl;
            DialogLinkText = "Send Custom Notification";
            DialogTitle = "Custon Notification";
            CheckboxColumnIndex = 0;
            ValueColumnName = "PersonID";
            ReturnListName = "PersonIDList";

        }
    }
}