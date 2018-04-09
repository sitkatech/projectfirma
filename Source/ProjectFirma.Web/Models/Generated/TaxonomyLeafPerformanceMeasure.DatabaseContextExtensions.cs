//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TaxonomyLeafPerformanceMeasure]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static TaxonomyLeafPerformanceMeasure GetTaxonomyLeafPerformanceMeasure(this IQueryable<TaxonomyLeafPerformanceMeasure> taxonomyLeafPerformanceMeasures, int taxonomyLeafPerformanceMeasureID)
        {
            var taxonomyLeafPerformanceMeasure = taxonomyLeafPerformanceMeasures.SingleOrDefault(x => x.TaxonomyLeafPerformanceMeasureID == taxonomyLeafPerformanceMeasureID);
            Check.RequireNotNullThrowNotFound(taxonomyLeafPerformanceMeasure, "TaxonomyLeafPerformanceMeasure", taxonomyLeafPerformanceMeasureID);
            return taxonomyLeafPerformanceMeasure;
        }

        public static void DeleteTaxonomyLeafPerformanceMeasure(this List<int> taxonomyLeafPerformanceMeasureIDList)
        {
            if(taxonomyLeafPerformanceMeasureIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllTaxonomyLeafPerformanceMeasures.RemoveRange(HttpRequestStorage.DatabaseEntities.TaxonomyLeafPerformanceMeasures.Where(x => taxonomyLeafPerformanceMeasureIDList.Contains(x.TaxonomyLeafPerformanceMeasureID)));
            }
        }

        public static void DeleteTaxonomyLeafPerformanceMeasure(this ICollection<TaxonomyLeafPerformanceMeasure> taxonomyLeafPerformanceMeasuresToDelete)
        {
            if(taxonomyLeafPerformanceMeasuresToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllTaxonomyLeafPerformanceMeasures.RemoveRange(taxonomyLeafPerformanceMeasuresToDelete);
            }
        }

        public static void DeleteTaxonomyLeafPerformanceMeasure(this int taxonomyLeafPerformanceMeasureID)
        {
            DeleteTaxonomyLeafPerformanceMeasure(new List<int> { taxonomyLeafPerformanceMeasureID });
        }

        public static void DeleteTaxonomyLeafPerformanceMeasure(this TaxonomyLeafPerformanceMeasure taxonomyLeafPerformanceMeasureToDelete)
        {
            DeleteTaxonomyLeafPerformanceMeasure(new List<TaxonomyLeafPerformanceMeasure> { taxonomyLeafPerformanceMeasureToDelete });
        }
    }
}