/*-----------------------------------------------------------------------
<copyright file="CommonUtility.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
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
