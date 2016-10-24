using System.Linq;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("View List of All Page Contents")]
    public class ProjectFirmaPageViewListFeature : EIPFeature
    {
        public ProjectFirmaPageViewListFeature()
            : base(LakeTahoeInfoBaseFeatureHelpers.AllEIPRolesExceptUnassigned)
        {
        }

        public override bool HasPermissionByPerson(Person person)
        {
            return LTInfoArea.All.Any(ltInfoArea => ltInfoArea.CanManageFieldDefinitionAndIntroTextForArea(person).HasPermission);
        }
    }
}