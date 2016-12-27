using System.Collections.Generic;
using System.Web.Mvc;
using ProjectFirma.Web.Views;

namespace ProjectFirma.Web.Views.TaxonomyTierOne
{
    public class EditViewData : FirmaUserControlViewData
    {
        public readonly IEnumerable<SelectListItem> TaxonomyTierTwos;
        public readonly string TaxonomyTierTwoDisplayName;
        public readonly bool HasProjects;

        public EditViewData(IEnumerable<SelectListItem> taxonomyTierTwos, string taxonomyTierTwoDisplayName, bool hasProjects)
        {
            TaxonomyTierTwos = taxonomyTierTwos;
            TaxonomyTierTwoDisplayName = taxonomyTierTwoDisplayName;
            HasProjects = hasProjects;
        }
    }
}