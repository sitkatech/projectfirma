using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using LtInfo.Common.DesignByContract;

namespace ProjectFirma.Web.Views.WebServices
{
    public class ListViewData : FirmaViewData
    {
        public readonly WebServiceToken WebServiceAccessToken;
        public readonly List<WebServiceDocumentation> ServiceDocumentationList;

        public ListViewData(Person currentPerson, WebServiceToken webServiceAccessToken, List<WebServiceDocumentation> serviceDocumentationList)
            : base(currentPerson)
        {
            ServiceDocumentationList = serviceDocumentationList;
            WebServiceAccessToken = webServiceAccessToken;
            PageTitle = "List of Web Services";
        }
    }

    public class WebServiceDocumentation
    {
        public string Name;
        private readonly string _exampleCsvUrl;
        private readonly string _exampleJsonUrl;
        private readonly List<string> _parameters;
        public string Documentation;

        public string GetExampleCsvUrl(WebServiceToken userToken)
        {
            if (String.IsNullOrEmpty(_exampleCsvUrl))
            {
                return String.Empty;
            }

            return _exampleCsvUrl.Replace(WebServiceToken.WebServiceTokenGuidForUnitTests.ToString(), userToken.ToString());
        }

        public string GetExampleJsonUrl(WebServiceToken userToken)
        {
            if (String.IsNullOrEmpty(_exampleJsonUrl))
            {
                return String.Empty;
            }

            return _exampleJsonUrl.Replace(WebServiceToken.WebServiceTokenGuidForUnitTests.ToString(), userToken.ToString());
        }

        public string GetParameters(WebServiceToken userToken)
        {
            if (!_parameters.Any())
            {
                return String.Empty;
            }

            return string.Join(", ", _parameters);
        }

        public WebServiceDocumentation(MethodInfo methodInfo)
        {
            var attribs = methodInfo.GetCustomAttributes(typeof(WebServiceDocumentationAttribute), false);
            Check.Require(attribs.Length == 1, "Expected 1 and only 1 WebServiceDocumentation attribute on found Web Methods.");

            var attrib = (WebServiceDocumentationAttribute)attribs[0];

            Documentation = attrib.Documentation;
            Name = methodInfo.Name;

            //TODO-MB: This should use a Route Template so that there's not one entry per ReturnType (this would also avert the repetition of _parameters assignment)

            var csvRouteMap = Service.WebServices.WebServiceRouteMap.FirstOrDefault(x => x.MethodName == methodInfo.Name && x.WebServiceReturnTypeEnum == WebServicesController.WebServiceReturnTypeEnum.CSV);
            if (csvRouteMap != null)
            {
                _exampleCsvUrl = csvRouteMap.Route.BuildUrlFromExpression();
                if (_parameters == null)
                {
                    _parameters = csvRouteMap.Parameters;
                }
            }

            var jsonRouteMap = Service.WebServices.WebServiceRouteMap.FirstOrDefault(x => x.MethodName == methodInfo.Name && x.WebServiceReturnTypeEnum == WebServicesController.WebServiceReturnTypeEnum.JSON);
            if (jsonRouteMap != null)
            {
                _exampleJsonUrl = jsonRouteMap.Route.BuildUrlFromExpression();
                if (_parameters == null)
                {
                    _parameters = csvRouteMap.Parameters;
                }
            }
        }
    }    
}