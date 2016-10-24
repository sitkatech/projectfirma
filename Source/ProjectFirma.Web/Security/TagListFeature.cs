using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("List Tags")]
    public class TagListFeature : EIPFeature
    {
        public TagListFeature() : base(new List<EIPRole> { EIPRole.Admin, EIPRole.ReadOnlyAdmin, EIPRole.TMPOManager })
        {
        }
    }
}