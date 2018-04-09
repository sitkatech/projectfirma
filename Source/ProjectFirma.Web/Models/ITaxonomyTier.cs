using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectFirma.Web.Models
{
    public interface ITaxonomyTier
    {
        int TaxonomyTierID { get; }
        string ThemeColor { get; }
        string DisplayName { get; }
        HtmlString GetDisplayNameAsUrl();
        List<IGrouping<PerformanceMeasure, TaxonomyLeafPerformanceMeasure>> GetTaxonomyTierPerformanceMeasures();
    }
}