using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ProjectFirma.Web.Models
{
    public static class TransportationSubGoalExtensionMethods
    {
        public static IEnumerable<SelectListItem> ToGroupedSelectList(this List<TransportationSubGoal> transportationSubGoals)
        {
            var selectListItems = new List<SelectListItem>();
            var groups = new Dictionary<string, SelectListGroup>();
            foreach (var transportationGoalGrouping in transportationSubGoals.GroupBy(x => x.TransportationGoal).OrderBy(x => x.Key.TransportationGoalNumber))
            {
                var transportationGoal = transportationGoalGrouping.Key;
                var topLevelGroup = new SelectListGroup() { Name = transportationGoal.DisplayName };
                groups.Add(transportationGoal.DisplayName, topLevelGroup);

                foreach (var transportationSubGoal in transportationGoalGrouping.OrderBy(x => x.TransportationSubGoalNumber))
                {
                    selectListItems.Add(new SelectListItem() { Value = transportationSubGoal.TransportationSubGoalID.ToString(), Text = transportationSubGoal.DisplayName, Group = topLevelGroup });
                }

            }
            return selectListItems;
        }
    }
}