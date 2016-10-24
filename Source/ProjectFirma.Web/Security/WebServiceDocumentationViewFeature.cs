using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Can View Web Services")]
    public class WebServiceDocumentationViewFeature : EIPFeature
    {
        public WebServiceDocumentationViewFeature() : base(EIPRole.All) { }
    }
}