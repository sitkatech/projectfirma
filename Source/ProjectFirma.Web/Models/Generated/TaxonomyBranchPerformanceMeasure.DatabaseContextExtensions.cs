//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TaxonomyBranchPerformanceMeasure]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static TaxonomyBranchPerformanceMeasure GetTaxonomyBranchPerformanceMeasure(this IQueryable<TaxonomyBranchPerformanceMeasure> taxonomyBranchPerformanceMeasures, int taxonomyBranchPerformanceMeasureID)
        {
            var taxonomyBranchPerformanceMeasure = taxonomyBranchPerformanceMeasures.SingleOrDefault(x => x.TaxonomyBranchPerformanceMeasureID == taxonomyBranchPerformanceMeasureID);
            Check.RequireNotNullThrowNotFound(taxonomyBranchPerformanceMeasure, "TaxonomyBranchPerformanceMeasure", taxonomyBranchPerformanceMeasureID);
            return taxonomyBranchPerformanceMeasure;
        }

        public static void DeleteTaxonomyBranchPerformanceMeasure(this List<int> taxonomyBranchPerformanceMeasureIDList)
        {
            if(taxonomyBranchPerformanceMeasureIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllTaxonomyBranchPerformanceMeasures.RemoveRange(HttpRequestStorage.DatabaseEntities.TaxonomyBranchPerformanceMeasures.Where(x => taxonomyBranchPerformanceMeasureIDList.Contains(x.TaxonomyBranchPerformanceMeasureID)));
            }
        }

        public static void DeleteTaxonomyBranchPerformanceMeasure(this ICollection<TaxonomyBranchPerformanceMeasure> taxonomyBranchPerformanceMeasuresToDelete)
        {
            if(taxonomyBranchPerformanceMeasuresToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllTaxonomyBranchPerformanceMeasures.RemoveRange(taxonomyBranchPerformanceMeasuresToDelete);
            }
        }

        public static void DeleteTaxonomyBranchPerformanceMeasure(this int taxonomyBranchPerformanceMeasureID)
        {
            DeleteTaxonomyBranchPerformanceMeasure(new List<int> { taxonomyBranchPerformanceMeasureID });
        }

        public static void DeleteTaxonomyBranchPerformanceMeasure(this TaxonomyBranchPerformanceMeasure taxonomyBranchPerformanceMeasureToDelete)
        {
            DeleteTaxonomyBranchPerformanceMeasure(new List<TaxonomyBranchPerformanceMeasure> { taxonomyBranchPerformanceMeasureToDelete });
        }
    }
}