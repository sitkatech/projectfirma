using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectFirmaModels.Models
{
    public interface ITaxonomyTier : IHaveASortOrder
    {
        int GetTaxonomyTierID();
        string ThemeColor { get; }
        HtmlString GetDisplayNameAsUrl();
        List<IGrouping<PerformanceMeasure, TaxonomyLeafPerformanceMeasure>> GetTaxonomyTierPerformanceMeasures();
        string GetDetailUrl();
        FancyTreeNode ToFancyTreeNode(Person currentPerson);
    }
}
