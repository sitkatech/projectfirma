//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ActionPriority]
using System.Collections.Generic;
using System.Linq;
using EntityFramework.Extensions;
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ActionPriority GetActionPriority(this IQueryable<ActionPriority> actionPriorities, int actionPriorityID)
        {
            var actionPriority = actionPriorities.SingleOrDefault(x => x.ActionPriorityID == actionPriorityID);
            Check.RequireNotNullThrowNotFound(actionPriority, "ActionPriority", actionPriorityID);
            return actionPriority;
        }

        public static void DeleteActionPriority(this IQueryable<ActionPriority> actionPriorities, List<int> actionPriorityIDList)
        {
            if(actionPriorityIDList.Any())
            {
                actionPriorities.Where(x => actionPriorityIDList.Contains(x.ActionPriorityID)).Delete();
            }
        }

        public static void DeleteActionPriority(this IQueryable<ActionPriority> actionPriorities, ICollection<ActionPriority> actionPrioritiesToDelete)
        {
            if(actionPrioritiesToDelete.Any())
            {
                var actionPriorityIDList = actionPrioritiesToDelete.Select(x => x.ActionPriorityID).ToList();
                actionPriorities.Where(x => actionPriorityIDList.Contains(x.ActionPriorityID)).Delete();
            }
        }

        public static void DeleteActionPriority(this IQueryable<ActionPriority> actionPriorities, int actionPriorityID)
        {
            DeleteActionPriority(actionPriorities, new List<int> { actionPriorityID });
        }

        public static void DeleteActionPriority(this IQueryable<ActionPriority> actionPriorities, ActionPriority actionPriorityToDelete)
        {
            DeleteActionPriority(actionPriorities, new List<ActionPriority> { actionPriorityToDelete });
        }
    }
}