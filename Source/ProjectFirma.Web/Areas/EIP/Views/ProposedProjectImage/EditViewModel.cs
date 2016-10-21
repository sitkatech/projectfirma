using System.ComponentModel.DataAnnotations;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Areas.EIP.Views.ProposedProjectImage
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

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditViewModel()
        {
        }

        public EditViewModel(Models.ProposedProjectImage proposedProjectImage)
        {
            Caption = proposedProjectImage.Caption;
            Credit = proposedProjectImage.Credit;
        }

        public virtual void UpdateModel(Models.ProposedProjectImage proposedProjectImage, Person person)
        {
            proposedProjectImage.Caption = Caption;
            proposedProjectImage.Credit = Credit;
        }
    }
}