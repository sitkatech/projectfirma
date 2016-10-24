//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TransportationStrategy]
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
        public static TransportationStrategy GetTransportationStrategy(this IQueryable<TransportationStrategy> transportationStrategies, int transportationStrategyID)
        {
            var transportationStrategy = transportationStrategies.SingleOrDefault(x => x.TransportationStrategyID == transportationStrategyID);
            Check.RequireNotNullThrowNotFound(transportationStrategy, "TransportationStrategy", transportationStrategyID);
            return transportationStrategy;
        }

        public static void DeleteTransportationStrategy(this IQueryable<TransportationStrategy> transportationStrategies, List<int> transportationStrategyIDList)
        {
            if(transportationStrategyIDList.Any())
            {
                transportationStrategies.Where(x => transportationStrategyIDList.Contains(x.TransportationStrategyID)).Delete();
            }
        }

        public static void DeleteTransportationStrategy(this IQueryable<TransportationStrategy> transportationStrategies, ICollection<TransportationStrategy> transportationStrategiesToDelete)
        {
            if(transportationStrategiesToDelete.Any())
            {
                var transportationStrategyIDList = transportationStrategiesToDelete.Select(x => x.TransportationStrategyID).ToList();
                transportationStrategies.Where(x => transportationStrategyIDList.Contains(x.TransportationStrategyID)).Delete();
            }
        }

        public static void DeleteTransportationStrategy(this IQueryable<TransportationStrategy> transportationStrategies, int transportationStrategyID)
        {
            DeleteTransportationStrategy(transportationStrategies, new List<int> { transportationStrategyID });
        }

        public static void DeleteTransportationStrategy(this IQueryable<TransportationStrategy> transportationStrategies, TransportationStrategy transportationStrategyToDelete)
        {
            DeleteTransportationStrategy(transportationStrategies, new List<TransportationStrategy> { transportationStrategyToDelete });
        }
    }
}