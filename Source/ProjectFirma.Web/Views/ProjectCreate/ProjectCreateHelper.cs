/*-----------------------------------------------------------------------
<copyright file="ProjectCreateHelper.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using LtInfo.Common.ModalDialog;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;

namespace ProjectFirma.Web.Views.ProjectCreate
{
    public class ProjectCreateHelper
    {
        private static readonly string ProjectTypeSelectionUrl =
            SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.ProjectTypeSelection());

        private static readonly string AddNewProjectButtonText =
            $"{BootstrapHtmlHelpers.MakeGlyphIcon("glyphicon-plus")} Add Project";

        private static readonly string ProjectTypeSelectionContinueButtonText =
            $"Continue {BootstrapHtmlHelpers.MakeGlyphIcon("glyphicon-chevron-right")}";

        public static HtmlString AddProjectButton()
        {
            return ModalDialogFormHelper.ModalDialogFormLink(AddNewProjectButtonText, ProjectTypeSelectionUrl,
                "Add a project", 700, ProjectTypeSelectionContinueButtonText, "Cancel",
                new List<string> {"btn", "btn-firma"}, null, null);
        }
    }
}