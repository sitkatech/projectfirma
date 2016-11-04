using System;
using System.Reflection;

namespace LtInfo.Common
{
    public class VersionInformation
    {
        private readonly DateTime _dateCompiled;
        private readonly Version _version;

        public VersionInformation(Assembly assemblyToDeriveInfoFrom)
        {
            _version = assemblyToDeriveInfoFrom.GetName().Version;
            _dateCompiled = GeneralUtility.GetExecutingAssemblyFile().LastWriteTime;
        }

        public Version Version
        {
            get { return _version; }
        }

        public DateTime DateCompiled
        {
            get { return _dateCompiled; }
        }
    }
}