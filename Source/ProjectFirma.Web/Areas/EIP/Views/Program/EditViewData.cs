using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Views;

namespace ProjectFirma.Web.Areas.EIP.Views.Program
{
    public class EditViewData : LakeTahoeInfoUserControlViewData
    {
        public readonly IEnumerable<SelectListItem> FocusAreas;
        public readonly string FocusAreaDisplayName;
        public readonly bool HasProjects;
        public readonly HtmlString AssociatedProgramsHtmlString;
        public readonly CkEditorExtension.CkEditorToolbar CkEditorToolbar;

        public EditViewData(IEnumerable<SelectListItem> focusAreas, string focusAreaDisplayName, bool hasProjects, HtmlString associatedProgramsHtmlString, CkEditorExtension.CkEditorToolbar ckEditorToolbar)
        {
            FocusAreas = focusAreas;
            FocusAreaDisplayName = focusAreaDisplayName;
            HasProjects = hasProjects;
            AssociatedProgramsHtmlString = associatedProgramsHtmlString;
            CkEditorToolbar = ckEditorToolbar;
        }
    }
}