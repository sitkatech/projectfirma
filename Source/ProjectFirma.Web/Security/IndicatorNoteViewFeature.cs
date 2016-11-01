using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("View Indicator Note")]
    public class IndicatorNoteViewFeature : FirmaFeature
    {
        public IndicatorNoteViewFeature()
            : base(new List<Role> { Role.SitkaAdmin, Role.Admin })
        {
        }
    }
}