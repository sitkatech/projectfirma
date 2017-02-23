/*-----------------------------------------------------------------------
<copyright file="ConnectionString.cs" company="Sitka Technology Group">
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
