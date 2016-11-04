using System.Text.RegularExpressions;

namespace LtInfo.Common
{
    public static class SitkaRegexLibrary
    {
        public static readonly Regex HttpLink = new Regex(@"\b((https?|ftp|file)://[-A-Z0-9+&@#/%?=~_|$!:,.;]*[A-Z0-9+&@#/%=~_|$])", RegexOptions.IgnoreCase);
    }
}