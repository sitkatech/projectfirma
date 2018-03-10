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
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.CustomPage;
using LtInfo.Common;
using LtInfo.Common.MvcResults;

namespace ProjectFirma.Web.Controllers
{
    public class CustomPageController : FirmaBaseController
    {
        [FirmaPageViewListFeature]
        public ViewResult Index()
        {
            var viewData = new IndexViewData(CurrentPerson);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [FirmaPageViewListFeature]
        public GridJsonNetJObjectResult<CustomPage> IndexGridJsonData()
        {
            var gridSpec = new CustomPageGridSpec(new FirmaPageViewListFeature().HasPermissionByPerson(CurrentPerson));
            var customPages = HttpRequestStorage.DatabaseEntities.CustomPages.ToList()
                .Where(x => new CustomPageManageFeature().HasPermission(CurrentPerson, x).HasPermission)
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
            var viewModel = new EditViewModel(customPage);
            return ViewEditInDialog(viewModel, customPage);
        }

        [HttpPost]
        [CustomPageManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditInDialog(CustomPagePrimaryKey customPagePrimaryKey, EditViewModel viewModel)
        {
            var customPage = customPagePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditInDialog(viewModel, customPage);
            }
            viewModel.UpdateModel(customPage);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditInDialog(EditViewModel viewModel, CustomPage customPage)
        {
            var ckEditorToolbar = CkEditorExtension.CkEditorToolbar.All;
            var viewData = new EditViewData(ckEditorToolbar,
                SitkaRoute<FileResourceController>.BuildUrlFromExpression(x => x.CkEditorUploadFileResourceForCustomPage(customPage)));
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [CustomPageManageFeature]
        public PartialViewResult CustomPageDetails(CustomPagePrimaryKey customPagePrimaryKey)
        {
            var customPage = customPagePrimaryKey.EntityObject;
            var customPageContentHtmlString = customPage.CustomPageContentHtmlString;
            if (!customPage.HasPageContent)
            {
                customPageContentHtmlString = new HtmlString(string.Format("No page content for Page \"{0}\".", customPage.CustomPageDisplayName));
            }
            var viewData = new CustomPageDetailsViewData(customPageContentHtmlString);
            return RazorPartialView<CustomPageDetails, CustomPageDetailsViewData>(viewData);
        }
    }
}
