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