//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TaxonomyTrunk]
using System.Collections.Generic;
using System.Linq;
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static TaxonomyTrunk GetTaxonomyTrunk(this IQueryable<TaxonomyTrunk> taxonomyTrunks, int taxonomyTrunkID)
        {
            var taxonomyTrunk = taxonomyTrunks.SingleOrDefault(x => x.TaxonomyTrunkID == taxonomyTrunkID);
            Check.RequireNotNullThrowNotFound(taxonomyTrunk, "TaxonomyTrunk", taxonomyTrunkID);
            return taxonomyTrunk;
        }

    }
}