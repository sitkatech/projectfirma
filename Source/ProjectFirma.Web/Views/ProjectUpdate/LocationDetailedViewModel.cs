using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class LocationDetailedViewModel : ProjectLocationDetailViewModel
    {
        [DisplayName("Comments")]
        [StringLength(ProjectUpdateBatch.FieldLengths.LocationDetailedComment)]
        public string Comments { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public LocationDetailedViewModel()
        {
        }

        public LocationDetailedViewModel(string comments)
        {
            Comments = comments;
        }
    }
}