using System;
using ProjectFirma.Web.Models;
using NUnit.Framework;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static class AssertCustom
    {
        public static void AssertThatIsWithinOnePennyOf(this decimal actualValue, decimal expectedValue, string message = "Actual value not within one penny of expected value.")
        {
            Assert.That(Math.Abs(actualValue - expectedValue), Is.LessThan(0.015m), message);
        }

        public static void AssertThatIsWithinOneDollarOf(this decimal actualValue, decimal expectedValue, string message = "Actual value not within one dollar of expected value.")
        {
            Assert.That(Math.Abs(actualValue - expectedValue), Is.LessThan(1.5m), message);
        }
    }
}