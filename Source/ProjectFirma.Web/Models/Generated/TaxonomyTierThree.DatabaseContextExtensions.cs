//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TaxonomyTierThree]
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
        public static TaxonomyTierThree GetTaxonomyTierThree(this IQueryable<TaxonomyTierThree> taxonomyTierThrees, int taxonomyTierThreeID)
        {
            var taxonomyTierThree = taxonomyTierThrees.SingleOrDefault(x => x.TaxonomyTierThreeID == taxonomyTierThreeID);
            Check.RequireNotNullThrowNotFound(taxonomyTierThree, "TaxonomyTierThree", taxonomyTierThreeID);
            return taxonomyTierThree;
        }

        public static void DeleteTaxonomyTierThree(this IQueryable<TaxonomyTierThree> taxonomyTierThrees, List<int> taxonomyTierThreeIDList)
        {
            if(taxonomyTierThreeIDList.Any())
            {
                taxonomyTierThrees.Where(x => taxonomyTierThreeIDList.Contains(x.TaxonomyTierThreeID)).Delete();
            }
        }

        public static void DeleteTaxonomyTierThree(this IQueryable<TaxonomyTierThree> taxonomyTierThrees, ICollection<TaxonomyTierThree> taxonomyTierThreesToDelete)
        {
            if(taxonomyTierThreesToDelete.Any())
            {
                var taxonomyTierThreeIDList = taxonomyTierThreesToDelete.Select(x => x.TaxonomyTierThreeID).ToList();
                taxonomyTierThrees.Where(x => taxonomyTierThreeIDList.Contains(x.TaxonomyTierThreeID)).Delete();
            }
        }

        public static void DeleteTaxonomyTierThree(this IQueryable<TaxonomyTierThree> taxonomyTierThrees, int taxonomyTierThreeID)
        {
            DeleteTaxonomyTierThree(taxonomyTierThrees, new List<int> { taxonomyTierThreeID });
        }

        public static void DeleteTaxonomyTierThree(this IQueryable<TaxonomyTierThree> taxonomyTierThrees, TaxonomyTierThree taxonomyTierThreeToDelete)
        {
            DeleteTaxonomyTierThree(taxonomyTierThrees, new List<TaxonomyTierThree> { taxonomyTierThreeToDelete });
        }
    }
}