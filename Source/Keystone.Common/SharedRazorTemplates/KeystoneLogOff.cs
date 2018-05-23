using EM.Common.Web;

namespace Obmep.Web.Views.KeystoneCommon
{
    public abstract class KeystoneLogOff : TypedPartialView<KeystoneLogOffModel>
    {
    }

    public class KeystoneLogOffModel
    {

        public KeystoneLogOffModel(string logoffUrl, string applicationName, string keystoneAboutUrl)
        {
            LogoffUrl = logoffUrl;
            ApplicationName = applicationName;
            KeystoneAboutUrl = keystoneAboutUrl;
        }

        public string KeystoneAboutUrl { get; private set; }
        public string LogoffUrl { get; private set; }
        public string ApplicationName { get; private set; }
    }
}