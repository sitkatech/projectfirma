//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FocusAreaImage]
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
        public static FocusAreaImage GetFocusAreaImage(this IQueryable<FocusAreaImage> focusAreaImages, int focusAreaImageID)
        {
            var focusAreaImage = focusAreaImages.SingleOrDefault(x => x.FocusAreaImageID == focusAreaImageID);
            Check.RequireNotNullThrowNotFound(focusAreaImage, "FocusAreaImage", focusAreaImageID);
            return focusAreaImage;
        }

        public static void DeleteFocusAreaImage(this IQueryable<FocusAreaImage> focusAreaImages, List<int> focusAreaImageIDList)
        {
            if(focusAreaImageIDList.Any())
            {
                focusAreaImages.Where(x => focusAreaImageIDList.Contains(x.FocusAreaImageID)).Delete();
            }
        }

        public static void DeleteFocusAreaImage(this IQueryable<FocusAreaImage> focusAreaImages, ICollection<FocusAreaImage> focusAreaImagesToDelete)
        {
            if(focusAreaImagesToDelete.Any())
            {
                var focusAreaImageIDList = focusAreaImagesToDelete.Select(x => x.FocusAreaImageID).ToList();
                focusAreaImages.Where(x => focusAreaImageIDList.Contains(x.FocusAreaImageID)).Delete();
            }
        }

        public static void DeleteFocusAreaImage(this IQueryable<FocusAreaImage> focusAreaImages, int focusAreaImageID)
        {
            DeleteFocusAreaImage(focusAreaImages, new List<int> { focusAreaImageID });
        }

        public static void DeleteFocusAreaImage(this IQueryable<FocusAreaImage> focusAreaImages, FocusAreaImage focusAreaImageToDelete)
        {
            DeleteFocusAreaImage(focusAreaImages, new List<FocusAreaImage> { focusAreaImageToDelete });
        }
    }
}