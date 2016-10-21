using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    /// <summary>
    /// Must be at least logged in
    /// </summary>
    [SecurityFeatureDescription("Has a Lake Tahoe Info role")]
    public class LoggedInUnclassifiedFeature : LakeTahoeInfoFeature
    {
        public LoggedInUnclassifiedFeature()
            : base(LTInfoRole.All)
        {
        }
    }
}