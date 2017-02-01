//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TaxonomyTierTwoPerformanceMeasure]
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
        public static TaxonomyTierTwoPerformanceMeasure GetTaxonomyTierTwoPerformanceMeasure(this IQueryable<TaxonomyTierTwoPerformanceMeasure> taxonomyTierTwoPerformanceMeasures, int taxonomyTierTwoPerformanceMeasureID)
        {
            var taxonomyTierTwoPerformanceMeasure = taxonomyTierTwoPerformanceMeasures.SingleOrDefault(x => x.TaxonomyTierTwoPerformanceMeasureID == taxonomyTierTwoPerformanceMeasureID);
            Check.RequireNotNullThrowNotFound(taxonomyTierTwoPerformanceMeasure, "TaxonomyTierTwoPerformanceMeasure", taxonomyTierTwoPerformanceMeasureID);
            return taxonomyTierTwoPerformanceMeasure;
        }

        public static void DeleteTaxonomyTierTwoPerformanceMeasure(this IQueryable<TaxonomyTierTwoPerformanceMeasure> taxonomyTierTwoPerformanceMeasures, List<int> taxonomyTierTwoPerformanceMeasureIDList)
        {
            if(taxonomyTierTwoPerformanceMeasureIDList.Any())
            {
                taxonomyTierTwoPerformanceMeasures.Where(x => taxonomyTierTwoPerformanceMeasureIDList.Contains(x.TaxonomyTierTwoPerformanceMeasureID)).Delete();
            }
        }

        public static void DeleteTaxonomyTierTwoPerformanceMeasure(this IQueryable<TaxonomyTierTwoPerformanceMeasure> taxonomyTierTwoPerformanceMeasures, ICollection<TaxonomyTierTwoPerformanceMeasure> taxonomyTierTwoPerformanceMeasuresToDelete)
        {
            if(taxonomyTierTwoPerformanceMeasuresToDelete.Any())
            {
                var taxonomyTierTwoPerformanceMeasureIDList = taxonomyTierTwoPerformanceMeasuresToDelete.Select(x => x.TaxonomyTierTwoPerformanceMeasureID).ToList();
                taxonomyTierTwoPerformanceMeasures.Where(x => taxonomyTierTwoPerformanceMeasureIDList.Contains(x.TaxonomyTierTwoPerformanceMeasureID)).Delete();
            }
        }

        public static void DeleteTaxonomyTierTwoPerformanceMeasure(this IQueryable<TaxonomyTierTwoPerformanceMeasure> taxonomyTierTwoPerformanceMeasures, int taxonomyTierTwoPerformanceMeasureID)
        {
            DeleteTaxonomyTierTwoPerformanceMeasure(taxonomyTierTwoPerformanceMeasures, new List<int> { taxonomyTierTwoPerformanceMeasureID });
        }

        public static void DeleteTaxonomyTierTwoPerformanceMeasure(this IQueryable<TaxonomyTierTwoPerformanceMeasure> taxonomyTierTwoPerformanceMeasures, TaxonomyTierTwoPerformanceMeasure taxonomyTierTwoPerformanceMeasureToDelete)
        {
            DeleteTaxonomyTierTwoPerformanceMeasure(taxonomyTierTwoPerformanceMeasures, new List<TaxonomyTierTwoPerformanceMeasure> { taxonomyTierTwoPerformanceMeasureToDelete });
        }
    }
}