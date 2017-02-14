//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TaxonomyTierThree]
using System.Collections.Generic;
using System.Linq;
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

        public static void DeleteTaxonomyTierThree(this List<int> taxonomyTierThreeIDList)
        {
            if(taxonomyTierThreeIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllTaxonomyTierThrees.RemoveRange(HttpRequestStorage.DatabaseEntities.TaxonomyTierThrees.Where(x => taxonomyTierThreeIDList.Contains(x.TaxonomyTierThreeID)));
            }
        }

        public static void DeleteTaxonomyTierThree(this ICollection<TaxonomyTierThree> taxonomyTierThreesToDelete)
        {
            if(taxonomyTierThreesToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllTaxonomyTierThrees.RemoveRange(taxonomyTierThreesToDelete);
            }
        }

        public static void DeleteTaxonomyTierThree(this int taxonomyTierThreeID)
        {
            DeleteTaxonomyTierThree(new List<int> { taxonomyTierThreeID });
        }

        public static void DeleteTaxonomyTierThree(this TaxonomyTierThree taxonomyTierThreeToDelete)
        {
            DeleteTaxonomyTierThree(new List<TaxonomyTierThree> { taxonomyTierThreeToDelete });
        }
    }
}