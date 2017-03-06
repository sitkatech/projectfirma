/*-----------------------------------------------------------------------
<copyright file="CurrencyTest.cs" company="Sitka Technology Group">
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
