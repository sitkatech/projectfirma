namespace LtInfo.Common.ModalDialog
{
    public class ModalDialogForm
    {
        private const int DefaultWidth = 800;
        private const string DefaultSaveButtonText = "Save";
        private const string DefaultCancelButtonText = "Cancel";

        public readonly string ContentUrl;
        public readonly string DialogTitle;
        public readonly int DialogWidth;
        public readonly string OnJavascriptReadyFunction;
        public readonly string LinkID;

        public readonly string SaveButtonText;
        public readonly string CancelButtonText;

        public ModalDialogForm(string contentUrl)
            : this(null, contentUrl, DefaultWidth, null, null, DefaultSaveButtonText, DefaultCancelButtonText)
        {
        }

        public ModalDialogForm(string contentUrl, string dialogTitle)
            : this(null, contentUrl, DefaultWidth, dialogTitle, null, DefaultSaveButtonText, DefaultCancelButtonText)
        {
        }

        public ModalDialogForm(string contentUrl, int dialogWidth, string dialogTitle)
            : this(null, contentUrl, dialogWidth, dialogTitle, null, DefaultSaveButtonText, DefaultCancelButtonText)
        {
        }

        public ModalDialogForm(string contentUrl, int dialogWidth, string dialogTitle, string onJavascriptReadyFunction)
            : this(null, contentUrl, dialogWidth, dialogTitle, onJavascriptReadyFunction, DefaultSaveButtonText, DefaultCancelButtonText)
        {
        }

        public ModalDialogForm(string linkID, string contentUrl, int dialogWidth, string dialogTitle, string onJavascriptReadyFunction)
            : this(linkID, contentUrl, dialogWidth, dialogTitle, onJavascriptReadyFunction, DefaultSaveButtonText, DefaultCancelButtonText)
        {
        }

        public ModalDialogForm(string linkID, string contentUrl, int dialogWidth, string dialogTitle, string onJavascriptReadyFunction, string saveButtonText, string cancelButtonText)
        {
            ContentUrl = contentUrl;
            DialogWidth = dialogWidth;
            DialogTitle = dialogTitle;
            OnJavascriptReadyFunction = onJavascriptReadyFunction;
            LinkID = linkID;
            SaveButtonText = saveButtonText;
            CancelButtonText = cancelButtonText;
        }
    }
}