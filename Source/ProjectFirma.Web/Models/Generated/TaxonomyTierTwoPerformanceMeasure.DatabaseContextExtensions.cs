//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TaxonomyTierTwoPerformanceMeasure]
using System.Collections.Generic;
using System.Linq;
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

        public static void DeleteTaxonomyTierTwoPerformanceMeasure(this List<int> taxonomyTierTwoPerformanceMeasureIDList)
        {
            if(taxonomyTierTwoPerformanceMeasureIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllTaxonomyTierTwoPerformanceMeasures.RemoveRange(HttpRequestStorage.DatabaseEntities.TaxonomyTierTwoPerformanceMeasures.Where(x => taxonomyTierTwoPerformanceMeasureIDList.Contains(x.TaxonomyTierTwoPerformanceMeasureID)));
            }
        }

        public static void DeleteTaxonomyTierTwoPerformanceMeasure(this ICollection<TaxonomyTierTwoPerformanceMeasure> taxonomyTierTwoPerformanceMeasuresToDelete)
        {
            if(taxonomyTierTwoPerformanceMeasuresToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllTaxonomyTierTwoPerformanceMeasures.RemoveRange(taxonomyTierTwoPerformanceMeasuresToDelete);
            }
        }

        public static void DeleteTaxonomyTierTwoPerformanceMeasure(this int taxonomyTierTwoPerformanceMeasureID)
        {
            DeleteTaxonomyTierTwoPerformanceMeasure(new List<int> { taxonomyTierTwoPerformanceMeasureID });
        }

        public static void DeleteTaxonomyTierTwoPerformanceMeasure(this TaxonomyTierTwoPerformanceMeasure taxonomyTierTwoPerformanceMeasureToDelete)
        {
            DeleteTaxonomyTierTwoPerformanceMeasure(new List<TaxonomyTierTwoPerformanceMeasure> { taxonomyTierTwoPerformanceMeasureToDelete });
        }
    }
}