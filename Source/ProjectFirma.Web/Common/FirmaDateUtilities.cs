/*-----------------------------------------------------------------------
<copyright file="FirmaDateUtilities.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using ProjectFirmaModels.Models;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using ProjectFirma.Web.Views.Shared;

namespace ProjectFirma.Web.Common
{
    public class FirmaDateUtilities
    {
        public const int YearsBeyondPresentForMaximumYearForUserInput = 30;

        /// <summary>
        /// Range of Years for user input, using MinimumYear and MaximumYearforUserInput
        /// </summary>
        /// <returns></returns>
        public static List<CalendarYearString> YearsForUserInput()
        {
            return GetRangeOfYears(MultiTenantHelpers.GetMinimumYear(), DateTime.Now.Year + YearsBeyondPresentForMaximumYearForUserInput).Select(x => new CalendarYearString(x)).ToList();
        }

        /// <summary>
        /// Range of Years for user input, using MinimumYearForReporting and DateTime.Now.Year
        /// </summary>
        /// <returns></returns>
        public static List<CalendarYearString> ReportingYearsForUserInput()
        {
            return GetRangeOfYears(MultiTenantHelpers.GetMinimumYear(), CalculateCurrentYearToUseForUpToAllowableInputInReporting()).Select(x => new CalendarYearString(x)).ToList();
        }
        public static List<int> ReportingYearsForUserInputAsIntegers()
        {
            return GetRangeOfYears(MultiTenantHelpers.GetMinimumYear(),
                CalculateCurrentYearToUseForUpToAllowableInputInReporting());
        }

        public static List<int> GetRangeOfYears(int startYear, int endYear)
        {
            startYear = Math.Min(endYear, startYear); // if the start year is greater than the end year, just use the end year
            return Enumerable.Range(startYear, (endYear - startYear) + 1).ToList();
        }

        public static DateTime LastReportingPeriodStartDate()
        {
            var startDayOfReportingYear = MultiTenantHelpers.GetStartDayOfReportingYear();
            return new DateTime(CalculateCurrentYearToUseForRequiredReporting(), startDayOfReportingYear.Month, startDayOfReportingYear.Day);
        }

        public static int CalculateCurrentYearToUseForRequiredReporting()
        {
            var startDayOfReportingYear = MultiTenantHelpers.GetStartDayOfReportingYear();
            return CalculateCurrentYearToUseForReportingImpl(DateTime.Today, startDayOfReportingYear.Month, startDayOfReportingYear.Day);
        }

        //Only public for unit testing
        public static int CalculateCurrentYearToUseForReportingImpl(DateTime currentDateTime, int reportingStartMonth, int reportingStartDay)
        {
            var dateToCheckAgainst = new DateTime(currentDateTime.Year, reportingStartMonth, reportingStartDay);
            return currentDateTime.IsDateBefore(dateToCheckAgainst) ? currentDateTime.Year - 1 : currentDateTime.Year;
        }

        public static DateUtilities.FiscalQuarter CalculateFiscalQuarter(DateTime dateTime)
        {
            return ((DateUtilities.Month)dateTime.Month).GetFiscalQuarter();
        }

        public static DateUtilities.CalendarQuarter CalculateCalendarQuarter(DateTime dateTime)
        {
            return ((DateUtilities.Month)dateTime.Month).GetCalendarQuarter();
        }

        public static int CalculateCurrentYearToUseForUpToAllowableInputInReporting()
        {
            var startDayOfReportingYear = MultiTenantHelpers.GetStartDayOfReportingYear();
            var currentDateTime = DateTime.Today;
            var dateToCheckAgainst = new DateTime(currentDateTime.Year, startDayOfReportingYear.Month, startDayOfReportingYear.Day);
            if (MultiTenantHelpers.UseFiscalYears())
            {
                return currentDateTime.IsDateBefore(dateToCheckAgainst) ? currentDateTime.Year : currentDateTime.Year + 1;
            }
            return currentDateTime.IsDateBefore(dateToCheckAgainst) ? currentDateTime.Year - 1 : currentDateTime.Year;
        }

        public static List<int> CalculateCalendarYearRangeForExpendituresAccountingForExistingYears(List<int> existingYears, IProject project, int currentYearToUse)
        {
            return CalculateCalendarYearRangeAccountingForExistingYears(existingYears, project?.PlanningDesignStartYear, project?.CompletionYear, currentYearToUse, MultiTenantHelpers.GetMinimumYear(), currentYearToUse);
        }

        public static List<int> CalculateCalendarYearRangeForBudgetsAccountingForExistingYears(List<int> existingYears, IProject project, int currentYearToUse)
        {
            return CalculateCalendarYearRangeAccountingForExistingYears(existingYears, project?.PlanningDesignStartYear, project?.CompletionYear, currentYearToUse, null, null);
        }

        public static List<int> CalculateCalendarYearRangeAccountingForExistingYears(List<int> existingYears, int? startYear, int? endYear, int currentYearToUse, int? floorYear, int? ceilingYear)
        {
            Check.Require((!endYear.HasValue && !startYear.HasValue) // both not provided
                          || (endYear.HasValue && (!startYear.HasValue || endYear.Value >= startYear.Value)) // endYear provided and needs to either have start year null or start year <= end year
                          || !endYear.HasValue // only have startYear
                ,
                $"Start Year {startYear} and End Year {endYear} are out of order!");
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
            return calendarYear > MultiTenantHelpers.GetMinimumYear() && calendarYear <= CalculateCurrentYearToUseForRequiredReporting();
        }

        public static List<int> GetRangeOfYearsForReporting()
        {
            return GetRangeOfYears(MultiTenantHelpers.GetMinimumYear(), CalculateCurrentYearToUseForRequiredReporting());
        }


    }
}
