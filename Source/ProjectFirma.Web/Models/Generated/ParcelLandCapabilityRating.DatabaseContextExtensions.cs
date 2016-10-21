//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ParcelLandCapabilityRating]
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
        public static ParcelLandCapabilityRating GetParcelLandCapabilityRating(this IQueryable<ParcelLandCapabilityRating> parcelLandCapabilityRatings, int parcelLandCapabilityRatingID)
        {
            var parcelLandCapabilityRating = parcelLandCapabilityRatings.SingleOrDefault(x => x.ParcelLandCapabilityRatingID == parcelLandCapabilityRatingID);
            Check.RequireNotNullThrowNotFound(parcelLandCapabilityRating, "ParcelLandCapabilityRating", parcelLandCapabilityRatingID);
            return parcelLandCapabilityRating;
        }

        public static void DeleteParcelLandCapabilityRating(this IQueryable<ParcelLandCapabilityRating> parcelLandCapabilityRatings, List<int> parcelLandCapabilityRatingIDList)
        {
            if(parcelLandCapabilityRatingIDList.Any())
            {
                parcelLandCapabilityRatings.Where(x => parcelLandCapabilityRatingIDList.Contains(x.ParcelLandCapabilityRatingID)).Delete();
            }
        }

        public static void DeleteParcelLandCapabilityRating(this IQueryable<ParcelLandCapabilityRating> parcelLandCapabilityRatings, ICollection<ParcelLandCapabilityRating> parcelLandCapabilityRatingsToDelete)
        {
            if(parcelLandCapabilityRatingsToDelete.Any())
            {
                var parcelLandCapabilityRatingIDList = parcelLandCapabilityRatingsToDelete.Select(x => x.ParcelLandCapabilityRatingID).ToList();
                parcelLandCapabilityRatings.Where(x => parcelLandCapabilityRatingIDList.Contains(x.ParcelLandCapabilityRatingID)).Delete();
            }
        }

        public static void DeleteParcelLandCapabilityRating(this IQueryable<ParcelLandCapabilityRating> parcelLandCapabilityRatings, int parcelLandCapabilityRatingID)
        {
            DeleteParcelLandCapabilityRating(parcelLandCapabilityRatings, new List<int> { parcelLandCapabilityRatingID });
        }

        public static void DeleteParcelLandCapabilityRating(this IQueryable<ParcelLandCapabilityRating> parcelLandCapabilityRatings, ParcelLandCapabilityRating parcelLandCapabilityRatingToDelete)
        {
            DeleteParcelLandCapabilityRating(parcelLandCapabilityRatings, new List<ParcelLandCapabilityRating> { parcelLandCapabilityRatingToDelete });
        }
    }
}