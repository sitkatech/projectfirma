//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ParcelCommodityBaileyRatingConfirmation]
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
        public static ParcelCommodityBaileyRatingConfirmation GetParcelCommodityBaileyRatingConfirmation(this IQueryable<ParcelCommodityBaileyRatingConfirmation> parcelCommodityBaileyRatingConfirmations, int parcelCommodityBaileyRatingConfirmationID)
        {
            var parcelCommodityBaileyRatingConfirmation = parcelCommodityBaileyRatingConfirmations.SingleOrDefault(x => x.ParcelCommodityBaileyRatingConfirmationID == parcelCommodityBaileyRatingConfirmationID);
            Check.RequireNotNullThrowNotFound(parcelCommodityBaileyRatingConfirmation, "ParcelCommodityBaileyRatingConfirmation", parcelCommodityBaileyRatingConfirmationID);
            return parcelCommodityBaileyRatingConfirmation;
        }

        public static void DeleteParcelCommodityBaileyRatingConfirmation(this IQueryable<ParcelCommodityBaileyRatingConfirmation> parcelCommodityBaileyRatingConfirmations, List<int> parcelCommodityBaileyRatingConfirmationIDList)
        {
            if(parcelCommodityBaileyRatingConfirmationIDList.Any())
            {
                parcelCommodityBaileyRatingConfirmations.Where(x => parcelCommodityBaileyRatingConfirmationIDList.Contains(x.ParcelCommodityBaileyRatingConfirmationID)).Delete();
            }
        }

        public static void DeleteParcelCommodityBaileyRatingConfirmation(this IQueryable<ParcelCommodityBaileyRatingConfirmation> parcelCommodityBaileyRatingConfirmations, ICollection<ParcelCommodityBaileyRatingConfirmation> parcelCommodityBaileyRatingConfirmationsToDelete)
        {
            if(parcelCommodityBaileyRatingConfirmationsToDelete.Any())
            {
                var parcelCommodityBaileyRatingConfirmationIDList = parcelCommodityBaileyRatingConfirmationsToDelete.Select(x => x.ParcelCommodityBaileyRatingConfirmationID).ToList();
                parcelCommodityBaileyRatingConfirmations.Where(x => parcelCommodityBaileyRatingConfirmationIDList.Contains(x.ParcelCommodityBaileyRatingConfirmationID)).Delete();
            }
        }

        public static void DeleteParcelCommodityBaileyRatingConfirmation(this IQueryable<ParcelCommodityBaileyRatingConfirmation> parcelCommodityBaileyRatingConfirmations, int parcelCommodityBaileyRatingConfirmationID)
        {
            DeleteParcelCommodityBaileyRatingConfirmation(parcelCommodityBaileyRatingConfirmations, new List<int> { parcelCommodityBaileyRatingConfirmationID });
        }

        public static void DeleteParcelCommodityBaileyRatingConfirmation(this IQueryable<ParcelCommodityBaileyRatingConfirmation> parcelCommodityBaileyRatingConfirmations, ParcelCommodityBaileyRatingConfirmation parcelCommodityBaileyRatingConfirmationToDelete)
        {
            DeleteParcelCommodityBaileyRatingConfirmation(parcelCommodityBaileyRatingConfirmations, new List<ParcelCommodityBaileyRatingConfirmation> { parcelCommodityBaileyRatingConfirmationToDelete });
        }
    }
}