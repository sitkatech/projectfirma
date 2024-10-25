using System.Collections.Generic;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Manage Project Evaluation")]
    public class ProjectEvaluationManageFeature : FirmaFeatureWithContext, IFirmaBaseFeatureWithContext<ProjectEvaluation>
    {
        private readonly FirmaFeatureWithContextImpl<ProjectEvaluation> _firmaFeatureWithContextImpl;

        public ProjectEvaluationManageFeature(): base(new List<Role>{Role.Admin, Role.ESAAdmin})
        {
            _firmaFeatureWithContextImpl = new FirmaFeatureWithContextImpl<ProjectEvaluation>(this);
            ActionFilter = _firmaFeatureWithContextImpl;
        }

        public void DemandPermission(FirmaSession firmaSession, ProjectEvaluation contextModelObject)
        {
            _firmaFeatureWithContextImpl.DemandPermission(firmaSession, contextModelObject);
        }

        public static bool HasProjectEvaluationManagePermission(FirmaSession currentFirmaSession, ProjectEvaluation projectEvaluation)
        {
            var permissionCheckResult = new ProjectEvaluationManageFeature().HasPermission(currentFirmaSession, projectEvaluation);
            return permissionCheckResult.HasPermission;
        }

        public PermissionCheckResult HasPermission(FirmaSession firmaSession, ProjectEvaluation contextModelObject)
        {
            if (!HasPermissionByFirmaSession(firmaSession))
            {
                return new PermissionCheckResult("You do not have permission to manage project evaluations");
            }

            var evaluation = contextModelObject.Evaluation;
            var permissionCheckResult = new EvaluationManageFeature().HasPermission(firmaSession, evaluation);
            return permissionCheckResult;
            
        }
    }
}