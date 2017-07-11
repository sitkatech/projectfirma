using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using LtInfo.Common;
using LtInfo.Common.Models;
using LtInfo.Common.Mvc;

namespace ProjectFirma.Web.Views.Organization
{
    public class EditBoundaryViewModel : FormViewModel, IValidatableObject
    {
        [Required, DisplayName("GIS File to Upload"), SitkaFileExtensions("zip")]
        public HttpPostedFileBase FileResourceData { get; set; }

        public void UpdateModel()
        {
            // Saving goes here
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            // Todo validations go here

            return errors;
        }
    }
}
