using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Manage Indicator")]
    public class IndicatorManageFeature : LakeTahoeInfoFeature
    {
        public IndicatorManageFeature() : base(new List<LTInfoRole> { LTInfoRole.IndicatorEditor, LTInfoRole.Admin }) { }
    }
}