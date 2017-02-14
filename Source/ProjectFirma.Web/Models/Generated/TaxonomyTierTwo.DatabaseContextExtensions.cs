//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TaxonomyTierTwo]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static TaxonomyTierTwo GetTaxonomyTierTwo(this IQueryable<TaxonomyTierTwo> taxonomyTierTwos, int taxonomyTierTwoID)
        {
            var taxonomyTierTwo = taxonomyTierTwos.SingleOrDefault(x => x.TaxonomyTierTwoID == taxonomyTierTwoID);
            Check.RequireNotNullThrowNotFound(taxonomyTierTwo, "TaxonomyTierTwo", taxonomyTierTwoID);
            return taxonomyTierTwo;
        }

        public static void DeleteTaxonomyTierTwo(this List<int> taxonomyTierTwoIDList)
        {
            if(taxonomyTierTwoIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllTaxonomyTierTwos.RemoveRange(HttpRequestStorage.DatabaseEntities.TaxonomyTierTwos.Where(x => taxonomyTierTwoIDList.Contains(x.TaxonomyTierTwoID)));
            }
        }

        public static void DeleteTaxonomyTierTwo(this ICollection<TaxonomyTierTwo> taxonomyTierTwosToDelete)
        {
            if(taxonomyTierTwosToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllTaxonomyTierTwos.RemoveRange(taxonomyTierTwosToDelete);
            }
        }

        public static void DeleteTaxonomyTierTwo(this int taxonomyTierTwoID)
        {
            DeleteTaxonomyTierTwo(new List<int> { taxonomyTierTwoID });
        }

        public static void DeleteTaxonomyTierTwo(this TaxonomyTierTwo taxonomyTierTwoToDelete)
        {
            DeleteTaxonomyTierTwo(new List<TaxonomyTierTwo> { taxonomyTierTwoToDelete });
        }
    }
}