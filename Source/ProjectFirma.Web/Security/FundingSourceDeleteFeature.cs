using System.Collections.Generic;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Delete {0}", FieldDefinitionEnum.FundingSource)]
    public class FundingSourceDeleteFeature : FirmaFeatureWithContext, IFirmaBaseFeatureWithContext<FundingSource>
    {
        private readonly FirmaFeatureWithContextImpl<FundingSource> _firmaFeatureWithContextImpl;

        public FundingSourceDeleteFeature() : base(new List<Role> {Role.Admin, Role.SitkaAdmin})
        {
            _firmaFeatureWithContextImpl = new FirmaFeatureWithContextImpl<FundingSource>(this);
            ActionFilter = _firmaFeatureWithContextImpl;
        }

        public PermissionCheckResult HasPermission(FirmaSession firmaSession, FundingSource contextModelObject)
        {
            if (!HasPermissionByFirmaSession(firmaSession))
            {
                return new PermissionCheckResult($"You don't have permission to delete {FieldDefinitionEnum.FundingSource.ToType().GetFieldDefinitionLabel()} {contextModelObject.GetDisplayName()}");
            }

            return new PermissionCheckResult();
        }

        public override bool HasPermissionByFirmaSession(FirmaSession firmaSession)
        {
            if (HttpRequestStorage.Tenant.AreFundingSourcesExternallySourced)
            {
                return false;
            }
            return base.HasPermissionByFirmaSession(firmaSession);
        }

        public void DemandPermission(FirmaSession firmaSession, FundingSource contextModelObject)
        {
            _firmaFeatureWithContextImpl.DemandPermission(firmaSession, contextModelObject);
        }
    }
}
