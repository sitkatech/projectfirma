using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Can View Web Services")]
    public class WebServiceDocumentationViewFeature : FirmaFeature
    {
        public WebServiceDocumentationViewFeature() : base(Role.All) { }
    }
}