using System;
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using NUnit.Framework;

namespace ProjectFirma.Web.Common
{
    [TestFixture]
    public class FirmaDateUtilitiesTest
    {
        [Test]
        public void CalculateCalendarYearRangeAccountingForExistingYearsWithCeilingOfCurrentYearToUseTest()
        {
            // Test empty list: should return just current year
            var currentYearToUse = DateTime.Today.Year;
            var ceilingYear = currentYearToUse;
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(), null, null, currentYearToUse, FirmaDateUtilities.MinimumYear, ceilingYear), Is.EquivalentTo(Enumerable.Range(currentYearToUse, 1)));

            // No existing budget records

            // Testing if only have a start year
            // -- Start Year in the past: should go from Start Year to Current Year
            var startYear = currentYearToUse - 2;
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(), startYear, null, currentYearToUse, FirmaDateUtilities.MinimumYear, ceilingYear), Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(startYear, currentYearToUse)));
            // -- Start Year same as current year: should just be Start Year
            startYear = currentYearToUse;
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(), startYear, null, currentYearToUse, FirmaDateUtilities.MinimumYear, ceilingYear), Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(startYear, startYear)));
            // -- Start Year in the future: should just be the ceiling year
            startYear = currentYearToUse + 3;
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(), startYear, null, currentYearToUse, FirmaDateUtilities.MinimumYear, ceilingYear), Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(ceilingYear, ceilingYear)));

            // Testing if only have a completion year
            var completionYear = currentYearToUse - 2;
            // -- Completion Year in the past or same as current year, should only show Completion Year
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(), null, completionYear, currentYearToUse, FirmaDateUtilities.MinimumYear, ceilingYear),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(completionYear, completionYear)));
            completionYear = currentYearToUse;
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(), null, completionYear, currentYearToUse, FirmaDateUtilities.MinimumYear, ceilingYear),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(completionYear, completionYear)));
            // -- Completion Year in the future: should be the ceiling year
            completionYear = currentYearToUse + 3;
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(), null, completionYear, currentYearToUse, FirmaDateUtilities.MinimumYear, ceilingYear),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(ceilingYear, ceilingYear)));

            // Testing if have both Start Year and Completion Year: should always be Start Year to Completion Year
            // -- Start Year in the past
            startYear = currentYearToUse - 2;
            // -- Completion year in the past
            completionYear = currentYearToUse - 1;
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(), startYear, completionYear, currentYearToUse, FirmaDateUtilities.MinimumYear, ceilingYear),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(startYear, completionYear)));
            // -- Completion year same as current year
            completionYear = currentYearToUse;
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(), startYear, completionYear, currentYearToUse, FirmaDateUtilities.MinimumYear, ceilingYear),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(startYear, completionYear)));
            // -- Completion year in future, should only go up to the ceiling year
            completionYear = startYear + 5;
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(), startYear, completionYear, currentYearToUse, FirmaDateUtilities.MinimumYear, ceilingYear),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(startYear, ceilingYear)));

            // -- Start Year same as current year
            startYear = currentYearToUse;
            // -- Completion year in the past; should throw since that cannot happen!
            completionYear = currentYearToUse - 1;
            Assert.Throws<PreconditionException>(() => FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(), startYear, completionYear, currentYearToUse, FirmaDateUtilities.MinimumYear, ceilingYear), "Cannot have a start year > end year!");
            // -- Completion year same as current year
            completionYear = currentYearToUse;
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(), startYear, completionYear, currentYearToUse, FirmaDateUtilities.MinimumYear, ceilingYear),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(startYear, completionYear)));
            // -- Completion year in future
            completionYear = startYear + 5;
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(), startYear, completionYear, currentYearToUse, FirmaDateUtilities.MinimumYear, ceilingYear),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(startYear, ceilingYear)));

            // -- Start Year in the future
            startYear = currentYearToUse + 2;
            // -- Completion year in the past; should throw since that cannot happen!
            completionYear = currentYearToUse - 1;
            Assert.Throws<PreconditionException>(() => FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(), startYear, completionYear, currentYearToUse, FirmaDateUtilities.MinimumYear, ceilingYear), "Cannot have a start year > end year!");
            // -- Completion year same as current year
            completionYear = currentYearToUse;
            Assert.Throws<PreconditionException>(() => FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(), startYear, completionYear, currentYearToUse, FirmaDateUtilities.MinimumYear, ceilingYear), "Cannot have a start year > end year!");
            // -- Completion year in future
            completionYear = startYear + 5;
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(), startYear, completionYear, currentYearToUse, FirmaDateUtilities.MinimumYear, ceilingYear),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(ceilingYear, ceilingYear)));

            // If we have existing budget records, we need to factor those in
            var yearBeforeCurrentYear = currentYearToUse - 2;
            var yearAfterCurrentYear = currentYearToUse + 4;
            // no start year and no end year provided
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int> { yearBeforeCurrentYear }, null, null, currentYearToUse, FirmaDateUtilities.MinimumYear, ceilingYear),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(yearBeforeCurrentYear, currentYearToUse)));
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int> { yearBeforeCurrentYear, yearAfterCurrentYear }, null, null, currentYearToUse, FirmaDateUtilities.MinimumYear, ceilingYear),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(yearBeforeCurrentYear, yearAfterCurrentYear)));
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int> { yearAfterCurrentYear }, null, null, currentYearToUse, FirmaDateUtilities.MinimumYear, ceilingYear),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(currentYearToUse, yearAfterCurrentYear)));
            // start year provided
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int> { yearBeforeCurrentYear }, currentYearToUse, null, currentYearToUse, FirmaDateUtilities.MinimumYear, ceilingYear),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(yearBeforeCurrentYear, currentYearToUse)));
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int> { yearBeforeCurrentYear, yearAfterCurrentYear }, currentYearToUse, null, currentYearToUse, FirmaDateUtilities.MinimumYear, ceilingYear),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(yearBeforeCurrentYear, yearAfterCurrentYear)));
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int> { yearAfterCurrentYear }, currentYearToUse, null, currentYearToUse, FirmaDateUtilities.MinimumYear, ceilingYear),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(currentYearToUse, yearAfterCurrentYear)));
            // end year provided
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int> { yearBeforeCurrentYear }, null, currentYearToUse, currentYearToUse, FirmaDateUtilities.MinimumYear, ceilingYear),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(yearBeforeCurrentYear, currentYearToUse)));
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int> { yearBeforeCurrentYear, yearAfterCurrentYear }, null, currentYearToUse, currentYearToUse, FirmaDateUtilities.MinimumYear, ceilingYear),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(yearBeforeCurrentYear, yearAfterCurrentYear)));
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int> { yearAfterCurrentYear }, null, currentYearToUse, currentYearToUse, FirmaDateUtilities.MinimumYear, ceilingYear),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(currentYearToUse, yearAfterCurrentYear)));
            // start year and end year provided
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int> { yearBeforeCurrentYear }, currentYearToUse - 1, currentYearToUse + 1, currentYearToUse, FirmaDateUtilities.MinimumYear, ceilingYear),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(yearBeforeCurrentYear, ceilingYear)));
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int> { yearBeforeCurrentYear, yearAfterCurrentYear }, currentYearToUse - 1, currentYearToUse + 1, currentYearToUse, FirmaDateUtilities.MinimumYear, ceilingYear),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(yearBeforeCurrentYear, yearAfterCurrentYear)));
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int> { yearAfterCurrentYear }, currentYearToUse - 1, currentYearToUse + 1, currentYearToUse, FirmaDateUtilities.MinimumYear, ceilingYear),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(currentYearToUse - 1, yearAfterCurrentYear)));
        }

        [Test]
        public void CalculateCalendarYearRangeAccountingForExistingYearsWithNoCeilingYearTest()
        {
            // Test empty list: should return just current year
            var currentYearToUse = DateTime.Today.Year;
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(), null, null, currentYearToUse, FirmaDateUtilities.MinimumYear, null), Is.EquivalentTo(Enumerable.Range(currentYearToUse, 1)));

            // No existing budget records

            // Testing if only have a start year
            // -- Start Year in the past: should go from Start Year to Current Year
            var startYear = currentYearToUse - 2;
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(), startYear, null, currentYearToUse, FirmaDateUtilities.MinimumYear, null), Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(startYear, currentYearToUse)));
            // -- Start Year same as current year: should just be Start Year
            startYear = currentYearToUse;
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(), startYear, null, currentYearToUse, FirmaDateUtilities.MinimumYear, null), Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(startYear, startYear)));
            // -- Start Year in the future: should just be Start Year
            startYear = currentYearToUse + 3;
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(), startYear, null, currentYearToUse, FirmaDateUtilities.MinimumYear, null), Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(startYear, startYear)));

            // Testing if only have a completion year
            var completionYear = currentYearToUse - 2;
            // -- Completion Year in the past or same as current year, should only show Completion Year
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(), null, completionYear, currentYearToUse, FirmaDateUtilities.MinimumYear, null),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(completionYear, completionYear)));
            completionYear = currentYearToUse;
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(), null, completionYear, currentYearToUse, FirmaDateUtilities.MinimumYear, null),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(completionYear, completionYear)));
            // -- Completion Year in the future: should be current year to Completion Year
            completionYear = currentYearToUse + 3;
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(), null, completionYear, currentYearToUse, FirmaDateUtilities.MinimumYear, null),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(currentYearToUse, completionYear)));

            // Testing if have both Start Year and Completion Year: should always be Start Year to Completion Year
            // -- Start Year in the past
            startYear = currentYearToUse - 4;
            // -- Completion year in the past
            completionYear = currentYearToUse - 1;
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(), startYear, completionYear, currentYearToUse, FirmaDateUtilities.MinimumYear, null),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(startYear, completionYear)));
            // -- Completion year same as current year
            completionYear = currentYearToUse;
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(), startYear, completionYear, currentYearToUse, FirmaDateUtilities.MinimumYear, null),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(startYear, completionYear)));
            // -- Completion year in future
            completionYear = startYear + 5;
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(), startYear, completionYear, currentYearToUse, FirmaDateUtilities.MinimumYear, null),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(startYear, completionYear)));

            // -- Start Year same as current year
            startYear = currentYearToUse;
            // -- Completion year in the past; should throw since that cannot happen!
            completionYear = currentYearToUse - 1;
            Assert.Throws<PreconditionException>(() => FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(), startYear, completionYear, currentYearToUse, FirmaDateUtilities.MinimumYear, null), "Cannot have a start year > end year!");
            // -- Completion year same as current year
            completionYear = currentYearToUse;
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(), startYear, completionYear, currentYearToUse, FirmaDateUtilities.MinimumYear, null),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(startYear, completionYear)));
            // -- Completion year in future
            completionYear = startYear + 5;
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(), startYear, completionYear, currentYearToUse, FirmaDateUtilities.MinimumYear, null),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(startYear, completionYear)));

            // -- Start Year in the future
            startYear = currentYearToUse + 2;
            // -- Completion year in the past; should throw since that cannot happen!
            completionYear = currentYearToUse - 1;
            Assert.Throws<PreconditionException>(() => FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(), startYear, completionYear, currentYearToUse, FirmaDateUtilities.MinimumYear, null), "Cannot have a start year > end year!");
            // -- Completion year same as current year
            completionYear = currentYearToUse;
            Assert.Throws<PreconditionException>(() => FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(), startYear, completionYear, currentYearToUse, FirmaDateUtilities.MinimumYear, null), "Cannot have a start year > end year!");
            // -- Completion year in future
            completionYear = startYear + 5;
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(), startYear, completionYear, currentYearToUse, FirmaDateUtilities.MinimumYear, null),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(startYear, completionYear)));

            // If we have existing budget records, we need to factor those in
            var yearBeforeCurrentYear = currentYearToUse - 2;
            var yearAfterCurrentYear = currentYearToUse + 4;
            // no start year and no end year provided
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int> { yearBeforeCurrentYear }, null, null, currentYearToUse, FirmaDateUtilities.MinimumYear, null),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(yearBeforeCurrentYear, currentYearToUse)));
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int> { yearBeforeCurrentYear, yearAfterCurrentYear }, null, null, currentYearToUse, FirmaDateUtilities.MinimumYear, null),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(yearBeforeCurrentYear, yearAfterCurrentYear)));
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int> { yearAfterCurrentYear }, null, null, currentYearToUse, FirmaDateUtilities.MinimumYear, null),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(currentYearToUse, yearAfterCurrentYear)));
            // start year provided
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int> { yearBeforeCurrentYear }, currentYearToUse, null, currentYearToUse, FirmaDateUtilities.MinimumYear, null),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(yearBeforeCurrentYear, currentYearToUse)));
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int> { yearBeforeCurrentYear, yearAfterCurrentYear }, currentYearToUse, null, currentYearToUse, FirmaDateUtilities.MinimumYear, null),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(yearBeforeCurrentYear, yearAfterCurrentYear)));
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int> { yearAfterCurrentYear }, currentYearToUse, null, currentYearToUse, FirmaDateUtilities.MinimumYear, null),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(currentYearToUse, yearAfterCurrentYear)));
            // end year provided
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int> { yearBeforeCurrentYear }, null, currentYearToUse, currentYearToUse, FirmaDateUtilities.MinimumYear, null),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(yearBeforeCurrentYear, currentYearToUse)));
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int> { yearBeforeCurrentYear, yearAfterCurrentYear }, null, currentYearToUse, currentYearToUse, FirmaDateUtilities.MinimumYear, null),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(yearBeforeCurrentYear, yearAfterCurrentYear)));
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int> { yearAfterCurrentYear }, null, currentYearToUse, currentYearToUse, FirmaDateUtilities.MinimumYear, null),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(currentYearToUse, yearAfterCurrentYear)));
            // start year and end year provided
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int> { yearBeforeCurrentYear }, currentYearToUse - 1, currentYearToUse + 1, currentYearToUse, FirmaDateUtilities.MinimumYear, null),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(yearBeforeCurrentYear, currentYearToUse + 1)));
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int> { yearBeforeCurrentYear, yearAfterCurrentYear }, currentYearToUse - 1, currentYearToUse + 1, currentYearToUse, FirmaDateUtilities.MinimumYear, null),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(yearBeforeCurrentYear, yearAfterCurrentYear)));
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int> { yearAfterCurrentYear }, currentYearToUse - 1, currentYearToUse + 1, currentYearToUse, FirmaDateUtilities.MinimumYear, null),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(currentYearToUse - 1, yearAfterCurrentYear)));
        }

        [Test]
        public void CurrentReportingYearSetCorrectlyTest()
        {
            var reportingPeriodStartMonth = 11;
            var reportingPeriodStartDay = 1;
            var currentDateTime = new DateTime(2015, 1, 1);
            var currentYearToUseForReporting = FirmaDateUtilities.CalculateCurrentYearToUseForReportingImpl(currentDateTime, reportingPeriodStartMonth, reportingPeriodStartDay);

            Assert.That(currentYearToUseForReporting, Is.EqualTo(2014));

            currentDateTime = new DateTime(2015, 12, 1);
            currentYearToUseForReporting = FirmaDateUtilities.CalculateCurrentYearToUseForReportingImpl(currentDateTime, reportingPeriodStartMonth, reportingPeriodStartDay);

            Assert.That(currentYearToUseForReporting, Is.EqualTo(2015));
            
            currentDateTime = new DateTime(2016, 1, 1);
            currentYearToUseForReporting = FirmaDateUtilities.CalculateCurrentYearToUseForReportingImpl(currentDateTime, reportingPeriodStartMonth, reportingPeriodStartDay);

            Assert.That(currentYearToUseForReporting, Is.EqualTo(2015));


            currentDateTime = new DateTime(2017, 1, 1);
            currentYearToUseForReporting = FirmaDateUtilities.CalculateCurrentYearToUseForReportingImpl(currentDateTime, reportingPeriodStartMonth, reportingPeriodStartDay);

            Assert.That(currentYearToUseForReporting, Is.EqualTo(2016));
        }

        [Test]
        public void IsDayToSendDelinquentReminderTest()
        {
            var deadlineMonth = 1;
            var deadlineDay = 15;
            var deadlineYear = FirmaDateUtilities.CalculateDeadlineYear();
            var reportingPeriodEndMonth = 10;
            var reportingPeriodEndDay = 1;
            var delinquentReminderIntervalInDays = 5;
            var futureDeadlineYear = deadlineYear + 1;
            var previousDeadlineYear = deadlineYear - 1;

            var result = FirmaDateUtilities.IsDayToSendDelinquentReminder(new DateTime(deadlineYear, deadlineMonth, deadlineDay + 1), delinquentReminderIntervalInDays, deadlineMonth, deadlineDay, reportingPeriodEndMonth, reportingPeriodEndDay);
            Assert.That(result, Is.False, string.Format("In reporting period but not a mod {0} day", delinquentReminderIntervalInDays));
            result = FirmaDateUtilities.IsDayToSendDelinquentReminder(new DateTime(deadlineYear, deadlineMonth, deadlineDay + delinquentReminderIntervalInDays), delinquentReminderIntervalInDays, deadlineMonth, deadlineDay, reportingPeriodEndMonth, reportingPeriodEndDay);
            Assert.That(result, Is.True, string.Format("In reporting period and a mod {0} day", delinquentReminderIntervalInDays));

            var resultList = new List<bool>();
            for (var i = 1; i <= delinquentReminderIntervalInDays; i++)
            {
                result = FirmaDateUtilities.IsDayToSendDelinquentReminder(new DateTime(deadlineYear, reportingPeriodEndMonth, reportingPeriodEndDay).AddDays(-i),
                    delinquentReminderIntervalInDays,
                    deadlineMonth,
                    deadlineDay,
                    reportingPeriodEndMonth,
                    reportingPeriodEndDay);
                resultList.Add(result);
            }
            Assert.That(resultList.Count(x => x), Is.EqualTo(1), string.Format("Should only have one reminder during this {0} day period when we are in the reporting period", delinquentReminderIntervalInDays));

            result = FirmaDateUtilities.IsDayToSendDelinquentReminder(new DateTime(deadlineYear, deadlineMonth, deadlineDay), delinquentReminderIntervalInDays, deadlineMonth, deadlineDay, reportingPeriodEndMonth, reportingPeriodEndDay);
            Assert.That(result, Is.False, "In reporting period and on deadline day");
            result = FirmaDateUtilities.IsDayToSendDelinquentReminder(new DateTime(deadlineYear, reportingPeriodEndMonth, reportingPeriodEndDay), delinquentReminderIntervalInDays, deadlineMonth, deadlineDay, reportingPeriodEndMonth, reportingPeriodEndDay);
            Assert.That(result, Is.False, "In reporting period and at reporting period end date");

            // future reporting year
            result = FirmaDateUtilities.IsDayToSendDelinquentReminder(new DateTime(deadlineYear, reportingPeriodEndMonth, reportingPeriodEndDay + 7), delinquentReminderIntervalInDays, deadlineMonth, deadlineDay, reportingPeriodEndMonth, reportingPeriodEndDay);
            Assert.That(result, Is.False, "After reporting period end day");

            result = FirmaDateUtilities.IsDayToSendDelinquentReminder(new DateTime(futureDeadlineYear, deadlineMonth, deadlineDay + 1), delinquentReminderIntervalInDays, deadlineMonth, deadlineDay, reportingPeriodEndMonth, reportingPeriodEndDay);
            Assert.That(result, Is.False, "Future reporting year but not a reporting day");
            result = FirmaDateUtilities.IsDayToSendDelinquentReminder(new DateTime(futureDeadlineYear, deadlineMonth, deadlineDay + delinquentReminderIntervalInDays), delinquentReminderIntervalInDays, deadlineMonth, deadlineDay, reportingPeriodEndMonth, reportingPeriodEndDay);
            Assert.That(result, Is.False, "Future reporting year and a reporting day");

            result = FirmaDateUtilities.IsDayToSendDelinquentReminder(new DateTime(futureDeadlineYear, deadlineMonth, deadlineDay), delinquentReminderIntervalInDays, deadlineMonth, deadlineDay, reportingPeriodEndMonth, reportingPeriodEndDay);
            Assert.That(result, Is.False, "Future reporting year and on deadline day");
            result = FirmaDateUtilities.IsDayToSendDelinquentReminder(new DateTime(futureDeadlineYear, reportingPeriodEndMonth, reportingPeriodEndDay), delinquentReminderIntervalInDays, deadlineMonth, deadlineDay, reportingPeriodEndMonth, reportingPeriodEndDay);
            Assert.That(result, Is.False, "Future reporting year and at reporting period end date");

            result = FirmaDateUtilities.IsDayToSendDelinquentReminder(new DateTime(previousDeadlineYear, deadlineMonth, deadlineDay + 1), delinquentReminderIntervalInDays, deadlineMonth, deadlineDay, reportingPeriodEndMonth, reportingPeriodEndDay);
            Assert.That(result, Is.False, "Previous reporting year but not a reporting day");
            result = FirmaDateUtilities.IsDayToSendDelinquentReminder(new DateTime(previousDeadlineYear, deadlineMonth, deadlineDay + delinquentReminderIntervalInDays), delinquentReminderIntervalInDays, deadlineMonth, deadlineDay, reportingPeriodEndMonth, reportingPeriodEndDay);
            Assert.That(result, Is.False, "Previous reporting year and a reporting day");

            result = FirmaDateUtilities.IsDayToSendDelinquentReminder(new DateTime(previousDeadlineYear, deadlineMonth, deadlineDay), delinquentReminderIntervalInDays, deadlineMonth, deadlineDay, reportingPeriodEndMonth, reportingPeriodEndDay);
            Assert.That(result, Is.False, "Previous reporting year and on deadline day");
            result = FirmaDateUtilities.IsDayToSendDelinquentReminder(new DateTime(previousDeadlineYear, reportingPeriodEndMonth, reportingPeriodEndDay), delinquentReminderIntervalInDays, deadlineMonth, deadlineDay, reportingPeriodEndMonth, reportingPeriodEndDay);
            Assert.That(result, Is.False, "Previous reporting year and at reporting period end date");
        }
    }
}