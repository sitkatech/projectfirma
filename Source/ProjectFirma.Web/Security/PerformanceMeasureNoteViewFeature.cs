using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("View PerformanceMeasure Note")]
    public class PerformanceMeasureNoteViewFeature : FirmaFeature
    {
        public PerformanceMeasureNoteViewFeature()
            : base(new List<Role> { Role.SitkaAdmin, Role.Admin })
        {
        }
    }
}