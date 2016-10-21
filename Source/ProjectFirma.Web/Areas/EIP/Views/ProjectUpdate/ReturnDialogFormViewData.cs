namespace ProjectFirma.Web.Areas.EIP.Views.ProjectUpdate
{
    public class ReturnDialogFormViewData
    {
        public readonly string ConfirmMessage;
        public readonly bool CanProceed;

        public ReturnDialogFormViewData(string confirmMessage) : this(confirmMessage, true)
        {
        }

        public ReturnDialogFormViewData(string confirmMessage, bool canProceed)
        {
            ConfirmMessage = confirmMessage;
            CanProceed = canProceed;
        }
    }
}