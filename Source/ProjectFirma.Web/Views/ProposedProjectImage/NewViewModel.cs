using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Mvc;

namespace ProjectFirma.Web.Views.ProposedProjectImage
{
    public class NewViewModel : EditViewModel, IValidatableObject
    {
        [Required]
        [DisplayName("Image File")]
        [SitkaFileExtensions("jpg|jpeg|gif|png")]
        public HttpPostedFileBase FileResourceData { get; set; }

        public override void UpdateModel(Models.ProposedProjectImage proposedProjectImage, Person person)
        {
            base.UpdateModel(proposedProjectImage, person);
            proposedProjectImage.FileResource = FileResource.CreateNewFromHttpPostedFileAndSave(FileResourceData, person);
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();
            FileResource.ValidateFileSize(FileResourceData, errors, GeneralUtility.NameOf(() => FileResourceData));
            return errors;
        }
    }
}