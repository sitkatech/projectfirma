//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TaxonomyTierOne]
using System.Collections.Generic;
using System.Linq;
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

        public static void DeleteTaxonomyTierOne(this List<int> taxonomyTierOneIDList)
        {
            if(taxonomyTierOneIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllTaxonomyTierOnes.RemoveRange(HttpRequestStorage.DatabaseEntities.TaxonomyTierOnes.Where(x => taxonomyTierOneIDList.Contains(x.TaxonomyTierOneID)));
            }
        }

        public static void DeleteTaxonomyTierOne(this ICollection<TaxonomyTierOne> taxonomyTierOnesToDelete)
        {
            if(taxonomyTierOnesToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllTaxonomyTierOnes.RemoveRange(taxonomyTierOnesToDelete);
            }
        }

        public static void DeleteTaxonomyTierOne(this int taxonomyTierOneID)
        {
            DeleteTaxonomyTierOne(new List<int> { taxonomyTierOneID });
        }

        public static void DeleteTaxonomyTierOne(this TaxonomyTierOne taxonomyTierOneToDelete)
        {
            DeleteTaxonomyTierOne(new List<TaxonomyTierOne> { taxonomyTierOneToDelete });
        }
    }
}