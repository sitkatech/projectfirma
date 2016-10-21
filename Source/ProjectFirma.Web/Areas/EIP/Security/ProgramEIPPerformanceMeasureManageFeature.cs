using System;
using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Areas.EIP.Security
{
    [SecurityFeatureDescription("Manage Program EIP PerformanceMeasure")]
    public class ProgramEIPPerformanceMeasureManageFeature : EIPFeatureWithContext, ILakeTahoeInfoBaseFeatureWithContext<EIPPerformanceMeasure>
    {
        private readonly LakeTahoeInfoFeatureWithContextImpl<EIPPerformanceMeasure> _lakeTahoeInfoFeatureWithContextImpl;

        public ProgramEIPPerformanceMeasureManageFeature() : base(new List<EIPRole> {EIPRole.Admin})
        {
            _lakeTahoeInfoFeatureWithContextImpl = new LakeTahoeInfoFeatureWithContextImpl<EIPPerformanceMeasure>(this);
            ActionFilter = _lakeTahoeInfoFeatureWithContextImpl;
        }

        public void DemandPermission(Person person, EIPPerformanceMeasure contextModelObject)
        {
            _lakeTahoeInfoFeatureWithContextImpl.DemandPermission(person, contextModelObject);
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