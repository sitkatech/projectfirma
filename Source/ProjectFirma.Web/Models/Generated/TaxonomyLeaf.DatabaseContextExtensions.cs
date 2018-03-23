//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TaxonomyLeaf]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static TaxonomyLeaf GetTaxonomyLeaf(this IQueryable<TaxonomyLeaf> taxonomyLeafs, int taxonomyLeafID)
        {
            var taxonomyLeaf = taxonomyLeafs.SingleOrDefault(x => x.TaxonomyLeafID == taxonomyLeafID);
            Check.RequireNotNullThrowNotFound(taxonomyLeaf, "TaxonomyLeaf", taxonomyLeafID);
            return taxonomyLeaf;
        }

        public static void DeleteTaxonomyLeaf(this List<int> taxonomyLeafIDList)
        {
            if(taxonomyLeafIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllTaxonomyLeafs.RemoveRange(HttpRequestStorage.DatabaseEntities.TaxonomyLeafs.Where(x => taxonomyLeafIDList.Contains(x.TaxonomyLeafID)));
            }
        }

        public static void DeleteTaxonomyLeaf(this ICollection<TaxonomyLeaf> taxonomyLeafsToDelete)
        {
            if(taxonomyLeafsToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllTaxonomyLeafs.RemoveRange(taxonomyLeafsToDelete);
            }
        }

        public static void DeleteTaxonomyLeaf(this int taxonomyLeafID)
        {
            DeleteTaxonomyLeaf(new List<int> { taxonomyLeafID });
        }

        public static void DeleteTaxonomyLeaf(this TaxonomyLeaf taxonomyLeafToDelete)
        {
            DeleteTaxonomyLeaf(new List<TaxonomyLeaf> { taxonomyLeafToDelete });
        }
    }
}