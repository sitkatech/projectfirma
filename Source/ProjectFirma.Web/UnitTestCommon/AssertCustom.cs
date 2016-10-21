using System;
using ProjectFirma.Web.Models;
using NUnit.Framework;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static class AssertCustom
    {
        public static void AssertAccelaKeyIsValid(AccelaCAPRecord accelaKey)
        {
            Assert.That(accelaKey, Is.Not.Null, "Key should not be null");
            Assert.That(!String.IsNullOrWhiteSpace(accelaKey.AccelaID), "Should have identifier display");
            Assert.That(!String.IsNullOrWhiteSpace(accelaKey.KeyOne), "Should have first key part");
            Assert.That(!String.IsNullOrWhiteSpace(accelaKey.KeyTwo), "Should have second key part");
            Assert.That(!String.IsNullOrWhiteSpace(accelaKey.KeyThree), "Should have third key part");
        }

        public static void AccelaCapRecordsAreEquivalent(AccelaCAPRecord accelaCapRecordFromAccela, AccelaCAPRecord accelaCapRecord)
        {
            Assert.That(accelaCapRecordFromAccela.ToHumanReadableString(), Is.EqualTo(accelaCapRecord.ToHumanReadableString()), "Should match keys");
        }

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