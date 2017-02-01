//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FirmaPageImage]
using System.Collections.Generic;
using System.Linq;
using Z.EntityFramework.Plus;
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

        public static void DeleteFirmaPageImage(this IQueryable<FirmaPageImage> firmaPageImages, List<int> firmaPageImageIDList)
        {
            if(firmaPageImageIDList.Any())
            {
                firmaPageImages.Where(x => firmaPageImageIDList.Contains(x.FirmaPageImageID)).Delete();
            }
        }

        public static void DeleteFirmaPageImage(this IQueryable<FirmaPageImage> firmaPageImages, ICollection<FirmaPageImage> firmaPageImagesToDelete)
        {
            if(firmaPageImagesToDelete.Any())
            {
                var firmaPageImageIDList = firmaPageImagesToDelete.Select(x => x.FirmaPageImageID).ToList();
                firmaPageImages.Where(x => firmaPageImageIDList.Contains(x.FirmaPageImageID)).Delete();
            }
        }

        public static void DeleteFirmaPageImage(this IQueryable<FirmaPageImage> firmaPageImages, int firmaPageImageID)
        {
            DeleteFirmaPageImage(firmaPageImages, new List<int> { firmaPageImageID });
        }

        public static void DeleteFirmaPageImage(this IQueryable<FirmaPageImage> firmaPageImages, FirmaPageImage firmaPageImageToDelete)
        {
            DeleteFirmaPageImage(firmaPageImages, new List<FirmaPageImage> { firmaPageImageToDelete });
        }
    }
}