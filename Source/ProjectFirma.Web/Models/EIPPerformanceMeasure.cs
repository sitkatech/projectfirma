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
    public partial class EIPPerformanceMeasure : IAuditableEntity
    {
        public const int EIPPerformanceMeasureIDMilesOfRoadTreated = 5;
        public const int EIPPerformanceMeasureIDMilesOfPedestrianAndBicycleRoutesImprovedOrConstructed = 23;

        public string DisplayName
        {
            get { return String.Format("{0} - {1}", EIPPerformanceMeasureID, DisplayNameNoNumber); }
        }

        public string DisplayNameNoNumber
        {
            get
            {
                var tmdlString = EIPPerformanceMeasureType == EIPPerformanceMeasureType.TMDLRelevant ? "TMDL - " : String.Empty;
                return String.Format("{0}{1}", tmdlString, Indicator.IndicatorDisplayName);
            }
        }

        public int ExpectedProjectsCount
        {
            get { return EIPPerformanceMeasureExpecteds.ToList().Select(pepm => pepm.ProjectID).Distinct().Count(); }
        }

        public int ReportedProjectsCount
        {
            get { return EIPPerformanceMeasureActuals.ToList().Select(pepm => pepm.ProjectID).Distinct().Count(); }
        }

        public Program PrimaryProgram
        {
            get
            {
                var programEIPPerformanceMeasure = ProgramEIPPerformanceMeasures.SingleOrDefault(ppm => ppm.IsPrimaryProgram);
                if (programEIPPerformanceMeasure != null)
                {
                    return programEIPPerformanceMeasure.Program;
                }
                return null;
            }
        }

        public List<IndicatorSubcategory> GetIndicatorSubcategories()
        {
            return IndicatorSubcategories.Any() ? IndicatorSubcategories.Select(x => x).OrderBy(x => x.IndicatorSubcategoryDisplayName).ToList() : new List<IndicatorSubcategory>();
        }

        public List<EIPPerformanceMeasureReportedValue> GetReportedEIPPerformanceMeasureValues()
        {
            return GetReportedEIPPerformanceMeasureValues(null);
        }

        public List<EIPPerformanceMeasureReportedValue> GetReportedEIPPerformanceMeasureValues(int? projectID)
        {
            return EIPPerformanceMeasureType.CalculateEIPPerformanceMeasureReportedValues(this, projectID);
        }

        public Dictionary<Program, bool> GetPrograms()
        {
            return EIPPerformanceMeasureType.GetPrograms(this);
        }

        public decimal? TotalExpenditure()
        {
            return SubcategoriesTotalReportedValues().Sum(x => x.CalculateWeightedTotalExpenditure());
        }

        public decimal? TotalExpenditurePerEIPPerformanceMeasureUnit()
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
            return GetReportedEIPPerformanceMeasureValues().Where(x => x.CalendarYear == calendarYear).Sum(x => x.CalculateWeightedAnnualExpenditure());
        }

        public double? TotalReportedValueWithNonZeroExpenditures()
        {
            return SubcategoriesTotalReportedValues().Where(x => x.CalculateWeightedTotalExpenditure() > 0).Sum(x => x.TotalReportedValue);
        }

        public List<EIPPerformanceMeasureSubcategoriesTotalReportedValue> SubcategoriesTotalReportedValues()
        {
            var groupByProjectAndSubcategory = GetReportedEIPPerformanceMeasureValues()
                .Where(x => ProjectFirmaDateUtilities.DateIsInReportingRange(x.CalendarYear))
                .GroupBy(x => new { x.Project, x.IndicatorSubcategoriesAsString }).ToList();

            return groupByProjectAndSubcategory.Select(reportedValuesGroup => new EIPPerformanceMeasureSubcategoriesTotalReportedValue(reportedValuesGroup.Key.Project, reportedValuesGroup.First().IndicatorSubcategoryOptions, this, reportedValuesGroup.Sum(x => x.ReportedValue))).ToList();
        }

        public string AuditDescriptionString
        {
            get { return Indicator != null ? Indicator.IndicatorName : ViewUtilities.NotFoundString; }
        }

        public static List<GoogleChartJson> GetSubcategoriesAsGoogleChartJsons(EIPPerformanceMeasure eipPerformanceMeasure, List<int> projectIDs)
        {
            Check.Require(eipPerformanceMeasure.IndicatorSubcategories.Any(), "Every EIP PM should have at least one Subcategory!");

            List<ProjectFundingSourceExpenditure> projectFundingSourceExpenditures;
            if (projectIDs != null && projectIDs.Any())
            {
                projectFundingSourceExpenditures = HttpRequestStorage.DatabaseEntities.ProjectFundingSourceExpenditures.GetExpendituresFromMininumYearForReportingOnward().Where(x => projectIDs.Contains(x.ProjectID)).ToList();
            }
            else
            {
                projectFundingSourceExpenditures = HttpRequestStorage.DatabaseEntities.ProjectFundingSourceExpenditures.GetExpendituresFromMininumYearForReportingOnward().ToList();
            }

            var yearRange = ProjectFirmaDateUtilities.GetRangeOfYearsForReporting();

            List<EIPPerformanceMeasureReportedValue> reportedValues;
            if (projectIDs != null && projectIDs.Any())
            {
                reportedValues = eipPerformanceMeasure.GetReportedEIPPerformanceMeasureValues().Where(x => x.Project.ProjectStage.AreEIPPerformanceMeasuresReportable() && projectIDs.Contains(x.Project.ProjectID)).ToList();
            }
            else
            {
                reportedValues = eipPerformanceMeasure.GetReportedEIPPerformanceMeasureValues().Where(x => x.Project.ProjectStage.AreEIPPerformanceMeasuresReportable()).ToList();
            }

            if (eipPerformanceMeasure.EIPPerformanceMeasureType == EIPPerformanceMeasureType.EIPPerformanceMeasure33)
            {
                return new List<GoogleChartJson> {IndicatorSubcategory.MakeGoogleChartJsonForPM33(eipPerformanceMeasure,
                    projectFundingSourceExpenditures,
                    yearRange.Where(x => x >= ProjectFirmaDateUtilities.GetMinimumYearForReportingExpenditures()).ToList())};
            }

            if (eipPerformanceMeasure.EIPPerformanceMeasureType == EIPPerformanceMeasureType.EIPPerformanceMeasure34)
            {
                return new List<GoogleChartJson> {IndicatorSubcategory.MakeGoogleChartJsonForPM34(eipPerformanceMeasure,
                    reportedValues,
                    yearRange.Where(x => x >= ProjectFirmaDateUtilities.GetMinimumYearForReportingExpenditures()).ToList())};
            }
            return IndicatorSubcategory.MakeGoogleChartJsonsForEIPSubcategories(eipPerformanceMeasure, reportedValues, yearRange);
        }
    }
}