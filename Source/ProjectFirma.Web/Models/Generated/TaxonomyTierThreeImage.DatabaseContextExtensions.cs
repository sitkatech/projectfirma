//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TaxonomyTierThreeImage]
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
        public static TaxonomyTierThreeImage GetTaxonomyTierThreeImage(this IQueryable<TaxonomyTierThreeImage> taxonomyTierThreeImages, int taxonomyTierThreeImageID)
        {
            var taxonomyTierThreeImage = taxonomyTierThreeImages.SingleOrDefault(x => x.TaxonomyTierThreeImageID == taxonomyTierThreeImageID);
            Check.RequireNotNullThrowNotFound(taxonomyTierThreeImage, "TaxonomyTierThreeImage", taxonomyTierThreeImageID);
            return taxonomyTierThreeImage;
        }

        public static void DeleteTaxonomyTierThreeImage(this IQueryable<TaxonomyTierThreeImage> taxonomyTierThreeImages, List<int> taxonomyTierThreeImageIDList)
        {
            if(taxonomyTierThreeImageIDList.Any())
            {
                taxonomyTierThreeImages.Where(x => taxonomyTierThreeImageIDList.Contains(x.TaxonomyTierThreeImageID)).Delete();
            }
        }

        public static void DeleteTaxonomyTierThreeImage(this IQueryable<TaxonomyTierThreeImage> taxonomyTierThreeImages, ICollection<TaxonomyTierThreeImage> taxonomyTierThreeImagesToDelete)
        {
            if(taxonomyTierThreeImagesToDelete.Any())
            {
                var taxonomyTierThreeImageIDList = taxonomyTierThreeImagesToDelete.Select(x => x.TaxonomyTierThreeImageID).ToList();
                taxonomyTierThreeImages.Where(x => taxonomyTierThreeImageIDList.Contains(x.TaxonomyTierThreeImageID)).Delete();
            }
        }

        public static void DeleteTaxonomyTierThreeImage(this IQueryable<TaxonomyTierThreeImage> taxonomyTierThreeImages, int taxonomyTierThreeImageID)
        {
            DeleteTaxonomyTierThreeImage(taxonomyTierThreeImages, new List<int> { taxonomyTierThreeImageID });
        }

        public static void DeleteTaxonomyTierThreeImage(this IQueryable<TaxonomyTierThreeImage> taxonomyTierThreeImages, TaxonomyTierThreeImage taxonomyTierThreeImageToDelete)
        {
            DeleteTaxonomyTierThreeImage(taxonomyTierThreeImages, new List<TaxonomyTierThreeImage> { taxonomyTierThreeImageToDelete });
        }
    }
}