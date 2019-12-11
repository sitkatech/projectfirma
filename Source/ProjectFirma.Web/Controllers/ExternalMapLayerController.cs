/*-----------------------------------------------------------------------
<copyright file="ExternalMapLayerController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Data.Entity.Spatial;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using GeoJSON.Net.Feature;
using LtInfo.Common;
using LtInfo.Common.Models;
using LtInfo.Common.Mvc;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.KeystoneDataService;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Security.Shared;
using ProjectFirma.Web.Views.ExternalMapLayer;
using ProjectFirma.Web.Views.Shared;


namespace ProjectFirma.Web.Controllers
{
    public class ExternalMapLayerController : FirmaBaseController
    {
        [AnonymousUnclassifiedFeature]
        public ViewResult Index()
        {
            return ViewIndex(SitkaRoute<ExternalMapLayerController>.BuildUrlFromExpression(x => x.IndexGridJsonData()));

        }

        [AnonymousUnclassifiedFeature]
        public ViewResult ViewIndex(string gridDataUrl)
        {
            var firmaPage = FirmaPageTypeEnum.OrganizationsList.GetFirmaPage();
            List<SelectListItem> activeOrAllOrganizationsSelectListItems = new List<SelectListItem>()
            {
                new SelectListItem() {Text = "Active Organizations Only", Value = SitkaRoute<ExternalMapLayerController>.BuildUrlFromExpression(x => x.IndexGridJsonData(IndexGridSpec.OrganizationStatusFilterTypeEnum.ActiveOrganizations))},
                new SelectListItem() {Text = "All Organizations", Value = SitkaRoute<ExternalMapLayerController>.BuildUrlFromExpression(x => x.IndexGridJsonData(IndexGridSpec.OrganizationStatusFilterTypeEnum.AllOrganizations))}
            };

            var viewData = new IndexViewData(CurrentFirmaSession, firmaPage, gridDataUrl, activeOrAllOrganizationsSelectListItems);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [AnonymousUnclassifiedFeature]
        public GridJsonNetJObjectResult<ExternalMapLayer> IndexGridJsonData()
        {
            var hasDeleteOrganizationPermission = new OrganizationManageFeature().HasPermissionByFirmaSession(CurrentFirmaSession);
            var gridSpec = new IndexGridSpec(CurrentFirmaSession, hasDeleteOrganizationPermission);
            var organizations = HttpRequestStorage.DatabaseEntities.Organizations.ToList();

            switch (organizationStatusFilterType)
            {
                case IndexGridSpec.OrganizationStatusFilterTypeEnum.ActiveOrganizations:
                    organizations = organizations.Where(x => x.IsActive).ToList();
                    break;
                case IndexGridSpec.OrganizationStatusFilterTypeEnum.AllOrganizations:
                    break;
                default:
                    throw new ArgumentOutOfRangeException("organizationStatusFilterType", organizationStatusFilterType,
                        null);
            }

            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Organization>(organizations.OrderBy(x => x.GetDisplayName()).ToList(), gridSpec);
            return gridJsonNetJObjectResult;
        }
//
//        [HttpGet]
//        [OrganizationManageFeature]
//        public PartialViewResult New()
//        {
//            var viewModel = new EditViewModel {IsActive = true};
//            return ViewEdit(viewModel, false, null);
//        }
//
//        [HttpPost]
//        [OrganizationManageFeature]
//        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
//        public ActionResult New(EditViewModel viewModel)
//        {
//            if (!ModelState.IsValid)
//            {
//                return ViewEdit(viewModel, true, null);
//            }
//            var organization = new Organization(String.Empty, true, ModelObjectHelpers.NotYetAssignedID);
//            viewModel.UpdateModel(organization, CurrentFirmaSession);
//            HttpRequestStorage.DatabaseEntities.AllOrganizations.Add(organization);
//            HttpRequestStorage.DatabaseEntities.SaveChanges();
//            SetMessageForDisplay($"Organization {organization.GetDisplayName()} successfully created.");
//
//            return new ModalDialogFormJsonResult();
//        }
//
//        [HttpGet]
//        [OrganizationManageFeature]
//        public PartialViewResult Edit(OrganizationPrimaryKey organizationPrimaryKey)
//        {
//            var organization = organizationPrimaryKey.EntityObject;
//            var viewModel = new EditViewModel(organization);
//            return ViewEdit(viewModel, organization.IsInKeystone(), organization.PrimaryContactPerson);
//        }
//
//        [HttpPost]
//        [OrganizationManageFeature]
//        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
//        public ActionResult Edit(OrganizationPrimaryKey organizationPrimaryKey, EditViewModel viewModel)
//        {
//            var organization = organizationPrimaryKey.EntityObject;
//            if (!ModelState.IsValid)
//            {
//                return ViewEdit(viewModel, organization.IsInKeystone(), organization.PrimaryContactPerson);
//            }
//            viewModel.UpdateModel(organization, CurrentFirmaSession);
//            return new ModalDialogFormJsonResult();
//        }
//
//        private PartialViewResult ViewEdit(EditViewModel viewModel, bool isInKeystone, Person currentPrimaryContactPerson)
//        {
//            var organizationTypesAsSelectListItems = HttpRequestStorage.DatabaseEntities.OrganizationTypes
//                .OrderBy(x => x.OrganizationTypeName)
//                .ToSelectListWithEmptyFirstRow(x => x.OrganizationTypeID.ToString(CultureInfo.InvariantCulture),
//                    x => x.OrganizationTypeName);
//            var activePeople = HttpRequestStorage.DatabaseEntities.People.GetActivePeople();
//            if (currentPrimaryContactPerson != null && !activePeople.Contains(currentPrimaryContactPerson))
//            {
//                activePeople.Add(currentPrimaryContactPerson);
//            }
//            var people = activePeople.OrderBy(x => x.GetFullNameLastFirst()).ToSelectListWithEmptyFirstRow(x => x.PersonID.ToString(CultureInfo.InvariantCulture),
//                x => x.GetFullNameFirstLastAndOrg());
//            var isSitkaAdmin = new SitkaAdminFeature().HasPermissionByFirmaSession(CurrentFirmaSession);
//            var viewData = new EditViewData(organizationTypesAsSelectListItems, people, isInKeystone, SitkaRoute<HelpController>.BuildUrlFromExpression(x => x.RequestOrganizationNameChange()), isSitkaAdmin);
//            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
//        }
//
//        [OrganizationViewFeature]
//        public ViewResult Detail(OrganizationPrimaryKey organizationPrimaryKey)
//        {
//            var organization = organizationPrimaryKey.EntityObject;
//            var expendituresDirectlyFromOrganizationViewGoogleChartViewData = GetCalendarYearExpendituresFromOrganizationFundingSourcesLineChartViewData(organization);
//            var expendituresReceivedFromOtherOrganizationsViewGoogleChartViewData = GetCalendarYearExpendituresFromProjectFundingSourcesLineChartViewData(organization, CurrentFirmaSession);
//
//            var mapInitJson = GetMapInitJson(organization, out var hasSpatialData, CurrentPerson);
//
//            var performanceMeasures = organization.GetAllActiveProjectsAndProposals(CurrentPerson).ToList()
//                .SelectMany(x => x.PerformanceMeasureActuals)
//                .Select(x => x.PerformanceMeasure).Distinct(new HavePrimaryKeyComparer<PerformanceMeasure>())
//                .OrderBy(x => x.PerformanceMeasureDisplayName)
//                .ToList();
//
//            var viewData = new DetailViewData(CurrentFirmaSession, organization, mapInitJson, hasSpatialData, performanceMeasures, expendituresDirectlyFromOrganizationViewGoogleChartViewData, expendituresReceivedFromOtherOrganizationsViewGoogleChartViewData);
//            return RazorView<Detail, DetailViewData>(viewData);
//        }
    }
}
