using System;

namespace ProjectFirma.Web.Views.Shared
{
    public class ConfirmDialogFormViewData
    {
        public readonly string ConfirmMessage;
        public readonly bool CanProceed;

        public ConfirmDialogFormViewData(string confirmMessage) : this(confirmMessage, true)
        {
        }

        public ConfirmDialogFormViewData(string confirmMessage, bool canProceed)
        {
            ConfirmMessage = confirmMessage;
            CanProceed = canProceed;
        }

        public static string GetStandardCannotDeleteMessage(string objectName)
        {
            return String.Format("You can't delete this {0} because it has associations to other items.", objectName);
        }

        public static string GetStandardCannotDeleteMessage(string objectName, string linkToObjectSummaryPage)
        {
            return String.Format("You can't delete this {0} because it has associations to other items. <span>Click {1} to view it.</span>", objectName, linkToObjectSummaryPage);
        }
    }
}