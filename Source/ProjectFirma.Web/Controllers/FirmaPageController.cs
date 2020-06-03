/*-----------------------------------------------------------------------
<copyright file="FirmaPageController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using System.Web.Mvc;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.FirmaPage;
using LtInfo.Common.MvcResults;

namespace ProjectFirma.Web.Controllers
{
    public class FirmaPageController : FirmaBaseController
    {
        [HttpGet]
        [FirmaPageManageFeature]
        public PartialViewResult EditInDialog(FirmaPagePrimaryKey firmaPagePrimaryKey)
        {
            var firmaPage = firmaPagePrimaryKey.EntityObject;
            var viewModel = new EditViewModel(firmaPage);
            return ViewEditInDialog(viewModel, firmaPage);
        }

        [HttpPost]
        [FirmaPageManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditInDialog(FirmaPagePrimaryKey firmaPagePrimaryKey, EditViewModel viewModel)
        {
            var firmaPage = firmaPagePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditInDialog(viewModel, firmaPage);
            }
            viewModel.UpdateModel(firmaPage, HttpRequestStorage.DatabaseEntities);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditInDialog(EditViewModel viewModel, FirmaPage firmaPage)
        {
            var ckEditorToolbar = firmaPage.FirmaPageType.FirmaPageRenderType == FirmaPageRenderType.PageContent ? CkEditorExtension.CkEditorToolbar.AllOnOneRowNoMaximize : CkEditorExtension.CkEditorToolbar.All;
            var viewData = new EditViewData(ckEditorToolbar,
                SitkaRoute<FileResourceController>.BuildUrlFromExpression(x => x.CkEditorUploadFileResource(firmaPage)));
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }
    }
}
