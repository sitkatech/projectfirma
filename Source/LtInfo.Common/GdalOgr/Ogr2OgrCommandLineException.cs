using System;

namespace LtInfo.Common.GdalOgr
{
    /// <summary>
    /// Anything that comes out of <see cref="Ogr2OgrCommandLineRunner"/>
    /// </summary>
    public class Ogr2OgrCommandLineException : ApplicationException
    {
        public Ogr2OgrCommandLineException(string errorMessage) : base(errorMessage) {}
    }
}