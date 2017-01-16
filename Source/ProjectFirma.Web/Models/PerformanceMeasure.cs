using System;
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Views.Shared;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public partial class PerformanceMeasure : IAuditableEntity
    {
        public const int PerformanceMeasureIDMilesOfPedestrianAndBicycleRoutesImprovedOrConstructed = 23;

        public int ExpectedProjectsCount
        {
            get { return PerformanceMeasureExpecteds.ToList().Select(pepm => pepm.ProjectID).Distinct().Count(); }
        }

        public int ReportedProjectsCount
        {
            get { return PerformanceMeasureActuals.ToList().Select(pepm => pepm.ProjectID).Distinct().Count(); }
        }

        public TaxonomyTierTwo PrimaryTaxonomyTierTwo
        {
            get
            {
                var taxonomyTierTwoPerformanceMeasure = TaxonomyTierTwoPerformanceMeasures.SingleOrDefault(ppm => ppm.IsPrimaryTaxonomyTierTwo);
                if (taxonomyTierTwoPerformanceMeasure != null)
                {
                    return taxonomyTierTwoPerformanceMeasure.TaxonomyTierTwo;
                }
                return null;
            }
        }

        public List<PerformanceMeasureSubcategory> GetPerformanceMeasureSubcategories()
        {
            return PerformanceMeasureSubcategories.Any()
                ? PerformanceMeasureSubcategories.Select(x => x).OrderBy(x => x.PerformanceMeasureSubcategoryDisplayName).ToList()
                : new List<PerformanceMeasureSubcategory>();
        }

        public List<PerformanceMeasureReportedValue> GetReportedPerformanceMeasureValues()
        {
            return GetReportedPerformanceMeasureValues(null);
        }

        public List<PerformanceMeasureReportedValue> GetReportedPerformanceMeasureValues(int? projectID)
        {
            var performanceMeasureActuals =
                HttpRequestStorage.DatabaseEntities.PerformanceMeasureActuals.Where(
                    pmav => pmav.PerformanceMeasureID == PerformanceMeasureID && (!projectID.HasValue || (projectID.HasValue && pmav.ProjectID == projectID))).ToList();
            var performanceMeasureReportedValues = PerformanceMeasureReportedValue.MakeFromList(performanceMeasureActuals);
            return performanceMeasureReportedValues.OrderByDescending(pma => pma.CalendarYear).ThenBy(pma => pma.ProjectName).ToList();
        }

        public Dictionary<TaxonomyTierTwo, bool> GetTaxonomyTierTwos()
        {
            return TaxonomyTierTwoPerformanceMeasures.Any()
                ? TaxonomyTierTwoPerformanceMeasures.ToDictionary(x => x.TaxonomyTierTwo, x => x.IsPrimaryTaxonomyTierTwo, new HavePrimaryKeyComparer<TaxonomyTierTwo>())
                : new Dictionary<TaxonomyTierTwo, bool>();
        }

        public decimal? TotalExpenditure()
        {
            return SubcategoriesTotalReportedValues().Sum(x => x.CalculateWeightedTotalExpenditure());
        }

        public decimal? TotalExpenditurePerPerformanceMeasureUnit()
        {
            var totalReportedValues = SubcategoriesTotalReportedValues().Where(x => x.CalculateWeightedTotalExpenditure() > 0).Sum(x => x.TotalReportedValue ?? 0);
            if (Math.Abs(totalReportedValues) < Double.Epsilon)
            {
                return null;
            }
            return TotalExpenditure()/(decimal) totalReportedValues;
        }

        public decimal? AnnualExpenditure(int calendarYear)
        {
            return GetReportedPerformanceMeasureValues().Where(x => x.CalendarYear == calendarYear).Sum(x => x.CalculateWeightedAnnualExpenditure());
        }

        public double? TotalReportedValueWithNonZeroExpenditures()
        {
            return SubcategoriesTotalReportedValues().Where(x => x.CalculateWeightedTotalExpenditure() > 0).Sum(x => x.TotalReportedValue);
        }

        public List<PerformanceMeasureSubcategoriesTotalReportedValue> SubcategoriesTotalReportedValues()
        {
            var groupByProjectAndSubcategory =
                GetReportedPerformanceMeasureValues()
                    .Where(x => FirmaDateUtilities.DateIsInReportingRange(x.CalendarYear))
                    .GroupBy(x => new {x.Project, x.PerformanceMeasureSubcategoriesAsString})
                    .ToList();

            return
                groupByProjectAndSubcategory.Select(
                    reportedValuesGroup =>
                        new PerformanceMeasureSubcategoriesTotalReportedValue(reportedValuesGroup.Key.Project,
                            reportedValuesGroup.First().PerformanceMeasureSubcategoryOptions,
                            this,
                            reportedValuesGroup.Sum(x => x.ReportedValue))).ToList();
        }

        public string AuditDescriptionString
        {
            get { return PerformanceMeasureDisplayName; }
        }

        public static List<GoogleChartJson> GetSubcategoriesAsGoogleChartJsons(PerformanceMeasure performanceMeasure, List<int> projectIDs)
        {
            try
            {
                Check.Require(performanceMeasure.PerformanceMeasureSubcategories.Any(), "Every Performance Measure must have at least one Subcategory!");
            }
            catch (Exception)
            {
                SitkaLogger.Instance.LogDetailedErrorMessage(string.Format("Found PM without Subcategory or Subcategory Option for PM {0} (ID {1})",
                    performanceMeasure.PerformanceMeasureDisplayName,
                    performanceMeasure.PerformanceMeasureID));
                throw;
            }
            

            var yearRange = FirmaDateUtilities.GetRangeOfYearsForReporting();

            List<PerformanceMeasureReportedValue> reportedValues;
            if (projectIDs != null && projectIDs.Any())
            {
                reportedValues = performanceMeasure.GetReportedPerformanceMeasureValues().Where(x => x.Project.ProjectStage.ArePerformanceMeasuresReportable() && projectIDs.Contains(x.Project.ProjectID)).ToList();
            }
            else
            {
                reportedValues = performanceMeasure.GetReportedPerformanceMeasureValues().Where(x => x.Project.ProjectStage.ArePerformanceMeasuresReportable()).ToList();
            }

            return PerformanceMeasureSubcategory.MakeGoogleChartJsonsForSubcategories(performanceMeasure, reportedValues, yearRange);
        }

        public bool HasRealSubcategories
        {
            get
            {
                return PerformanceMeasureSubcategories.Any(x => x.PerformanceMeasureSubcategoryOptions.Count > 1);
            }
        }

        public List<PerformanceMeasureSubcategory> GetSubcategoriesForPerformanceMeasureChart()
        {
            return PerformanceMeasureSubcategories.Where(x => x.PerformanceMeasureSubcategoryOptions.Count > 1 && x.ShowOnChart).ToList();
        }

        public int GetRealSubcategoryCount()
        {
            return HasRealSubcategories ? PerformanceMeasureSubcategories.Count : 0;
        }

        public Dictionary<string, GoogleChartJson> GetGoogleChartJsonDictionary(List<int> projectIDs)
        {
            var googleChartJsons = GetSubcategoriesAsGoogleChartJsons(this, projectIDs);
            return googleChartJsons.ToDictionary(x => x.ChartName);
        }
    }
}