using System.Collections.Generic;
using NUnit.Framework;

namespace ProjectFirma.Web.Common
{
    [TestFixture]
    public class FirmaHelpersTest
    {
        [Test]
        public void NoNumbersShouldReturnEmptyList()
        {
            var years = new List<int>();
            var result = FirmaHelpers.CalculateNumberRanges(years);
            Assert.That(result, Is.Empty);
        }
        [Test]
        public void OneNumberShouldOnlyShowOneNumber()
        {
            var years = new List<int> {1977};
            var result = FirmaHelpers.CalculateNumberRanges(years);
            var expected = new List<string> {"1977"};
            Assert.That(result, Is.EquivalentTo(expected));
        }

        [Test]
        public void TwoNonSequentialNumbersShouldShowTheTwoNumbers()
        {
            var years = new List<int> {1984, 1977};
            var result = FirmaHelpers.CalculateNumberRanges(years);
            var expected = new List<string> { "1977", "1984" };
            Assert.That(result, Is.EquivalentTo(expected));
        }


        [Test]
        public void AllSequentialNumberShouldShowARange()
        {
            var years = new List<int> {1, 2, 3, 4, 5};
            var result = FirmaHelpers.CalculateNumberRanges(years);
            var expected = new List<string> { "1-5" };
            Assert.That(result, Is.EquivalentTo(expected));
        }

        [Test]
        public void MultipleNumbersMultipleRanges()
        {
            var years = new List<int> { 1, 2, 3, 4, 5, 12, 13, 14, 19 };
            var result = FirmaHelpers.CalculateNumberRanges(years);
            var expected = new List<string> { "1-5", "12-14", "19" };
            Assert.That(result, Is.EquivalentTo(expected));
        }
    }
}