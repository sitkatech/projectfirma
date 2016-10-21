using System.ComponentModel.DataAnnotations;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Areas.EIP.Views.ProjectImage
{
    public class EditViewModel : FormViewModel
    {
        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.PhotoCaption)]
        [StringLength(Models.ProjectImage.FieldLengths.Caption)]
        public string Caption { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.PhotoCredit)]
        [StringLength(Models.ProjectImage.FieldLengths.Credit)]
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

        public EditViewModel(Models.ProjectImage projectImage)
        {
            Caption = projectImage.Caption;
            Credit = projectImage.Credit;
            ProjectImageTimingID = projectImage.ProjectImageTimingID;
            ExcludeFromFactSheet = projectImage.ExcludeFromFactSheet;
        }

        public virtual void UpdateModel(Models.ProjectImage projectImage, Person person)
        {
            projectImage.Caption = Caption;
            projectImage.Credit = Credit;
            projectImage.ProjectImageTimingID = ProjectImageTimingID;
            projectImage.ExcludeFromFactSheet = ExcludeFromFactSheet;
        }
    }
}