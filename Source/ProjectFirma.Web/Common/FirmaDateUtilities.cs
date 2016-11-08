using System;
using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;

namespace ProjectFirma.Web.Common
{
    public class FirmaDateUtilities
    {
        public const int MinimumYear = 2007;
        public const int YearsBeyondPresentForMaximumYearForUserInput = 70;

        /// <summary>
        /// Range of Years for user input, using MinimumYear and MaximumYearforUserInput
        /// </summary>
        /// <returns></returns>
        public static List<int> YearsForUserInput()
        {
            return GetRangeOfYears(MinimumYear, DateTime.Now.Year + YearsBeyondPresentForMaximumYearForUserInput);
        }


        /// <summary>
        /// Range of Years for user input, using MinimumYear and MaximumYearforUserInput
        /// </summary>
        /// <returns></returns>
        public static List<int> FutureYearsForUserInput()
        {
            return GetRangeOfYears(DateTime.Now.Year, DateTime.Now.Year + YearsBeyondPresentForMaximumYearForUserInput);
        }

        /// <summary>
        /// Range of Years for user input, using MinimumYearForReporting and DateTime.Now.Year
        /// </summary>
        /// <returns></returns>
        public static List<int> ReportingYearsForUserInput()
        {
            return GetRangeOfYears(MinimumYear, DateTime.Now.Year);
        }

        public static List<int> GetRangeOfYears(int startYear, int endYear)
        {
            startYear = Math.Min(endYear, startYear); // if the start year is greater than the end year, just use the end year
            return Enumerable.Range(startYear, (endYear - startYear) + 1).ToList();
        }

        public static DateTime LastReportingPeriodStartDate()
        {
            return new DateTime(CalculateCurrentYearToUseForReporting(), FirmaWebConfiguration.ReportingPeriodStartMonth, FirmaWebConfiguration.ReportingPeriodStartDay);
        }

        public static int GetMinimumYearForReportingExpenditures()
        {
            return MinimumYear;
        }

        public static int CalculateCurrentYearToUseForReporting()
        {
            var reportingPeriodStartMonth = FirmaWebConfiguration.ReportingPeriodStartMonth;
            var reportingPeriodStartDay = FirmaWebConfiguration.ReportingPeriodStartDay;
            return CalculateCurrentYearToUseForReportingImpl(DateTime.Today, reportingPeriodStartMonth, reportingPeriodStartDay);
        }

        //Only public for unit testing
        public static int CalculateCurrentYearToUseForReportingImpl(DateTime currentDateTime, int reportingStartMonth, int reportingStartDay)
        {
            var dateToCheckAgainst = new DateTime(currentDateTime.Year, reportingStartMonth, reportingStartDay);
            return currentDateTime.IsDateBefore(dateToCheckAgainst) ? currentDateTime.Year - 1 : currentDateTime.Year;
        }

        public static List<int> CalculateCalendarYearRangeForExpendituresAccountingForExistingYears(List<int> existingYears, IProject project, int currentYearToUse)
        {
            return CalculateCalendarYearRangeAccountingForExistingYears(existingYears, project == null ? null : project.PlanningDesignStartYear, project == null ? null : project.CompletionYear, currentYearToUse, MinimumYear, currentYearToUse);
        }

        public static List<int> CalculateCalendarYearRangeForBudgetsAccountingForExistingYears(List<int> existingYears, IProject project, int currentYearToUse)
        {
            return CalculateCalendarYearRangeAccountingForExistingYears(existingYears, project == null ? null : project.PlanningDesignStartYear, project == null ? null : project.CompletionYear, currentYearToUse, null, null);
        }

