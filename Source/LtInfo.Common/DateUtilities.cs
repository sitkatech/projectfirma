/*-----------------------------------------------------------------------
<copyright file="DateUtilities.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
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

namespace LtInfo.Common
{
    public static class DateUtilities
    {
        public const int MonthsInFiscalYear = 12;

        public enum FiscalQuarter
        {
            First = 1,
            Second = 2,
            Third = 3,
            Fourth = 4
        }

        public enum CalendarQuarter
        {
            First = 1,
            Second = 2,
            Third = 3,
            Fourth = 4
        }

        public enum Month
        {
            January = 1,
            February = 2,
            March = 3,
            April = 4,
            May = 5,
            June = 6,
            July = 7,
            August = 8,
            September = 9,
            October = 10,
            November = 11,
            December = 12
        }

        public static string ShortMonthName(Month month)
        {
            // "Jan", "Feb", etc.
            return month.ToString().Substring(0, 3);
        }

        public static DateTime GetEpoch()
        {
            return DateTime.Parse("1754-01-01 00:00:00.000");
        }

        public static DateTime GetLastDateInMonth(this DateTime dateInMonth)
        {
            return new DateTime(dateInMonth.Year, dateInMonth.Month, DateTime.DaysInMonth(dateInMonth.Year, dateInMonth.Month));
        }

        public static DateTime GetFirstDateInFiscalQuarter(FiscalQuarter qtr, int calendarYear)
        {
            if (qtr == FiscalQuarter.First) // 1st FiscalQuarter = October 1 to December 31
            {
                return new DateTime(calendarYear, 10, 1);
            }
            if (qtr == FiscalQuarter.Second) // 2nd FiscalQuarter = January 1 to  March 31
            {
                return new DateTime(calendarYear, 1, 1);
            }
            if (qtr == FiscalQuarter.Third) // 3rd FiscalQuarter = April 1 to June 30
            {
                return new DateTime(calendarYear, 4, 1);
            }
            // 4th FiscalQuarter = July 1 to Sept 30
            return new DateTime(calendarYear, 7, 1);
        }



        public static DateTime GetLastDateInFiscalQuarter(FiscalQuarter qtr, int calendarYear)
        {
            if (qtr == FiscalQuarter.First) // 1st FiscalQuarter = October 1 to December 31
            {
                return new DateTime(calendarYear, 12, DateTime.DaysInMonth(calendarYear, 12));
            }
            if (qtr == FiscalQuarter.Second) // 2nd FiscalQuarter = January 1 to  March 31
            {
                return new DateTime(calendarYear, 3, DateTime.DaysInMonth(calendarYear, 3));
            }
            if (qtr == FiscalQuarter.Third) // 3rd FiscalQuarter = April 1 to June 30
            {
                return new DateTime(calendarYear, 6, DateTime.DaysInMonth(calendarYear, 6));
            }
            // 4th FiscalQuarter = July 1 to Sept 30
            return new DateTime(calendarYear, 9, DateTime.DaysInMonth(calendarYear, 9));
        }


        public static DateTime GetFirstDateInFiscalQuarter(this DateTime dateInQuarter)
        {
            FiscalQuarter qtr = ((Month)dateInQuarter.Month).GetFiscalQuarter();

            return GetFirstDateInFiscalQuarter(qtr, dateInQuarter.Year);
        }



        public static DateTime GetLastDateInFiscalQuarter(this DateTime dateInQuarter)
        {
            FiscalQuarter qtr = ((Month)dateInQuarter.Month).GetFiscalQuarter();

            return GetLastDateInFiscalQuarter(qtr, dateInQuarter.Year);
        }

        public static FiscalQuarter GetFiscalQuarter(this Month month)
        {
            if (month >= Month.October)
            {
                return FiscalQuarter.First; // 1st Fiscal FiscalQuarter = October 1 to December 31
            }
            if (month <= Month.March)
            {
                return FiscalQuarter.Second; // 2nd Fiscal FiscalQuarter = January 1 to  March 31
            }
            if (month >= Month.April && month <= Month.June)
            {
                return FiscalQuarter.Third; // 3rd Fiscal FiscalQuarter = April 1 to June 30
            }
            //else if (month >= Month.July && month <= Month.September)
            return FiscalQuarter.Fourth; // 4th Fiscal FiscalQuarter = July 1 to September 30
        }

        /// <summary>
        /// A separate method to just get the calendar quarter instead of fiscal quarter
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        public static CalendarQuarter GetCalendarQuarter(this Month month)
        {
            if (month <= Month.March)
            {
                return CalendarQuarter.First; // 1st CalendarQuarter = January 1 to  March 31
            }
            if (month >= Month.April && month <= Month.June)
            {
                return CalendarQuarter.Second; // 2nd CalendarQuarter = April 1 to June 30
            }
            if (month >= Month.July && month <= Month.September)
            {
                return CalendarQuarter.Third; // 3rd CalendarQuarter = July 1 to September 30
            }
            return CalendarQuarter.Fourth; // 4th CalendarQuarter = October 1 to end of year
        }

        public static FiscalQuarter GetCurrentFiscalQuarter()
        {
            return ((Month)DateTime.Now.Month).GetFiscalQuarter();
        }

        public static FiscalQuarter GetPreviousFiscalQuarter()
        {
            return GetFiscalQuarterPreviousToFiscalQuarter(GetCurrentFiscalQuarter());
        }

        public static DateTime GetLastDateOfPreviousFiscalQuarter(DateTime fromDate)
        {
            // What quarter are we in?
            FiscalQuarter currentQuarter = GetFiscalQuarter((Month)fromDate.Month);
            // What's the previous quarter?
            FiscalQuarter previousQuarter = GetFiscalQuarterPreviousToFiscalQuarter(currentQuarter);
            // If we wrapped our FY  (i.e. went from quarter 2 => quarter 1), decrease the calendar year to the previous year.
            int calendarYear = fromDate.Year;
            if (previousQuarter == FiscalQuarter.First && currentQuarter == FiscalQuarter.Second)
            {
                calendarYear -= 1;
            }

            // Use the previous Quarter / Calendar Year to get the last date in the fiscal quarter
            return GetLastDateInFiscalQuarter(previousQuarter, calendarYear);
        }

        public static FiscalQuarter GetFiscalQuarterPreviousToFiscalQuarter(this FiscalQuarter givenFiscalQuarter)
        {
            int fiscalQuarterNumber = (int)givenFiscalQuarter - 1;
            if (fiscalQuarterNumber == 0)
            {
                // Wrap back to prior year
                fiscalQuarterNumber = 4;
            }
            return (FiscalQuarter)fiscalQuarterNumber;
        }

        public static DateTime GetEarliestDate(DateTime firstDate, DateTime secondDate)
        {
            return Convert.ToDateTime((firstDate.IsDateBefore(secondDate)) ? firstDate : secondDate);
        }

        public static DateTime GetLatestDate(DateTime firstDate, DateTime secondDate)
        {
            return Convert.ToDateTime((firstDate.IsDateAfter(secondDate)) ? firstDate : secondDate);
        }

        public static bool IsTodayOnOrBeforeDate(this DateTime dateToCheck)
        {
            return DateTime.Today.IsDateOnOrBefore(dateToCheck);
        }

        public static bool IsDateOnOrBefore(this DateTime dateToCheck, DateTime dateToCheckAgainst)
        {
            return dateToCheck.Date.CompareTo(dateToCheckAgainst.Date) < 1;
        }

        public static bool IsDateOnOrAfter(this DateTime dateToCheck, DateTime dateToCheckAgainst)
        {
            return dateToCheck.Date.CompareTo(dateToCheckAgainst.Date) > -1;
        }

        public static bool IsDateBefore(this DateTime dateToCheck, DateTime dateToCheckAgainst)
        {
            return dateToCheck.Date.CompareTo(dateToCheckAgainst.Date) < 0;
        }

        public static bool IsDateAfter(this DateTime dateToCheck, DateTime dateToCheckAgainst)
        {
            return dateToCheck.Date.CompareTo(dateToCheckAgainst.Date) > 0;
        }

        public static bool IsDateInRange(this DateTime dateToCheck, DateTime startOfRange, DateTime endOfRange)
        {
            return dateToCheck.IsDateOnOrAfter(startOfRange) && dateToCheck.IsDateOnOrBefore(endOfRange);
        }

        public static string GetDifferenceInEnglish(DateTime firstDate, DateTime secondDate, bool showMinutes)
        {
            var age = firstDate.Subtract(secondDate);

            var days = Convert.ToInt32(Math.Floor(age.TotalDays));
            var hours = Convert.ToInt32(Math.Floor(age.TotalHours - (days * 24)));
            var minutes = Convert.ToInt32(Math.Floor(age.TotalMinutes - (days * 24 * 60) - (hours * 60)));

            if (showMinutes)
            {
                return String.Format("{0} day{1}, {2} hour{3}, {4} minute{5}"
                                    , days
                                    , days == 1 ? "" : "s"
                                    , hours
                                    , hours == 1 ? "" : "s"
                                    , minutes
                                    , minutes == 1 ? "" : "s"
                                    );
            }

            // No minutes
            return String.Format("{0} day{1}, {2} hour{3}"
                                , days
                                , days == 1 ? "" : "s"
                                , hours
                                , hours == 1 ? "" : "s"
                                );

        }

        /// <summary>
        /// Tests if two given periods overlap each other.
        /// </summary>
        /// <param name="startDate1">Base period start</param>
        /// <param name="endDate1">Base period end</param>
        /// <param name="startDate2">Test period start</param>
        /// <param name="endDate2">Test period end</param>
        /// <returns>
        /// 	<c>true</c> if the periods overlap; otherwise, <c>false</c>.
        /// </returns>
        public static bool DateRangesOverlap(DateTime startDate1, DateTime endDate1, DateTime startDate2, DateTime endDate2)
        {
            // More simple?
            // return !((TS < BS && TE < BS) || (TS > BE && TE > BE));

            // The version below, without comments 
            //
            //return (
            //    (TS >= BS && TS < BE) || (TE <= BE && TE > BS) || (TS <= BS && TE >= BE)
            //);

            return (
                // 1. Case:
                //
                //       TS-------TE
                //    BS------BE 
                //
                // TS is after BS but before BE
                (startDate2 >= startDate1 && startDate2 < endDate1)
                || // or

                // 2. Case
                //
                //    TS-------TE
                //        BS---------BE
                //
                // TE is before BE but after BS
                (endDate2 <= endDate1 && endDate2 > startDate1)
                || // or

                // 3. Case
                //
                //  TS----------TE
                //     BS----BE
                //
                // TS is before BS and TE is after BE
                (startDate2 <= startDate1 && endDate2 >= endDate1)
            );
        }

        /// <summary>
        /// Gets a simplified version that removes two things:
        /// - Values with zero values that aren't significant digits: (0 days, 0 hours, 36 minutes) => 36 minutes
        /// - Less significant values as net time increases. 36 minutes => 3 hours => 1 day
        /// </summary>
        /// <param name="firstDate"></param>
        /// <param name="secondDate"></param>
        /// <returns></returns>
        public static string GetDifferenceInEnglishSimplified(DateTime firstDate, DateTime secondDate)
        {
            var age = firstDate.Subtract(secondDate);

            var days = Convert.ToInt32(Math.Floor(age.TotalDays));
            var hours = Convert.ToInt32(Math.Floor(age.TotalHours - (days * 24)));
            var minutes = Convert.ToInt32(Math.Floor(age.TotalMinutes - (days * 24 * 60) - (hours * 60)));
            var seconds = Convert.ToInt32(Math.Floor(age.TotalSeconds - (days * 24 * 60) - (hours * 60) - (minutes * 60)));

            if (days > 0) return String.Format("{0} day{1}", days, days == 1 ? "" : "s");
            if (hours > 0) return String.Format("{0} hour{1}", hours, hours == 1 ? "" : "s");
            if (minutes > 0) return String.Format("{0} minute{1}", minutes, minutes == 1 ? "" : "s");
            return String.Format("{0} second{1}", seconds, seconds == 1 ? "" : "s");
        }

        public static int GetDifferenceInDays(DateTime firstDate, DateTime secondDate)
        {
            return firstDate.Date.Subtract(secondDate.Date).Days;
        }

        public static int GetDaysSinceToday(this DateTime dateToCheck)
        {
            return GetDifferenceInDays(DateTime.Today, dateToCheck);
        }

        public static int GetDaysFromToday(this DateTime dateToCheck)
        {
            return GetDifferenceInDays(dateToCheck, DateTime.Today);
        }

        public static int GetCurrentFiscalYear()
        {
            return DateTime.Now.GetFiscalYear();
        }

        public static int GetPreviousFiscalYear(this DateTime dateToCheck)
        {
            return dateToCheck.GetFiscalYear() - 1;
        }

        public static int GetNextFiscalYear(this DateTime dateToCheck)
        {
            return DateTime.Now.GetFiscalYear() + 1;
        }

        public static int GetFiscalYear(this DateTime dateToCheck)
        {
            if (((Month)dateToCheck.Month).GetFiscalQuarter() == FiscalQuarter.First)
                return dateToCheck.Year + 1;
            return dateToCheck.Year;
        }

        public static int GetFiscalMonth(this DateTime dateToCheck)
        {
            var month = (Month) dateToCheck.Month;
            switch (month)
            {
                case  Month.October:
                    return 1;
                case Month.November:
                    return 2;
                case Month.December:
                    return 3;
                case Month.January:
                    return 4;
                case Month.February:
                    return 5;
                case Month.March:
                    return 6;
                case Month.April:
                    return 7;
                case Month.May:
                    return 8;
                case Month.June:
                    return 9;
                case Month.July:
                    return 10;
                case Month.August:
                    return 11;
                case Month.September:
                    return 12;
                default:
                    return 0;
            }
        }

        public static DateTime GetFirstDateInFiscalYear(this DateTime dateInFiscalYear)
        {
            int fiscalYear = dateInFiscalYear.GetFiscalYear();
            return GetFirstDateInFiscalYear(fiscalYear);
        }

        public static DateTime GetFirstDateInFiscalYear(int fiscalYear)
        {
            const int firstDayInMonth = 1;

            const int firstFiscalMonth = (int)Month.October;
            return new DateTime(fiscalYear - 1, firstFiscalMonth, firstDayInMonth);
        }

        public static DateTime GetLastDateInFiscalYear(this DateTime dateInFiscalYear)
        {
            int fiscalYear = dateInFiscalYear.GetFiscalYear();
            return GetLastDateInFiscalYear(fiscalYear);
        }

        public static DateTime GetLastDateInFiscalYear(int fiscalYear)
        {
            const int lastDayInMonth = 30;
            const int lastFiscalMonth = (int)Month.September;
            return new DateTime(fiscalYear, lastFiscalMonth, lastDayInMonth);
        }

        public static DateTime GetFirstDateInYear(int calendarYear)
        {
            const int firstDayInMonth = 1;
            const int firstCalendarMonth = (int)Month.January;
            return new DateTime(calendarYear, firstCalendarMonth, firstDayInMonth);
        }

        public static DateTime GetFirstDateInYear(this DateTime date)
        {
            return GetFirstDateInYear(date.Year);
        }

        public static DateTime GetLastDateInYear(int calendarYear)
        {
            const int lastDayInMonth = 31;
            const int lastCalendarMonth = (int)Month.December;
            return new DateTime(calendarYear, lastCalendarMonth, lastDayInMonth);
        }

        public static DateTime GetLastDateInYear(this DateTime date)
        {
            return GetLastDateInFiscalYear(date.Year);
        }

        /// <summary>
        /// Indicates if string would parse as a date
        /// </summary>
        public static bool IsValidDateFormat(this string stringToCheck)
        {
            DateTime dummy;
            return DateTime.TryParse(stringToCheck, out dummy);
        }

        public static DateTime GetFirstDateInMonth(this DateTime dateInMonth)
        {
            return new DateTime(dateInMonth.Year, dateInMonth.Month, 1);
        }

        public static DateTime SubtractMonths(this DateTime date, int months)
        {
            return date.AddMonths(months * -1);
        }

        public static int GetPreviousFiscalYear()
        {
            return DateTime.Now.GetPreviousFiscalYear();
        }

        public static int GetNextFiscalYear()
        {
            return DateTime.Now.GetNextFiscalYear();
        }

        public static int GetCalendarYearForFiscalYearFiscalMonth(int fiscalYear, int fiscalMonth)
        {
            return GetCalendarDateForFiscalYearFiscalMonth(fiscalYear, fiscalMonth).Year;
        }

        public static int GetCalendarMonthForFiscalYearFiscalMonth(int fiscalYear, int fiscalMonth)
        {
            return GetCalendarDateForFiscalYearFiscalMonth(fiscalYear, fiscalMonth).Month;
        }

        public static DateTime GetCalendarDateForFiscalYearFiscalMonth(int fiscalYear, int fiscalMonth)
        {
            var startFyDate = GetFirstDateInFiscalYear(fiscalYear);
            return startFyDate.AddMonths(fiscalMonth - 1);
        }

        public static List<int> GetRangeOfYears(int startYear, int endYear)
        {
            return Enumerable.Range(startYear, (endYear - startYear) + 1).ToList();
        }
    }
}
