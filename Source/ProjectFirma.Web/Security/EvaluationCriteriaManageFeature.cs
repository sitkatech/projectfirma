using System;
using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Manage Evaluation Criteria Content")]
    public class EvaluationCriteriaManageFeature : FirmaFeatureWithContext, IFirmaBaseFeatureWithContext<EvaluationCriteria>
    {
        private readonly FirmaFeatureWithContextImpl<EvaluationCriteria> _firmaFeatureWithContextImpl;

        public EvaluationCriteriaManageFeature(): base(new List<Role>{Role.Admin, Role.SitkaAdmin})
        {
            _firmaFeatureWithContextImpl = new FirmaFeatureWithContextImpl<EvaluationCriteria>(this);
            ActionFilter = _firmaFeatureWithContextImpl;
        }

        public void DemandPermission(FirmaSession firmaSession, EvaluationCriteria contextModelObject)
        {
            _firmaFeatureWithContextImpl.DemandPermission(firmaSession, contextModelObject);
        }

        public static bool HasEvaluationCriteriaManagePermission(FirmaSession currentFirmaSession, EvaluationCriteria evaluationCriteria)
        {
            var permissionCheckResult = new EvaluationCriteriaManageFeature().HasPermission(currentFirmaSession, evaluationCriteria);
            return permissionCheckResult.HasPermission;
        }

        public PermissionCheckResult HasPermission(FirmaSession firmaSession, EvaluationCriteria contextModelObject)
        {
            if (firmaSession.IsAnonymousOrUnassigned())
            {
                return new PermissionCheckResult("Anonymous users can't manage evaluation criteria");
            }

            var evaluation = contextModelObject.Evaluation;
            var permissionCheckResult = new EvaluationManageFeature().HasPermission(firmaSession, evaluation);
            return permissionCheckResult;
            
        }
    }
}