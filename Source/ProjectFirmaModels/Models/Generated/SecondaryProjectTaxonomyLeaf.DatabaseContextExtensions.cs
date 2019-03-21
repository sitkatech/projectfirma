//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[SecondaryProjectTaxonomyLeaf]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static SecondaryProjectTaxonomyLeaf GetSecondaryProjectTaxonomyLeaf(this IQueryable<SecondaryProjectTaxonomyLeaf> secondaryProjectTaxonomyLeafs, int secondaryProjectTaxonomyLeafID)
        {
            var secondaryProjectTaxonomyLeaf = secondaryProjectTaxonomyLeafs.SingleOrDefault(x => x.SecondaryProjectTaxonomyLeafID == secondaryProjectTaxonomyLeafID);
            Check.RequireNotNullThrowNotFound(secondaryProjectTaxonomyLeaf, "SecondaryProjectTaxonomyLeaf", secondaryProjectTaxonomyLeafID);
            return secondaryProjectTaxonomyLeaf;
        }

    }
}