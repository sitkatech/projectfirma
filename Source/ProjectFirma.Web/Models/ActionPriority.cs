using System;
using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using LtInfo.Common;

namespace ProjectFirma.Web.Models
{
    public partial class ActionPriority : IAuditableEntity
    {
        public string DisplayNumber
        {
            get { return string.Format("{0}.{1:00}", Program.DisplayNumber, ActionPriorityNumber); }
        }

        public string DisplayName
        {
            get { return string.Format("{0} - {1}", DisplayNumber, ActionPriorityName); }
        }

        public string CustomizedMapUrl
        {
            get { return ProjectMapCustomization.BuildCustomizedUrl(ProjectLocationFilterType.ActionPriority, ActionPriorityID.ToString(), ProjectColorByType.ProjectStage); }
        }

        public static byte GetNextActionPriorityNumberForProgram(IQueryable<ActionPriority> existingActionPriorities, int programID)
        {
            var actionPrioritiesForProgram = existingActionPriorities.Where(x => x.ProgramID == programID).ToList();
            byte nextActionPriorityNumber = 1;
            if (actionPrioritiesForProgram.Any())
            {
                nextActionPriorityNumber += actionPrioritiesForProgram.Max(x => x.ActionPriorityNumber);
            }
            return nextActionPriorityNumber;
        }

        public static bool IsActionPriorityNameUnique(IEnumerable<ActionPriority> actionPriorities, string actionPriorityName, int currentActionPriorityID)
        {
            var actionPriority =
                actionPriorities.SingleOrDefault(
                    x => x.ActionPriorityID != currentActionPriorityID && String.Equals(x.ActionPriorityName, actionPriorityName, StringComparison.InvariantCultureIgnoreCase));
            return actionPriority == null;
        }

        public string AuditDescriptionString
        {
            get { return ActionPriorityName; }
        }

        public FancyTreeNode ToFancyTreeNode()
        {
            var fancyTreeNode = new FancyTreeNode(string.Format("{0} - {1}", DisplayNumber, UrlTemplate.MakeHrefString(this.GetSummaryUrl(), ActionPriorityName)), ActionPriorityID.ToString(), false)
            {
                ThemeColor = Program.FocusArea.FocusAreaColor,
                MapUrl = CustomizedMapUrl,
                Children = Projects.Select(x => x.ToFancyTreeNode()).OrderBy(x => x.Title).ToList()
            };
            return fancyTreeNode;
        }
    }
}