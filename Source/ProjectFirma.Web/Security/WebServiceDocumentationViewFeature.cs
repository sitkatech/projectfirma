using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Can View Web Services")]
    public class WebServiceDocumentationViewFeature : LakeTahoeInfoFeature
    {
        public WebServiceDocumentationViewFeature() : base(LTInfoRole.All) { }
    }
}