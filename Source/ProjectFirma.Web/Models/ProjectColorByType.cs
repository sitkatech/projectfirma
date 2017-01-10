using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectColorByType
    {
        public abstract string DisplayName { get; }   
    }

    public partial class ProjectColorByTypeTaxonomyTierThree
    {
        public override string DisplayName
        {
            get { return MultiTenantHelpers.GetTaxonomyTierThreeDisplayName(); }
        }
    }

    public partial class ProjectColorByTypeProjectStage
    {
        public override string DisplayName
        {
            get { return ProjectColorByTypeDisplayName; }
        }
    }


}