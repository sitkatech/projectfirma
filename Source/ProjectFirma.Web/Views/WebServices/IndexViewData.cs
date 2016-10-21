using System;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared;

namespace ProjectFirma.Web.Views.WebServices
{
    public class IndexViewData : SiteLayoutViewData
    {
        public readonly Guid? WebServiceAccessToken;
        public readonly string WebServicesListUrl;
        public readonly string GetWebServiceAccessTokenUrl;

        public IndexViewData(Person currentPerson, Guid? webServiceAccessToken, string webServicesListUrl, string getWebServiceAccessTokenUrl) : base(currentPerson, false)
        {
            WebServiceAccessToken = webServiceAccessToken;
            PageTitle = "Web Services";
            WebServicesListUrl = webServicesListUrl;
            GetWebServiceAccessTokenUrl = getWebServiceAccessTokenUrl;
        }
    }
}