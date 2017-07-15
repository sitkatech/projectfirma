using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using GeoJSON.Net.Feature;
using LtInfo.Common;
using LtInfo.Common.Models;
using Newtonsoft.Json;

namespace ProjectFirma.Web.Views.Organization
{
    public class ApproveUploadGisViewModel : FormViewModel, IValidatableObject
    {
        [DisplayName("Organization Boundary"), Required]
        public string OrganizationBoundaryGeoJson { get; set; }

        public static void UpdateModel(Models.Organization organization)
        {
            
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            try
            {
                JsonConvert.DeserializeObject<Feature>(OrganizationBoundaryGeoJson);
            }
            catch
            {
                errors.Add(new SitkaValidationResult<ApproveUploadGisViewModel, string>(
                    "Unable to deserialize Organization Boundary. Make sure the Organization Boundary is valid GeoJSON.",
                    x => x.OrganizationBoundaryGeoJson));
            }

            return errors;
        }
    }
}
