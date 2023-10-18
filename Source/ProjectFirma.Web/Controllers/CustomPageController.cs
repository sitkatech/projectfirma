﻿/*-----------------------------------------------------------------------
<copyright file="CustomPageController.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
Copyright (c) Tahoe Regional Planning Agency and Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
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
using System.Collections.Generic;
using System.Data.Entity;
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
        [Route("HelpCustomPage/{vanityUrl}")]
        public ActionResult Help(string vanityUrl)
        {
            return ViewCustomPage("HelpCustomPage", vanityUrl);
        }

        [AnonymousUnclassifiedFeature]
        public ActionResult ViewCustomPage(string route, string vanityUrl)
        {
            var customPage = MultiTenantHelpers.GetCustomPages()
                .SingleOrDefault(x => string.Equals(x.CustomPageVanityUrl, vanityUrl, StringComparison.OrdinalIgnoreCase));
            if (vanityUrl.IsEmpty() || customPage == null)
            {
                // Search engines sometimes have stale routes; we re-map for them.
                // (This is really fairly coddled, but it could benefit humans too, theoretically.)
                string remappedVanityUrl = null;
                switch (vanityUrl)
                {
                    case "MeetingsAndNotes":
                        remappedVanityUrl = "MeetingNotes";
                        break;
                    case "AboutClackamasPartnership":
                        remappedVanityUrl = "About";
                        break;
                }

                // If we found a remapping, redirect permanently to it
                if (remappedVanityUrl != null)
                {
                    return RedirectToAction(new SitkaRoute<CustomPageController>(x => x.ViewCustomPage(route, remappedVanityUrl)));
                }

                // Otherwise, we just redirect to the site's main page, and put up a warning in case this was actually a human doing the navigation.
                SetWarningForDisplay($"Could not find vanity URL /{route}: \"{vanityUrl}\"");
                return RedirectToAction(new SitkaRoute<HomeController>(x => x.Index()));

                // Since we either return the requested vanity URL, OR redirect to SOMETHING, search engines should
                // stop bashing their heads eventually here.
            }
            new CustomPageViewFeature().DemandPermission(CurrentFirmaSession, customPage);
            var hasPermission = new CustomPageManageFeature().HasPermission(CurrentFirmaSession).HasPermission;
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
                .Where(x => new CustomPageManageFeature().HasPermission(CurrentFirmaSession).HasPermission)
                .OrderBy(x => x.FirmaMenuItemID).ThenBy(x => x.SortOrder).ThenBy(x => x.CustomPageDisplayName)
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
            var tinyMceToolbarStyle = TinyMCEExtension.TinyMCEToolbarStyle.All;
            var viewData = new EditHtmlContentInDialogViewData(tinyMceToolbarStyle);
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
            var customPage = new CustomPage(string.Empty, string.Empty, FirmaMenuItem.About);

            var maxSortOrderForMenu = HttpRequestStorage.DatabaseEntities.CustomPages
                .Where(x => x.FirmaMenuItemID == viewModel.FirmaMenuItemID).Max(x => x.SortOrder);
            customPage.SortOrder = maxSortOrderForMenu.HasValue ? maxSortOrderForMenu + 1 : null;

            HttpRequestStorage.DatabaseEntities.CustomPageRoles.Load();
            var customPageRoles = HttpRequestStorage.DatabaseEntities.AllCustomPageRoles.Local;
            viewModel.UpdateModel(customPage, CurrentFirmaSession, customPageRoles);
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
            HttpRequestStorage.DatabaseEntities.CustomPageRoles.Load();
            var customPageRoles = HttpRequestStorage.DatabaseEntities.AllCustomPageRoles.Local;
            viewModel.UpdateModel(customPage, CurrentFirmaSession, customPageRoles);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEdit(EditViewModel viewModel)
        {
            var menusAsSelectListItems = FirmaMenuItem.All.ToSelectListWithEmptyFirstRow(
                x => x.FirmaMenuItemID.ToString(CultureInfo.InvariantCulture),
                x => x.GetFirmaMenuItemDisplayName());

            var viewData = new EditViewData(menusAsSelectListItems);
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

        [FirmaAdminFeature]
        public PartialViewResult EditSortOrder()
        {
            var customPages = HttpRequestStorage.DatabaseEntities.CustomPages;
            EditSortOrderInMenuGroupViewModel viewModel = new EditSortOrderInMenuGroupViewModel();
            return ViewEditSortOrder(customPages, viewModel);
        }

        private PartialViewResult ViewEditSortOrder(IQueryable<CustomPage> customPages, EditSortOrderInMenuGroupViewModel viewModel)
        {
            var aboutCustomPages = customPages.Where(x => x.FirmaMenuItemID == FirmaMenuItem.About.FirmaMenuItemID);
            var projectsCustomPages = customPages.Where(x => x.FirmaMenuItemID == FirmaMenuItem.Projects.FirmaMenuItemID);
            var programInfoCustomPages = customPages.Where(x => x.FirmaMenuItemID == FirmaMenuItem.ProgramInfo.FirmaMenuItemID);
            var resultsCustomPages = customPages.Where(x => x.FirmaMenuItemID == FirmaMenuItem.Results.FirmaMenuItemID);
            var helpCustomPages = customPages.Where(x => x.FirmaMenuItemID == FirmaMenuItem.Help.FirmaMenuItemID);

            var menuItemToSortableList = new Dictionary<FirmaMenuItem, List<IHaveASortOrder>>
            {
                { FirmaMenuItem.About, new List<IHaveASortOrder>(aboutCustomPages) },
                { FirmaMenuItem.Projects, new List<IHaveASortOrder>(projectsCustomPages) },
                { FirmaMenuItem.ProgramInfo, new List<IHaveASortOrder>(programInfoCustomPages) },
                { FirmaMenuItem.Results, new List<IHaveASortOrder>(resultsCustomPages) },
                { FirmaMenuItem.Help, new List<IHaveASortOrder>(helpCustomPages) }
            };

            EditSortOrderInMenuGroupViewData viewData = new EditSortOrderInMenuGroupViewData(menuItemToSortableList, "Custom Pages");
            return RazorPartialView<EditSortOrderInMenuGroup, EditSortOrderInMenuGroupViewData, EditSortOrderInMenuGroupViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [FirmaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditSortOrder(EditSortOrderInMenuGroupViewModel viewModel)
        {
            var customPages = HttpRequestStorage.DatabaseEntities.CustomPages;


            if (!ModelState.IsValid)
            {
                return ViewEditSortOrder(customPages, viewModel);
            }

            viewModel.UpdateModel(new List<IHaveASortOrder>(customPages));
            SetMessageForDisplay($"Successfully Updated Custom Page Sort Order");
            return new ModalDialogFormJsonResult();
        }
    }
}
