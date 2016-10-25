using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared;

namespace ProjectFirma.Web.Views.ProgramInfo
{
    public class EipTaxonomyViewData : FirmaViewData
    {
        public readonly List<FancyTreeNode> FocusAreasAsFancyTreeNodes;

        public EipTaxonomyViewData(Person currentPerson, Models.ProjectFirmaPage projectFirmaPage,
            List<FancyTreeNode> focusAreasAsFancyTreeNodes) : base(currentPerson, projectFirmaPage)
        {
            FocusAreasAsFancyTreeNodes = focusAreasAsFancyTreeNodes;
            PageTitle = "EIP Focus Areas, Programs, and Action Priorities";
        }
    }
}