using System.Web;

namespace ProjectFirma.Web.Models
{
    public interface ITaxonomyTier
    {
        int TaxonomyTierID { get; }
        string ThemeColor { get; }
        string DisplayName { get; }
        HtmlString GetDisplayNameAsUrl();
    }
}