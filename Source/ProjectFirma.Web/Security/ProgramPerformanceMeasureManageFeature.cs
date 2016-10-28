using System;
using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Manage Program PerformanceMeasure")]
    public class ProgramPerformanceMeasureManageFeature : FirmaFeatureWithContext, IFirmaBaseFeatureWithContext<PerformanceMeasure>
    {
        private readonly FirmaFeatureWithContextImpl<PerformanceMeasure> _firmaFeatureWithContextImpl;

        public ProgramPerformanceMeasureManageFeature()
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
                return new PermissionCheckResult(String.Format("You don't have permission to Edit Programs for PM {0}", contextModelObject.DisplayName));
            }

            var performanceMeasureTypeValidToSetPrograms = contextModelObject.PerformanceMeasureType.CanAssociatePrograms();
            if (!performanceMeasureTypeValidToSetPrograms)
            {
                return new PermissionCheckResult(string.Format("You can not set Program associations for PM {0}.", contextModelObject.DisplayName));
            }

            return new PermissionCheckResult();
        }
    }
}