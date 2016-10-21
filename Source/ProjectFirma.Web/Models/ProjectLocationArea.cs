using System.Data.Entity.Spatial;
using System.Linq;
using ProjectFirma.Web.Areas.EIP.Views.Map;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectLocationArea : IAuditableEntity
    {
        public string ProjectLocationAreaName
        {
            get { return ProjectLocationAreaGroup.ProjectLocationAreaGroupType.GetProjectLocationAreaName(this); }
        }

        public string ProjectLocationAreaDisplayName
        {
            get { return ProjectLocationAreaGroup.ProjectLocationAreaGroupType.GetProjectLocationAreaDisplayName(this); }
        }

        public LayerGeoJson GetLayerGeoJson()
        {
            return ProjectLocationAreaGroup.ProjectLocationAreaGroupType.GetLayerGeoJson(this);
        }

        public DbGeometry GetGeometry()
        {
            return ProjectLocationAreaGroup.ProjectLocationAreaGroupType.GetGeometry(this);
        }

        public string AuditDescriptionString
        {
            get
            {
                return "Project location named area deleted";
            }
        }

        public FancyTreeNode ToFancyTreeNode()
        {
            var fancyTreeNode = new FancyTreeNode(ProjectLocationAreaDisplayName, ProjectLocationAreaDisplayName, false)
            {
                MapUrl = null,
                Children = Projects.OrderBy(x => x.DisplayName).Select(x => x.ToFancyTreeNode()).ToList()
            };
            return fancyTreeNode;
        }
    }
}