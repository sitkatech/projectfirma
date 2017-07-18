using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;
using LtInfo.Common;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.Organization
{
    public class ApproveUploadGisViewModel : FormViewModel, IValidatableObject
    {
        [DisplayName("Organization Boundary"), Required]
        public string OrganizationBoundaryWkt { get; set; }

        public void UpdateModel(Models.Organization organization)
        {
            organization.OrganizationBoundary = DbGeometry.FromText(OrganizationBoundaryWkt);
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            try
            {
                DbGeometry.FromText(OrganizationBoundaryWkt);
            }
            catch
            {
                errors.Add(new SitkaValidationResult<ApproveUploadGisViewModel, string>(
                    "Unable to deserialize Organization Boundary. Make sure the Organization Boundary is valid Well-Known Text (WKT).",
                    x => x.OrganizationBoundaryWkt));
            }

            return errors;
        }
    }
}
