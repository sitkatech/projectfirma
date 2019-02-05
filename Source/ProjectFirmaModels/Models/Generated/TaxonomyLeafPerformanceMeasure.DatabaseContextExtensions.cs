//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TaxonomyLeafPerformanceMeasure]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static TaxonomyLeafPerformanceMeasure GetTaxonomyLeafPerformanceMeasure(this IQueryable<TaxonomyLeafPerformanceMeasure> taxonomyLeafPerformanceMeasures, int taxonomyLeafPerformanceMeasureID)
        {
            var taxonomyLeafPerformanceMeasure = taxonomyLeafPerformanceMeasures.SingleOrDefault(x => x.TaxonomyLeafPerformanceMeasureID == taxonomyLeafPerformanceMeasureID);
            Check.RequireNotNullThrowNotFound(taxonomyLeafPerformanceMeasure, "TaxonomyLeafPerformanceMeasure", taxonomyLeafPerformanceMeasureID);
            return taxonomyLeafPerformanceMeasure;
        }

    }
}