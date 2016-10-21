using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security.Shared
{
    [SecurityFeatureDescription("Anonymous Access")]
    public class AnonymousUnclassifiedFeature : LakeTahoeInfoBaseFeature
    {
        public AnonymousUnclassifiedFeature() : base(new List<IRole>(), null)
        {
        }
    }
}