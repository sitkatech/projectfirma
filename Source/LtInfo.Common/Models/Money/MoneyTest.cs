/*-----------------------------------------------------------------------
<copyright file="MoneyTest.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
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
using System.Collections.Specialized;
using System.Globalization;
using System.Threading;
using System.Web.Mvc;
using NUnit.Framework;

namespace System.Tests
{
    [TestFixture]
    public class MoneyTest
    {
        [Test]
        public void MoneyHasValueEquality()
        {
            var money1 = new Money(101.5M);
            var money2 = new Money(101.5M);

            Assert.That(money1, Is.EqualTo(money2));
            Assert.That(money1, Is.Not.SameAs(money2));
        }

        [Test]
        public void MoneyImplicitlyConvertsFromPrimitiveNumbers()
        {
            Money money;
            const byte byteValue = 50;
            money = byteValue;
            Assert.That(new Money(50), Is.EqualTo(money));

            const sbyte sByteValue = 75;
            money = sByteValue;
            Assert.That(new Money(75), Is.EqualTo(money));

            const short int16Value = 100;
            money = int16Value;
            Assert.That(new Money(100), Is.EqualTo(money));

            const int int32Value = 200;
            money = int32Value;
            Assert.That(new Money(200), Is.EqualTo(money));

            const long int64Value = 300;
            money = int64Value;
            Assert.That(new Money(300), Is.EqualTo(money));

            const ushort uInt16Value = 400;
            money = uInt16Value;
            Assert.That(new Money(400), Is.EqualTo(money));

            const uint uInt32Value = 500;
            money = uInt32Value;
            Assert.That(new Money(500), Is.EqualTo(money));

            const ulong uInt64Value = 600;
            money = uInt64Value;
            Assert.That(new Money(600), Is.EqualTo(money));

            const float singleValue = 700;
            money = singleValue;
            Assert.That(new Money(700), Is.EqualTo(money));

            const double doubleValue = 800;
            money = doubleValue;
            Assert.That(new Money(800), Is.EqualTo(money));

            const decimal decimalValue = 900;
            money = decimalValue;
            Assert.That(new Money(900), Is.EqualTo(money));
        }

        [Test]
        public void MoneyWholeAmountAdditionIsCorrect()
        {
            // whole number
            Money money1 = 101M;
            Money money2 = 99M;

            Assert.That(new Money(200), Is.EqualTo(money1 + money2));
        }

        [Test]
        public void MoneyFractionalAmountAdditionIsCorrect()
        {
            // fractions
            Money money1 = 100.00M;
            Money money2 = 0.01M;

            Assert.That(new Money(100.01M), Is.EqualTo(money1 + money2));
        }

        [Test]
        public void MoneyFractionalAmountWithOverflowAdditionIsCorrect()
        {
            // overflow
            Money money1 = 100.999M;
            Money money2 = 0.9M;

            Assert.That(new Money(101.899M), Is.EqualTo(money1 + money2));
        }

        [Test]
        public void MoneyNegativeAmountAdditionIsCorrect()
        {
            // negative
            Money money1 = 100.999M;
            Money money2 = -0.9M;

            Assert.That(new Money(100.099M), Is.EqualTo(money1 + money2));
        }

        [Test]
        public void MoneyNegativeAmountWithOverflowAdditionIsCorrect()
        {
            // negative overflow
            Money money1 = -100.999M;
            Money money2 = -0.9M;

            Assert.That(new Money(-101.899M), Is.EqualTo(money1 + money2));
        }

        [Test]
        public void MoneyWholeAmountSubtractionIsCorrect()
        {
            // whole number
            Money money1 = 101M;
            Money money2 = 99M;

            Assert.That(new Money(2), Is.EqualTo(money1 - money2));
        }

        [Test]
        public void MoneyFractionalAmountSubtractionIsCorrect()
        {
            // fractions
            Money money1 = 100.00M;
            Money money2 = 0.01M;

            Assert.That(new Money(99.99M), Is.EqualTo(money1 - money2));
        }

        [Test]
        public void MoneyFractionalAmountWithOverflowSubtractionIsCorrect()
        {
            // overflow
            Money money1 = 100.5M;
            Money money2 = 0.9M;

            Assert.That(new Money(99.6M), Is.EqualTo(money1 - money2));
        }

        [Test]
        public void MoneyNegativeAmountSubtractionIsCorrect()
        {
            // negative
            Money money1 = 100.999M;
            Money money2 = -0.9M;

            Assert.That(new Money(101.899M), Is.EqualTo(money1 - money2));
        }

        [Test]
        public void MoneyNegativeAmountWithOverflowSubtractionIsCorrect()
        {
            // negative overflow
            Money money1 = -100.999M;
            Money money2 = -0.9M;

            Assert.That(new Money(-100.099M), Is.EqualTo(money1 - money2));
        }

        [Test]
        public void MoneyScalarWholeMultiplicationIsCorrect()
        {
            Money money = 100.125;

            Assert.That(new Money(500.625M), Is.EqualTo(money * 5));
        }

        [Test]
        public void MoneyScalarFractionalMultiplicationIsCorrect()
        {
            Money money = 100.125;

            Assert.That(new Money(50.0625M), Is.EqualTo(money * 0.5M));
        }

        [Test]
        public void MoneyScalarNegativeWholeMultiplicationIsCorrect()
        {
            Money money = -100.125;

            Assert.That(new Money(-500.625M), Is.EqualTo(money * 5));
        }

        [Test]
        public void MoneyScalarNegativeFractionalMultiplicationIsCorrect()
        {
            Money money = -100.125;

            Assert.That(new Money(-50.0625M), Is.EqualTo(money * 0.5M));
        }

        [Test]
        public void MoneyScalarWholeDivisionIsCorrect()
        {
            Money money = 100.125;

            Assert.That(new Money(50.0625M), Is.EqualTo(money / 2));
        }

        [Test]
        public void MoneyScalarFractionalDivisionIsCorrect()
        {
            Money money = 100.125;

            Assert.That(new Money(200.25M), Is.EqualTo(money / 0.5M));
        }

        [Test]
        public void MoneyScalarNegativeWholeDivisionIsCorrect()
        {
            Money money = -100.125;

            Assert.That(new Money(-50.0625M), Is.EqualTo(money / 2));
        }

        [Test]
        public void MoneyScalarNegativeFractionalDivisionIsCorrect()
        {
            Money money = -100.125;

            Assert.That(new Money(-200.25M), Is.EqualTo(money / 0.5M));
        }

        [Test]
        public void MoneyEqualOperatorIsCorrect()
        {
            Money money1 = 100.125;
            Money money2 = 100.125;

            Assert.True(money1 == money2);

            money2 = 101.125;
            Assert.False(money1 == money2);

            money2 = 100.25;
            Assert.False(money1 == money2);
        }

        [Test]
        public void MoneyNotEqualOperatorIsCorrect()
        {
            Money money1 = 100.125;
            Money money2 = 100.125;

            Assert.False(money1 != money2);

            money2 = 101.125;
            Assert.True(money1 != money2);

            money2 = 100.25;
            Assert.True(money1 != money2);
        }

        [Test]
        public void MoneyGreaterThanEqualOperatorIsCorrect()
        {
            Money money1 = 100.125;
            Money money2 = 100.125;

            Assert.True(money1 >= money2);

            money2 = 101.125;
            Assert.True(money2 >= money1);
            Assert.False(money1 >= money2);

            money2 = 100.25;
            Assert.True(money2 >= money1);
            Assert.False(money1 >= money2);
        }

        [Test]
        public void MoneyLessThanEqualOperatorIsCorrect()
        {
            Money money1 = 100.125;
            Money money2 = 100.125;

            Assert.True(money1 <= money2);

            money2 = 101.125;
            Assert.False(money2 <= money1);
            Assert.True(money1 <= money2);

            money2 = 100.25;
            Assert.False(money2 <= money1);
            Assert.True(money1 <= money2);
        }

        [Test]
        public void MoneyGreaterThanOperatorIsCorrect()
        {
            Money money1 = 100.125;
            Money money2 = 100.125;

            Assert.False(money1 > money2);

            money2 = 101.125;
            Assert.True(money2 > money1);
            Assert.False(money1 > money2);

            money2 = 100.25;
            Assert.True(money2 > money1);
            Assert.False(money1 > money2);
        }

        [Test]
        public void MoneyLessThanOperatorIsCorrect()
        {
            Money money1 = 100.125;
            Money money2 = 100.125;

            Assert.False(money1 < money2);

            money2 = 101.125;
            Assert.False(money2 < money1);
            Assert.True(money1 < money2);

            money2 = 100.25;
            Assert.False(money2 < money1);
            Assert.True(money1 < money2);
        }

        [Test]
        public void MoneyPrintsCorrectly()
        {
            var previousCulture = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            var money = new Money(100.125M, Currency.Usd);
            var formattedMoney = money.ToString();
            Assert.That("$100.13", Is.EqualTo(formattedMoney));
            Thread.CurrentThread.CurrentCulture = previousCulture;
        }

        [Test]
        public void MoneyOperationsInvolvingDifferentCurrencyAllFail()
        {
            var money1 = new Money(101.5M, Currency.Aud);
            var money2 = new Money(98.5M, Currency.Cad);
            Money m;
            Boolean b;

            Assert.Throws<InvalidOperationException>(() => { m = money1 + money2; });
            Assert.Throws<InvalidOperationException>(() => { m = money1 - money2; });
            Assert.Throws<InvalidOperationException>(() => { b = money1 == money2; });
            Assert.Throws<InvalidOperationException>(() => { b = money1 != money2; });
            Assert.Throws<InvalidOperationException>(() => { b = money1 > money2; });
            Assert.Throws<InvalidOperationException>(() => { b = money1 < money2; });
            Assert.Throws<InvalidOperationException>(() => { b = money1 >= money2; });
            Assert.Throws<InvalidOperationException>(() => { b = money1 <= money2; });
        }

        [Test]
        public void MoneyTryParseIsCorrect()
        {
            const string usd = "$123.45";
            const string gbp = "£123.45";
            const string cad = "CAD123.45";

            Money actual;

            var result = Money.TryParse(usd, out actual);
            Assert.True(result);
            Assert.That(new Money(123.45M, Currency.Usd), Is.EqualTo(actual));

            result = Money.TryParse(gbp, out actual);
            Assert.True(result);
            Assert.That(new Money(123.45M, Currency.Gbp), Is.EqualTo(actual));

            result = Money.TryParse(cad, out actual);
            Assert.True(result);
            Assert.That(new Money(123.45M, Currency.Cad), Is.EqualTo(actual));
        }

        private class Foo
        {
            public Money? Budget { get; set; }
        }

        public static TModel SetupAndBind<TBinder, TModel>(NameValueCollection nameValueCollection) where TBinder : IModelBinder, new()
        {
            var valueProvider = new NameValueCollectionValueProvider(nameValueCollection, null);
            var modelType = typeof(TModel);
            var modelMetaData = ModelMetadataProviders.Current.GetMetadataForType(null, modelType);
            var bindingContext = new ModelBindingContext { ModelName = modelType.Name, ValueProvider = valueProvider, ModelMetadata = modelMetaData };
            return (TModel) new TBinder().BindModel(null, bindingContext);
        }
    }
}
