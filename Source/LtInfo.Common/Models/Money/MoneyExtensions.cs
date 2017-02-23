/*-----------------------------------------------------------------------
<copyright file="MoneyExtensions.cs" company="Sitka Technology Group">
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
