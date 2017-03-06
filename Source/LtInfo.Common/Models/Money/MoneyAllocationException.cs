/*-----------------------------------------------------------------------
<copyright file="MoneyAllocationException.cs" company="Sitka Technology Group">
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
using System;
using System.Runtime.Serialization;

namespace System
{
    [Serializable]
    public class MoneyAllocationException : Exception
    {
        private readonly Money _amountToDistribute;
        private readonly Money _distributionTotal;
        private readonly Decimal[] _distribution;

        public MoneyAllocationException(Money amountToDistribute,
                                        Money distributionTotal,
                                        Decimal[] distribution)
        {
            _amountToDistribute = amountToDistribute;
            _distribution = distribution;
            _distributionTotal = distributionTotal;
        }

        public MoneyAllocationException(Money amountToDistribute,
                                        Money distributionTotal,
                                        Decimal[] distribution,
                                        String message)
            : base(message)
        {
            _amountToDistribute = amountToDistribute;
            _distribution = distribution;
            _distributionTotal = distributionTotal;
        }

        public MoneyAllocationException(Money amountToDistribute,
                                        Money distributionTotal,
                                        Decimal[] distribution,
                                        String message,
                                        Exception inner)
            : base(message, inner)
        {
            _amountToDistribute = amountToDistribute;
            _distribution = distribution;
            _distributionTotal = distributionTotal;
        }

        protected MoneyAllocationException(SerializationInfo info,
                                           StreamingContext context)
            : base(info, context)
        {
            _amountToDistribute = (Money)info.GetValue("_amountToDistribute",
                                                       typeof(Money));
            _distributionTotal = (Money)info.GetValue("_distributionTotal",
                                                      typeof(Money));
            _distribution = (Decimal[])info.GetValue("_distribution",
                                                     typeof(Decimal[]));
        }

        public Decimal[] Distribution
        {
            get { return _distribution; }
        }

        public Money DistributionTotal
        {
            get { return _distributionTotal; }
        }

        public Money AmountToDistribute
        {
            get { return _amountToDistribute; }
        }
    }
}
