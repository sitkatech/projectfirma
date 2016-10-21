using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.Shared
{
    public class ConfirmDialogFormViewModel : PartialViewModel
    {
        public int ModelIDToUse { get; set; }

        /// <summary>
        /// Needed by Model Binder
        /// </summary>
        public ConfirmDialogFormViewModel()
        {
        }

        public ConfirmDialogFormViewModel(int idToDelete)
        {
            ModelIDToUse = idToDelete;
        }
    }
}