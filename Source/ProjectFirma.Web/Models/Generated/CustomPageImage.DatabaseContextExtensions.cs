//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[CustomPageImage]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static CustomPageImage GetCustomPageImage(this IQueryable<CustomPageImage> customPageImages, int customPageImageID)
        {
            var customPageImage = customPageImages.SingleOrDefault(x => x.CustomPageImageID == customPageImageID);
            Check.RequireNotNullThrowNotFound(customPageImage, "CustomPageImage", customPageImageID);
            return customPageImage;
        }

        public static void DeleteCustomPageImage(this List<int> customPageImageIDList)
        {
            if(customPageImageIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllCustomPageImages.RemoveRange(HttpRequestStorage.DatabaseEntities.CustomPageImages.Where(x => customPageImageIDList.Contains(x.CustomPageImageID)));
            }
        }

        public static void DeleteCustomPageImage(this ICollection<CustomPageImage> customPageImagesToDelete)
        {
            if(customPageImagesToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllCustomPageImages.RemoveRange(customPageImagesToDelete);
            }
        }

        public static void DeleteCustomPageImage(this int customPageImageID)
        {
            DeleteCustomPageImage(new List<int> { customPageImageID });
        }

        public static void DeleteCustomPageImage(this CustomPageImage customPageImageToDelete)
        {
            DeleteCustomPageImage(new List<CustomPageImage> { customPageImageToDelete });
        }
    }
}