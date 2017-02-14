//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TaxonomyTierThreeImage]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static TaxonomyTierThreeImage GetTaxonomyTierThreeImage(this IQueryable<TaxonomyTierThreeImage> taxonomyTierThreeImages, int taxonomyTierThreeImageID)
        {
            var taxonomyTierThreeImage = taxonomyTierThreeImages.SingleOrDefault(x => x.TaxonomyTierThreeImageID == taxonomyTierThreeImageID);
            Check.RequireNotNullThrowNotFound(taxonomyTierThreeImage, "TaxonomyTierThreeImage", taxonomyTierThreeImageID);
            return taxonomyTierThreeImage;
        }

        public static void DeleteTaxonomyTierThreeImage(this List<int> taxonomyTierThreeImageIDList)
        {
            if(taxonomyTierThreeImageIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllTaxonomyTierThreeImages.RemoveRange(HttpRequestStorage.DatabaseEntities.TaxonomyTierThreeImages.Where(x => taxonomyTierThreeImageIDList.Contains(x.TaxonomyTierThreeImageID)));
            }
        }

        public static void DeleteTaxonomyTierThreeImage(this ICollection<TaxonomyTierThreeImage> taxonomyTierThreeImagesToDelete)
        {
            if(taxonomyTierThreeImagesToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllTaxonomyTierThreeImages.RemoveRange(taxonomyTierThreeImagesToDelete);
            }
        }

        public static void DeleteTaxonomyTierThreeImage(this int taxonomyTierThreeImageID)
        {
            DeleteTaxonomyTierThreeImage(new List<int> { taxonomyTierThreeImageID });
        }

        public static void DeleteTaxonomyTierThreeImage(this TaxonomyTierThreeImage taxonomyTierThreeImageToDelete)
        {
            DeleteTaxonomyTierThreeImage(new List<TaxonomyTierThreeImage> { taxonomyTierThreeImageToDelete });
        }
    }
}