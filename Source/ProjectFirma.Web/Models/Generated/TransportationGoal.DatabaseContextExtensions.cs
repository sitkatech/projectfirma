//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TransportationGoal]
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
        public static TransportationGoal GetTransportationGoal(this IQueryable<TransportationGoal> transportationGoals, int transportationGoalID)
        {
            var transportationGoal = transportationGoals.SingleOrDefault(x => x.TransportationGoalID == transportationGoalID);
            Check.RequireNotNullThrowNotFound(transportationGoal, "TransportationGoal", transportationGoalID);
            return transportationGoal;
        }

        public static void DeleteTransportationGoal(this IQueryable<TransportationGoal> transportationGoals, List<int> transportationGoalIDList)
        {
            if(transportationGoalIDList.Any())
            {
                transportationGoals.Where(x => transportationGoalIDList.Contains(x.TransportationGoalID)).Delete();
            }
        }

        public static void DeleteTransportationGoal(this IQueryable<TransportationGoal> transportationGoals, ICollection<TransportationGoal> transportationGoalsToDelete)
        {
            if(transportationGoalsToDelete.Any())
            {
                var transportationGoalIDList = transportationGoalsToDelete.Select(x => x.TransportationGoalID).ToList();
                transportationGoals.Where(x => transportationGoalIDList.Contains(x.TransportationGoalID)).Delete();
            }
        }

        public static void DeleteTransportationGoal(this IQueryable<TransportationGoal> transportationGoals, int transportationGoalID)
        {
            DeleteTransportationGoal(transportationGoals, new List<int> { transportationGoalID });
        }

        public static void DeleteTransportationGoal(this IQueryable<TransportationGoal> transportationGoals, TransportationGoal transportationGoalToDelete)
        {
            DeleteTransportationGoal(transportationGoals, new List<TransportationGoal> { transportationGoalToDelete });
        }
    }
}