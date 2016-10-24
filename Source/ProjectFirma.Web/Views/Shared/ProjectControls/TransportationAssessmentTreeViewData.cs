using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views;

namespace ProjectFirma.Web.Views.Shared.ProjectControls
{
    public class TransportationAssessmentTreeViewData : LakeTahoeInfoUserControlViewData
    {
        public readonly List<FancyTreeNode> TransportationGoalsAsFancyTreeNodes;

        public TransportationAssessmentTreeViewData(List<FancyTreeNode> transportationGoalsAsFancyTreeNodes)
        {
            TransportationGoalsAsFancyTreeNodes = transportationGoalsAsFancyTreeNodes;
        }
    }
}