using System;
using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Views.Shared;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Models
{
    public partial class PerformanceMeasure : IAuditableEntity
    {
        public const int PerformanceMeasureIDMilesOfPedestrianAndBicycleRoutesImprovedOrConstructed = 23;

        public string DisplayName
        {
            get { return String.Format("{0} - {1}", PerformanceMeasureID, DisplayNameNoNumber); }
        }

        public string DisplayNameNoNumber
        {
            get
            {
                var tmdlString = PerformanceMeasureType == Models.PerformanceMeasureType.TMDLRelevant ? "TMDL - " : String.Empty;
                return String.Format("{0}{1}", tmdlString, Indicator.IndicatorDisplayName);
            }
        }

        public int ExpectedProjectsCount
        {
            get { return PerformanceMeasureExpecteds.ToList().Select(pepm => pepm.ProjectID).Distinct().Count(); }
        }

        public int ReportedProjectsCount
        {
            get { return PerformanceMeasureActuals.ToList().Select(pepm => pepm.ProjectID).Distinct().Count(); }
        }

        public Program PrimaryProgram
        {
            get
            {
                var programPerformanceMeasure = ProgramPerformanceMeasures.SingleOrDefault(ppm => ppm.IsPrimaryProgram);
                if (programPerformanceMeasure != null)
                {
                    return programPerformanceMeasure.Program;
                }
                return null;
            }
        }

        public List<IndicatorSubcategory> GetIndicatorSubcategories()
        {
            return IndicatorSubcategories.Any() ? IndicatorSubcategories.Select(x => x).OrderBy(x => x.IndicatorSubcategoryDisplayName).ToList() : new List<IndicatorSubcategory>();
        }

        public List<PerformanceMeasureReportedValue> GetReportedPerformanceMeasureValues()
        {
            return GetReportedPerformanceMeasureValues(null);
        }

        public List<PerformanceMeasureReportedValue> GetReportedPerformanceMeasureValues(int? projectID)
        {
            return PerformanceMeasureType.CalculatePerformanceMeasureReportedValues(this, projectID);
        }

        public Dictionary<Program, bool> GetPrograms()
        {
            return PerformanceMeasureType.GetPrograms(this);
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
            return TotalExpenditure() / (decimal)totalReportedValues;
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
            var groupByProjectAndSubcategory = GetReportedPerformanceMeasureValues()
                .Where(x => FirmaDateUtilities.DateIsInReportingRange(x.CalendarYear))
                .GroupBy(x => new { x.Project, x.IndicatorSubcategoriesAsString }).ToList();

            return groupByProjectAndSubcategory.Select(reportedValuesGroup => new PerformanceMeasureSubcategoriesTotalReportedValue(reportedValuesGroup.Key.Project, reportedValuesGroup.First().IndicatorSubcategoryOptions, this, reportedValuesGroup.Sum(x => x.ReportedValue))).ToList();
        }

        public string AuditDescriptionString
        {
            get { return Indicator != null ? Indicator.IndicatorName : ViewUtilities.NotFoundString; }
        }

        public static List<GoogleChartJson> GetSubcategoriesAsGoogleChartJsons(PerformanceMeasure performanceMeasure, List<int> projectIDs)
        {
            Check.Require(performanceMeasure.IndicatorSubcategories.Any(), "Every PM should have at least one Subcategory!");

            List<ProjectFundingSourceExpenditure> projectFundingSourceExpenditures;
            if (projectIDs != null && projectIDs.Any())
            {
                projectFundingSourceExpenditures = HttpRequestStorage.DatabaseEntities.ProjectFundingSourceExpenditures.GetExpendituresFromMininumYearForReportingOnward().Where(x => projectIDs.Contains(x.ProjectID)).ToList();
            }
            else
            {
                projectFundingSourceExpenditures = HttpRequestStorage.DatabaseEntities.ProjectFundingSourceExpenditures.GetExpendituresFromMininumYearForReportingOnward().ToList();
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

            if (performanceMeasure.PerformanceMeasureType == Models.PerformanceMeasureType.PerformanceMeasure33)
            {
                return new List<GoogleChartJson> {IndicatorSubcategory.MakeGoogleChartJsonForPM33(performanceMeasure,
                    projectFundingSourceExpenditures,
                    yearRange.Where(x => x >= FirmaDateUtilities.GetMinimumYearForReportingExpenditures()).ToList())};
            }

            if (performanceMeasure.PerformanceMeasureType == Models.PerformanceMeasureType.PerformanceMeasure34)
            {
                return new List<GoogleChartJson> {IndicatorSubcategory.MakeGoogleChartJsonForPM34(performanceMeasure,
                    reportedValues,
                    yearRange.Where(x => x >= FirmaDateUtilities.GetMinimumYearForReportingExpenditures()).ToList())};
            }
            return IndicatorSubcategory.MakeGoogleChartJsonsForSubcategories(performanceMeasure, reportedValues, yearRange);
        }
    }
}