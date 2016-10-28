using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Security.Shared;
using ProjectFirma.Web.Service;
using ProjectFirma.Web.Service.ServiceModels;
using ProjectFirma.Web.Views.WebServices;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.MvcResults;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Controllers
{
    public class WebServicesController : FirmaBaseController
    {
        public enum WebServiceReturnTypeEnum
        {
            CSV,
            JSON
        }

        /// <summary>
        /// Allows for framework default construction
        /// </summary>
        public WebServicesController()
        {
        }

        [AnonymousUnclassifiedFeature]
        public ViewResult Index()
        {
            var webServicesListUrl = SitkaRoute<WebServicesController>.BuildUrlFromExpression(x => x.List());
            var getWebServiceAccessTokenUrl = SitkaRoute<WebServicesController>.BuildUrlFromExpression(x => x.GetWebServiceAccessToken(CurrentPerson));
            var viewData = new IndexViewData(CurrentPerson, CurrentPerson.WebServiceAccessToken, webServicesListUrl, getWebServiceAccessTokenUrl);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [WebServiceDocumentationViewFeature]
        public PartialViewResult GetWebServiceAccessToken(PersonPrimaryKey personPrimaryKey)
        {
            Check.Require(personPrimaryKey.PrimaryKeyValue == CurrentPerson.PersonID, "The person ID passed in to GetWebServiceAccessToken must match the logged in user!");
            var person = personPrimaryKey.EntityObject;
            if (!person.WebServiceAccessToken.HasValue)
            {
                person.WebServiceAccessToken = Guid.NewGuid();
                HttpRequestStorage.DatabaseEntities.SaveChanges(CurrentPerson);
            }
            var viewData = new ViewAccessTokenViewData(person.WebServiceAccessToken.Value, SitkaRoute<WebServicesController>.BuildUrlFromExpression(c => c.List()));
            return RazorPartialView<ViewAccessToken, ViewAccessTokenViewData>(viewData);
        }

        [WebServiceDocumentationViewFeature]
        public ViewResult List()
        {
            Check.RequireThrowNotAuthorized(CurrentPerson.WebServiceAccessToken.HasValue, "Person must have already received their access token before accessing web service list.");
            var allMethods = FindAttributedMethods(typeof(IWebServices), typeof(WebServiceDocumentationAttribute));
            var serviceDocumentationList = allMethods.Select(c => new WebServiceDocumentation(c)).ToList();
            var viewData = new ListViewData(CurrentPerson, new WebServiceToken(CurrentPerson.WebServiceAccessToken.Value.ToString()), serviceDocumentationList);
            return RazorView<List, ListViewData>(viewData);
        }

        [AnonymousUnclassifiedFeature]
        public ActionResult GetProject(WebServiceReturnTypeEnum webServiceReturnTypeEnum, WebServiceToken webServiceToken, string optionalProjectNumber)
        {
            var projects = WebServiceProject.GetProject(optionalProjectNumber);
            var gridSpec = new WebServiceProjectGridSpec();
            return GetResultsAsCsvDowloadOrJsonResult(webServiceReturnTypeEnum, projects, gridSpec, "Project");
        }

        [AnonymousUnclassifiedFeature]
        public ActionResult GetProjects(WebServiceReturnTypeEnum webServiceReturnTypeEnum, WebServiceToken webServiceToken)
        {
            var projects = WebServiceProject.GetProjects();
            var gridSpec = new WebServiceProjectGridSpec();
            return GetResultsAsCsvDowloadOrJsonResult(webServiceReturnTypeEnum, projects, gridSpec, "Projects");
        }

        [AnonymousUnclassifiedFeature]
        public ActionResult GetProjectsByOrganization(WebServiceReturnTypeEnum webServiceReturnTypeEnum, WebServiceToken webServiceToken, OrganizationPrimaryKey organizationPK)
        {
            var projects = WebServiceProject.GetProjectsByOrganization(organizationPK.PrimaryKeyValue);
            var gridSpec = new WebServiceProjectGridSpec();
            return GetResultsAsCsvDowloadOrJsonResult(webServiceReturnTypeEnum, projects, gridSpec, "ProjectsByOrganization");
        }

        [AnonymousUnclassifiedFeature]
        public ActionResult GetProjectAccomplishments(WebServiceReturnTypeEnum webServiceReturnTypeEnum, WebServiceToken webServiceToken, string projectNumber)
        {
            Check.RequireNotNull(projectNumber, "ProjectNumber cannot be null");
            var projects = WebServiceProjectAccomplishments.GetProjectAccomplishments(projectNumber);
            var gridSpec = new WebServiceProjectAccomplishmentsGridSpec();
            return GetResultsAsCsvDowloadOrJsonResult(webServiceReturnTypeEnum, projects, gridSpec, "ProjectAccomplishments");
        }

        [AnonymousUnclassifiedFeature]
        public ActionResult GetProjectDescription(WebServiceReturnTypeEnum webServiceReturnTypeEnum, WebServiceToken webServiceToken, string projectNumber)
        {
            Check.RequireNotNull(projectNumber, "ProjectNumber cannot be null");
            var projects = WebServiceProjectDescription.GetProjectDescription(projectNumber);
            var gridSpec = new WebServiceProjectDescriptionGridSpec();
            return GetResultsAsCsvDowloadOrJsonResult(webServiceReturnTypeEnum, projects, gridSpec, "ProjectDescription");
        }

        [AnonymousUnclassifiedFeature]
        public ActionResult GetProjectKeyPhoto(WebServiceReturnTypeEnum webServiceReturnTypeEnum, WebServiceToken webServiceToken, string projectNumber)
        {
            Check.RequireNotNull(projectNumber, "ProjectNumber cannot be null");
            var projects = WebServiceProjectKeyPhoto.GetProjectKeyPhoto(projectNumber);
            var gridSpec = new WebServiceProjectKeyPhotoGridSpec();
            return GetResultsAsCsvDowloadOrJsonResult(webServiceReturnTypeEnum, projects, gridSpec, "ProjectKeyPhoto");
        }

        [AnonymousUnclassifiedFeature]
        public ActionResult GetIndicators(WebServiceReturnTypeEnum webServiceReturnTypeEnum, WebServiceToken webServiceToken)
        {
            var indicators = WebServicePerformanceMeasure.GetIndicators();
            var gridSpec = new WebServicePerformanceMeasureGridSpec();
            return GetResultsAsCsvDowloadOrJsonResult(webServiceReturnTypeEnum, indicators, gridSpec, "Indicators");
        }

        [AnonymousUnclassifiedFeature]
        public ActionResult GetOrganizations(WebServiceReturnTypeEnum webServiceReturnTypeEnum, WebServiceToken webServiceToken)
        {
            var organizations = WebServiceOrganization.GetOrganizations();
            var gridSpec = new WebServiceOrganizationGridSpec();
            return GetResultsAsCsvDowloadOrJsonResult(webServiceReturnTypeEnum, organizations, gridSpec, "Organizations");
        }

        private ActionResult GetResultsAsCsvDowloadOrJsonResult<T>(WebServiceReturnTypeEnum webServiceReturnTypeEnum, IEnumerable<T> results, GridSpec<T> gridSpec, string downloadFileDescriptorPrefix)
        {
            switch (webServiceReturnTypeEnum)
            {
                case WebServiceReturnTypeEnum.CSV:
                    var csv = results.ToCsv(gridSpec);
                    var descriptor = new DownloadFileDescriptor(downloadFileDescriptorPrefix);
                    return new CsvDownloadResult(descriptor, csv);
                case WebServiceReturnTypeEnum.JSON:
                    return Json(results, JsonRequestBehavior.AllowGet);
                default:
                    throw new ArgumentOutOfRangeException(string.Format("Invalid return type {0}", webServiceReturnTypeEnum));
            }
        }
    }
}
