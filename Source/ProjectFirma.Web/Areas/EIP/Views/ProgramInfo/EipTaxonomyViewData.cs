using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Areas.EIP.Views.ProgramInfo
{
    public class EipTaxonomyViewData : EIPViewData
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