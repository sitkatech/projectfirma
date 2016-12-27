using System;
using System.Collections.Generic;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Manage Taxonomy Tier Two Performance Measure")]
    public class TaxonomyTierTwoPerformanceMeasureManageFeature : FirmaFeatureWithContext, IFirmaBaseFeatureWithContext<PerformanceMeasure>
    {
        private readonly FirmaFeatureWithContextImpl<PerformanceMeasure> _firmaFeatureWithContextImpl;

        public TaxonomyTierTwoPerformanceMeasureManageFeature()
            : base(new List<Role> { Role.SitkaAdmin, Role.Admin })
        {
            _firmaFeatureWithContextImpl = new FirmaFeatureWithContextImpl<PerformanceMeasure>(this);
            ActionFilter = _firmaFeatureWithContextImpl;
        }

        public void DemandPermission(Person person, PerformanceMeasure contextModelObject)
        {
            _firmaFeatureWithContextImpl.DemandPermission(person, contextModelObject);
        }

        public PermissionCheckResult HasPermission(Person person, PerformanceMeasure contextModelObject)
        {
            var hasPermissionByPerson = HasPermissionByPerson(person);
            if (!hasPermissionByPerson)
            {
                return new PermissionCheckResult(String.Format("You don't have permission to Edit {0} for PM {1}", MultiTenantHelpers.GetTaxonomyTierTwoDisplayNamePluralized(), contextModelObject.DisplayName));
            }

            return new PermissionCheckResult();
        }
    }
}