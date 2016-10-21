//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TransportationCostParameterSet]
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
        public static TransportationCostParameterSet GetTransportationCostParameterSet(this IQueryable<TransportationCostParameterSet> transportationCostParameterSets, int transportationCostParameterSetID)
        {
            var transportationCostParameterSet = transportationCostParameterSets.SingleOrDefault(x => x.TransportationCostParameterSetID == transportationCostParameterSetID);
            Check.RequireNotNullThrowNotFound(transportationCostParameterSet, "TransportationCostParameterSet", transportationCostParameterSetID);
            return transportationCostParameterSet;
        }

        public static void DeleteTransportationCostParameterSet(this IQueryable<TransportationCostParameterSet> transportationCostParameterSets, List<int> transportationCostParameterSetIDList)
        {
            if(transportationCostParameterSetIDList.Any())
            {
                transportationCostParameterSets.Where(x => transportationCostParameterSetIDList.Contains(x.TransportationCostParameterSetID)).Delete();
            }
        }

        public static void DeleteTransportationCostParameterSet(this IQueryable<TransportationCostParameterSet> transportationCostParameterSets, ICollection<TransportationCostParameterSet> transportationCostParameterSetsToDelete)
        {
            if(transportationCostParameterSetsToDelete.Any())
            {
                var transportationCostParameterSetIDList = transportationCostParameterSetsToDelete.Select(x => x.TransportationCostParameterSetID).ToList();
                transportationCostParameterSets.Where(x => transportationCostParameterSetIDList.Contains(x.TransportationCostParameterSetID)).Delete();
            }
        }

        public static void DeleteTransportationCostParameterSet(this IQueryable<TransportationCostParameterSet> transportationCostParameterSets, int transportationCostParameterSetID)
        {
            DeleteTransportationCostParameterSet(transportationCostParameterSets, new List<int> { transportationCostParameterSetID });
        }

        public static void DeleteTransportationCostParameterSet(this IQueryable<TransportationCostParameterSet> transportationCostParameterSets, TransportationCostParameterSet transportationCostParameterSetToDelete)
        {
            DeleteTransportationCostParameterSet(transportationCostParameterSets, new List<TransportationCostParameterSet> { transportationCostParameterSetToDelete });
        }
    }
}