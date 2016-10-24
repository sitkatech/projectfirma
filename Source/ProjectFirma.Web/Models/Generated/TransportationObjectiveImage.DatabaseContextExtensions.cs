//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TransportationObjectiveImage]
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
        public static TransportationObjectiveImage GetTransportationObjectiveImage(this IQueryable<TransportationObjectiveImage> transportationObjectiveImages, int transportationObjectiveImageID)
        {
            var transportationObjectiveImage = transportationObjectiveImages.SingleOrDefault(x => x.TransportationObjectiveImageID == transportationObjectiveImageID);
            Check.RequireNotNullThrowNotFound(transportationObjectiveImage, "TransportationObjectiveImage", transportationObjectiveImageID);
            return transportationObjectiveImage;
        }

        public static void DeleteTransportationObjectiveImage(this IQueryable<TransportationObjectiveImage> transportationObjectiveImages, List<int> transportationObjectiveImageIDList)
        {
            if(transportationObjectiveImageIDList.Any())
            {
                transportationObjectiveImages.Where(x => transportationObjectiveImageIDList.Contains(x.TransportationObjectiveImageID)).Delete();
            }
        }

        public static void DeleteTransportationObjectiveImage(this IQueryable<TransportationObjectiveImage> transportationObjectiveImages, ICollection<TransportationObjectiveImage> transportationObjectiveImagesToDelete)
        {
            if(transportationObjectiveImagesToDelete.Any())
            {
                var transportationObjectiveImageIDList = transportationObjectiveImagesToDelete.Select(x => x.TransportationObjectiveImageID).ToList();
                transportationObjectiveImages.Where(x => transportationObjectiveImageIDList.Contains(x.TransportationObjectiveImageID)).Delete();
            }
        }

        public static void DeleteTransportationObjectiveImage(this IQueryable<TransportationObjectiveImage> transportationObjectiveImages, int transportationObjectiveImageID)
        {
            DeleteTransportationObjectiveImage(transportationObjectiveImages, new List<int> { transportationObjectiveImageID });
        }

        public static void DeleteTransportationObjectiveImage(this IQueryable<TransportationObjectiveImage> transportationObjectiveImages, TransportationObjectiveImage transportationObjectiveImageToDelete)
        {
            DeleteTransportationObjectiveImage(transportationObjectiveImages, new List<TransportationObjectiveImage> { transportationObjectiveImageToDelete });
        }
    }
}