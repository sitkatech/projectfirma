using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using LtInfo.Common;

namespace ProjectFirma.Web.Models
{
    public partial class TaxonomyTierThree : IAuditableEntity
    {
        public string DeleteUrl
        {
            get { return SitkaRoute<TaxonomyTierThreeController>.BuildUrlFromExpression(c => c.DeleteTaxonomyTierThree(TaxonomyTierThreeID)); }
        }

        public string DisplayName
        {
            get { return string.Format("{0}: {1}", TaxonomyTierThreeCode, TaxonomyTierThreeName); }
        }

        public HtmlString GetDisplayNameAsUrl()
        {
            return UrlTemplate.MakeHrefString(SummaryUrl, DisplayName);
        }

        public string SummaryUrl
        {
            get { return SitkaRoute<TaxonomyTierThreeController>.BuildUrlFromExpression(x => x.Detail(TaxonomyTierThreeID)); }
        }

        public string CustomizedMapUrl
        {
            get { return ProjectMapCustomization.BuildCustomizedUrl(ProjectLocationFilterType.TaxonomyTierThree, TaxonomyTierThreeID.ToString(), ProjectColorByType.ProjectStage); }
        }

        public ICollection<Project> Projects
        {
            get { return TaxonomyTierTwos.SelectMany(x => x.TaxonomyTierOnes.SelectMany(y => y.Projects)).ToList(); }
        }

        public static bool IsTaxonomyTierThreeNameUnique(IEnumerable<TaxonomyTierThree> taxonomyTierThrees, string taxonomyTierThreeName, int currentTaxonomyTierThreeID)
        {
            var taxonomyTierThree = taxonomyTierThrees.SingleOrDefault(x => x.TaxonomyTierThreeID != currentTaxonomyTierThreeID && String.Equals(x.TaxonomyTierThreeName, taxonomyTierThreeName, StringComparison.InvariantCultureIgnoreCase));
            return taxonomyTierThree == null;
        }

        public string AuditDescriptionString
        {
            get { return DisplayName; }
        }

        public List<TaxonomyTierOne> TaxonomyTierOnes
        {
            get { return TaxonomyTierTwos.SelectMany(x => x.TaxonomyTierOnes).OrderBy(x => x.TaxonomyTierOneName).ToList(); }
        }

        public FancyTreeNode ToFancyTreeNode()
        {
            var fancyTreeNode = new FancyTreeNode(string.Format("{0}", UrlTemplate.MakeHrefString(SummaryUrl, DisplayName)), TaxonomyTierThreeID.ToString(), true)
            {
                ThemeColor = ThemeColor,
                MapUrl = CustomizedMapUrl,
                Children = TaxonomyTierTwos.Select(x => x.ToFancyTreeNode()).ToList()
            };
            return fancyTreeNode;
        }
    }
}