//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TaxonomyTierTwoImage]
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
        public static TaxonomyTierTwoImage GetTaxonomyTierTwoImage(this IQueryable<TaxonomyTierTwoImage> taxonomyTierTwoImages, int taxonomyTierTwoImageID)
        {
            var taxonomyTierTwoImage = taxonomyTierTwoImages.SingleOrDefault(x => x.TaxonomyTierTwoImageID == taxonomyTierTwoImageID);
            Check.RequireNotNullThrowNotFound(taxonomyTierTwoImage, "TaxonomyTierTwoImage", taxonomyTierTwoImageID);
            return taxonomyTierTwoImage;
        }

        public static void DeleteTaxonomyTierTwoImage(this IQueryable<TaxonomyTierTwoImage> taxonomyTierTwoImages, List<int> taxonomyTierTwoImageIDList)
        {
            if(taxonomyTierTwoImageIDList.Any())
            {
                taxonomyTierTwoImages.Where(x => taxonomyTierTwoImageIDList.Contains(x.TaxonomyTierTwoImageID)).Delete();
            }
        }

        public static void DeleteTaxonomyTierTwoImage(this IQueryable<TaxonomyTierTwoImage> taxonomyTierTwoImages, ICollection<TaxonomyTierTwoImage> taxonomyTierTwoImagesToDelete)
        {
            if(taxonomyTierTwoImagesToDelete.Any())
            {
                var taxonomyTierTwoImageIDList = taxonomyTierTwoImagesToDelete.Select(x => x.TaxonomyTierTwoImageID).ToList();
                taxonomyTierTwoImages.Where(x => taxonomyTierTwoImageIDList.Contains(x.TaxonomyTierTwoImageID)).Delete();
            }
        }

        public static void DeleteTaxonomyTierTwoImage(this IQueryable<TaxonomyTierTwoImage> taxonomyTierTwoImages, int taxonomyTierTwoImageID)
        {
            DeleteTaxonomyTierTwoImage(taxonomyTierTwoImages, new List<int> { taxonomyTierTwoImageID });
        }

        public static void DeleteTaxonomyTierTwoImage(this IQueryable<TaxonomyTierTwoImage> taxonomyTierTwoImages, TaxonomyTierTwoImage taxonomyTierTwoImageToDelete)
        {
            DeleteTaxonomyTierTwoImage(taxonomyTierTwoImages, new List<TaxonomyTierTwoImage> { taxonomyTierTwoImageToDelete });
        }
    }
}