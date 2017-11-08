/*-----------------------------------------------------------------------
<copyright file="FirmaEnvironment.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
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
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Common
{
    /// <summary>
    ///     Encapsulates Project Firma Environmental specific differences
    /// </summary>
    public abstract class FirmaEnvironment
    {
        public abstract bool IsUnitTestWebServiceTokenOkInThisEnvironment { get; }
        public abstract FirmaEnvironmentType FirmaEnvironmentType { get; }

        public abstract string DomainPrefix { get; }

        public string GetCanonicalHostNameForEnvironment(Tenant tenant)
        {
            var separator = ".";
            if (tenant.IsSubDomain)
            {
                separator = "-";
            }
            return $"{DomainPrefix}{separator}{tenant.TenantDomain}";
        }

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
            // OK in local because this is where we run unit tests
            public override bool IsUnitTestWebServiceTokenOkInThisEnvironment => true;

            public override FirmaEnvironmentType FirmaEnvironmentType => FirmaEnvironmentType.Local;
            public override string DomainPrefix => "localhost";
        }

        private class FirmaEnvironmentProd : FirmaEnvironment
        {
            // Definitely not OK in Prod, no unit testing here would be a security hole
            public override bool IsUnitTestWebServiceTokenOkInThisEnvironment => false;

            public override FirmaEnvironmentType FirmaEnvironmentType => FirmaEnvironmentType.Prod;
            public override string DomainPrefix => "www";
        }

        private class FirmaEnvironmentQa : FirmaEnvironment
        {
            // Not OK in QA, no unit testing here
            public override bool IsUnitTestWebServiceTokenOkInThisEnvironment => true;

            public override FirmaEnvironmentType FirmaEnvironmentType => FirmaEnvironmentType.Qa;
            public override string DomainPrefix => "qa";
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
