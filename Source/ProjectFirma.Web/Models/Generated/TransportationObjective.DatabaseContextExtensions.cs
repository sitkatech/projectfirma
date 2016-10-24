//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TransportationObjective]
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
        public static TransportationObjective GetTransportationObjective(this IQueryable<TransportationObjective> transportationObjectives, int transportationObjectiveID)
        {
            var transportationObjective = transportationObjectives.SingleOrDefault(x => x.TransportationObjectiveID == transportationObjectiveID);
            Check.RequireNotNullThrowNotFound(transportationObjective, "TransportationObjective", transportationObjectiveID);
            return transportationObjective;
        }

        public static void DeleteTransportationObjective(this IQueryable<TransportationObjective> transportationObjectives, List<int> transportationObjectiveIDList)
        {
            if(transportationObjectiveIDList.Any())
            {
                transportationObjectives.Where(x => transportationObjectiveIDList.Contains(x.TransportationObjectiveID)).Delete();
            }
        }

        public static void DeleteTransportationObjective(this IQueryable<TransportationObjective> transportationObjectives, ICollection<TransportationObjective> transportationObjectivesToDelete)
        {
            if(transportationObjectivesToDelete.Any())
            {
                var transportationObjectiveIDList = transportationObjectivesToDelete.Select(x => x.TransportationObjectiveID).ToList();
                transportationObjectives.Where(x => transportationObjectiveIDList.Contains(x.TransportationObjectiveID)).Delete();
            }
        }

        public static void DeleteTransportationObjective(this IQueryable<TransportationObjective> transportationObjectives, int transportationObjectiveID)
        {
            DeleteTransportationObjective(transportationObjectives, new List<int> { transportationObjectiveID });
        }

        public static void DeleteTransportationObjective(this IQueryable<TransportationObjective> transportationObjectives, TransportationObjective transportationObjectiveToDelete)
        {
            DeleteTransportationObjective(transportationObjectives, new List<TransportationObjective> { transportationObjectiveToDelete });
        }
    }
}