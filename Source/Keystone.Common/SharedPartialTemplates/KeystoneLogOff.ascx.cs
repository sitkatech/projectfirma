
// ReSharper disable once CheckNamespace
namespace Keystone.Common.Web.Views.KeystoneCommon
{
    public class KeystoneLogOff : System.Web.Mvc.ViewUserControl<KeystoneLogOffModel>
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