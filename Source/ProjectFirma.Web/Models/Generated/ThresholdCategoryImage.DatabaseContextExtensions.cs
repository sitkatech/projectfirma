//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ThresholdCategoryImage]
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
        public static ThresholdCategoryImage GetThresholdCategoryImage(this IQueryable<ThresholdCategoryImage> thresholdCategoryImages, int thresholdCategoryImageID)
        {
            var thresholdCategoryImage = thresholdCategoryImages.SingleOrDefault(x => x.ThresholdCategoryImageID == thresholdCategoryImageID);
            Check.RequireNotNullThrowNotFound(thresholdCategoryImage, "ThresholdCategoryImage", thresholdCategoryImageID);
            return thresholdCategoryImage;
        }

        public static void DeleteThresholdCategoryImage(this IQueryable<ThresholdCategoryImage> thresholdCategoryImages, List<int> thresholdCategoryImageIDList)
        {
            if(thresholdCategoryImageIDList.Any())
            {
                thresholdCategoryImages.Where(x => thresholdCategoryImageIDList.Contains(x.ThresholdCategoryImageID)).Delete();
            }
        }

        public static void DeleteThresholdCategoryImage(this IQueryable<ThresholdCategoryImage> thresholdCategoryImages, ICollection<ThresholdCategoryImage> thresholdCategoryImagesToDelete)
        {
            if(thresholdCategoryImagesToDelete.Any())
            {
                var thresholdCategoryImageIDList = thresholdCategoryImagesToDelete.Select(x => x.ThresholdCategoryImageID).ToList();
                thresholdCategoryImages.Where(x => thresholdCategoryImageIDList.Contains(x.ThresholdCategoryImageID)).Delete();
            }
        }

        public static void DeleteThresholdCategoryImage(this IQueryable<ThresholdCategoryImage> thresholdCategoryImages, int thresholdCategoryImageID)
        {
            DeleteThresholdCategoryImage(thresholdCategoryImages, new List<int> { thresholdCategoryImageID });
        }

        public static void DeleteThresholdCategoryImage(this IQueryable<ThresholdCategoryImage> thresholdCategoryImages, ThresholdCategoryImage thresholdCategoryImageToDelete)
        {
            DeleteThresholdCategoryImage(thresholdCategoryImages, new List<ThresholdCategoryImage> { thresholdCategoryImageToDelete });
        }
    }
}