using System.Collections.Generic;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Areas.EIP.Views.Shared.ProjectLocationControls
{
    public class ProjectLocationDetailViewModel : FormViewModel
    {
        public List<WktAndAnnotation> WktAndAnnotations { get; set; }
    }

    public class WktAndAnnotation
    {
        public string Wkt { get; set; }
        public string Annotation { get; set; }
    }
}