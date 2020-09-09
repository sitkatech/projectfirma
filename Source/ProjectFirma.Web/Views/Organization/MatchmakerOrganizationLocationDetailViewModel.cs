using System.Collections.Generic;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.Organization
{
    public class MatchmakerOrganizationLocationDetailViewModel : FormViewModel
    {
        public MatchmakerOrganizationLocationDetailViewModel()
        {
        }

        public class WktAndOtherInfo
        {
            public string Wkt { get; set; }
            public string Annotation { get; set; }
            public string LayerSource { get; set; }
        }

        public MatchmakerOrganizationLocationDetailViewModel(ProjectFirmaModels.Models.Organization organization)
        {
            UseOrganizationBoundaryForMatchmaker = organization.UseOrganizationBoundaryForMatchmaker;
        }

        public List<WktAndOtherInfo> WktAndOtherInfos { get; set; }
        public bool UseOrganizationBoundaryForMatchmaker { get; set; }
    }
}