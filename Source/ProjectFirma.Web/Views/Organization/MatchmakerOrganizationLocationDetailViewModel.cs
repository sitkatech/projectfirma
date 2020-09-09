using System.Collections.Generic;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.Organization
{
    public class MatchmakerOrganizationLocationDetailViewModel : FormViewModel
    {
        public class WktAndAnnotation
        {
            public string Wkt { get; set; }
            public string Annotation { get; set; }
        }

        public MatchmakerOrganizationLocationDetailViewModel(ProjectFirmaModels.Models.Organization organization)
        {
            UseOrganizationBoundaryForMatchmaker = organization.UseOrganizationBoundaryForMatchmaker;
        }

        public List<WktAndAnnotation> WktAndAnnotations { get; set; }
        public bool UseOrganizationBoundaryForMatchmaker { get; set; }
    }
}