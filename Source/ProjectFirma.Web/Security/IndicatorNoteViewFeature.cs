using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("View Indicator Note")]
    public class IndicatorNoteViewFeature : EIPFeature
    {
        public IndicatorNoteViewFeature() : base(new List<EIPRole> {EIPRole.ReadOnlyAdmin, EIPRole.Admin})
        {
        }
    }
}