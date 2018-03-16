using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Delete proposed projects")]
    public class ProjectDeleteProposalFeature : FirmaFeatureWithContext, IFirmaBaseFeatureWithContext<Project>
    {
        private readonly FirmaFeatureWithContextImpl<Project> _lakeTahoeInfoFeatureWithContextImpl;

        public ProjectDeleteProposalFeature() : base(FirmaBaseFeatureHelpers.AllRolesExceptUnassigned)
        {
            _lakeTahoeInfoFeatureWithContextImpl = new FirmaFeatureWithContextImpl<Project>(this);
            ActionFilter = _lakeTahoeInfoFeatureWithContextImpl;
        }

        public void DemandPermission(Person person, Project contextModelObject)
        {
            _lakeTahoeInfoFeatureWithContextImpl.DemandPermission(person, contextModelObject);
        }

        public PermissionCheckResult HasPermission(Person person, Project contextModelObject)
        {
            var permissionDeniedMessage = $"Project {contextModelObject.DisplayName} is not deletable by you";
            if (new ProjectDeleteFeature().HasPermission(person, contextModelObject).HasPermission)
            {
                return new PermissionCheckResult();
            }

            return contextModelObject.IsMyProject(person) && (contextModelObject.ProjectApprovalStatus == ProjectApprovalStatus.Draft || contextModelObject.ProjectApprovalStatus == ProjectApprovalStatus.Rejected)
                ? new PermissionCheckResult()
                : new PermissionCheckResult(permissionDeniedMessage);
        }
    }
}