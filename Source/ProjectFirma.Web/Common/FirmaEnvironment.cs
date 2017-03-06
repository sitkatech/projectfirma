/*-----------------------------------------------------------------------
<copyright file="FirmaEnvironment.cs" company="Tahoe Regional Planning Agency">
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
using LtInfo.Common;

namespace ProjectFirma.Web.Common
{
    /// <summary>
    ///     Encapsulates Project Firma Environmental specific differences
    /// </summary>
    public abstract class FirmaEnvironment
    {
        public abstract bool IsUnitTestWebServiceTokenOkInThisEnvironment { get; }
        public abstract FirmaEnvironmentType FirmaEnvironmentType { get; }

        public static FirmaEnvironment MakeFirmaEnvironment(string firmaEnvironmentSetting)
        {
            var firmaEnvironmentType = firmaEnvironmentSetting.ParseAsEnum<FirmaEnvironmentType>();
            switch (firmaEnvironmentType)
            {
                case FirmaEnvironmentType.Local:
                    return new FirmaEnvironmentLocal();
                case FirmaEnvironmentType.Qa:
                    return new FirmaEnvironmentQa();
                case FirmaEnvironmentType.Prod:
                    return new FirmaEnvironmentProd();
                default:
                    throw new ArgumentOutOfRangeException(string.Format("Unknown {0} {1}", typeof(FirmaEnvironmentType).Name, firmaEnvironmentType));
            }
        }

        private class FirmaEnvironmentLocal : FirmaEnvironment
        {
            public override bool IsUnitTestWebServiceTokenOkInThisEnvironment
            {
                get
                {
                    // OK in local because this is where we run unit tests
                    return true;
                }
            }

            public override FirmaEnvironmentType FirmaEnvironmentType
            {
                get { return FirmaEnvironmentType.Local; }
            }
        }

        private class FirmaEnvironmentProd : FirmaEnvironment
        {
            public override bool IsUnitTestWebServiceTokenOkInThisEnvironment
            {
                get
                {
                    // Definitely not OK in Prod, no unit testing here would be a security hole
                    return false;
                }
            }

            public override FirmaEnvironmentType FirmaEnvironmentType
            {
                get { return FirmaEnvironmentType.Prod; }
            }
        }

        private class FirmaEnvironmentQa : FirmaEnvironment
        {
            public override bool IsUnitTestWebServiceTokenOkInThisEnvironment
            {
                get
                {
                    // Not OK in QA, no unit testing here
                    return true;
                }
            }

            public override FirmaEnvironmentType FirmaEnvironmentType
            {
                get { return FirmaEnvironmentType.Qa; }
            }
        }
    }


    /// <summary>
    ///     Type enum for the environment name
    /// </summary>
    public enum FirmaEnvironmentType
    {
        Local,
        Qa,
        Prod
    }
}
