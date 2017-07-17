//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FirmaHomePageImage]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static FirmaHomePageImage GetFirmaHomePageImage(this IQueryable<FirmaHomePageImage> firmaHomePageImages, int firmaHomePageImageID)
        {
            var firmaHomePageImage = firmaHomePageImages.SingleOrDefault(x => x.FirmaHomePageImageID == firmaHomePageImageID);
            Check.RequireNotNullThrowNotFound(firmaHomePageImage, "FirmaHomePageImage", firmaHomePageImageID);
            return firmaHomePageImage;
        }

        public static void DeleteFirmaHomePageImage(this List<int> firmaHomePageImageIDList)
        {
            if(firmaHomePageImageIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllFirmaHomePageImages.RemoveRange(HttpRequestStorage.DatabaseEntities.FirmaHomePageImages.Where(x => firmaHomePageImageIDList.Contains(x.FirmaHomePageImageID)));
            }
        }

        public static void DeleteFirmaHomePageImage(this ICollection<FirmaHomePageImage> firmaHomePageImagesToDelete)
        {
            if(firmaHomePageImagesToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllFirmaHomePageImages.RemoveRange(firmaHomePageImagesToDelete);
            }
        }

        public static void DeleteFirmaHomePageImage(this int firmaHomePageImageID)
        {
            DeleteFirmaHomePageImage(new List<int> { firmaHomePageImageID });
        }

        public static void DeleteFirmaHomePageImage(this FirmaHomePageImage firmaHomePageImageToDelete)
        {
            DeleteFirmaHomePageImage(new List<FirmaHomePageImage> { firmaHomePageImageToDelete });
        }
    }
}