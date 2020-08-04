using System.Collections.Generic;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("View Potential Partners via Match Maker")]
    public class MatchMakerViewPotentialPartnersFeature : FirmaFeature
    {
        public MatchMakerViewPotentialPartnersFeature() : base(new List<Role> { Role.SitkaAdmin, Role.Admin, Role.ProjectSteward }) 
        {
        }
    }
}

