using System.Collections.Generic;
using System.Web;
using LtInfo.Common.BootstrapWrappers;

namespace ProjectFirma.Web.Models
{
    public static class ProjectWizardComponents
    {
        public static readonly HtmlString RequiredInfoNotProvidedIcon = BootstrapHtmlHelpers.MakeGlyphIcon("glyphicon-warning-sign red",
            "Required information has not been completely provided (not ready to submit)");
        public static readonly HtmlString RequiredInfoOkSubmitReadyIcon = BootstrapHtmlHelpers.MakeGlyphIcon("glyphicon-ok black", "Required information has been provided (ready to submit)");
        public static readonly HtmlString SectionHasUpdatesIcon = BootstrapHtmlHelpers.MakeGlyphIcon("glyphicon-flag", "This section has been updated");

        public static HtmlString MakeDisabledSectionLink(string sectionLabel)
        {
            return BootstrapHtmlHelpers.MakeModalDialogAlertLink(string.Format("Unable to edit {0} until Basics are complete", sectionLabel),
                string.Format("Unable to edit section {0}", sectionLabel),
                "Close",
                sectionLabel,
                new List<string>{"disabledSection"});
        }
    }
}