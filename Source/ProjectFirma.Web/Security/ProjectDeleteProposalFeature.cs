using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

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

        public void DemandPermission(FirmaSession firmaSession, Project contextModelObject)
        {
            _lakeTahoeInfoFeatureWithContextImpl.DemandPermission(firmaSession, contextModelObject);
        }

        public PermissionCheckResult HasPermission(FirmaSession firmaSession, Project contextModelObject)
        {
            var permissionDeniedMessage = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {contextModelObject.GetDisplayName()} is not deletable by you";
            if (new ProjectDeleteFeature().HasPermission(firmaSession, contextModelObject).HasPermission)
            {
                return new PermissionCheckResult();
            }

            return contextModelObject.IsMyProject(firmaSession) && (contextModelObject.ProjectApprovalStatus == ProjectApprovalStatus.Draft || contextModelObject.ProjectApprovalStatus == ProjectApprovalStatus.Rejected)
                ? new PermissionCheckResult()
                : new PermissionCheckResult(permissionDeniedMessage);
        }
    }
}