/*-----------------------------------------------------------------------
<copyright file="ProjectWizardComponents.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
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

        public static HtmlString MakeDisabledSectionLinkForApprovedAndRejectedProjects(string sectionLabel)
        {
            return BootstrapHtmlHelpers.MakeModalDialogAlertLink("Unable to edit project through this wizard.",
                string.Format("Unable to edit section {0}", sectionLabel),
                "Close",
                sectionLabel,
                new List<string> { "disabledSection" });
        }
    }
}
