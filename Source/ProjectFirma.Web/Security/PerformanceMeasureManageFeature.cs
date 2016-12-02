using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Manage PerformanceMeasure")]
    public class PerformanceMeasureManageFeature : FirmaFeature
    {
        public PerformanceMeasureManageFeature() : base(new List<Role> { Role.SitkaAdmin, Role.Admin }) { }
    }
}