using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.Organization
{
    public class ApproveUploadGisViewModel : FormViewModel
    {
        [DisplayName("Organization Boundary Polygon"), Required]
        public string OrganizationBoundaryGeoJson { get; set; }
    }
}
