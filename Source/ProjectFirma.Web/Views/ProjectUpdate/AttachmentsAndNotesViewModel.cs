using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using LtInfo.Common.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class AttachmentsAndNotesViewModel : FormViewModel
    {
        [DisplayName("Reviewer Comments")]
        [StringLength(ProjectUpdateBatch.FieldLengths.AttachmentsAndNotesComment)]
        public string Comments { get; set; }

        /// <summary>
        /// Required by the ModelBinder
        /// </summary>
        public AttachmentsAndNotesViewModel()
        {
        }

        public AttachmentsAndNotesViewModel(ProjectUpdateBatch projectUpdateBatch)
        {
            Comments = projectUpdateBatch.AttachmentsAndNotesComment;
        }

    }
}