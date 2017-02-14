//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FirmaPageImage]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static FirmaPageImage GetFirmaPageImage(this IQueryable<FirmaPageImage> firmaPageImages, int firmaPageImageID)
        {
            var firmaPageImage = firmaPageImages.SingleOrDefault(x => x.FirmaPageImageID == firmaPageImageID);
            Check.RequireNotNullThrowNotFound(firmaPageImage, "FirmaPageImage", firmaPageImageID);
            return firmaPageImage;
        }

        public static void DeleteFirmaPageImage(this List<int> firmaPageImageIDList)
        {
            if(firmaPageImageIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllFirmaPageImages.RemoveRange(HttpRequestStorage.DatabaseEntities.FirmaPageImages.Where(x => firmaPageImageIDList.Contains(x.FirmaPageImageID)));
            }
        }

        public static void DeleteFirmaPageImage(this ICollection<FirmaPageImage> firmaPageImagesToDelete)
        {
            if(firmaPageImagesToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllFirmaPageImages.RemoveRange(firmaPageImagesToDelete);
            }
        }

        public static void DeleteFirmaPageImage(this int firmaPageImageID)
        {
            DeleteFirmaPageImage(new List<int> { firmaPageImageID });
        }

        public static void DeleteFirmaPageImage(this FirmaPageImage firmaPageImageToDelete)
        {
            DeleteFirmaPageImage(new List<FirmaPageImage> { firmaPageImageToDelete });
        }
    }
}