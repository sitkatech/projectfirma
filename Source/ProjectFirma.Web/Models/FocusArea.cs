using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using LtInfo.Common;

namespace ProjectFirma.Web.Models
{
    public partial class FocusArea : IAuditableEntity
    {
        public string DeleteUrl
        {
            get { return SitkaRoute<FocusAreaController>.BuildUrlFromExpression(c => c.DeleteFocusArea(FocusAreaID)); }
        }

        public string DisplayNumber
        {
            get { return String.Format("{0:00}", FocusAreaNumber); }
        }

        public string DisplayName
        {
            get { return String.Format("{0} - {1}", DisplayNumber, FocusAreaName); }
        }

        public HtmlString DisplayNameAsUrl
        {
            get { return UrlTemplate.MakeHrefString(SummaryUrl, DisplayName); }
        }

        public string SummaryUrl
        {
            get { return SitkaRoute<FocusAreaController>.BuildUrlFromExpression(x => x.Summary(FocusAreaID)); }
        }

        public string CustomizedMapUrl
        {
            get { return ProjectMapCustomization.BuildCustomizedUrl(ProjectLocationFilterType.FocusArea, FocusAreaID.ToString(), ProjectColorByType.ProjectStage); }
        }

        public ICollection<Project> Projects
        {
            get { return Programs.SelectMany(x => x.ActionPriorities.SelectMany(y => y.Projects)).ToList(); }
        }

        public static bool IsFocusAreaNameUnique(IEnumerable<FocusArea> focusAreas, string focusAreaName, int currentFocusAreaID)
        {
            var focusArea = focusAreas.SingleOrDefault(x => x.FocusAreaID != currentFocusAreaID && String.Equals(x.FocusAreaName, focusAreaName, StringComparison.InvariantCultureIgnoreCase));
            return focusArea == null;
        }

        public static byte GetNextFocusAreaNumber(IEnumerable<FocusArea> focusAreas)
        {
            return (byte) (focusAreas.Max(x => x.FocusAreaNumber) + 1);
        }

        public string AuditDescriptionString
        {
            get { return DisplayName; }
        }

        public List<ActionPriority> ActionPriorities
        {
            get { return Programs.SelectMany(x => x.ActionPriorities).OrderBy(x => x.DisplayNumber).ToList(); }
        }

        public FancyTreeNode ToFancyTreeNode()
        {
            var fancyTreeNode = new FancyTreeNode(string.Format("{0} - {1}", DisplayNumber, UrlTemplate.MakeHrefString(SummaryUrl, FocusAreaName)), FocusAreaID.ToString(), true)
            {
                ThemeColor = FocusAreaColor,
                MapUrl = CustomizedMapUrl,
                Children = Programs.Select(x => x.ToFancyTreeNode()).ToList()
            };
            return fancyTreeNode;
        }
    }
}