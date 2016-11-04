namespace System
{
    public static class MoneyExtensions
    {
        public static Money[] Distribute(this Money money,
                                         FractionReceivers fractionReceivers,
                                         RoundingPlaces roundingPlaces,
                                         Decimal distribution)
        {
            return new MoneyDistributor(money, fractionReceivers, roundingPlaces).Distribute(distribution);
        }

        public static Money[] Distribute(this Money money,
                                         FractionReceivers fractionReceivers,
                                         RoundingPlaces roundingPlaces,
                                         Decimal distribution1,
                                         Decimal distribution2)
        {
            return new MoneyDistributor(money, fractionReceivers, roundingPlaces).Distribute(distribution1,
                                                                                             distribution2);
        }

        public static Money[] Distribute(this Money money,
                                         FractionReceivers fractionReceivers,
                                         RoundingPlaces roundingPlaces,
                                         Decimal distribution1,
                                         Decimal distribution2,
                                         Decimal distribution3)
        {
            return new MoneyDistributor(money, fractionReceivers, roundingPlaces).Distribute(distribution1,
                                                                                             distribution2,
                                                                                             distribution3);
        }

        public static Money[] Distribute(this Money money,
                                         FractionReceivers fractionReceivers,
                                         RoundingPlaces roundingPlaces,
                                         params Decimal[] distributions)
        {
            return new MoneyDistributor(money, fractionReceivers, roundingPlaces).Distribute(distributions);
        }

        public static Money[] Distribute(this Money money,
                                         FractionReceivers fractionReceivers,
                                         RoundingPlaces roundingPlaces,
                                         Int32 count)
        {
            return new MoneyDistributor(money, fractionReceivers, roundingPlaces).Distribute(count);
        }
    }
}