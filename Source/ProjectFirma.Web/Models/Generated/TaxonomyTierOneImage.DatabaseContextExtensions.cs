//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TaxonomyTierOneImage]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static TaxonomyTierOneImage GetTaxonomyTierOneImage(this IQueryable<TaxonomyTierOneImage> taxonomyTierOneImages, int taxonomyTierOneImageID)
        {
            var taxonomyTierOneImage = taxonomyTierOneImages.SingleOrDefault(x => x.TaxonomyTierOneImageID == taxonomyTierOneImageID);
            Check.RequireNotNullThrowNotFound(taxonomyTierOneImage, "TaxonomyTierOneImage", taxonomyTierOneImageID);
            return taxonomyTierOneImage;
        }

        public static void DeleteTaxonomyTierOneImage(this List<int> taxonomyTierOneImageIDList)
        {
            if(taxonomyTierOneImageIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllTaxonomyTierOneImages.RemoveRange(HttpRequestStorage.DatabaseEntities.TaxonomyTierOneImages.Where(x => taxonomyTierOneImageIDList.Contains(x.TaxonomyTierOneImageID)));
            }
        }

        public static void DeleteTaxonomyTierOneImage(this ICollection<TaxonomyTierOneImage> taxonomyTierOneImagesToDelete)
        {
            if(taxonomyTierOneImagesToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllTaxonomyTierOneImages.RemoveRange(taxonomyTierOneImagesToDelete);
            }
        }

        public static void DeleteTaxonomyTierOneImage(this int taxonomyTierOneImageID)
        {
            DeleteTaxonomyTierOneImage(new List<int> { taxonomyTierOneImageID });
        }

        public static void DeleteTaxonomyTierOneImage(this TaxonomyTierOneImage taxonomyTierOneImageToDelete)
        {
            DeleteTaxonomyTierOneImage(new List<TaxonomyTierOneImage> { taxonomyTierOneImageToDelete });
        }
    }
}