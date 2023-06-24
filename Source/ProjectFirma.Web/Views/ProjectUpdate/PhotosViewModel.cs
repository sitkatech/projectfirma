using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using LtInfo.Common.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class PhotosViewModel : FormViewModel
    {
        [DisplayName("Reviewer Comments")]
        [StringLength(ProjectUpdateBatch.FieldLengths.PhotosComment)]
        public string Comments { get; set; }

        /// <summary>
        /// Required by the ModelBinder
        /// </summary>
        public PhotosViewModel()
        {
        }

        public PhotosViewModel(ProjectUpdateBatch projectUpdateBatch)
        {
            Comments = projectUpdateBatch.PhotosComment;
        }

    }
}