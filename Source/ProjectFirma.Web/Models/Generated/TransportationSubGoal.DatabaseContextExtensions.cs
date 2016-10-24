//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TransportationSubGoal]
using System.Collections.Generic;
using System.Linq;
using EntityFramework.Extensions;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static TransportationSubGoal GetTransportationSubGoal(this IQueryable<TransportationSubGoal> transportationSubGoals, int transportationSubGoalID)
        {
            var transportationSubGoal = transportationSubGoals.SingleOrDefault(x => x.TransportationSubGoalID == transportationSubGoalID);
            Check.RequireNotNullThrowNotFound(transportationSubGoal, "TransportationSubGoal", transportationSubGoalID);
            return transportationSubGoal;
        }

        public static void DeleteTransportationSubGoal(this IQueryable<TransportationSubGoal> transportationSubGoals, List<int> transportationSubGoalIDList)
        {
            if(transportationSubGoalIDList.Any())
            {
                transportationSubGoals.Where(x => transportationSubGoalIDList.Contains(x.TransportationSubGoalID)).Delete();
            }
        }

        public static void DeleteTransportationSubGoal(this IQueryable<TransportationSubGoal> transportationSubGoals, ICollection<TransportationSubGoal> transportationSubGoalsToDelete)
        {
            if(transportationSubGoalsToDelete.Any())
            {
                var transportationSubGoalIDList = transportationSubGoalsToDelete.Select(x => x.TransportationSubGoalID).ToList();
                transportationSubGoals.Where(x => transportationSubGoalIDList.Contains(x.TransportationSubGoalID)).Delete();
            }
        }

        public static void DeleteTransportationSubGoal(this IQueryable<TransportationSubGoal> transportationSubGoals, int transportationSubGoalID)
        {
            DeleteTransportationSubGoal(transportationSubGoals, new List<int> { transportationSubGoalID });
        }

        public static void DeleteTransportationSubGoal(this IQueryable<TransportationSubGoal> transportationSubGoals, TransportationSubGoal transportationSubGoalToDelete)
        {
            DeleteTransportationSubGoal(transportationSubGoals, new List<TransportationSubGoal> { transportationSubGoalToDelete });
        }
    }
}