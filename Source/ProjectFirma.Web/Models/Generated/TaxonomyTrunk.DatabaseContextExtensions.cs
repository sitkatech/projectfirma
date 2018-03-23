//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TaxonomyTrunk]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static TaxonomyTrunk GetTaxonomyTrunk(this IQueryable<TaxonomyTrunk> taxonomyTrunks, int taxonomyTrunkID)
        {
            var taxonomyTrunk = taxonomyTrunks.SingleOrDefault(x => x.TaxonomyTrunkID == taxonomyTrunkID);
            Check.RequireNotNullThrowNotFound(taxonomyTrunk, "TaxonomyTrunk", taxonomyTrunkID);
            return taxonomyTrunk;
        }

        public static void DeleteTaxonomyTrunk(this List<int> taxonomyTrunkIDList)
        {
            if(taxonomyTrunkIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllTaxonomyTrunks.RemoveRange(HttpRequestStorage.DatabaseEntities.TaxonomyTrunks.Where(x => taxonomyTrunkIDList.Contains(x.TaxonomyTrunkID)));
            }
        }

        public static void DeleteTaxonomyTrunk(this ICollection<TaxonomyTrunk> taxonomyTrunksToDelete)
        {
            if(taxonomyTrunksToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllTaxonomyTrunks.RemoveRange(taxonomyTrunksToDelete);
            }
        }

        public static void DeleteTaxonomyTrunk(this int taxonomyTrunkID)
        {
            DeleteTaxonomyTrunk(new List<int> { taxonomyTrunkID });
        }

        public static void DeleteTaxonomyTrunk(this TaxonomyTrunk taxonomyTrunkToDelete)
        {
            DeleteTaxonomyTrunk(new List<TaxonomyTrunk> { taxonomyTrunkToDelete });
        }
    }
}