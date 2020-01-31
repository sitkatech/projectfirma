using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using LtInfo.Common.Models;
using Newtonsoft.Json;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ProjectStatus
{
    public class EditViewModel : FormViewModel, IValidatableObject
    {
        public int ProjectStatusID { get; set; }

        [Required]
        [StringLength(ProjectFirmaModels.Models.ProjectStatus.FieldLengths.ProjectStatusName)]
        [DisplayName("Name")]
        public string ProjectStatusName { get; set; }

        [Required]
        [StringLength(ProjectFirmaModels.Models.ProjectStatus.FieldLengths.ProjectStatusDisplayName)]
        [DisplayName("Display Name")]
        public string ProjectStatusDisplayName { get; set; }

        [Required]
        [StringLength(ProjectFirmaModels.Models.ProjectStatus.FieldLengths.ProjectStatusDescription)]
        [DisplayName("Description")]
        public string ProjectStatusDescription { get; set; }

        [Required]
        [StringLength(ProjectFirmaModels.Models.ProjectStatus.FieldLengths.ProjectStatusColor)]
        [DisplayName("Color")]
        public string ProjectStatusColor { get; set; }


        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditViewModel()
        {
        }

        public EditViewModel(ProjectFirmaModels.Models.ProjectStatus projectStatus)
        {
            ProjectStatusName = projectStatus.ProjectStatusName;
            ProjectStatusDisplayName = projectStatus.ProjectStatusDisplayName;
            ProjectStatusDescription = projectStatus.ProjectStatusDescription;
            ProjectStatusColor = projectStatus.ProjectStatusColor;

        }


        public void UpdateModel(ProjectFirmaModels.Models.ProjectStatus projectStatus, FirmaSession currentFirmaSession)
        {
            projectStatus.ProjectStatusName = ProjectStatusName;
            projectStatus.ProjectStatusDisplayName = ProjectStatusDisplayName;
            projectStatus.ProjectStatusDescription = ProjectStatusDescription;
            projectStatus.ProjectStatusColor = ProjectStatusColor;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            return results;

        }
    }
}
