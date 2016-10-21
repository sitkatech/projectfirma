//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TransportationProjectBudgetUpdate]
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
        public static TransportationProjectBudgetUpdate GetTransportationProjectBudgetUpdate(this IQueryable<TransportationProjectBudgetUpdate> transportationProjectBudgetUpdates, int transportationProjectBudgetUpdateID)
        {
            var transportationProjectBudgetUpdate = transportationProjectBudgetUpdates.SingleOrDefault(x => x.TransportationProjectBudgetUpdateID == transportationProjectBudgetUpdateID);
            Check.RequireNotNullThrowNotFound(transportationProjectBudgetUpdate, "TransportationProjectBudgetUpdate", transportationProjectBudgetUpdateID);
            return transportationProjectBudgetUpdate;
        }

        public static void DeleteTransportationProjectBudgetUpdate(this IQueryable<TransportationProjectBudgetUpdate> transportationProjectBudgetUpdates, List<int> transportationProjectBudgetUpdateIDList)
        {
            if(transportationProjectBudgetUpdateIDList.Any())
            {
                transportationProjectBudgetUpdates.Where(x => transportationProjectBudgetUpdateIDList.Contains(x.TransportationProjectBudgetUpdateID)).Delete();
            }
        }

        public static void DeleteTransportationProjectBudgetUpdate(this IQueryable<TransportationProjectBudgetUpdate> transportationProjectBudgetUpdates, ICollection<TransportationProjectBudgetUpdate> transportationProjectBudgetUpdatesToDelete)
        {
            if(transportationProjectBudgetUpdatesToDelete.Any())
            {
                var transportationProjectBudgetUpdateIDList = transportationProjectBudgetUpdatesToDelete.Select(x => x.TransportationProjectBudgetUpdateID).ToList();
                transportationProjectBudgetUpdates.Where(x => transportationProjectBudgetUpdateIDList.Contains(x.TransportationProjectBudgetUpdateID)).Delete();
            }
        }

        public static void DeleteTransportationProjectBudgetUpdate(this IQueryable<TransportationProjectBudgetUpdate> transportationProjectBudgetUpdates, int transportationProjectBudgetUpdateID)
        {
            DeleteTransportationProjectBudgetUpdate(transportationProjectBudgetUpdates, new List<int> { transportationProjectBudgetUpdateID });
        }

        public static void DeleteTransportationProjectBudgetUpdate(this IQueryable<TransportationProjectBudgetUpdate> transportationProjectBudgetUpdates, TransportationProjectBudgetUpdate transportationProjectBudgetUpdateToDelete)
        {
            DeleteTransportationProjectBudgetUpdate(transportationProjectBudgetUpdates, new List<TransportationProjectBudgetUpdate> { transportationProjectBudgetUpdateToDelete });
        }
    }
}