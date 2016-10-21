using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    public abstract class LakeTahoeInfoFeature : LakeTahoeInfoBaseFeature
    {
        protected LakeTahoeInfoFeature(List<LTInfoRole> roles) : base(roles.Select(x => (IRole)x).ToList(), LTInfoArea.LTInfo) { }
    }
}