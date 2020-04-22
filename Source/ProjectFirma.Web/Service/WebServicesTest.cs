/*-----------------------------------------------------------------------
<copyright file="WebServicesTest.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.ServiceModel;
using System.Threading.Tasks;
using ApprovalTests.Reporters;
using LtInfo.Common;
using LtInfo.Common.MvcResults;
using NUnit.Framework;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.UnitTestCommon;
using AssertCustom = LtInfo.Common.AssertCustom;
using SitkaController = ProjectFirma.Web.Common.SitkaController;

namespace ProjectFirma.Web.Service
{
    [TestFixture]
    public class WebServicesTest
    {
        private static readonly Type _webServiceControllerType = typeof(WebServicesController);
        private readonly List<MethodInfo> _allWebServiceControllerActionMethodInfos = SitkaController.FindControllerActions(_webServiceControllerType).Where(x => x.DeclaringType != typeof(SitkaController)).ToList();
        private readonly List<string> _webServiceMethodsNotAvailableViaMvcController = new List<string> { };
        private readonly List<string> _webServiceMethodsThatAreNotWebServices = new List<string> {"Index", "List", "GetWebServiceAccessToken"};

        [Test]
        [Description("All of the CSV web service methods must also be implemented in SOAP, and vice versa.")]
        public void AllMethodsExistCsvAndSoap()
        {
            var webServiceMethodNames =
                SitkaController.FindAttributedMethods(typeof(IWebServices), typeof(OperationContractAttribute)).Select(m => m.Name).Except(_webServiceMethodsNotAvailableViaMvcController);
            var webServiceControllerActionNames = _allWebServiceControllerActionMethodInfos.Select(a => a.Name).Except(_webServiceMethodsThatAreNotWebServices);

            var missingFromWebService = webServiceControllerActionNames.Except(webServiceMethodNames);
            Assert.That(missingFromWebService, Is.Empty, "There are CSV controller actions that aren't in the web service.");

            var missingFromCsvControllerAction = webServiceMethodNames.Except(webServiceControllerActionNames);
            Assert.That(missingFromCsvControllerAction, Is.Empty, "There are web service actions that aren't in the CSV controller actions.");
        }

        //MB: Disabled since typeof is now ActionResult
        /*
        [Test]
        [Description("All of the web service controller methods must return a CSV file.")]
        public void AllMethodsShouldReturnCsvFile()
        {
            var requiredReturnType = typeof(CsvDownloadResult);

            var methodsWithoutCsvType = _allWebServiceControllerActionMethodInfos.Where(x => x.ReturnType != requiredReturnType);

            Assert.That(methodsWithoutCsvType, Is.Empty, string.Format("The following methods do not return required type {0}:\r\n{1}", requiredReturnType.Name, MakeMethodList(methodsWithoutCsvType)));
        }
        */

        //TODO-MB: This should also check that ReturnType is the first parameter...
        [Test]
        [Description("For security purposes all the methods should take a security token.")]
        public void AllMethodsShouldTakeWebServiceTokenParameter()
        {
            foreach (var actionMethod in _allWebServiceControllerActionMethodInfos.Where(x => !_webServiceMethodsThatAreNotWebServices.Contains(x.Name)))
            {
                var parameters = actionMethod.GetParameters();
                var currentMethodName = String.Format("{0}.{1}()", _webServiceControllerType.Name, actionMethod.Name);
                Assert.That(parameters.Length, Is.GreaterThanOrEqualTo(1), string.Format("{0} had no parameters at all, needs at least one for the token.", currentMethodName));

                var webServiceTokenParameter = parameters.FirstOrDefault(x => x.Name == WebServiceToken.WebServiceTokenModelBinder.WebServiceTokenParameterName);
                Assert.That(webServiceTokenParameter, Is.Not.Null,
                            string.Format("{0} does not have required parameter named \"{1}\".", currentMethodName, WebServiceToken.WebServiceTokenModelBinder.WebServiceTokenParameterName));

                var secondParameter = parameters[1];
                Assert.That(secondParameter, Is.EqualTo(webServiceTokenParameter),
                            String.Format("{0} should have required parameter {1} as the *SECOND* parameter.", currentMethodName, WebServiceToken.WebServiceTokenModelBinder.WebServiceTokenParameterName));

                Assert.That(secondParameter.ParameterType, Is.EqualTo(typeof(WebServiceToken)),
                            string.Format("Mandatory {0} parameter should be of required type {1}", WebServiceToken.WebServiceTokenModelBinder.WebServiceTokenParameterName,
                                          typeof(WebServiceToken).Name));
            }
        }

        [Test]
        [Description("This test verifies the shape of all of the CSV download files")]
        [Ignore]
        public void AllWebServicesHaveCorrectCsvColumns()
        {
            var testSubject = new WebServicesController();
            var testCases = new[]
            {
                new CsvColumnTestCase("GetProject",
                    () => (CsvDownloadResult) testSubject.GetProject(WebServicesController.WebServiceReturnTypeEnum.CSV, WebServiceToken.WebServiceTokenForUnitTests, WebServices.GetSampleProjectID()), "ProjectID,ProjectName,TaxonomyTrunk,TaxonomyBranch,TaxonomyLeaf,Stage,ProjectDescription,LeadImplementer,PlanningStartDate,ImplementationStartDate,EndDate,Latitude,Longitude,Datum,ProjectRegion,ProjectState,ProjectJurisdiction,ProjectGeospatialArea,ProjectDetailUrl,ProjectFactSheetUrl"),
                new CsvColumnTestCase("GetProjects",
                    () => (CsvDownloadResult) testSubject.GetProjects(WebServicesController.WebServiceReturnTypeEnum.CSV, WebServiceToken.WebServiceTokenForUnitTests), "ProjectID,ProjectName,TaxonomyTrunk,TaxonomyBranch,TaxonomyLeaf,Stage,ProjectDescription,LeadImplementer,PlanningStartDate,ImplementationStartDate,EndDate,Latitude,Longitude,Datum,ProjectRegion,ProjectState,ProjectJurisdiction,ProjectGeospatialArea,ProjectDetailUrl,ProjectFactSheetUrl"),
                new CsvColumnTestCase("GetProjectsByOrganization",
                    () =>
                        (CsvDownloadResult)
                            testSubject.GetProjectsByOrganization(WebServicesController.WebServiceReturnTypeEnum.CSV, WebServiceToken.WebServiceTokenForUnitTests, WebServices.GetSampleOrganizationID()), "ProjectID,ProjectName,TaxonomyTrunk,TaxonomyBranch,TaxonomyLeaf,Stage,ProjectDescription,LeadImplementer,PlanningStartDate,ImplementationStartDate,EndDate,Latitude,Longitude,Datum,ProjectRegion,ProjectState,ProjectJurisdiction,ProjectGeospatialArea,ProjectDetailUrl,ProjectFactSheetUrl"),
//                new CsvColumnTestCase("GetProjectAccomplishments",
//                    () =>
//                        (CsvDownloadResult)
//                            testSubject.GetProjectAccomplishments(WebServicesController.WebServiceReturnTypeEnum.CSV, WebServiceToken.WebServiceTokenForUnitTests, WebServices.GetSampleProjectID()),
//"ProjectID,PerformanceMeasureID,PerformanceMeasureName,PerformanceMeasureUnits,PerformanceMeasureProjectYear,PerformanceMeasureProjectValue,PMSubcategoryName1,PMSubcategoryOptionCount1,PMSubcategoryName2,PMSubcategoryOptionCount2,PMSubcategoryName3,PMSubcategoryOptionCount3,PMSubcategoryName4,PMSubcategoryOptionCount4"),
                new CsvColumnTestCase("GetProjectDescription",
                    () =>
                        (CsvDownloadResult)
                            testSubject.GetProjectDescription(WebServicesController.WebServiceReturnTypeEnum.CSV, WebServiceToken.WebServiceTokenForUnitTests, WebServices.GetSampleProjectID()),
                    "ProjectID,ProjectName,ProjectDescription"),
                //new CsvColumnTestCase("GetProjectKeyPhoto",
                //    () =>
                //        (CsvDownloadResult)
                //            testSubject.GetProjectKeyPhoto(WebServicesController.WebServiceReturnTypeEnum.CSV, WebServiceToken.WebServiceTokenForUnitTests, WebServices.GetSampleProjectID()),
                //    "ProjectID,ProjectName,KeyPhotoUrl"),
                new CsvColumnTestCase("GetPerformanceMeasures",
                    () => (CsvDownloadResult) testSubject.GetPerformanceMeasures(WebServicesController.WebServiceReturnTypeEnum.CSV, WebServiceToken.WebServiceTokenForUnitTests),
"PerformanceMeasureID,PerformanceMeasureName,PerformanceMeasureDescription,PerformanceMeasureUnits,PMSubcategoryName1,PMSubcategoryOptionCount1,PMSubcategoryName2,PMSubcategoryOptionCount2,PMSubcategoryName3,PMSubcategoryOptionCount3,PMSubcategoryName4,PMSubcategoryOptionCount4"),
                new CsvColumnTestCase("GetOrganizations",
                    () => (CsvDownloadResult) testSubject.GetOrganizations(WebServicesController.WebServiceReturnTypeEnum.CSV, WebServiceToken.WebServiceTokenForUnitTests),
"OrganizationID,Organization,OrganizationShortName,OrganizationType,PrimaryContact,NumberOfProjects,NumberOfFundingSources,NumberOfUsers,OrganizationSummaryUrl"),
            };

            foreach (var testCase in testCases)
            {
                AssertHasExpectedCsvColumns(testCase.Name, testCase.Func.Invoke(), testCase.FirstColumnList);
            }

            var missingTests = _allWebServiceControllerActionMethodInfos.Select(x => x.Name).Except(_webServiceMethodsThatAreNotWebServices).Except(testCases.Select(x => x.Name));
            Assert.That(missingTests, Is.Empty,
                        "There's not enough test entrees for each of the web service methods. Might need an entry in this test to describe the expected columns in the CSV download. Modify test by adding in expected results.");


        }

        private struct CsvColumnTestCase
        {
            public readonly string FirstColumnList;
            public readonly Func<CsvDownloadResult> Func;
            public readonly string Name;

            public CsvColumnTestCase(string name, Func<CsvDownloadResult> func, string firstColumnList)
            {
                Name = name;
                Func = func;
                FirstColumnList = firstColumnList;
            }
        }

        private static void AssertHasExpectedCsvColumns(string name, CsvDownloadResult result, string expectedColumnStringList)
        {
            var firstLine = result.CsvContents.Replace("\r\n", "\n").Split('\n')[0].Replace("\"", "");
            Assert.That(firstLine, Is.EqualTo(expectedColumnStringList), string.Format("CSV file does not have the expected columns in the first row for test named \"{0}\".\r\nActual: {1}", name, firstLine));
        }
   
        public string MakeMethodList(IEnumerable<MethodInfo> methods)
        {
            var methodFullNames = methods.Select(x => String.Format("{0}.{1}()", x.DeclaringType.Name, x.Name));
            return string.Join("\r\n", methodFullNames.ToArray());
        }

        [Test]
        [Description("We have had prior issues with web services not working on particular tenants, so this test ensures we have consistent access")]
        public void CanRetrieveWebServiceListForAllTenants()
        {
            AssertCustom.IgnoreUntil(DateTime.Parse("12/15/2020 12:00"),"Test added by SLG and SMG 12/10/2019 is not working, may not be able to make it work properly as written. Tests attempt to see web services urls but that requires login through Keystone which is not easy to do. May be able to re-write as a controller test. Ignoring for now. -MF");
            var allTenantCanonicalHostnames = ProjectFirmaModels.Models.Tenant.All.Select(t => t.CanonicalHostNameLocal).ToList();
            var sitkaTenantCanonicalHostName = ProjectFirmaModels.Models.Tenant.SitkaTechnologyGroup.CanonicalHostNameLocal;
            var testUrlForSitkaTenant = SitkaRoute<WebServicesController>.BuildAbsoluteUrlFromExpression(wsc => wsc.List());
            var failedMessages = new List<string>();

            foreach (var currentTenantCanonicalHostname in allTenantCanonicalHostnames)
            {
                // build the url
                var currentTestUrl = testUrlForSitkaTenant.Replace(sitkaTenantCanonicalHostName, currentTenantCanonicalHostname);
                try
                {
                    var responseText = HttpHelper.GetUrl(currentTestUrl);
                    Assert.That(!responseText.Contains("<title>Sitka Keystone", StringComparison.InvariantCultureIgnoreCase), "Test Precondition - hoping to end up on the service site not on the keystone website");
                    Assert.That(responseText, Is.StringContaining("service"));
                }
                catch (Exception e)
                {
                    failedMessages.Add($"Url: {currentTestUrl}, unexpected exception: {e}");
                }
            }
            Assert.That(!failedMessages.Any(), $"Received the following errors: {string.Join("\r\n", failedMessages)}");
        }
    }//EOC
}//EON
