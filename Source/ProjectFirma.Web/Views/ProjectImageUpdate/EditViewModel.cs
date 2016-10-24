using System.ComponentModel.DataAnnotations;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.ProjectImageUpdate
{
    public class EditViewModel : FormViewModel
    {
        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.PhotoCaption)]
        [StringLength(Models.ProjectImageUpdate.FieldLengths.Caption)]
        public string Caption { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.PhotoCredit)]
        [StringLength(Models.ProjectImageUpdate.FieldLengths.Credit)]
        public string Credit { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.PhotoTiming)]
        public int ProjectImageTimingID { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.ExcludeFromFactSheet)]
        public bool ExcludeFromFactSheet { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditViewModel()
        {
        }

        public EditViewModel(Models.ProjectImageUpdate projectImageUpdate)
        {
            Caption = projectImageUpdate.Caption;
            Credit = projectImageUpdate.Credit;
            ProjectImageTimingID = projectImageUpdate.ProjectImageTimingID;
            ExcludeFromFactSheet = projectImageUpdate.ExcludeFromFactSheet;
        }

        public virtual void UpdateModel(Models.ProjectImageUpdate projectImageUpdate, Person person)
        {
            projectImageUpdate.Caption = Caption;
            projectImageUpdate.Credit = Credit;
            projectImageUpdate.ProjectImageTimingID = ProjectImageTimingID;
            projectImageUpdate.ExcludeFromFactSheet = ExcludeFromFactSheet;
        }
    }
}