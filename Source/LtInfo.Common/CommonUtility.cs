using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace LtInfo.Common
{
    public static class CommonUtility
    {
        public static string IndentLinesInStringByAmount(string linesToIndent, uint indentLevel, string indentToken)
        {
            if (linesToIndent == null)
            {
                return null;
            }
            if (linesToIndent == String.Empty)
            {
                return String.Empty;
            }
            if (indentLevel == 0 || String.IsNullOrEmpty(indentToken))
            {
                return linesToIndent;
            }

            var indentString = String.Empty;
            for (var i = 0; i < indentLevel; i++)
            {
                indentString += indentToken;
            }

            var lineMatches = Regex.Matches(linesToIndent, "[^\r\n]+([\r\n]+)?");
            var newLines = lineMatches.Cast<Match>().Select(x => indentString + x.Value);
            var newText = String.Join(String.Empty, newLines);
            return newText;
        }

        public static IEnumerable<Tuple<int, int>> ToContiguousRanges(this HashSet<int> nums)
        {
            return nums.Where(n => !nums.Contains(n - 1)).Zip(nums.Where(n => !nums.Contains(n + 1)), Tuple.Create);
        }
    }
}
