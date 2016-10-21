using System;
using System.Text.RegularExpressions;

namespace ProjectFirma.Web.Areas.EIP.Views.Shared
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