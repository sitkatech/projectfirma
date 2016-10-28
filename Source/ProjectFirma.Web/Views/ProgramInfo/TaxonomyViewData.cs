using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.ProgramInfo
{
    public class TaxonomyViewData : FirmaViewData
    {
        public readonly List<FancyTreeNode> FocusAreasAsFancyTreeNodes;

        public TaxonomyViewData(Person currentPerson, Models.FirmaPage firmaPage,
            List<FancyTreeNode> focusAreasAsFancyTreeNodes) : base(currentPerson, firmaPage)
        {
            FocusAreasAsFancyTreeNodes = focusAreasAsFancyTreeNodes;
            PageTitle = "Focus Areas, Programs, and Action Priorities";
        }
    }
}