        public static List<int> CalculateCalendarYearRangeAccountingForExistingYears(List<int> existingYears, int? startYear, int? endYear, int currentYearToUse, int? floorYear, int? ceilingYear)
        {
            Check.Require((!endYear.HasValue && !startYear.HasValue) // both not provided
                          || (endYear.HasValue && (!startYear.HasValue || endYear.Value >= startYear.Value)) // endYear provided and needs to either have start year null or start year <= end year
                          || !endYear.HasValue // only have startYear
                ,
                String.Format("Start Year {0} and End Year {1} are out of order!", startYear, endYear));
            var currentYear = currentYearToUse;
            var defaultStartYear = currentYear;
            if (startYear.HasValue)
            {
                defaultStartYear = startYear.Value;
            }
            else if (endYear.HasValue && endYear.Value <= currentYear)
            {
                defaultStartYear = endYear.Value;
            }
            var defaultEndYear = currentYear;
            if (endYear.HasValue)
            {
                defaultEndYear = endYear.Value;
            }
            else if (startYear.HasValue && startYear.Value > currentYear)
            {
                defaultEndYear = startYear.Value;
            }

            // if provided a floor year, make the minimum be that
            if (floorYear.HasValue)
            {
                defaultStartYear = Math.Max(floorYear.Value, defaultStartYear);
                defaultEndYear = Math.Max(floorYear.Value, defaultEndYear);
            }

            // if provided a ceiling year, cap it to that
            if (ceilingYear.HasValue)
            {
                defaultStartYear = Math.Min(ceilingYear.Value, defaultStartYear);
                defaultEndYear = Math.Min(ceilingYear.Value, defaultEndYear);
            }

            var minEnteredCalendarYear = existingYears.Any() ? Math.Min(existingYears.Min(), defaultStartYear) : defaultStartYear;
            var maxEnteredCalendarYear = existingYears.Any() ? Math.Max(existingYears.Max(), defaultEndYear) : defaultEndYear;
            var calendarYearsToPopulate = GetRangeOfYears(minEnteredCalendarYear, maxEnteredCalendarYear);
            return calendarYearsToPopulate;
        }

        public static bool DateIsInReportingRange(int calendarYear)
        {
            return calendarYear > MinimumYear && calendarYear <= CalculateCurrentYearToUseForReporting();
        }

        public static List<int> GetRangeOfYearsForReportingExpenditures()
        {
            return GetRangeOfYears(GetMinimumYearForReportingExpenditures(), CalculateCurrentYearToUseForReporting());
        }

        public static List<int> GetRangeOfYearsForReporting()
        {
            return GetRangeOfYears(MinimumYear, CalculateCurrentYearToUseForReporting());
        }

        public static bool IsDayToSendDelinquentReminder(DateTime dateToCheck, int delinquentReminderIntervalInDays, int deadlineMonth, int deadlineDay, int reportingPeriodEndMonth, int reportingPeriodEndDay)
        {
            var deadlineYear = CalculateDeadlineYear();
            var deadlineDate = new DateTime(deadlineYear, deadlineMonth, deadlineDay);
            var reportingPeriodEndDate = new DateTime(deadlineYear, reportingPeriodEndMonth, reportingPeriodEndDay);
            var withinDelinquentReminderPeriod = dateToCheck > deadlineDate && dateToCheck < reportingPeriodEndDate;
            var daysFromDeadline = (dateToCheck - deadlineDate).Days;
            var isDayToSendDelinquentReminder = daysFromDeadline > 0 && daysFromDeadline % delinquentReminderIntervalInDays == 0;
            return withinDelinquentReminderPeriod && isDayToSendDelinquentReminder;
        }

        public static int CalculateDeadlineYear()
        {
            var currentDateTime = DateTime.Today;
            var dateToCheckAgainst = new DateTime(DateTime.Today.Year, FirmaWebConfiguration.ReportingPeriodStartMonth, FirmaWebConfiguration.ReportingPeriodStartDay);
            var reportingYear = currentDateTime.IsDateBefore(dateToCheckAgainst) ? currentDateTime.Year : currentDateTime.Year + 1;
            return reportingYear;
        }
    }
}