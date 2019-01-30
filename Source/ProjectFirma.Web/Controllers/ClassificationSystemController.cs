/*-----------------------------------------------------------------------
<copyright file="ProgramInfoController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.ClassificationSystem;

namespace ProjectFirma.Web.Controllers
{
    public class ClassificationSystemController : FirmaBaseController
    {
        [HttpGet]
        [FirmaAdminFeature]
        public PartialViewResult EditInDialog(ClassificationSystemPrimaryKey classificationSystemPrimaryKey)
        {
            var classificationSystem = classificationSystemPrimaryKey.EntityObject;
            var viewModel = new EditPageContentViewModel(classificationSystem);
            return ViewEditInDialog(viewModel, classificationSystem);
        }

        [HttpPost]
        [FirmaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditInDialog(ClassificationSystemPrimaryKey classificationSystemPrimaryKey, EditPageContentViewModel viewModel)
        {
            var classificationSystem = classificationSystemPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditInDialog(viewModel, classificationSystem);
            }
            viewModel.UpdateModel(classificationSystem);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditInDialog(EditPageContentViewModel viewModel, ProjectFirmaModels.Models.ClassificationSystem classificationSystem)
        {
            var ckEditorToolbar = CkEditorExtension.CkEditorToolbar.Minimal;
            var viewData = new EditPageContentViewData(ckEditorToolbar);
            return RazorPartialView<EditPageContent, EditPageContentViewData, EditPageContentViewModel>(viewData, viewModel);
        }
    }
}
