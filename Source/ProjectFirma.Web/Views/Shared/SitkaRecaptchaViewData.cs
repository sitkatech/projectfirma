using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.Shared
{
    public class SitkaRecaptchaViewData
    {
        public SitkaRecaptchaViewData()
        {
            RecaptchaPublicKey = ProjectFirmaWebConfiguration.RecaptchaPublicKey;
            Theme = "clean";
        }

        public readonly string RecaptchaPublicKey;
        public readonly string Theme;
    }
}