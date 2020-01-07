using System;
using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Manage Evaluation Criterion Content")]
    public class EvaluationCriterionManageFeature : FirmaFeatureWithContext, IFirmaBaseFeatureWithContext<EvaluationCriterion>
    {
        private readonly FirmaFeatureWithContextImpl<EvaluationCriterion> _firmaFeatureWithContextImpl;

        public EvaluationCriterionManageFeature(): base(new List<Role>{Role.Admin, Role.SitkaAdmin})
        {
            _firmaFeatureWithContextImpl = new FirmaFeatureWithContextImpl<EvaluationCriterion>(this);
            ActionFilter = _firmaFeatureWithContextImpl;
        }

        public void DemandPermission(FirmaSession firmaSession, EvaluationCriterion contextModelObject)
        {
            _firmaFeatureWithContextImpl.DemandPermission(firmaSession, contextModelObject);
        }

        public static bool HasEvaluationCriterionManagePermission(FirmaSession currentFirmaSession, EvaluationCriterion evaluationCriterion)
        {
            var permissionCheckResult = new EvaluationCriterionManageFeature().HasPermission(currentFirmaSession, evaluationCriterion);
            return permissionCheckResult.HasPermission;
        }

        public PermissionCheckResult HasPermission(FirmaSession firmaSession, EvaluationCriterion contextModelObject)
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