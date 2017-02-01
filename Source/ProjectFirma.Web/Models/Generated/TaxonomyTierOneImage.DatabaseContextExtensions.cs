//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TaxonomyTierOneImage]
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
        public static TaxonomyTierOneImage GetTaxonomyTierOneImage(this IQueryable<TaxonomyTierOneImage> taxonomyTierOneImages, int taxonomyTierOneImageID)
        {
            var taxonomyTierOneImage = taxonomyTierOneImages.SingleOrDefault(x => x.TaxonomyTierOneImageID == taxonomyTierOneImageID);
            Check.RequireNotNullThrowNotFound(taxonomyTierOneImage, "TaxonomyTierOneImage", taxonomyTierOneImageID);
            return taxonomyTierOneImage;
        }

        public static void DeleteTaxonomyTierOneImage(this IQueryable<TaxonomyTierOneImage> taxonomyTierOneImages, List<int> taxonomyTierOneImageIDList)
        {
            if(taxonomyTierOneImageIDList.Any())
            {
                taxonomyTierOneImages.Where(x => taxonomyTierOneImageIDList.Contains(x.TaxonomyTierOneImageID)).Delete();
            }
        }

        public static void DeleteTaxonomyTierOneImage(this IQueryable<TaxonomyTierOneImage> taxonomyTierOneImages, ICollection<TaxonomyTierOneImage> taxonomyTierOneImagesToDelete)
        {
            if(taxonomyTierOneImagesToDelete.Any())
            {
                var taxonomyTierOneImageIDList = taxonomyTierOneImagesToDelete.Select(x => x.TaxonomyTierOneImageID).ToList();
                taxonomyTierOneImages.Where(x => taxonomyTierOneImageIDList.Contains(x.TaxonomyTierOneImageID)).Delete();
            }
        }

        public static void DeleteTaxonomyTierOneImage(this IQueryable<TaxonomyTierOneImage> taxonomyTierOneImages, int taxonomyTierOneImageID)
        {
            DeleteTaxonomyTierOneImage(taxonomyTierOneImages, new List<int> { taxonomyTierOneImageID });
        }

        public static void DeleteTaxonomyTierOneImage(this IQueryable<TaxonomyTierOneImage> taxonomyTierOneImages, TaxonomyTierOneImage taxonomyTierOneImageToDelete)
        {
            DeleteTaxonomyTierOneImage(taxonomyTierOneImages, new List<TaxonomyTierOneImage> { taxonomyTierOneImageToDelete });
        }
    }
}