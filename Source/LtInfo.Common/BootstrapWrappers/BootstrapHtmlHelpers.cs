using System.Collections.Generic;
using System.Web;

namespace LtInfo.Common.BootstrapWrappers
{
    public static class BootstrapHtmlHelpers
    {
        public static HtmlString MakeGlyphIcon(string glyphIconName)
        {
            return new HtmlString(string.Format("<span class=\"glyphicon {0}\"></span>", glyphIconName));
        }

        public static HtmlString MakeGlyphIconWithHiddenText(string glyphIconName, string text)
        {
            return new HtmlString(string.Format("<span class=\"glyphicon {0}\"></span><span style='display:none'>{1}</span>", glyphIconName, text));
        }

        public static HtmlString MakeGlyphIcon(string glyphIconName, string title)
        {
            return new HtmlString(string.Format("<span title=\"{0}\" class=\"glyphicon {1}\"></span>", title, glyphIconName));
        }

        //TODO: This is fragile when quotes or apostrophes are passed in to any of the string parameters.
        public static HtmlString MakeModalDialogAlertButton(string alertText, string alertTitle, string closeButtonText, string linkText, List<string> cssClasses)
        {
            if (cssClasses == null)
                cssClasses = new List<string>();

            cssClasses.Add("btn");
            return MakeModalDialogAlertLink(alertText, alertTitle, closeButtonText, linkText, cssClasses);
        }

        public static HtmlString MakeModalDialogAlertLink(string alertText, string alertTitle, string closeButtonText, string linkText, List<string> cssClasses)
        {
            return
                new HtmlString(string.Format("<a href=\"javascript:void(0)\" class=\"{0}\" onclick=\"createBootstrapAlert({1}, {2}, {3})\">{4}</a>",
                    string.Join(" ", cssClasses),
                    alertText.ToHTMLFormattedString().ToString().ToJS(),
                    alertTitle.ToHTMLFormattedString().ToString().ToJS(),
                    closeButtonText.ToHTMLFormattedString().ToString().ToJS(),
                    linkText.ToHTMLFormattedString()));
        }

        public static HtmlString MakeModalDialogAlertLinkFromUrl(string url, string alertTitle, string closeButtonText, string linkText, List<string> cssClasses, string onJavascriptReadyFunction)
        {
            var javascripReadyFunctionAsParameter = !string.IsNullOrWhiteSpace(onJavascriptReadyFunction) ? string.Format("function() {{{0}();}}", onJavascriptReadyFunction) : "null";
            return
                new HtmlString(string.Format("<a href=\"{0}\" class=\"{1}\" onclick=\"return createBootstrapAlertFromUrl(this, {2}, {3}, {4});\">{5}</a>",
                    url,
                    string.Join(" ", cssClasses),
                    alertTitle.ToHTMLFormattedString().ToString().ToJS(),
                    closeButtonText.ToHTMLFormattedString().ToString().ToJS(),
                    javascripReadyFunctionAsParameter,
                    linkText.ToHTMLFormattedString()));
        }

    }
}