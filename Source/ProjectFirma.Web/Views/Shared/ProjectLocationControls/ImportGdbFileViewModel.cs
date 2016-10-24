using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Mvc;

namespace ProjectFirma.Web.Views.Shared.ProjectControls
{
    public class ImportGdbFileViewModel : IValidatableObject
    {
        [Required]
        [DisplayName("Zipped File Geodatabase to Upload")]
        [SitkaFileExtensions("zip")]
        public HttpPostedFileBase FileResourceData { get; set; }

        public void UpdateModel(Models.Project project, Person person)
        {
            //projectLocation.FileResource = FileResource.CreateNewFromHttpPostedFile(FileResourceData, person);
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();
            FileResource.ValidateFileSize(FileResourceData, errors, GeneralUtility.NameOf(() => FileResourceData));
            return errors;
        }
    }
}