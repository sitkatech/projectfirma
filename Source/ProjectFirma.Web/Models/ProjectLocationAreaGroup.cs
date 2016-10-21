using System.Linq;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectLocationAreaGroup
    {
        public FancyTreeNode ToFancyTreeNode()
        {
            var fancyTreeNode = new FancyTreeNode(ProjectLocationAreaGroupType.ProjectLocationAreaGroupTypeDisplayName, ProjectLocationAreaGroupType.ProjectLocationAreaGroupTypeName, true)
            {
                MapUrl = null,
                Children = ProjectLocationAreas.OrderBy(x => x.ProjectLocationAreaDisplayName).Select(x => x.ToFancyTreeNode()).ToList()
            };
            return fancyTreeNode;
        }
    }
}