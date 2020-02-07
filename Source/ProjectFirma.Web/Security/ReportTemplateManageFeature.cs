using System.Collections.Generic;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Add, Edit or Delete Report Templates")]
    public class ReportTemplateManageFeature : FirmaFeatureWithContext, IFirmaBaseFeatureWithContext<ReportTemplate>
    {
        private readonly FirmaFeatureWithContextImpl<ReportTemplate> _firmaFeatureWithContextImpl;

        public ReportTemplateManageFeature() : base(new List<Role> {Role.Admin, Role.SitkaAdmin})
        {
            _firmaFeatureWithContextImpl = new FirmaFeatureWithContextImpl<ReportTemplate>(this);
            ActionFilter = _firmaFeatureWithContextImpl;
        }

        public void DemandPermission(FirmaSession firmaSession, ReportTemplate contextModelObject)
        {
            _firmaFeatureWithContextImpl.DemandPermission(firmaSession, contextModelObject);
        }

        public PermissionCheckResult HasPermission(FirmaSession firmaSession, ReportTemplate contextModelObject)
        {
            if (HasPermissionByFirmaSession(firmaSession))
            {
                return new PermissionCheckResult();
            }
            return new PermissionCheckResult("Does not have administration privileges");
        }
    }
    

}