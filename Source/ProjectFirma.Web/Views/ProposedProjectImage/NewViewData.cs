using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ProjectFirma.Web.Views.ProposedProjectImage
{
    public class NewViewData
    {
        public readonly Models.ProposedProject ProposedProject;
        public readonly string SupportedFileExtensionsCommaSeparated;
        public readonly List<string> SupportedFileExtensions;

        public NewViewData(Models.ProposedProject proposedProject)
        {
            ProposedProject = proposedProject;
            SupportedFileExtensions = new List<string> {"jpg", "png", "gif", "tiff", "bmp"};
            SupportedFileExtensionsCommaSeparated = string.Join(", ", SupportedFileExtensions.OrderBy(x => x));
        }
    }
}