namespace ProjectFirma.Web.Models
{
    public class FeaturePermission
    {
        public string FeatureName;
        public bool HasPermission;

        public FeaturePermission(string featureName, bool hasPermission)
        {
            FeatureName = featureName;
            HasPermission = hasPermission;
        }
    }
}