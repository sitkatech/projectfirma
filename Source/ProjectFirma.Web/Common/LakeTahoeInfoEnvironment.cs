using System;
using LtInfo.Common;

namespace ProjectFirma.Web.Common
{
    /// <summary>
    ///     Encapsulates LakeTahoeInfo Environmental specific differences
    /// </summary>
    public abstract class LakeTahoeInfoEnvironment
    {
        public abstract bool IsUnitTestWebServiceTokenOkInThisEnvironment { get; }
        public abstract LakeTahoeInfoEnvironmentType LakeTahoeInfoEnvironmentType { get; }

        public static LakeTahoeInfoEnvironment MakeLakeTahoeInfoEnvironment(string lakeTahoeInfoEnvironmentSetting)
        {
            var lakeTahoeInfoEnvironment = lakeTahoeInfoEnvironmentSetting.ParseAsEnum<LakeTahoeInfoEnvironmentType>();
            switch (lakeTahoeInfoEnvironment)
            {
                case LakeTahoeInfoEnvironmentType.Local:
                    return new LakeTahoeInfoEnvironmentLocal();
                case LakeTahoeInfoEnvironmentType.Qa:
                    return new LakeTahoeInfoEnvironmentQa();
                case LakeTahoeInfoEnvironmentType.Prod:
                    return new LakeTahoeInfoEnvironmentProd();
                default:
                    throw new ArgumentOutOfRangeException(string.Format("Unknown {0} {1}", typeof(LakeTahoeInfoEnvironmentType).Name, lakeTahoeInfoEnvironment));
            }
        }

        private class LakeTahoeInfoEnvironmentLocal : LakeTahoeInfoEnvironment
        {
            public override bool IsUnitTestWebServiceTokenOkInThisEnvironment
            {
                get
                {
                    // OK in local because this is where we run unit tests
                    return true;
                }
            }

            public override LakeTahoeInfoEnvironmentType LakeTahoeInfoEnvironmentType
            {
                get { return LakeTahoeInfoEnvironmentType.Local; }
            }
        }

        private class LakeTahoeInfoEnvironmentProd : LakeTahoeInfoEnvironment
        {
            public override bool IsUnitTestWebServiceTokenOkInThisEnvironment
            {
                get
                {
                    // Definitely not OK in Prod, no unit testing here would be a security hole
                    return false;
                }
            }

            public override LakeTahoeInfoEnvironmentType LakeTahoeInfoEnvironmentType
            {
                get { return LakeTahoeInfoEnvironmentType.Prod; }
            }
        }

        private class LakeTahoeInfoEnvironmentQa : LakeTahoeInfoEnvironment
        {
            public override bool IsUnitTestWebServiceTokenOkInThisEnvironment
            {
                get
                {
                    // Not OK in QA, no unit testing here
                    return true;
                }
            }

            public override LakeTahoeInfoEnvironmentType LakeTahoeInfoEnvironmentType
            {
                get { return LakeTahoeInfoEnvironmentType.Qa; }
            }
        }
    }


    /// <summary>
    ///     Type enum for the environment name
    /// </summary>
    public enum LakeTahoeInfoEnvironmentType
    {
        Local,
        Qa,
        Prod
    }
}