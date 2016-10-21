using System.Collections.Generic;
using System.Web.Mvc;
using ProjectFirma.Web.Views;

namespace ProjectFirma.Web.Areas.EIP.Views.ProjectImage
{
    public class EditViewData : LakeTahoeInfoUserControlViewData
    {
        public readonly Models.ProjectImage ProjectImage;
        public readonly IEnumerable<SelectListItem> ProjectImageTimings;

        public EditViewData(Models.ProjectImage projectImage, IEnumerable<SelectListItem> projectImageTimings)
        {
            ProjectImage = projectImage;
            ProjectImageTimings = projectImageTimings;
        }
    }
}