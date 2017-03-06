/*-----------------------------------------------------------------------
<copyright file="HtmlDiffContainer.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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
using System.Text.RegularExpressions;

namespace ProjectFirma.Web.Views.Shared
{
    public class HtmlDiffContainer
    {
        private static readonly Regex CheckForInsertsOrDeletesRegEx =
            new Regex(String.Format(@"class=""{0}""|class=""{1}""|col style=""background-color: {2}""|col style=""background-color: {3}""",
                DisplayCssClassAddedElement,
                DisplayCssClassDeletedElement,
                BackgroundColorForAddedElement,
                BackgroundColorForDeletedElement), RegexOptions.Compiled | RegexOptions.Multiline);

        public readonly string OriginalHtml;
        public readonly string UpdatedHtml;
        public bool HasChanged
        {
            get { return OriginalHtml != UpdatedHtml || CheckForInsertsOrDeletesRegEx.IsMatch(UpdatedHtml); }
        }

        public HtmlDiffContainer(string originalHtml, string updatedHtml)
        {
            OriginalHtml = originalHtml;
            UpdatedHtml = updatedHtml;
        }

        public const string BackgroundColorForAddedElement = "#cfc";
        public const string BackgroundColorForDeletedElement = "#FEC8C8";
        public const string DisplayCssClassDeletedElement = "deleted-element";
        public const string DisplayCssClassAddedElement = "added-element";
    }
}
