using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectFirma.Web.Areas.EIP.Controllers;
using LtInfo.Common;

namespace ProjectFirma.Web.Models
{
    public static class ActionPriorityModelExtensions
    {
        public static HtmlString GetDisplayNameAsUrl(this ActionPriority actionPriority)
        {
            return UrlTemplate.MakeHrefString(actionPriority.GetSummaryUrl(), actionPriority.DisplayName);
        }

        public static string GetSummaryUrl(this ActionPriority actionPriority)
        {
            return SitkaRoute<ActionPriorityController>.BuildUrlFromExpression(x => x.Summary(actionPriority.ActionPriorityID));
        }

        public static string GetDeleteUrl(this ActionPriority actionPriority)
        {
            return SitkaRoute<ActionPriorityController>.BuildUrlFromExpression(c => c.DeleteActionPriority(actionPriority.ActionPriorityID));
        }

        public static IEnumerable<SelectListItem> ToGroupedSelectList(this List<ActionPriority> actionPriorities)
        {
            var selectListItems = new List<SelectListItem>();
            var groups = new Dictionary<string, SelectListGroup>();
            foreach (var focusAreaGrouping in actionPriorities.GroupBy(x => x.Program.FocusArea).OrderBy(x => x.Key.DisplayName))
            {
                var focusArea = focusAreaGrouping.Key;
                var topLevelGroup = new SelectListGroup() {Name = focusArea.DisplayName};
                groups.Add(focusArea.DisplayName, topLevelGroup);
                
                foreach (var programGrouping in focusAreaGrouping.GroupBy(x => x.Program).OrderBy(x => x.Key.DisplayName))
                {
                    var program = programGrouping.Key;
                    var selectListGroup = new SelectListGroup() {Name = program.DisplayName};
                    groups.Add(program.DisplayName, selectListGroup);

                    selectListItems.Add(new SelectListItem(){Text = program.DisplayName, Group = topLevelGroup, Disabled = true});

                    foreach (var actionPriority in programGrouping.OrderBy(x => x.DisplayName))
                    {
                        selectListItems.Add(new SelectListItem() { Value = actionPriority.ActionPriorityID.ToString(), Text = actionPriority.DisplayName, Group = topLevelGroup });
                    }
                }

            }
            return selectListItems;
        }
    }
}