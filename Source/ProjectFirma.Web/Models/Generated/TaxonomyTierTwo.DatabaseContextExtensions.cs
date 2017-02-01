//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TaxonomyTierTwo]
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
        public static TaxonomyTierTwo GetTaxonomyTierTwo(this IQueryable<TaxonomyTierTwo> taxonomyTierTwos, int taxonomyTierTwoID)
        {
            var taxonomyTierTwo = taxonomyTierTwos.SingleOrDefault(x => x.TaxonomyTierTwoID == taxonomyTierTwoID);
            Check.RequireNotNullThrowNotFound(taxonomyTierTwo, "TaxonomyTierTwo", taxonomyTierTwoID);
            return taxonomyTierTwo;
        }

        public static void DeleteTaxonomyTierTwo(this IQueryable<TaxonomyTierTwo> taxonomyTierTwos, List<int> taxonomyTierTwoIDList)
        {
            if(taxonomyTierTwoIDList.Any())
            {
                taxonomyTierTwos.Where(x => taxonomyTierTwoIDList.Contains(x.TaxonomyTierTwoID)).Delete();
            }
        }

        public static void DeleteTaxonomyTierTwo(this IQueryable<TaxonomyTierTwo> taxonomyTierTwos, ICollection<TaxonomyTierTwo> taxonomyTierTwosToDelete)
        {
            if(taxonomyTierTwosToDelete.Any())
            {
                var taxonomyTierTwoIDList = taxonomyTierTwosToDelete.Select(x => x.TaxonomyTierTwoID).ToList();
                taxonomyTierTwos.Where(x => taxonomyTierTwoIDList.Contains(x.TaxonomyTierTwoID)).Delete();
            }
        }

        public static void DeleteTaxonomyTierTwo(this IQueryable<TaxonomyTierTwo> taxonomyTierTwos, int taxonomyTierTwoID)
        {
            DeleteTaxonomyTierTwo(taxonomyTierTwos, new List<int> { taxonomyTierTwoID });
        }

        public static void DeleteTaxonomyTierTwo(this IQueryable<TaxonomyTierTwo> taxonomyTierTwos, TaxonomyTierTwo taxonomyTierTwoToDelete)
        {
            DeleteTaxonomyTierTwo(taxonomyTierTwos, new List<TaxonomyTierTwo> { taxonomyTierTwoToDelete });
        }
    }
}