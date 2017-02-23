/*-----------------------------------------------------------------------
<copyright file="WebServices.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
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
using System.Linq.Expressions;
using System.ServiceModel;
using System.ServiceModel.Activation;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Service.ServiceModels;
using LtInfo.Common;

namespace ProjectFirma.Web.Service
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class WebServices : IWebServices
    {
        private static T CommandWrapper<T>(string allegedWebServiceTokenString, Func<T> func)
        {
            return CommandWrapper(allegedWebServiceTokenString, x => func.Invoke());
        }

        private static T CommandWrapper<T>(string allegedWebServiceTokenString, Func<WebServiceToken, T> func)
        {
            var webServiceToken = new WebServiceToken(allegedWebServiceTokenString);

            // To prevent code from doing Notifications and any other stuff for production bits only, temporarily mark this thread here to be in Unit Test Mode
            if (webServiceToken.IsWebServiceTokenForUnitTests)
            {
                BrowserAutomationCookie.SetIsRunningUnderWebBrowserAutomation();
            }

            return func.Invoke(webServiceToken);
        }

        public List<WebServiceProject> GetProject(string returnType, string webServiceToken, int projectID)
        {
            return CommandWrapper(webServiceToken, () =>
            {
                var filteredProjects = WebServiceProject.GetProject(projectID);
                return filteredProjects;
            });
        }

        public List<WebServiceProject> GetProjects(string returnType, string webServiceToken)
        {
            return CommandWrapper(webServiceToken, () =>
            {
                var filteredProjects = WebServiceProject.GetProjects();
                return filteredProjects;
            });
        }

        public List<WebServiceProject> GetProjectsByOrganization(string returnType, string webServiceToken, int organizationID)
        {
            return CommandWrapper(webServiceToken, () =>
            {
                var filteredProjects = WebServiceProject.GetProjectsByOrganization(organizationID);
                return filteredProjects;
            });
        }


        public List<WebServiceProjectAccomplishments> GetProjectAccomplishments(string returnType, string webServiceToken, int projectID)
        {
            return CommandWrapper(webServiceToken, () =>
            {
                var filteredProjects = WebServiceProjectAccomplishments.GetProjectAccomplishments(projectID);
                return filteredProjects;
            });
        }

        public List<WebServiceProjectDescription> GetProjectDescription(string returnType, string webServiceToken, int projectID)
        {
            return CommandWrapper(webServiceToken, () =>
            {
                var filteredProjects = WebServiceProjectDescription.GetProjectDescription(projectID);
                return filteredProjects;
            });
        }

        public List<WebServiceProjectKeyPhoto> GetProjectKeyPhoto(string returnType, string webServiceToken, int projectID)
        {
            return CommandWrapper(webServiceToken, () =>
            {
                var filteredProjects = WebServiceProjectKeyPhoto.GetProjectKeyPhoto(projectID);
                return filteredProjects;
            });
        }

        public List<WebServicePerformanceMeasure> GetPerformanceMeasures(string returnType, string webServiceToken)
        {
            return CommandWrapper(webServiceToken, () =>
            {
                var filteredProjects = WebServicePerformanceMeasure.GetPerformanceMeasures();
                return filteredProjects;
            });
        }

        public List<WebServiceOrganization> GetOrganizations(string returnType, string webServiceToken)
        {
            return CommandWrapper(webServiceToken, () =>
            {
                var filteredProjects = WebServiceOrganization.GetOrganizations();
                return filteredProjects;
            });
        }

        public const int SampleProjectID = 1;
        public const int SampleOrganizationID = 1; //Sitka

        public class SampleRouteEntry
        {
            public readonly string MethodName;
            public readonly SitkaRoute<WebServicesController> Route;
            public readonly WebServicesController.WebServiceReturnTypeEnum WebServiceReturnTypeEnum;
            public readonly List<string> Parameters;
            public SampleRouteEntry(string methodName, SitkaRoute<WebServicesController> route, WebServicesController.WebServiceReturnTypeEnum webServiceReturnTypeEnum, List<string> parameters)
            {
                MethodName = methodName;
                Route = route;
                WebServiceReturnTypeEnum = webServiceReturnTypeEnum;
                Parameters = parameters;
            }
        }

        public static readonly List<SampleRouteEntry> WebServiceRouteMap = new List<SampleRouteEntry>
        {
            /* CSV */

            new SampleRouteEntry( 
                MethodNameFromExpression(c => c.GetProject(WebServicesController.WebServiceReturnTypeEnum.CSV.ToString(), WebServiceToken.WebServiceTokenGuidForUnitTests.ToString()
                    , SampleProjectID)),
                new SitkaRoute<WebServicesController>(c => c.GetProject(WebServicesController.WebServiceReturnTypeEnum.CSV, WebServiceToken.WebServiceTokenForUnitTests
                    , SampleProjectID))
                , WebServicesController.WebServiceReturnTypeEnum.CSV
                , new List<string> {"Return Type", "Authorization Token", "(optional) Project Number"}
                ),
            new SampleRouteEntry( 
                MethodNameFromExpression(c => c.GetProjects(WebServicesController.WebServiceReturnTypeEnum.CSV.ToString(), WebServiceToken.WebServiceTokenGuidForUnitTests.ToString())),
                new SitkaRoute<WebServicesController>(c => c.GetProjects(WebServicesController.WebServiceReturnTypeEnum.CSV, WebServiceToken.WebServiceTokenForUnitTests))
                , WebServicesController.WebServiceReturnTypeEnum.CSV
                , new List<string> {"Return Type", "Authorization Token", "(optional) Project Number"}
                ),
            new SampleRouteEntry( 
                MethodNameFromExpression(c => c.GetProjectsByOrganization(WebServicesController.WebServiceReturnTypeEnum.CSV.ToString(), WebServiceToken.WebServiceTokenGuidForUnitTests.ToString()
                    , SampleOrganizationID)),
                new SitkaRoute<WebServicesController>(c => c.GetProjectsByOrganization(WebServicesController.WebServiceReturnTypeEnum.CSV, WebServiceToken.WebServiceTokenForUnitTests
                    , SampleOrganizationID))
                , WebServicesController.WebServiceReturnTypeEnum.CSV
                , new List<string> {"Return Type", "Authorization Token", "OrganizationID"}
                ),
            new SampleRouteEntry( 
                MethodNameFromExpression(c => c.GetProjectAccomplishments(WebServicesController.WebServiceReturnTypeEnum.CSV.ToString(), WebServiceToken.WebServiceTokenGuidForUnitTests.ToString()
                    , SampleProjectID)),
                new SitkaRoute<WebServicesController>(c => c.GetProjectAccomplishments(WebServicesController.WebServiceReturnTypeEnum.CSV, WebServiceToken.WebServiceTokenForUnitTests
                    , SampleProjectID))
                , WebServicesController.WebServiceReturnTypeEnum.CSV
                , new List<string> {"Return Type", "Authorization Token", "Project Number"}
                ),
            new SampleRouteEntry( 
                MethodNameFromExpression(c => c.GetProjectDescription(WebServicesController.WebServiceReturnTypeEnum.CSV.ToString(), WebServiceToken.WebServiceTokenGuidForUnitTests.ToString()
                    , SampleProjectID)),
                new SitkaRoute<WebServicesController>(c => c.GetProjectDescription(WebServicesController.WebServiceReturnTypeEnum.CSV, WebServiceToken.WebServiceTokenForUnitTests
                    , SampleProjectID))
                , WebServicesController.WebServiceReturnTypeEnum.CSV
                , new List<string> {"Return Type", "Authorization Token", "Project Number"}
                ),
            new SampleRouteEntry( 
                MethodNameFromExpression(c => c.GetProjectKeyPhoto(WebServicesController.WebServiceReturnTypeEnum.CSV.ToString(), WebServiceToken.WebServiceTokenGuidForUnitTests.ToString()
                    , SampleProjectID)),
                new SitkaRoute<WebServicesController>(c => c.GetProjectKeyPhoto(WebServicesController.WebServiceReturnTypeEnum.CSV, WebServiceToken.WebServiceTokenForUnitTests
                    , SampleProjectID))
                , WebServicesController.WebServiceReturnTypeEnum.CSV
                , new List<string> {"Return Type", "Authorization Token", "Project Number"}
                ),
            new SampleRouteEntry( 
                MethodNameFromExpression(c => c.GetPerformanceMeasures(WebServicesController.WebServiceReturnTypeEnum.CSV.ToString(), WebServiceToken.WebServiceTokenGuidForUnitTests.ToString())),
                new SitkaRoute<WebServicesController>(c => c.GetPerformanceMeasures(WebServicesController.WebServiceReturnTypeEnum.CSV, WebServiceToken.WebServiceTokenForUnitTests))
                , WebServicesController.WebServiceReturnTypeEnum.CSV
                , new List<string> {"Return Type", "Authorization Token"}
                ),
            new SampleRouteEntry( 
                MethodNameFromExpression(c => c.GetOrganizations(WebServicesController.WebServiceReturnTypeEnum.CSV.ToString(), WebServiceToken.WebServiceTokenGuidForUnitTests.ToString())),
                new SitkaRoute<WebServicesController>(c => c.GetOrganizations(WebServicesController.WebServiceReturnTypeEnum.CSV, WebServiceToken.WebServiceTokenForUnitTests))
                , WebServicesController.WebServiceReturnTypeEnum.CSV
                , new List<string> {"Return Type", "Authorization Token"}
                ),

            /* JSON */
            /* (MB: this way you can just copy past the CSV section then do a Find and Replace to generate this) */

            new SampleRouteEntry( 
                MethodNameFromExpression(c => c.GetProject(WebServicesController.WebServiceReturnTypeEnum.JSON.ToString(), WebServiceToken.WebServiceTokenGuidForUnitTests.ToString()
                    , SampleProjectID)),
                new SitkaRoute<WebServicesController>(c => c.GetProject(WebServicesController.WebServiceReturnTypeEnum.JSON, WebServiceToken.WebServiceTokenForUnitTests
                    , SampleProjectID))
                , WebServicesController.WebServiceReturnTypeEnum.JSON
                , new List<string> {"Return Type", "Authorization Token", "(optional) Project Number"}
                ),
            new SampleRouteEntry( 
                MethodNameFromExpression(c => c.GetProjects(WebServicesController.WebServiceReturnTypeEnum.JSON.ToString(), WebServiceToken.WebServiceTokenGuidForUnitTests.ToString())),
                new SitkaRoute<WebServicesController>(c => c.GetProjects(WebServicesController.WebServiceReturnTypeEnum.JSON, WebServiceToken.WebServiceTokenForUnitTests))
                , WebServicesController.WebServiceReturnTypeEnum.JSON
                , new List<string> {"Return Type", "Authorization Token", "(optional) Project Number"}
                ),
            new SampleRouteEntry( 
                MethodNameFromExpression(c => c.GetProjectsByOrganization(WebServicesController.WebServiceReturnTypeEnum.JSON.ToString(), WebServiceToken.WebServiceTokenGuidForUnitTests.ToString()
                    , SampleOrganizationID)),
                new SitkaRoute<WebServicesController>(c => c.GetProjectsByOrganization(WebServicesController.WebServiceReturnTypeEnum.JSON, WebServiceToken.WebServiceTokenForUnitTests
                    , SampleOrganizationID))
                , WebServicesController.WebServiceReturnTypeEnum.JSON
                , new List<string> {"Return Type", "Authorization Token", "(optional) Project Number"}
                ),
            new SampleRouteEntry( 
                MethodNameFromExpression(c => c.GetProjectAccomplishments(WebServicesController.WebServiceReturnTypeEnum.JSON.ToString(), WebServiceToken.WebServiceTokenGuidForUnitTests.ToString()
                    , SampleProjectID)),
                new SitkaRoute<WebServicesController>(c => c.GetProjectAccomplishments(WebServicesController.WebServiceReturnTypeEnum.JSON, WebServiceToken.WebServiceTokenForUnitTests
                    , SampleProjectID))
                , WebServicesController.WebServiceReturnTypeEnum.JSON
                , new List<string> {"Return Type", "Authorization Token", "(optional) Project Number"}
                ),
            new SampleRouteEntry( 
                MethodNameFromExpression(c => c.GetProjectDescription(WebServicesController.WebServiceReturnTypeEnum.JSON.ToString(), WebServiceToken.WebServiceTokenGuidForUnitTests.ToString()
                    , SampleProjectID)),
                new SitkaRoute<WebServicesController>(c => c.GetProjectDescription(WebServicesController.WebServiceReturnTypeEnum.JSON, WebServiceToken.WebServiceTokenForUnitTests
                    , SampleProjectID))
                , WebServicesController.WebServiceReturnTypeEnum.JSON
                , new List<string> {"Return Type", "Authorization Token", "(optional) Project Number"}
                ),
            new SampleRouteEntry( 
                MethodNameFromExpression(c => c.GetProjectKeyPhoto(WebServicesController.WebServiceReturnTypeEnum.JSON.ToString(), WebServiceToken.WebServiceTokenGuidForUnitTests.ToString()
                    , SampleProjectID)),
                new SitkaRoute<WebServicesController>(c => c.GetProjectKeyPhoto(WebServicesController.WebServiceReturnTypeEnum.JSON, WebServiceToken.WebServiceTokenForUnitTests
                    , SampleProjectID))
                , WebServicesController.WebServiceReturnTypeEnum.JSON
                , new List<string> {"Return Type", "Authorization Token", "(optional) Project Number"}
                ),
            new SampleRouteEntry( 
                MethodNameFromExpression(c => c.GetPerformanceMeasures(WebServicesController.WebServiceReturnTypeEnum.JSON.ToString(), WebServiceToken.WebServiceTokenGuidForUnitTests.ToString())),
                new SitkaRoute<WebServicesController>(c => c.GetPerformanceMeasures(WebServicesController.WebServiceReturnTypeEnum.JSON, WebServiceToken.WebServiceTokenForUnitTests))
                , WebServicesController.WebServiceReturnTypeEnum.JSON
                , new List<string> {"Return Type", "Authorization Token", "(optional) Project Number"}
                ),
            new SampleRouteEntry( 
                MethodNameFromExpression(c => c.GetOrganizations(WebServicesController.WebServiceReturnTypeEnum.JSON.ToString(), WebServiceToken.WebServiceTokenGuidForUnitTests.ToString())),
                new SitkaRoute<WebServicesController>(c => c.GetOrganizations(WebServicesController.WebServiceReturnTypeEnum.JSON, WebServiceToken.WebServiceTokenForUnitTests))
                , WebServicesController.WebServiceReturnTypeEnum.JSON
                , new List<string> {"Return Type", "Authorization Token"}
                )
        };

        public static string MethodNameFromExpression(Expression<Action<IWebServices>> expression)
        {
            return ((MethodCallExpression)expression.Body).Method.Name;
        }
    }
}
