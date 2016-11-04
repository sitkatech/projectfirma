using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.MvcResults;
using NUnit.Framework;

namespace LtInfo.Common
{
    /// <summary>
    /// Contains functions for use in Unit testing
    /// </summary>
    public static class AssertCustom
    {
        public static void IgnoreUntil(DateTime timeWhenIgnoreExpires, string message)
        {
            var now = DateTime.Now;
            var difference = timeWhenIgnoreExpires - now;
            if(difference <= TimeSpan.Zero)
            {
                Assert.Fail("{0}\r\nTest was set to be temporarily ignored and the ignore has expired.\r\nCurrent time {1:MM/dd/yyyy HH:mm:ss} is past ignore expiration time {2:MM/dd/yyyy HH:mm:ss} by {3}", message, now, timeWhenIgnoreExpires, -difference);
            }
            else
            {
                Assert.Ignore("{0}\r\nIgnored until {1:MM/dd/yyyy HH:mm:ss}. The current time is {2:MM/dd/yyyy HH:mm:ss} and the test will be ignored for {3} longer.", message, timeWhenIgnoreExpires, now, difference);
            }
        }

        public static void FirstIsSubsetOfSecond<T>(IEnumerable<T> first, IEnumerable<T> second, string message)
        {
            var firstList = first.ToList();
            Assert.That(second.Intersect(firstList).ToList(), Is.EquivalentTo(firstList.ToList()), message);
        }

        public static void AreEqual(ActionResult expected, ActionResult actual)
        {
            AreEqual(expected, actual, null);
        }

        public static void AreEqual(ActionResult expected, ActionResult actual, string message)
        {
            BothNullOrBothNotNull(expected, actual, message);
            if (AreBothNull(expected, actual))
            {
                return;
            }

            Assert.That(actual, Is.InstanceOf(expected.GetType()), String.Format("The ActionResult types do not match. {0}", message));

            Check.Invariant(expected.GetType().IsInstanceOfType(actual), "Should only be possible to get here if types agree");
            if (expected is ViewResult)
            {
                Check.Invariant(actual is ViewResult, "Should only be possible to get here if types agree");
                AreEqual((ViewResult) expected, (ViewResult) actual, message);
            }
            else if (expected is RedirectResult)
            {
                Check.Invariant(actual is RedirectResult, "Should only be possible to get here if types agree");
                AreEqual((RedirectResult)expected, (RedirectResult)actual, message);
            }
            else if (expected is ModalDialogFormJsonResult)
            {
                Check.Invariant(actual is ModalDialogFormJsonResult, "Should only be possible to get here if types agree");
                AreEqual((ModalDialogFormJsonResult)expected, (ModalDialogFormJsonResult)actual, message);
            }
            else
            {
                throw new ArgumentException(String.Format("Don't know yet how to compare ActionResults of type {0}, extend this method to add support.", expected.GetType().Name));
            }
        }

        private static void AreEqual(ViewResult expected, ViewResult actual, string message)
        {
            BothNullOrBothNotNull(expected, actual, message);
            if (AreBothNull(expected, actual))
                return;

            Assert.That(actual.ViewName, Is.EqualTo(expected.ViewName), String.Format("ViewName mismatch. {0}", message));
            Assert.That(actual.ViewData, Is.InstanceOf(expected.ViewData.GetType()));
        }

        private static void AreEqual(RedirectResult expected, RedirectResult actual, string message)
        {
            BothNullOrBothNotNull(expected, actual, message);
            if (AreBothNull(expected, actual))
                return;

            Assert.That(actual.Url, Is.EqualTo(expected.Url), String.Format("Redirect mismatch. {0}", message));
        }

        private static void AreEqual(ModalDialogFormJsonResult expected, ModalDialogFormJsonResult actual, string message)
        {
            BothNullOrBothNotNull(expected, actual, message);
        }

        private static bool AreBothNull(object lhs, object rhs)
        {
            return (lhs == null && rhs == null);
        }

        private static void BothNullOrBothNotNull(object lhs, object rhs, string message)
        {
            if (lhs == null && rhs != null)
                Assert.Fail("Not equal because first argument is *null* and second argument is not null. {0}", message);
            if (lhs != null && rhs == null)
                Assert.Fail("Not equal because first argument is not null and second argument is *null*. {0}", message);
        }

        public static void DataTableHasExpectedColumnType(DataTable dataTable, DataColumn expectedColumn, string message)
        {
            Assert.That(dataTable.Columns.Contains(expectedColumn.ColumnName), String.Format("{0}: DataTable did not contain expected column \"{1}\"", message, expectedColumn.ColumnName));
            Assert.That(dataTable.Columns[expectedColumn.ColumnName].DataType, Is.EqualTo(expectedColumn.DataType), String.Format("{0}: DataTable column \"{1}\" did not match expected data type {2}", message, expectedColumn.ColumnName, expectedColumn.DataType.Name));
        }

        public static void DataTableHasExpectedColumns(DataTable dataTable, IEnumerable<DataColumn> expectedCols, string message)
        {
            expectedCols.ToList().ForEach(col => DataTableHasExpectedColumnType(dataTable, col, message));
        }

        public static void AssertColumnExistsAndMatchesValue<T>(GridSpec<T> gridSpec, string expectColumnName, T sampleObject, string expectedValue)
        {
            var expectedColumn = gridSpec.SingleOrDefault(c => String.Equals(c.ColumnNameInnerText, expectColumnName, StringComparison.InvariantCultureIgnoreCase));
            Assert.That(expectedColumn, Is.Not.Null, String.Format("Missing Column \"{0}\"", expectColumnName));
            // ReSharper disable PossibleNullReferenceException
            Assert.That(expectedColumn.CalculateStringValue(sampleObject), Is.StringContaining(expectedValue), String.Format("Column \"{0}\" had an unexpected value.", expectColumnName));
            // ReSharper restore PossibleNullReferenceException
        }

        public static void AssertColumnDoesNotExist<T>(GridSpec<T> gridSpec, string expectColumnName)
        {
            var expectedColumn = gridSpec.SingleOrDefault(c => String.Equals(c.ColumnNameInnerText, expectColumnName, StringComparison.InvariantCultureIgnoreCase));
            Assert.That(expectedColumn, Is.Null, String.Format("Should not have Column \"{0}\"", expectColumnName));
        }
    }
}