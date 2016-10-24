using System;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.WebServices
{
    public class IndexViewData : EIPViewData
    {
        public readonly Guid? WebServiceAccessToken;
        public readonly string WebServicesListUrl;
        public readonly string GetWebServiceAccessTokenUrl;

        public IndexViewData(Person currentPerson, Guid? webServiceAccessToken, string webServicesListUrl, string getWebServiceAccessTokenUrl) : base(currentPerson)
        {
            WebServiceAccessToken = webServiceAccessToken;
            PageTitle = "Web Services";
            WebServicesListUrl = webServicesListUrl;
            GetWebServiceAccessTokenUrl = getWebServiceAccessTokenUrl;
        }
    }
}