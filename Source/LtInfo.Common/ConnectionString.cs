using System;
using System.IO;
using System.Xml.Serialization;
using LtInfo.Common.DesignByContract;

namespace LtInfo.Common
{
    [Serializable]
    public class ConnectionString
    {
        protected string clearTextConnection;

        [XmlAttribute]
        public string keyfile;

        [XmlAttribute]
        public string connect;

        public override string ToString()
        {
            if (clearTextConnection != null)
                return clearTextConnection;

            if (!String.IsNullOrEmpty(keyfile))
            {
                // the keyfile in the .config file is relative to where the assembly is executing
                var thisAssemblyDirectory = GeneralUtility.GetExecutingAssemblyDirectory();
                var keyFileInfo = new FileInfo(Path.Combine(thisAssemblyDirectory.FullName, keyfile));
                Check.RequireFileExists(keyFileInfo, string.Format("Could keyfile=\"{0}\" not found (looked in path {1}) as specified in configuration element {2}. Check config file and filesystem.", keyfile, keyFileInfo.FullName, GetType().Name));
                var crypto = Encryptor.Instance(keyFileInfo);
                clearTextConnection = crypto.Decrypt(connect);
            }
            else
            {
                // no keyfile must mean that the connect string is not munged
                clearTextConnection = connect;
            }

            return clearTextConnection;
        }
    }
}