//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TaxonomyLeaf]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static TaxonomyLeaf GetTaxonomyLeaf(this IQueryable<TaxonomyLeaf> taxonomyLeafs, int taxonomyLeafID)
        {
            var taxonomyLeaf = taxonomyLeafs.SingleOrDefault(x => x.TaxonomyLeafID == taxonomyLeafID);
            Check.RequireNotNullThrowNotFound(taxonomyLeaf, "TaxonomyLeaf", taxonomyLeafID);
            return taxonomyLeaf;
        }

    }
}