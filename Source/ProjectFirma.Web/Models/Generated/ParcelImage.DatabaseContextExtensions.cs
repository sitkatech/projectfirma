//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ParcelImage]
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
        public static ParcelImage GetParcelImage(this IQueryable<ParcelImage> parcelImages, int parcelImageID)
        {
            var parcelImage = parcelImages.SingleOrDefault(x => x.ParcelImageID == parcelImageID);
            Check.RequireNotNullThrowNotFound(parcelImage, "ParcelImage", parcelImageID);
            return parcelImage;
        }

        public static void DeleteParcelImage(this IQueryable<ParcelImage> parcelImages, List<int> parcelImageIDList)
        {
            if(parcelImageIDList.Any())
            {
                parcelImages.Where(x => parcelImageIDList.Contains(x.ParcelImageID)).Delete();
            }
        }

        public static void DeleteParcelImage(this IQueryable<ParcelImage> parcelImages, ICollection<ParcelImage> parcelImagesToDelete)
        {
            if(parcelImagesToDelete.Any())
            {
                var parcelImageIDList = parcelImagesToDelete.Select(x => x.ParcelImageID).ToList();
                parcelImages.Where(x => parcelImageIDList.Contains(x.ParcelImageID)).Delete();
            }
        }

        public static void DeleteParcelImage(this IQueryable<ParcelImage> parcelImages, int parcelImageID)
        {
            DeleteParcelImage(parcelImages, new List<int> { parcelImageID });
        }

        public static void DeleteParcelImage(this IQueryable<ParcelImage> parcelImages, ParcelImage parcelImageToDelete)
        {
            DeleteParcelImage(parcelImages, new List<ParcelImage> { parcelImageToDelete });
        }
    }
}