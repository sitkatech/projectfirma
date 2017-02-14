//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TaxonomyTierTwoImage]
using System.Collections.Generic;
using System.Linq;
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

        public static void DeleteTaxonomyTierTwoImage(this List<int> taxonomyTierTwoImageIDList)
        {
            if(taxonomyTierTwoImageIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllTaxonomyTierTwoImages.RemoveRange(HttpRequestStorage.DatabaseEntities.TaxonomyTierTwoImages.Where(x => taxonomyTierTwoImageIDList.Contains(x.TaxonomyTierTwoImageID)));
            }
        }

        public static void DeleteTaxonomyTierTwoImage(this ICollection<TaxonomyTierTwoImage> taxonomyTierTwoImagesToDelete)
        {
            if(taxonomyTierTwoImagesToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllTaxonomyTierTwoImages.RemoveRange(taxonomyTierTwoImagesToDelete);
            }
        }

        public static void DeleteTaxonomyTierTwoImage(this int taxonomyTierTwoImageID)
        {
            DeleteTaxonomyTierTwoImage(new List<int> { taxonomyTierTwoImageID });
        }

        public static void DeleteTaxonomyTierTwoImage(this TaxonomyTierTwoImage taxonomyTierTwoImageToDelete)
        {
            DeleteTaxonomyTierTwoImage(new List<TaxonomyTierTwoImage> { taxonomyTierTwoImageToDelete });
        }
    }
}