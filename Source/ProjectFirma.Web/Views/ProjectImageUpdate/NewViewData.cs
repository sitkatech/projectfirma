using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ProjectFirma.Web.Views.ProjectImageUpdate
{
    public class NewViewData
    {
        public readonly Models.ProjectUpdateBatch ProjectUpdateBatch;
        public readonly string SupportedFileExtensionsCommaSeparated;
        public readonly List<string> SupportedFileExtensions;
        public readonly IEnumerable<SelectListItem> ProjectImageTimings;

        public NewViewData(Models.ProjectUpdateBatch projectUpdateBatch, IEnumerable<SelectListItem> projectImageTimings)
        {
            ProjectUpdateBatch = projectUpdateBatch;
            ProjectImageTimings = projectImageTimings;
            SupportedFileExtensions = new List<string> {"jpg", "png", "gif", "tiff", "bmp"};
            SupportedFileExtensionsCommaSeparated = string.Join(", ", SupportedFileExtensions.OrderBy(x => x));
        }
    }
}