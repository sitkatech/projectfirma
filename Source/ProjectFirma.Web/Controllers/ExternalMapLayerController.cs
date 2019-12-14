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
            var firmaPage = FirmaPageTypeEnum.ExternalMapLayers.GetFirmaPage();
            var gridDataUrl = SitkaRoute<ExternalMapLayerController>.BuildUrlFromExpression(x => x.IndexGridJsonData());
            var userCanManage = new FirmaAdminFeature().HasPermission(CurrentFirmaSession).HasPermission;

            var viewData = new IndexViewData(CurrentFirmaSession, firmaPage, gridDataUrl, userCanManage);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [AnonymousUnclassifiedFeature]
        public GridJsonNetJObjectResult<ExternalMapLayer> IndexGridJsonData()
        {
            var gridSpec = new IndexGridSpec();
            var externalMapLayers = HttpRequestStorage.DatabaseEntities.ExternalMapLayers.OrderBy(x => x.DisplayName).ToList();

            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<ExternalMapLayer>(externalMapLayers, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [HttpGet]
        [FirmaAdminFeature]
        public PartialViewResult New()
        {
            var externalMapLayer = new ExternalMapLayer(string.Empty, string.Empty, true, true, true);
            var viewModel = new EditViewModel(externalMapLayer);
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [FirmaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            var externalMapLayer = ExternalMapLayer.CreateNewBlank();
            viewModel.UpdateModel(externalMapLayer);
            HttpRequestStorage.DatabaseEntities.AllExternalMapLayers.Add(externalMapLayer);
            SetMessageForDisplay($"External map layer {externalMapLayer.DisplayName} successfully created.");
            return new ModalDialogFormJsonResult();
        }

        //        [HttpGet]
        //        [FirmaAdminFeature]
        //        public PartialViewResult Edit(OrganizationPrimaryKey organizationPrimaryKey)
        //        {
        //            var organization = organizationPrimaryKey.EntityObject;
        //            var viewModel = new EditViewModel(organization);
        //            return ViewEdit(viewModel, organization.IsInKeystone(), organization.PrimaryContactPerson);
        //        }
        //
        //        [HttpPost]
        //        [FirmaAdminFeature]
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

        private PartialViewResult ViewEdit(EditViewModel viewModel)
        {
            var viewData = new EditViewData();
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }
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
