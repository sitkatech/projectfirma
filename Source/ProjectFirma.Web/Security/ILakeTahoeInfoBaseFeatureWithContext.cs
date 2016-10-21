using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    public interface ILakeTahoeInfoBaseFeatureWithContext<in T>
    {
        PermissionCheckResult HasPermission(Person person, T contextModelObject);
        void DemandPermission(Person person, T contextModelObject);
        string FeatureName { get; }
    }
}