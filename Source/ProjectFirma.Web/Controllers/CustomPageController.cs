/*-----------------------------------------------------------------------
<copyright file="CustomPageController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using LtInfo.Common.Mvc;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Security.Shared;
using ProjectFirma.Web.Views.CustomPage;
using ProjectFirma.Web.Views.Shared;
using ProjectFirmaModels.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Controllers
{
    public class CustomPageController : FirmaBaseController
    {
        [AnonymousUnclassifiedFeature]
        [Route("About/{vanityUrl}")]
        public ActionResult About(string vanityUrl)
        {
            return ViewCustomPage("About", vanityUrl);
        }

        [AnonymousUnclassifiedFeature]
        [Route("ProjectCustomPage/{vanityUrl}")]
        public ActionResult Project(string vanityUrl)
        {
            return ViewCustomPage("ProjectCustomPage", vanityUrl);
        }

        [AnonymousUnclassifiedFeature]
        [Route("ProgramInfoCustomPage/{vanityUrl}")]
        public ActionResult ProgramInfo(string vanityUrl)
        {
            return ViewCustomPage("ProgramInfoCustomPage", vanityUrl);
        }

        [AnonymousUnclassifiedFeature]
        [Route("ResultsCustomPage/{vanityUrl}")]
        public ActionResult Results(string vanityUrl)
        {
            return ViewCustomPage("ResultsCustomPage", vanityUrl);
        }

        [AnonymousUnclassifiedFeature]
        [Route("ReportsCustomPage/{vanityUrl}")]
        public ActionResult Reports(string vanityUrl)
        {
            return ViewCustomPage("ReportsCustomPage", vanityUrl);
        }

        [AnonymousUnclassifiedFeature]
        [Route("ManageCustomPage/{vanityUrl}")]
        public ActionResult Manage(string vanityUrl)
        {
            return ViewCustomPage("ManageCustomPage", vanityUrl);
        }

        [AnonymousUnclassifiedFeature]
        [Route("ConfigureCustomPage/{vanityUrl}")]
        public ActionResult Configure(string vanityUrl)
        {
            return ViewCustomPage("ConfigureCustomPage", vanityUrl);
        }

        [AnonymousUnclassifiedFeature]
        public ViewResult ViewCustomPage(string route, string vanityUrl)
        {
            var customPage = MultiTenantHelpers.GetCustomPages()
                .SingleOrDefault(x => string.Equals(x.CustomPageVanityUrl, vanityUrl, StringComparison.OrdinalIgnoreCase));
            if (vanityUrl.IsEmpty() || customPage == null)
            {
                throw new ArgumentException($"Bad vanity url for /{route}: \"{vanityUrl}\"");
            }
            new CustomPageViewFeature().DemandPermission(CurrentFirmaSession, customPage);
            var hasPermission = new CustomPageManageFeature().HasPermission(CurrentFirmaSession, customPage).HasPermission;
            var viewData = new DisplayPageContentViewData(CurrentFirmaSession, customPage, hasPermission);
            return RazorView<DisplayPageContent, DisplayPageContentViewData>(viewData);
        }

        [FirmaPageViewListFeature]
        public ViewResult Index()
        {
            var viewData = new IndexViewData(CurrentFirmaSession);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [FirmaPageViewListFeature]
        public GridJsonNetJObjectResult<CustomPage> IndexGridJsonData()
        {
            var gridSpec = new CustomPageGridSpec(new FirmaPageViewListFeature().HasPermissionByFirmaSession(CurrentFirmaSession));
            var customPages = HttpRequestStorage.DatabaseEntities.CustomPages.ToList()
                .Where(x => new CustomPageManageFeature().HasPermission(CurrentFirmaSession, x).HasPermission)
                .OrderBy(x => x.CustomPageDisplayName)
                .ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<CustomPage>(customPages, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [HttpGet]
        [CustomPageManageFeature]
        public PartialViewResult EditInDialog(CustomPagePrimaryKey customPagePrimaryKey)
        {
            var customPage = customPagePrimaryKey.EntityObject;
            var viewModel = new EditHtmlContentInDialogViewModel(customPage);
            return ViewEditInDialog(viewModel, customPage);
        }

        [HttpPost]
        [CustomPageManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditInDialog(CustomPagePrimaryKey customPagePrimaryKey, EditHtmlContentInDialogViewModel viewModel)
        {
            var customPage = customPagePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditInDialog(viewModel, customPage);
            }
            viewModel.UpdateModel(customPage, HttpRequestStorage.DatabaseEntities);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditInDialog(EditHtmlContentInDialogViewModel viewModel, CustomPage customPage)
        {
            var ckEditorToolbar = CkEditorExtension.CkEditorToolbar.All;
            var viewData = new EditHtmlContentInDialogViewData(ckEditorToolbar,
                SitkaRoute<FileResourceController>.BuildUrlFromExpression(x => x.CkEditorUploadFileResourceForCustomPage(customPage)));
            return RazorPartialView<EditHtmlContentInDialog, EditHtmlContentInDialogViewData, EditHtmlContentInDialogViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [CustomPageManageFeature]
        public PartialViewResult CustomPageDetails(CustomPagePrimaryKey customPagePrimaryKey)
        {
            var customPage = customPagePrimaryKey.EntityObject;
            var customPageContentHtmlString = customPage.CustomPageContentHtmlString;
            if (!customPage.HasPageContent())
            {
                customPageContentHtmlString = new HtmlString(string.Format("No page content for Page \"{0}\".", customPage.CustomPageDisplayName));
            }
            var viewData = new CustomPageDetailsViewData(customPageContentHtmlString);
            return RazorPartialView<CustomPageDetails, CustomPageDetailsViewData>(viewData);
        }


        [HttpGet]
        [FirmaPageViewListFeature]
        public PartialViewResult New()
        {
            var viewModel = new EditViewModel();
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [FirmaPageViewListFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            var customPage = new CustomPage(string.Empty, string.Empty, CustomPageDisplayType.Disabled, FirmaMenuItem.About);
            viewModel.UpdateModel(customPage, CurrentFirmaSession);
            HttpRequestStorage.DatabaseEntities.AllCustomPages.Add(customPage);
            HttpRequestStorage.DatabaseEntities.SaveChanges();
            SetMessageForDisplay($"Custom Page '{customPage.CustomPageDisplayName}' successfully created.");

            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [CustomPageManageFeature]
        public PartialViewResult Edit(CustomPagePrimaryKey customPagePrimaryKey)
        {
            var customPage = customPagePrimaryKey.EntityObject;
            var viewModel = new EditViewModel(customPage);
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [CustomPageManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(CustomPagePrimaryKey customPagePrimaryKey, EditViewModel viewModel)
        {
            var customPage = customPagePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            viewModel.UpdateModel(customPage, CurrentFirmaSession);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEdit(EditViewModel viewModel)
        {
            var menusAsSelectListItems = FirmaMenuItem.All.ToSelectListWithEmptyFirstRow(
                x => x.FirmaMenuItemID.ToString(CultureInfo.InvariantCulture),
                x => x.GetFirmaMenuItemDisplayName());
            var customPageTypesAsSelectListItems = CustomPageDisplayType.All.OrderBy(x => x.CustomPageDisplayTypeDisplayName)
                .ToSelectListWithEmptyFirstRow(x => x.CustomPageDisplayTypeID.ToString(CultureInfo.InvariantCulture),
                    x => x.CustomPageDisplayTypeDisplayName);

            var viewData = new EditViewData(menusAsSelectListItems, customPageTypesAsSelectListItems);
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [CustomPageManageFeature]
        public PartialViewResult DeleteCustomPage(CustomPagePrimaryKey customPagePrimaryKey)
        {
            var customPage = customPagePrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(customPage.CustomPageID);
            return ViewDeleteCustomPage(customPage, viewModel);
        }

        private PartialViewResult ViewDeleteCustomPage(CustomPage customPage, ConfirmDialogFormViewModel viewModel)
        {
            var canDelete = true;
            var confirmMessage = canDelete
                ? $"Are you sure you want to delete the Custom Page '{customPage.CustomPageDisplayName}'?"
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage("Custom Page", SitkaRoute<CustomPageController>.BuildLinkFromExpression(x => x.About(customPage.CustomPageVanityUrl), "here"));

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [CustomPageManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteCustomPage(CustomPagePrimaryKey customPagePrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var customPage = customPagePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteCustomPage(customPage, viewModel);
            }
            SetMessageForDisplay($"Custom Page '{customPage.CustomPageDisplayName}' successfully removed.");

            customPage.DeleteFull(HttpRequestStorage.DatabaseEntities);
            return new ModalDialogFormJsonResult();
        }
    }
}
