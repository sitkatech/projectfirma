using NUnit.Framework;

namespace System.Tests
{
    public class MoneyDistributorTest
    {
        [Test]
        public void UniformDistributionMustBeBetween0And1()
        {
            var distributor = new MoneyDistributor(1.0M, FractionReceivers.LastToFirst, RoundingPlaces.Two);

            Assert.Throws<ArgumentOutOfRangeException>(() => distributor.Distribute(0));
            Assert.Throws<ArgumentOutOfRangeException>(() => distributor.Distribute(1.1M));
        }


        [Test]
        public void DistributeUniformRatioToLastIsCorrect()
        {
            Money amountToDistribute = 0.05M;

            // two decimal places
            var distributor = new MoneyDistributor(amountToDistribute, FractionReceivers.LastToFirst, RoundingPlaces.Two);

            var distribution = distributor.Distribute(0.3M);

            Assert.That(3, Is.EqualTo(distribution.Length));
            Assert.That(new Money(0.01M), Is.EqualTo(distribution[0]));
            Assert.That(new Money(0.02M), Is.EqualTo(distribution[1]));
            Assert.That(new Money(0.02M), Is.EqualTo(distribution[2]));

            // seven decimal places
            distributor = new MoneyDistributor(amountToDistribute,
                                               FractionReceivers.LastToFirst,
                                               RoundingPlaces.Seven);

            distribution = distributor.Distribute(0.3M);

            Assert.That(3, Is.EqualTo(distribution.Length));
            Assert.That(new Money(0.0166666M), Is.EqualTo(distribution[0]));
            Assert.That(new Money(0.0166667M), Is.EqualTo(distribution[1]));
            Assert.That(new Money(0.0166667M), Is.EqualTo(distribution[2]));
        }

        [Test]
        [Ignore("Still not implemented")]
        public void DistributeNonuniformRatiosToLastIsCorrect()
        {
            Money amountToDistribute = 0.05M;

            var distributor = new MoneyDistributor(amountToDistribute, FractionReceivers.LastToFirst, RoundingPlaces.Two);

            var distribution = distributor.Distribute(0.7M, 0.3M);

            Assert.That(2, Is.EqualTo(distribution.Length));
            Assert.That(0.03, Is.EqualTo(distribution[0]));
            Assert.That(0.02, Is.EqualTo(distribution[1]));
        }
    }
}
