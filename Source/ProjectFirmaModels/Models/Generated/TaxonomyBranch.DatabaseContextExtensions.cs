//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TaxonomyBranch]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static TaxonomyBranch GetTaxonomyBranch(this IQueryable<TaxonomyBranch> taxonomyBranches, int taxonomyBranchID)
        {
            var taxonomyBranch = taxonomyBranches.SingleOrDefault(x => x.TaxonomyBranchID == taxonomyBranchID);
            Check.RequireNotNullThrowNotFound(taxonomyBranch, "TaxonomyBranch", taxonomyBranchID);
            return taxonomyBranch;
        }

    }
}