using System.Collections.Generic;
using System.Web.Mvc;
using ProjectFirma.Web.Views;

namespace ProjectFirma.Web.Views.ProjectImage
{
    public class EditViewData : FirmaUserControlViewData
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