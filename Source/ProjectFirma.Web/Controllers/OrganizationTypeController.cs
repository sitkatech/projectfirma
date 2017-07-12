/*-----------------------------------------------------------------------
<copyright file="TaxonomyTierTwoController.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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

using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared;
using LtInfo.Common;
using LtInfo.Common.Mvc;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Views.OrganizationType;


namespace ProjectFirma.Web.Controllers
{
    public class OrganizationTypeController : FirmaBaseController
    {
        [OrganizationTypeViewFeature]
        public ViewResult Index()
        {
            return IndexImpl();
        }

        [FirmaAdminFeature]
        public ViewResult Manage()
        {
            return IndexImpl();
        }

        private ViewResult IndexImpl()
        {
            var viewData = new IndexViewData(CurrentPerson);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [OrganizationTypeViewFeature]
        public GridJsonNetJObjectResult<OrganizationType> IndexGridJsonData()
        {
            var hasDeletePermission = new OrganizationTypeManageFeature().HasPermissionByPerson(CurrentPerson);
            var gridSpec = new IndexGridSpec(hasDeletePermission);
            var organizationTypes = HttpRequestStorage.DatabaseEntities.OrganizationTypes.ToList().OrderBy(x => x.OrganizationTypeName).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<OrganizationType>(organizationTypes, gridSpec);
            return gridJsonNetJObjectResult;
        }

      
        [HttpGet]
        [OrganizationTypeManageFeature]
        public PartialViewResult New()
        {
            var viewModel = new EditViewModel();
            return ViewNew(viewModel);
        }

        [HttpPost]
        [OrganizationTypeManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewNew(viewModel);
            }
            var organizationType = new OrganizationType(viewModel.OrganizationTypeName, viewModel.OrganizationTypeAbbreviation, viewModel.LegendColor);
            viewModel.UpdateModel(organizationType, CurrentPerson);
            HttpRequestStorage.DatabaseEntities.AllOrganizationTypes.Add(organizationType);

            HttpRequestStorage.DatabaseEntities.SaveChanges();
            SetMessageForDisplay(
                $"New {FieldDefinition.OrganizationType.GetFieldDefinitionLabel()} {organizationType.OrganizationTypeName} successfully created!");
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [OrganizationTypeManageFeature]
        public PartialViewResult Edit(OrganizationTypePrimaryKey organizationTypePrimaryKey)
        {
            var organizationType = organizationTypePrimaryKey.EntityObject;
            var viewModel = new EditViewModel(organizationType);
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [OrganizationTypeManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(OrganizationTypePrimaryKey organizationTypePrimaryKey, EditViewModel viewModel)
        {
            var organizationType = organizationTypePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            viewModel.UpdateModel(organizationType, CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewNew(EditViewModel viewModel)
        {
            return ViewEdit(viewModel);
        }

        private PartialViewResult ViewEdit(EditViewModel viewModel)
        {            
            var viewData = new EditViewData();
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [OrganizationTypeManageFeature]
        public PartialViewResult DeleteOrganizationType(OrganizationTypePrimaryKey organizationTypePrimaryKey)
        {
            var organizationType = organizationTypePrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(organizationType.OrganizationTypeID);
            return ViewDeleteOrganizationType(organizationType, viewModel);
        }

        private PartialViewResult ViewDeleteOrganizationType(OrganizationType organizationType, ConfirmDialogFormViewModel viewModel)
        {
            var canDelete = !organizationType.HasDependentObjects(); //TODO
            var fieldDefinitionLabel = FieldDefinition.OrganizationType.GetFieldDefinitionLabel();
            var confirmMessage = canDelete
                ? string.Format("Are you sure you want to delete this {0} '{1}'?", fieldDefinitionLabel, organizationType.OrganizationTypeName)
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage(fieldDefinitionLabel, SitkaRoute<OrganizationTypeController>.BuildLinkFromExpression(x => x.Index(), "here"));

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [OrganizationTypeManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteOrganizationType(OrganizationTypePrimaryKey organizationTypePrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var organizationType = organizationTypePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteOrganizationType(organizationType, viewModel);
            }
            organizationType.DeleteOrganizationType();
            return new ModalDialogFormJsonResult();
        }

    }
}
