using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("List Tags")]
    public class TagListFeature : EIPFeature
    {
        public TagListFeature() : base(new List<Role> { Role.Admin, Role.ReadOnlyAdmin, Role.TMPOManager })
        {
        }
    }
}