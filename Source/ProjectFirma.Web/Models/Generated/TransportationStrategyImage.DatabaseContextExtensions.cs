//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TransportationStrategyImage]
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
        public static TransportationStrategyImage GetTransportationStrategyImage(this IQueryable<TransportationStrategyImage> transportationStrategyImages, int transportationStrategyImageID)
        {
            var transportationStrategyImage = transportationStrategyImages.SingleOrDefault(x => x.TransportationStrategyImageID == transportationStrategyImageID);
            Check.RequireNotNullThrowNotFound(transportationStrategyImage, "TransportationStrategyImage", transportationStrategyImageID);
            return transportationStrategyImage;
        }

        public static void DeleteTransportationStrategyImage(this IQueryable<TransportationStrategyImage> transportationStrategyImages, List<int> transportationStrategyImageIDList)
        {
            if(transportationStrategyImageIDList.Any())
            {
                transportationStrategyImages.Where(x => transportationStrategyImageIDList.Contains(x.TransportationStrategyImageID)).Delete();
            }
        }

        public static void DeleteTransportationStrategyImage(this IQueryable<TransportationStrategyImage> transportationStrategyImages, ICollection<TransportationStrategyImage> transportationStrategyImagesToDelete)
        {
            if(transportationStrategyImagesToDelete.Any())
            {
                var transportationStrategyImageIDList = transportationStrategyImagesToDelete.Select(x => x.TransportationStrategyImageID).ToList();
                transportationStrategyImages.Where(x => transportationStrategyImageIDList.Contains(x.TransportationStrategyImageID)).Delete();
            }
        }

        public static void DeleteTransportationStrategyImage(this IQueryable<TransportationStrategyImage> transportationStrategyImages, int transportationStrategyImageID)
        {
            DeleteTransportationStrategyImage(transportationStrategyImages, new List<int> { transportationStrategyImageID });
        }

        public static void DeleteTransportationStrategyImage(this IQueryable<TransportationStrategyImage> transportationStrategyImages, TransportationStrategyImage transportationStrategyImageToDelete)
        {
            DeleteTransportationStrategyImage(transportationStrategyImages, new List<TransportationStrategyImage> { transportationStrategyImageToDelete });
        }
    }
}