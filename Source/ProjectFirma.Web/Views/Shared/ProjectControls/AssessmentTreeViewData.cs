using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Shared.ProjectControls
{
    public class AssessmentTreeViewData : FirmaUserControlViewData
    {
        public readonly List<FancyTreeNode> AssessmentGoalsAsFancyTreeNodes;

        public AssessmentTreeViewData(List<FancyTreeNode> assessmentGoalsAsFancyTreeNodes)
        {
            AssessmentGoalsAsFancyTreeNodes = assessmentGoalsAsFancyTreeNodes;
        }
    }
}