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