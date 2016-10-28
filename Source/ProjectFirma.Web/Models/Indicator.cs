using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Views.Shared;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public partial class Indicator : IAuditableEntity
    {
        public string AuditDescriptionString
        {
            get { return IndicatorName; }
        }

        public string DataSourceUrl
        {
            get
            {
                return PerformanceMeasure.GetInfoSheetUrl();
            }
        }

        public bool HasRealSubcategories
        {
            get
            {
                if (PerformanceMeasure.PerformanceMeasureType == PerformanceMeasureType.PerformanceMeasure33)
                {
                    return true;
                }
                return IndicatorSubcategories.Any(x => x.IndicatorSubcategoryOptions.Count > 1);
            }
        }

        public List<IndicatorSubcategory> GetSubcategoriesForIndicatorChart()
        {
            if (PerformanceMeasure.PerformanceMeasureType == PerformanceMeasureType.PerformanceMeasure33)
            {
                return IndicatorSubcategories.ToList();
            }

            return IndicatorSubcategories.Where(x => x.IndicatorSubcategoryOptions.Count > 1 && x.ShowOnChart).OrderBy(x => x.SortOrder).ToList();
        }

        public int GetRealSubcategoryCount()
        {
            return HasRealSubcategories ? IndicatorSubcategories.Count : 0;
        }

        public Dictionary<string, GoogleChartJson> GetGoogleChartJsonDictionary(List<int> projectIDs)
        {
            var googleChartJsons = PerformanceMeasure.GetSubcategoriesAsGoogleChartJsons(PerformanceMeasure, projectIDs);
            return googleChartJsons.ToDictionary(x => x.ChartName);
        }

        public List<Indicator> GetRelatedIndicatorsByIndicatorType(IndicatorType indicatorType)
        {
            var actionIndicatorsThatYouRelateTo = IndicatorRelationships.Where(x => x.RelatedIndicator.IndicatorType == indicatorType)
                .Select(x => x.RelatedIndicator).ToList();
            var actionIndicatorsThatYouAreRelatedTo = IndicatorRelationshipsWhereYouAreTheRelatedIndicator.Where(x => x.Indicator.IndicatorType == indicatorType)
                .Select(x => x.Indicator)
                .ToList();
            return
                actionIndicatorsThatYouRelateTo.Union(actionIndicatorsThatYouAreRelatedTo, new HavePrimaryKeyComparer<Indicator>()).ToList();
        }

    }
}