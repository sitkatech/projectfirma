using System.Collections.Generic;
using System.Web.Mvc;

namespace ProjectFirma.Web.Views.TaxonomyTierTwo
{
    public class EditViewData : FirmaUserControlViewData
    {
        public readonly IEnumerable<SelectListItem> TaxonomyTierThrees;
        public readonly string TaxonomyTierThreeDisplayName;
        public readonly bool HasProjects;

        public EditViewData(IEnumerable<SelectListItem> taxonomyTierThrees, string taxonomyTierThreeDisplayName, bool hasProjects)
        {
            TaxonomyTierThrees = taxonomyTierThrees;
            TaxonomyTierThreeDisplayName = taxonomyTierThreeDisplayName;
            HasProjects = hasProjects;
        }
    }
}