//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TransportationProjectBudget]
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
        public static TransportationProjectBudget GetTransportationProjectBudget(this IQueryable<TransportationProjectBudget> transportationProjectBudgets, int transportationProjectBudgetID)
        {
            var transportationProjectBudget = transportationProjectBudgets.SingleOrDefault(x => x.TransportationProjectBudgetID == transportationProjectBudgetID);
            Check.RequireNotNullThrowNotFound(transportationProjectBudget, "TransportationProjectBudget", transportationProjectBudgetID);
            return transportationProjectBudget;
        }

        public static void DeleteTransportationProjectBudget(this IQueryable<TransportationProjectBudget> transportationProjectBudgets, List<int> transportationProjectBudgetIDList)
        {
            if(transportationProjectBudgetIDList.Any())
            {
                transportationProjectBudgets.Where(x => transportationProjectBudgetIDList.Contains(x.TransportationProjectBudgetID)).Delete();
            }
        }

        public static void DeleteTransportationProjectBudget(this IQueryable<TransportationProjectBudget> transportationProjectBudgets, ICollection<TransportationProjectBudget> transportationProjectBudgetsToDelete)
        {
            if(transportationProjectBudgetsToDelete.Any())
            {
                var transportationProjectBudgetIDList = transportationProjectBudgetsToDelete.Select(x => x.TransportationProjectBudgetID).ToList();
                transportationProjectBudgets.Where(x => transportationProjectBudgetIDList.Contains(x.TransportationProjectBudgetID)).Delete();
            }
        }

        public static void DeleteTransportationProjectBudget(this IQueryable<TransportationProjectBudget> transportationProjectBudgets, int transportationProjectBudgetID)
        {
            DeleteTransportationProjectBudget(transportationProjectBudgets, new List<int> { transportationProjectBudgetID });
        }

        public static void DeleteTransportationProjectBudget(this IQueryable<TransportationProjectBudget> transportationProjectBudgets, TransportationProjectBudget transportationProjectBudgetToDelete)
        {
            DeleteTransportationProjectBudget(transportationProjectBudgets, new List<TransportationProjectBudget> { transportationProjectBudgetToDelete });
        }
    }
}