//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TaxonomyTierOne]
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
        public static TaxonomyTierOne GetTaxonomyTierOne(this IQueryable<TaxonomyTierOne> taxonomyTierOnes, int taxonomyTierOneID)
        {
            var taxonomyTierOne = taxonomyTierOnes.SingleOrDefault(x => x.TaxonomyTierOneID == taxonomyTierOneID);
            Check.RequireNotNullThrowNotFound(taxonomyTierOne, "TaxonomyTierOne", taxonomyTierOneID);
            return taxonomyTierOne;
        }

        public static void DeleteTaxonomyTierOne(this IQueryable<TaxonomyTierOne> taxonomyTierOnes, List<int> taxonomyTierOneIDList)
        {
            if(taxonomyTierOneIDList.Any())
            {
                taxonomyTierOnes.Where(x => taxonomyTierOneIDList.Contains(x.TaxonomyTierOneID)).Delete();
            }
        }

        public static void DeleteTaxonomyTierOne(this IQueryable<TaxonomyTierOne> taxonomyTierOnes, ICollection<TaxonomyTierOne> taxonomyTierOnesToDelete)
        {
            if(taxonomyTierOnesToDelete.Any())
            {
                var taxonomyTierOneIDList = taxonomyTierOnesToDelete.Select(x => x.TaxonomyTierOneID).ToList();
                taxonomyTierOnes.Where(x => taxonomyTierOneIDList.Contains(x.TaxonomyTierOneID)).Delete();
            }
        }

        public static void DeleteTaxonomyTierOne(this IQueryable<TaxonomyTierOne> taxonomyTierOnes, int taxonomyTierOneID)
        {
            DeleteTaxonomyTierOne(taxonomyTierOnes, new List<int> { taxonomyTierOneID });
        }

        public static void DeleteTaxonomyTierOne(this IQueryable<TaxonomyTierOne> taxonomyTierOnes, TaxonomyTierOne taxonomyTierOneToDelete)
        {
            DeleteTaxonomyTierOne(taxonomyTierOnes, new List<TaxonomyTierOne> { taxonomyTierOneToDelete });
        }
    }
}