using System.Globalization;
using NUnit.Framework;

namespace System.Tests
{
    [TestFixture]
    public class CurrencyTest
    {
        [Test]
        public void CurrencyFromCurrentCultureEqualsCurrentCultureCurrency()
        {
            // NOTE: I think this test could fail in certain cultures...
            var currency1 = new Currency(new RegionInfo(CultureInfo.CurrentCulture.LCID).ISOCurrencySymbol);
            var currency2 = Currency.FromCurrentCulture();

            Assert.That(currency1.Name, Is.EqualTo(currency2.Name));
            Assert.That(currency1.Symbol, Is.EqualTo(currency2.Symbol));
            Assert.That(currency1.Iso3LetterCode, Is.EqualTo(currency2.Iso3LetterCode));
            Assert.That(currency1.IsoNumericCode, Is.EqualTo(currency2.IsoNumericCode));
        }

        [Test]
        public void CurrencyFromSpecificCultureInfoIsCorrect()
        {
            var currency = Currency.FromCultureInfo(new CultureInfo(1052));

            Assert.That(8, Is.EqualTo(currency.IsoNumericCode));
        }

        [Test]
        public void CurrencyFromSpecificIsoCodeIsCorrect()
        {
            var currency = Currency.FromIso3LetterCode("EUR");

            Assert.That(978, Is.EqualTo(currency.IsoNumericCode));
        }

        [Test]
        public void CurrencyHasValueEquality()
        {
            var currency1 = new Currency("USD");
            var currency2 = new Currency("USD");
            object boxedCurrency2 = currency2;

            Assert.True(currency1.Equals(currency2));
            Assert.True(currency1.Equals(boxedCurrency2));
        }
    }
}
