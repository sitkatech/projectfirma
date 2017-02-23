/*-----------------------------------------------------------------------
<copyright file="DownloadFileDescriptor.cs" company="Sitka Technology Group">
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
using System.Text.RegularExpressions;
using LtInfo.Common.DesignByContract;

namespace LtInfo.Common.Views
{
    /// <summary>
    /// Provides a consistent naming style for downloaded files and removes any characters that could cause inconsistent name on download
    /// </summary>
    public class DownloadFileDescriptor
    {
        private DownloadFileDescriptor()
        {
            Descriptor1 = String.Empty;
            Descriptor2 = String.Empty;
        }

        public DownloadFileDescriptor(string prefix) : this()
        {
            Prefix = prefix;
            CheckPrefixValid();
        }

        public DownloadFileDescriptor(string prefix, string descriptor1) : this()
        {
            Prefix = prefix;
            Descriptor1 = descriptor1 ?? String.Empty;
            CheckPrefixValid();
        }

        public DownloadFileDescriptor(string prefix, string descriptor1, string descriptor2) : this()
        {
            Prefix = prefix;
            Descriptor1 = descriptor1 ?? String.Empty;
            Descriptor2 = descriptor2 ?? String.Empty;
            CheckPrefixValid();
        }

        public string Prefix { get; private set; }
        public string Descriptor1 { get; private set; }
        public string Descriptor2 { get; private set; }
        public string MimeType { get { return Common.MimeType.TextCsv; } }

        private void CheckPrefixValid()
        {
            Check.RequireNotNullNotEmptyNotWhitespace(Prefix, "Need at least a prefix to create a name");
        }

        private static string FormatDescriptor(string input)
        {
            if (GeneralUtility.IsNullOrEmptyOrOnlyWhitespace(input))
            {
                return String.Empty;
            }
            return string.Format("-{0}", RemoveFunnyCharacters(input));
        }

        /// <summary>
        /// Strips out characters that could result in inconsistent name on file download
        /// </summary>
        private static string RemoveFunnyCharacters(string s)
        {
            const string charactersThatCouldResultInInconsistentName = "\\\"',&;/:*?<>| \t\r\n\f";
            string pattern = "[" + Regex.Escape(charactersThatCouldResultInInconsistentName) + "]";
            return Regex.Replace(s, pattern, String.Empty);
        }

        /// <summary>
        /// Pulls together the pieces for a consistent filename for the download prompt
        /// </summary>
        public string ToStandardizedCsvDownloadFilename()
        {
            string filename = string.Format("{0}{1}{2}.csv",
                                            RemoveFunnyCharacters(Prefix),
                                            FormatDescriptor(Descriptor1), FormatDescriptor(Descriptor2));
            return filename;
        }
    }
}
