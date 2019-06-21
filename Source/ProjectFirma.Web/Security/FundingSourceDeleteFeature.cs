using System.Collections.Generic;
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

        public PermissionCheckResult HasPermission(Person person, FundingSource contextModelObject)
        {
            if (!HasPermissionByPerson(person))
            {
                return new PermissionCheckResult($"You don't have permission to delete {FieldDefinitionEnum.FundingSource.ToType().GetFieldDefinitionLabel()} {contextModelObject.GetDisplayName()}");
            }

            return new PermissionCheckResult();
        }

        public void DemandPermission(Person person, FundingSource contextModelObject)
        {
            _firmaFeatureWithContextImpl.DemandPermission(person, contextModelObject);
        }
    }
}
