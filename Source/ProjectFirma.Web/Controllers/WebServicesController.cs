/*-----------------------------------------------------------------------
<copyright file="WebServicesController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Web.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Security.Shared;
using ProjectFirma.Web.Service;
using ProjectFirma.Web.Service.ServiceModels;
using ProjectFirma.Web.Views.WebServices;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Mvc;
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

        [LoggedInUnclassifiedFeature]
        public ViewResult Index()
        {
            var webServicesListUrl = SitkaRoute<WebServicesController>.BuildUrlFromExpression(x => x.List());
            var getWebServiceAccessTokenUrl = SitkaRoute<WebServicesController>.BuildUrlFromExpression(x => x.GetWebServiceAccessToken(CurrentPerson));
            var viewData = new IndexViewData(CurrentFirmaSession, CurrentPerson?.WebServiceAccessToken, webServicesListUrl, getWebServiceAccessTokenUrl);
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
            Check.RequireThrowNotAuthorized(CurrentPerson?.WebServiceAccessToken != null, "Person must have already received their access token before accessing web service list.");
            var allMethods = FindAttributedMethods(typeof(IWebServices), typeof(WebServiceDocumentationAttribute));
            var serviceDocumentationList = allMethods.Select(c => new WebServiceDocumentation(c)).ToList();
            var geospatialAreaTypeList = HttpRequestStorage.DatabaseEntities.GeospatialAreaTypes.ToList();
            var viewData = new ListViewData(CurrentFirmaSession, new WebServiceToken(CurrentPerson.WebServiceAccessToken.Value.ToString()), serviceDocumentationList, geospatialAreaTypeList);
            return RazorView<List, ListViewData>(viewData);
        }

        [AnonymousUnclassifiedFeature]
        public ActionResult GetProject(WebServiceReturnTypeEnum webServiceReturnTypeEnum, WebServiceToken webServiceToken, ProjectPrimaryKey projectPK)
        {
            var projects = WebServiceProject.GetProject(projectPK.PrimaryKeyValue);
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

        //[AnonymousUnclassifiedFeature]
        //public ActionResult GetProjectAccomplishments(WebServiceReturnTypeEnum webServiceReturnTypeEnum, WebServiceToken webServiceToken, ProjectPrimaryKey projectPK)
        //{
        //    var projects = WebServiceProjectAccomplishments.GetProjectAccomplishments(projectPK.PrimaryKeyValue);
        //    var gridSpec = new WebServiceProjectAccomplishmentsGridSpec();
        //    return GetResultsAsCsvDowloadOrJsonResult(webServiceReturnTypeEnum, projects, gridSpec, "ProjectAccomplishments");
        //}

        [AnonymousUnclassifiedFeature]
        public ActionResult GetProjectDescription(WebServiceReturnTypeEnum webServiceReturnTypeEnum, WebServiceToken webServiceToken, ProjectPrimaryKey projectPK)
        {
            var projects = WebServiceProjectDescription.GetProjectDescription(projectPK.PrimaryKeyValue);
            var gridSpec = new WebServiceProjectDescriptionGridSpec();
            return GetResultsAsCsvDowloadOrJsonResult(webServiceReturnTypeEnum, projects, gridSpec, "ProjectDescription");
        }

        //[AnonymousUnclassifiedFeature]
        //public ActionResult GetProjectKeyPhoto(WebServiceReturnTypeEnum webServiceReturnTypeEnum, WebServiceToken webServiceToken, ProjectPrimaryKey projectPK)
        //{
        //    var projects = WebServiceProjectKeyPhoto.GetProjectKeyPhoto(projectPK.PrimaryKeyValue);
        //    var gridSpec = new WebServiceProjectKeyPhotoGridSpec();
        //    return GetResultsAsCsvDowloadOrJsonResult(webServiceReturnTypeEnum, projects, gridSpec, "ProjectKeyPhoto");
        //}

        [AnonymousUnclassifiedFeature]
        public ActionResult GetPerformanceMeasures(WebServiceReturnTypeEnum webServiceReturnTypeEnum, WebServiceToken webServiceToken)
        {
            var performanceMeasures = WebServicePerformanceMeasure.GetPerformanceMeasures();
            var gridSpec = new WebServicePerformanceMeasureGridSpec();
            return GetResultsAsCsvDowloadOrJsonResult(webServiceReturnTypeEnum, performanceMeasures, gridSpec, "PerformanceMeasures");
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
                    throw new ArgumentOutOfRangeException($"Invalid return type {webServiceReturnTypeEnum}");
            }
        }
    }
}
