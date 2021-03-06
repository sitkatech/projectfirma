using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;
using LtInfo.Common;
using LtInfo.Common.DbSpatial;
using LtInfo.Common.Models;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Organization
{
    public class ApproveUploadGisViewModel : FormViewModel, IValidatableObject
    {
        [DisplayName("Organization Boundary"), Required]
        public string OrganizationBoundaryWkt { get; set; }

        public void UpdateModel(ProjectFirmaModels.Models.Organization organization, out bool oneHadToBeCorrected)
        {
            oneHadToBeCorrected = false;
            var dbGeom = DbGeometry.FromText(OrganizationBoundaryWkt, LtInfoGeometryConfiguration.DefaultCoordinateSystemId);

            if (!dbGeom.IsValid)
            {
                var sqlInvalid = dbGeom.ToSqlGeometry();
                var sqlValid = sqlInvalid.MakeValid();
                dbGeom = sqlValid.ToDbGeometry(LtInfoGeometryConfiguration.DefaultCoordinateSystemId);
                oneHadToBeCorrected = true;
            }

            organization.OrganizationBoundary = dbGeom;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            try
            {
                DbGeometry.FromText(OrganizationBoundaryWkt, LtInfoGeometryConfiguration.DefaultCoordinateSystemId);
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
