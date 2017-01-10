using System.Collections.Generic;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.ProgramInfo
{
    public class TaxonomyViewData : FirmaViewData
    {
        public readonly List<FancyTreeNode> TopLevelTaxonomyTierAsFancyTreeNodes;

        public TaxonomyViewData(Person currentPerson, Models.FirmaPage firmaPage,
            List<FancyTreeNode> topLevelTaxonomyTierAsFancyTreeNodes) : base(currentPerson, firmaPage, false)
        {
            TopLevelTaxonomyTierAsFancyTreeNodes = topLevelTaxonomyTierAsFancyTreeNodes;
            PageTitle = MultiTenantHelpers.GetTaxonomySystemName();
        }
    }
}