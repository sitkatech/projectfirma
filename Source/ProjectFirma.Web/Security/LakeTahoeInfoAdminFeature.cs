using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("_Admin for Lake Tahoe Info")]
    public class LakeTahoeInfoAdminFeature : LakeTahoeInfoFeature
    {
        public LakeTahoeInfoAdminFeature() : base(new List<LTInfoRole> { LTInfoRole.Admin }) { }
    }
}