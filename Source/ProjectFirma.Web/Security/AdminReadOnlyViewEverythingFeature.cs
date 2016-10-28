using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    /// <summary>
    /// User can view -- but not necessarily edit -- all details of a particular Project, including Admin-level information
    /// </summary>
    [SecurityFeatureDescription("_Admin / TMPO Manager / ReadOnlyAdmin")]
    public class AdminReadOnlyViewEverythingFeature : FirmaFeature
    {
        public AdminReadOnlyViewEverythingFeature()
            : base(new List<Role> { Role.ReadOnlyAdmin, Role.SitkaAdmin, Role.Admin, Role.TMPOManager })
        {
        }
    }
}