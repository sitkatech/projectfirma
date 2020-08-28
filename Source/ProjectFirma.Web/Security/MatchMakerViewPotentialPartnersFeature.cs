using System.Collections.Generic;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("View Potential Partners via Match Maker")]
    public class MatchMakerViewPotentialPartnersFeature : FirmaFeature
    {
        public MatchMakerViewPotentialPartnersFeature() : base(new List<Role> { Role.SitkaAdmin, Role.Admin, Role.ProjectSteward }) 
        {
        }

        public override bool HasPermissionByPerson(Person person)
        {
            return FirmaWebConfiguration.FeatureMatchMakerEnabled && 
                   MultiTenantHelpers.GetTenantAttributeFromCache().EnableMatchmaker && 
                   base.HasPermissionByPerson(person);
        }

        public override bool HasPermissionByFirmaSession(FirmaSession firmaSession)
        {
            return FirmaWebConfiguration.FeatureMatchMakerEnabled &&
                   MultiTenantHelpers.GetTenantAttributeFromCache().EnableMatchmaker &&
                   base.HasPermissionByFirmaSession(firmaSession);
        }
    }
}

