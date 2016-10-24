using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ProjectFirma.Web.Views.ProjectImage
{
    public class NewViewData
    {
        public readonly Models.Project Project;
        public readonly string SupportedFileExtensionsCommaSeparated;
        public readonly List<string> SupportedFileExtensions;
        public readonly IEnumerable<SelectListItem> ProjectImageTimings;

        public NewViewData(Models.Project project, IEnumerable<SelectListItem> projectImageTimings)
        {
            Project = project;
            ProjectImageTimings = projectImageTimings;
            SupportedFileExtensions = new List<string> {"jpg", "png", "gif", "tiff", "bmp"};
            SupportedFileExtensionsCommaSeparated = string.Join(", ", SupportedFileExtensions.OrderBy(x => x));
        }
    }
}