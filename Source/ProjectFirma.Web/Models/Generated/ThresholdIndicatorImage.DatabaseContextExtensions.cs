//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ThresholdIndicatorImage]
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
        public static ThresholdIndicatorImage GetThresholdIndicatorImage(this IQueryable<ThresholdIndicatorImage> thresholdIndicatorImages, int thresholdIndicatorImageID)
        {
            var thresholdIndicatorImage = thresholdIndicatorImages.SingleOrDefault(x => x.ThresholdIndicatorImageID == thresholdIndicatorImageID);
            Check.RequireNotNullThrowNotFound(thresholdIndicatorImage, "ThresholdIndicatorImage", thresholdIndicatorImageID);
            return thresholdIndicatorImage;
        }

        public static void DeleteThresholdIndicatorImage(this IQueryable<ThresholdIndicatorImage> thresholdIndicatorImages, List<int> thresholdIndicatorImageIDList)
        {
            if(thresholdIndicatorImageIDList.Any())
            {
                thresholdIndicatorImages.Where(x => thresholdIndicatorImageIDList.Contains(x.ThresholdIndicatorImageID)).Delete();
            }
        }

        public static void DeleteThresholdIndicatorImage(this IQueryable<ThresholdIndicatorImage> thresholdIndicatorImages, ICollection<ThresholdIndicatorImage> thresholdIndicatorImagesToDelete)
        {
            if(thresholdIndicatorImagesToDelete.Any())
            {
                var thresholdIndicatorImageIDList = thresholdIndicatorImagesToDelete.Select(x => x.ThresholdIndicatorImageID).ToList();
                thresholdIndicatorImages.Where(x => thresholdIndicatorImageIDList.Contains(x.ThresholdIndicatorImageID)).Delete();
            }
        }

        public static void DeleteThresholdIndicatorImage(this IQueryable<ThresholdIndicatorImage> thresholdIndicatorImages, int thresholdIndicatorImageID)
        {
            DeleteThresholdIndicatorImage(thresholdIndicatorImages, new List<int> { thresholdIndicatorImageID });
        }

        public static void DeleteThresholdIndicatorImage(this IQueryable<ThresholdIndicatorImage> thresholdIndicatorImages, ThresholdIndicatorImage thresholdIndicatorImageToDelete)
        {
            DeleteThresholdIndicatorImage(thresholdIndicatorImages, new List<ThresholdIndicatorImage> { thresholdIndicatorImageToDelete });
        }
    }
}