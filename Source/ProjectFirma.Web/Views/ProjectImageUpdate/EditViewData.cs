using System.Collections.Generic;
using System.Web.Mvc;
using ProjectFirma.Web.Views;

namespace ProjectFirma.Web.Views.ProjectImageUpdate
{
    public class EditViewData : LakeTahoeInfoUserControlViewData
    {
        public readonly Models.ProjectImageUpdate ProjectImageUpdate;
        public readonly IEnumerable<SelectListItem> ProjectImageTimings;

        public EditViewData(Models.ProjectImageUpdate projectImageUpdate, IEnumerable<SelectListItem> projectImageTimings)
        {
            ProjectImageUpdate = projectImageUpdate;
            ProjectImageTimings = projectImageTimings;
        }
    }
}