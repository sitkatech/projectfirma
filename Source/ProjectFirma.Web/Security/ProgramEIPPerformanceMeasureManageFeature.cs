using System;
using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Manage Program EIP PerformanceMeasure")]
    public class ProgramEIPPerformanceMeasureManageFeature : EIPFeatureWithContext, IFirmaBaseFeatureWithContext<EIPPerformanceMeasure>
    {
        private readonly FirmaFeatureWithContextImpl<EIPPerformanceMeasure> _firmaFeatureWithContextImpl;

        public ProgramEIPPerformanceMeasureManageFeature()
            : base(new List<Role> { Role.SitkaAdmin, Role.Admin })
        {
            _firmaFeatureWithContextImpl = new FirmaFeatureWithContextImpl<EIPPerformanceMeasure>(this);
            ActionFilter = _firmaFeatureWithContextImpl;
        }

        public void DemandPermission(Person person, EIPPerformanceMeasure contextModelObject)
        {
            _firmaFeatureWithContextImpl.DemandPermission(person, contextModelObject);
        }

        public PermissionCheckResult HasPermission(Person person, EIPPerformanceMeasure contextModelObject)
        {
            var hasPermissionByPerson = HasPermissionByPerson(person);
            if (!hasPermissionByPerson)
            {
                return new PermissionCheckResult(String.Format("You don't have permission to Edit Programs for PM {0}", contextModelObject.DisplayName));
            }

            var eipPerformanceMeasureTypeValidToSetPrograms = contextModelObject.EIPPerformanceMeasureType.CanAssociatePrograms();
            if (!eipPerformanceMeasureTypeValidToSetPrograms)
            {
                return new PermissionCheckResult(string.Format("You can not set Program associations for PM {0}.", contextModelObject.DisplayName));
            }

            return new PermissionCheckResult();
        }
    }
}