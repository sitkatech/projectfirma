/*-----------------------------------------------------------------------
<copyright file="ListViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;
using LtInfo.Common.DesignByContract;

namespace ProjectFirma.Web.Views.WebServices
{
    public class ListViewData : FirmaViewData
    {
        public readonly WebServiceToken UserWebServiceAccessToken;
        public readonly List<WebServiceDocumentation> ServiceDocumentationList;
        public readonly List<GeospatialAreaType> GeospatialAreaTypeList;
        public readonly List<GeoServerServiceDocumentation> GeoServerServiceDocumentationList;

        public ListViewData(FirmaSession currentFirmaSession, WebServiceToken userWebServiceAccessToken,
            List<WebServiceDocumentation> serviceDocumentationList, List<GeospatialAreaType> geospatialAreaTypeList, ProjectFirmaModels.Models.FirmaPage firmaPage)
            : base(currentFirmaSession, firmaPage)
        {
            ServiceDocumentationList = serviceDocumentationList;
            UserWebServiceAccessToken = userWebServiceAccessToken;
            PageTitle = "List of Web Services";
            GeospatialAreaTypeList = geospatialAreaTypeList;
            GeoServerServiceDocumentationList = new List<GeoServerServiceDocumentation>
            {
                new GeoServerServiceDocumentation("WFS 1.1.0",
                    "Provides project simple locations, project detailed locations, and geospatial area features in vector format and can be consumed or added to geospatial applications such as ArcGIS or QGIS.",
                    "wfs"),
                new GeoServerServiceDocumentation("WMS 1.1.0",
                    "Provides project simple locations, project detailed locations, and geospatial area features and can be consumed or added to geospatial applications such as ArcGIS or QGIS.",
                    "wms")
                
            };
        }
    }

    public class GeoServerServiceDocumentation
    {
        public string ServiceName;
        public string ServiceDescription;
        public string ServiceUrl;

        public GeoServerServiceDocumentation(string serviceName, string serviceDescription, string geoServerServiceEndpoint)
        {
            ServiceName = serviceName;
            ServiceDescription = serviceDescription;
            var geoServerNamespace = MultiTenantHelpers.GetTenantAttribute().GeoServerNamespace;
            var geoServerUrl = FirmaWebConfiguration.GeoServerUrl;
            ServiceUrl = $"{geoServerUrl}{geoServerNamespace}/{geoServerServiceEndpoint}";
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

            return _exampleCsvUrl.Replace(WebServiceToken.WebServiceTokenGuidForParameterizedReplacement.ToString(), userToken.ToString());
        }

        public string GetExampleJsonUrl(WebServiceToken userToken)
        {
            if (String.IsNullOrEmpty(_exampleJsonUrl))
            {
                return String.Empty;
            }

            return _exampleJsonUrl.Replace(WebServiceToken.WebServiceTokenGuidForParameterizedReplacement.ToString(), userToken.ToString());
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
            var webServiceRouteMap = Service.WebServices.GetWebServiceRouteMap();

            var csvRouteMap = webServiceRouteMap.FirstOrDefault(x => x.MethodName == methodInfo.Name && x.WebServiceReturnTypeEnum == WebServicesController.WebServiceReturnTypeEnum.CSV);
            if (csvRouteMap != null)
            {
                _exampleCsvUrl = csvRouteMap.Route.BuildUrlFromExpression();
                if (_parameters == null)
                {
                    _parameters = csvRouteMap.Parameters;
                }
            }
            var jsonRouteMap = webServiceRouteMap.FirstOrDefault(x => x.MethodName == methodInfo.Name && x.WebServiceReturnTypeEnum == WebServicesController.WebServiceReturnTypeEnum.JSON);
            if (jsonRouteMap != null)
            {
                _exampleJsonUrl = jsonRouteMap.Route.BuildUrlFromExpression();
                if (_parameters == null)
                {
                    _parameters = jsonRouteMap.Parameters;
                }
            }
        }
    }    
}
