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

        public List<WebServiceProject> GetProject(string returnType, string webServiceToken, string optionalProjectNumber)
        {
            return CommandWrapper(webServiceToken, () =>
            {
                var filteredProjects = WebServiceProject.GetProject(optionalProjectNumber);
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


        public List<WebServiceProjectAccomplishments> GetProjectAccomplishments(string returnType, string webServiceToken, string projectNumber)
        {
            return CommandWrapper(webServiceToken, () =>
            {
                var filteredProjects = WebServiceProjectAccomplishments.GetProjectAccomplishments(projectNumber);
                return filteredProjects;
            });
        }

        public List<WebServiceProjectDescription> GetProjectDescription(string returnType, string webServiceToken, string projectNumber)
        {
            return CommandWrapper(webServiceToken, () =>
            {
                var filteredProjects = WebServiceProjectDescription.GetProjectDescription(projectNumber);
                return filteredProjects;
            });
        }

        public List<WebServiceProjectKeyPhoto> GetProjectKeyPhoto(string returnType, string webServiceToken, string projectNumber)
        {
            return CommandWrapper(webServiceToken, () =>
            {
                var filteredProjects = WebServiceProjectKeyPhoto.GetProjectKeyPhoto(projectNumber);
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

        public const string SampleProjectNumber = "01.01.01.0001";
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
                    , SampleProjectNumber)),
                new SitkaRoute<WebServicesController>(c => c.GetProject(WebServicesController.WebServiceReturnTypeEnum.CSV, WebServiceToken.WebServiceTokenForUnitTests
                    , SampleProjectNumber))
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
                    , SampleProjectNumber)),
                new SitkaRoute<WebServicesController>(c => c.GetProjectAccomplishments(WebServicesController.WebServiceReturnTypeEnum.CSV, WebServiceToken.WebServiceTokenForUnitTests
                    , SampleProjectNumber))
                , WebServicesController.WebServiceReturnTypeEnum.CSV
                , new List<string> {"Return Type", "Authorization Token", "Project Number"}
                ),
            new SampleRouteEntry( 
                MethodNameFromExpression(c => c.GetProjectDescription(WebServicesController.WebServiceReturnTypeEnum.CSV.ToString(), WebServiceToken.WebServiceTokenGuidForUnitTests.ToString()
                    , SampleProjectNumber)),
                new SitkaRoute<WebServicesController>(c => c.GetProjectDescription(WebServicesController.WebServiceReturnTypeEnum.CSV, WebServiceToken.WebServiceTokenForUnitTests
                    , SampleProjectNumber))
                , WebServicesController.WebServiceReturnTypeEnum.CSV
                , new List<string> {"Return Type", "Authorization Token", "Project Number"}
                ),
            new SampleRouteEntry( 
                MethodNameFromExpression(c => c.GetProjectKeyPhoto(WebServicesController.WebServiceReturnTypeEnum.CSV.ToString(), WebServiceToken.WebServiceTokenGuidForUnitTests.ToString()
                    , SampleProjectNumber)),
                new SitkaRoute<WebServicesController>(c => c.GetProjectKeyPhoto(WebServicesController.WebServiceReturnTypeEnum.CSV, WebServiceToken.WebServiceTokenForUnitTests
                    , SampleProjectNumber))
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
                    , SampleProjectNumber)),
                new SitkaRoute<WebServicesController>(c => c.GetProject(WebServicesController.WebServiceReturnTypeEnum.JSON, WebServiceToken.WebServiceTokenForUnitTests
                    , SampleProjectNumber))
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
                    , SampleProjectNumber)),
                new SitkaRoute<WebServicesController>(c => c.GetProjectAccomplishments(WebServicesController.WebServiceReturnTypeEnum.JSON, WebServiceToken.WebServiceTokenForUnitTests
                    , SampleProjectNumber))
                , WebServicesController.WebServiceReturnTypeEnum.JSON
                , new List<string> {"Return Type", "Authorization Token", "(optional) Project Number"}
                ),
            new SampleRouteEntry( 
                MethodNameFromExpression(c => c.GetProjectDescription(WebServicesController.WebServiceReturnTypeEnum.JSON.ToString(), WebServiceToken.WebServiceTokenGuidForUnitTests.ToString()
                    , SampleProjectNumber)),
                new SitkaRoute<WebServicesController>(c => c.GetProjectDescription(WebServicesController.WebServiceReturnTypeEnum.JSON, WebServiceToken.WebServiceTokenForUnitTests
                    , SampleProjectNumber))
                , WebServicesController.WebServiceReturnTypeEnum.JSON
                , new List<string> {"Return Type", "Authorization Token", "(optional) Project Number"}
                ),
            new SampleRouteEntry( 
                MethodNameFromExpression(c => c.GetProjectKeyPhoto(WebServicesController.WebServiceReturnTypeEnum.JSON.ToString(), WebServiceToken.WebServiceTokenGuidForUnitTests.ToString()
                    , SampleProjectNumber)),
                new SitkaRoute<WebServicesController>(c => c.GetProjectKeyPhoto(WebServicesController.WebServiceReturnTypeEnum.JSON, WebServiceToken.WebServiceTokenForUnitTests
                    , SampleProjectNumber))
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