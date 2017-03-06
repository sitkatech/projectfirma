/*-----------------------------------------------------------------------
<copyright file="FirmaMathUtilities.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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

namespace ProjectFirma.Web.Common
{
    public static class FirmaMathUtilities
    {
        /// <summary>
        /// Raises b to the power of n. Wraps the double-only function Math.Pow for decimal inputs and output.
        /// </summary>
        
        public static decimal Pow(this decimal b, decimal n)
        {
            return Convert.ToDecimal(Math.Pow(Convert.ToDouble(b), Convert.ToDouble(n)));
        }

        /// <summary>
        /// Calculation for the future value of a present sum as described at <see cref="https://en.wikipedia.org/wiki/Time_value_of_money#Future_value_of_a_present_sum"/>
        /// </summary>
        /// <param name="pv">The value at time = 0 (present value)</param>
        /// <param name="i">The interest rate at which the amount compounds each period</param>
        /// <param name="currentYear">The year represent time = 0</param>
        /// <param name="futureYear">The year at time = n</param>
        /// <returns>The future value FV of PV</returns>
        public static decimal FutureValueOfPresentSum(decimal pv, decimal i, int currentYear, int futureYear)
        {
            return FutureValueOfPresentSum(pv, i, futureYear - currentYear);
        }

        /// <summary>
        /// Calculation for the future value of a present sum as described at <see cref="https://en.wikipedia.org/wiki/Time_value_of_money#Future_value_of_a_present_sum"/>
        /// </summary>
        /// <param name="pv">The value at time = 0 (present value)</param>
        /// <param name="i">The interest rate at which the amount compounds each period</param>
        /// <param name="n">The number of periods</param>
        /// <returns>The future value FV of PV</returns>
        public static decimal FutureValueOfPresentSum(decimal pv, decimal i, int n)
        {
            return pv * (1 + i).Pow(n);
        }
    }
}
