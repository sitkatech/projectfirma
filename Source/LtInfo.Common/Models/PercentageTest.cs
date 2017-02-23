/*-----------------------------------------------------------------------
<copyright file="PercentageTest.cs" company="Sitka Technology Group">
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
using System;
using System.Globalization;
using System.Threading;
using NUnit.Framework;

namespace LtInfo.Common.Models
{
    [TestFixture]
    public class PercentageTests
    {
        [Test]
        public void PercentageHasValueEquality()
        {
            var percentage1 = new Percentage(.57M);
            var percentage2 = new Percentage(.57M);

            Assert.That(percentage1, Is.EqualTo(percentage2));
            Assert.That(percentage1, Is.Not.SameAs(percentage2));
        }

        [Test]
        public void PercentageImplicitlyConvertsFromPrimitiveNumbers()
        {
            Percentage percentage;
            const byte byteValue = 0;
            percentage = byteValue;
            Assert.That(new Percentage(0), Is.EqualTo(percentage));

            const sbyte sByteValue = 1;
            percentage = sByteValue;
            Assert.That(new Percentage(1), Is.EqualTo(percentage));

            const short int16Value = 0;
            percentage = int16Value;
            Assert.That(new Percentage(0), Is.EqualTo(percentage));

            const int int32Value = 1;
            percentage = int32Value;
            Assert.That(new Percentage(1), Is.EqualTo(percentage));

            const long int64Value = 1;
            percentage = int64Value;
            Assert.That(new Percentage(1), Is.EqualTo(percentage));

            const ushort uInt16Value = 0;
            percentage = uInt16Value;
            Assert.That(new Percentage(0), Is.EqualTo(percentage));

            const uint uInt32Value = 1;
            percentage = uInt32Value;
            Assert.That(new Percentage(1), Is.EqualTo(percentage));

            const ulong uInt64Value = 1;
            percentage = uInt64Value;
            Assert.That(new Percentage(1), Is.EqualTo(percentage));

            const float singleValue = 0;
            percentage = singleValue;
            Assert.That(new Percentage(0), Is.EqualTo(percentage));

            const double doubleValue = .65;
            percentage = doubleValue;
            Assert.That(new Percentage(.65M), Is.EqualTo(percentage));

            const decimal decimalValue = .77m;
            percentage = decimalValue;
            Assert.That(new Percentage(.77m), Is.EqualTo(percentage));
        }

        [Test]
        public void PercentageWholeAmountAdditionIsCorrect()
        {
            // whole number
            Percentage percentage1 = 0M;
            Percentage percentage2 = 1M;

            Assert.That(new Percentage(1), Is.EqualTo(percentage1 + percentage2));
        }

        [Test]
        public void PercentageFractionalAmountAdditionIsCorrect()
        {
            // fractions
            Percentage percentage1 = .22M;
            Percentage percentage2 = .71M;

            Assert.That(new Percentage(.93M), Is.EqualTo(percentage1 + percentage2));
        }

        [Test]
        public void PercentageWholeAmountSubtractionIsCorrect()
        {
            // whole number
            Percentage percentage1 = 1M;
            Percentage percentage2 = 1M;

            Assert.That(new Percentage(0), Is.EqualTo(percentage1 - percentage2));
        }

        [Test]
        public void PercentageFractionalAmountSubtractionIsCorrect()
        {
            // fractions
            Percentage percentage1 = .45M;
            Percentage percentage2 = 0.01M;

            Assert.That(new Percentage(.44M), Is.EqualTo(percentage1 - percentage2));
        }

        [Test]
        public void PercentageScalarWholeMultiplicationIsCorrect()
        {
            Percentage percentage = .125;

            Assert.That(new Percentage(.5M), Is.EqualTo(percentage * 4));
        }

        [Test]
        public void PercentageScalarFractionalMultiplicationIsCorrect()
        {
            Percentage percentage = .88125;

            Assert.That(new Percentage(.440625M), Is.EqualTo(percentage * 0.5M));
        }

        [Test]
        public void PercentageScalarWholeDivisionIsCorrect()
        {
            Percentage percentage = .75;

            Assert.That(new Percentage(.375M), Is.EqualTo(percentage / 2));
        }

        [Test]
        public void PercentageScalarFractionalDivisionIsCorrect()
        {
            Percentage percentage = .125;

            Assert.That(new Percentage(.25M), Is.EqualTo(percentage / 0.5M));
        }

        [Test]
        public void PercentageEqualOperatorIsCorrect()
        {
            Percentage percentage1 = .125;
            Percentage percentage2 = .125;

            Assert.True(percentage1 == percentage2);

            percentage2 = .135;
            Assert.False(percentage1 == percentage2);

            percentage2 = .25;
            Assert.False(percentage1 == percentage2);
        }

        [Test]
        public void PercentageNotEqualOperatorIsCorrect()
        {
            Percentage percentage1 = .125;
            Percentage percentage2 = .125;

            Assert.False(percentage1 != percentage2);

            percentage2 = .135;
            Assert.True(percentage1 != percentage2);

            percentage2 = .25;
            Assert.True(percentage1 != percentage2);
        }

        [Test]
        public void PercentageGreaterThanEqualOperatorIsCorrect()
        {
            Percentage percentage1 = .125;
            Percentage percentage2 = .125;

            Assert.True(percentage1 >= percentage2);

            percentage2 = .135;
            Assert.True(percentage2 >= percentage1);
            Assert.False(percentage1 >= percentage2);

            percentage2 = .25;
            Assert.True(percentage2 >= percentage1);
            Assert.False(percentage1 >= percentage2);
        }

        [Test]
        public void PercentageLessThanEqualOperatorIsCorrect()
        {
            Percentage percentage1 = .125;
            Percentage percentage2 = .125;

            Assert.True(percentage1 <= percentage2);

            percentage2 = .135;
            Assert.False(percentage2 <= percentage1);
            Assert.True(percentage1 <= percentage2);

            percentage2 = .25;
            Assert.False(percentage2 <= percentage1);
            Assert.True(percentage1 <= percentage2);
        }

        [Test]
        public void PercentageGreaterThanOperatorIsCorrect()
        {
            Percentage percentage1 = .125;
            Percentage percentage2 = .125;

            Assert.False(percentage1 > percentage2);

            percentage2 = .135;
            Assert.True(percentage2 > percentage1);
            Assert.False(percentage1 > percentage2);

            percentage2 = .25;
            Assert.True(percentage2 > percentage1);
            Assert.False(percentage1 > percentage2);
        }

        [Test]
        public void PercentageLessThanOperatorIsCorrect()
        {
            Percentage percentage1 = .125;
            Percentage percentage2 = .125;

            Assert.False(percentage1 < percentage2);

            percentage2 = .135;
            Assert.False(percentage2 < percentage1);
            Assert.True(percentage1 < percentage2);

            percentage2 = .25;
            Assert.False(percentage2 < percentage1);
            Assert.True(percentage1 < percentage2);
        }

        [Test]
        public void PercentagePrintsCorrectly()
        {
            var previousCulture = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            var percentage = new Percentage(.125M);
            var formattedPercentage = percentage.ToString();
            Assert.That("12.50%", Is.EqualTo(formattedPercentage));
            Thread.CurrentThread.CurrentCulture = previousCulture;
        }

        [Test]
        public void PercentageTryParseIsCorrect()
        {
            Percentage actual;

            var result = Percentage.TryParse("76.54%", out actual);
            Assert.True(result);
            Assert.That(new Percentage(.7654M), Is.EqualTo(actual));

            result = Percentage.TryParse("21.3%", out actual);
            Assert.True(result);
            Assert.That(new Percentage(.213M), Is.EqualTo(actual));

            result = Percentage.TryParse(".368%", out actual);
            Assert.True(result);
            Assert.That(new Percentage(.00368M), Is.EqualTo(actual));

            Assert.Throws<ArgumentOutOfRangeException>(() => Percentage.TryParse("101%", out actual), "We only do 0 to 100%");
            Assert.Throws<ArgumentOutOfRangeException>(() => Percentage.TryParse("-1%", out actual), "We only do 0 to 100%");
        }

        //[Test]
        //public void CanModelBind()
        //{
        //    var formCollection = new NameValueCollection
        //    {
        //        { "Budget", "$2,345.67" }
        //    };

        //    var boundModel = SetupAndBind<Percentage.PercentageModelBinder, Foo>(formCollection);
        //    Assert.AreEqual(new Percentage(2345.67m), boundModel.Budget);
        //}

        //private class Foo
        //{
        //    public Percentage? Budget { get; set; }
        //}

        //public static TModel SetupAndBind<TBinder, TModel>(NameValueCollection nameValueCollection) where TBinder : IModelBinder, new()
        //{
        //    var valueProvider = new NameValueCollectionValueProvider(nameValueCollection, null);
        //    var modelType = typeof(TModel);
        //    var modelMetaData = ModelMetadataProviders.Current.GetMetadataForType(null, modelType);
        //    var bindingContext = new ModelBindingContext { ModelName = modelType.Name, ValueProvider = valueProvider, ModelMetadata = modelMetaData, };
        //    return (TModel)new TBinder().BindModel(null, bindingContext);
        //}
    }
}
