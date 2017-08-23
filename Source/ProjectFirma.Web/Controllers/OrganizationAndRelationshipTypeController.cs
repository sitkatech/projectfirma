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

using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared;
using LtInfo.Common;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Views.OrganizationAndRelationshipType;


namespace ProjectFirma.Web.Controllers
{
    public class OrganizationAndRelationshipTypeController : FirmaBaseController
    {
        [OrganizationAndRelationshipTypeViewFeature]
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

        [OrganizationAndRelationshipTypeViewFeature]
        public GridJsonNetJObjectResult<OrganizationType> OrganizationTypeGridJsonData()
        {
            var hasManagePermissions = new OrganizationAndRelationshipTypeManageFeature().HasPermissionByPerson(CurrentPerson);
            var gridSpec = new OrganizationTypeGridSpec(hasManagePermissions);
            var organizationTypes = HttpRequestStorage.DatabaseEntities.OrganizationTypes.ToList().OrderBy(x => x.OrganizationTypeName).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<OrganizationType>(organizationTypes, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [OrganizationAndRelationshipTypeViewFeature]
        public GridJsonNetJObjectResult<RelationshipType> RelationshipTypeGridJsonData()
        {
            var hasManagePermissions = new OrganizationAndRelationshipTypeManageFeature().HasPermissionByPerson(CurrentPerson);
            var gridSpec = new RelationshipTypeGridSpec(hasManagePermissions, HttpRequestStorage.DatabaseEntities.OrganizationTypes.ToList());
            var relationshipTypes = HttpRequestStorage.DatabaseEntities.RelationshipTypes.ToList().OrderBy(x => x.RelationshipTypeName).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<RelationshipType>(relationshipTypes, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [HttpGet]
        [OrganizationAndRelationshipTypeManageFeature]
        public PartialViewResult NewOrganizationType()
        {
            var viewModel = new EditOrganizationTypeViewModel();
            return ViewNewOrganizationType(viewModel);
        }

        [HttpPost]
        [OrganizationAndRelationshipTypeManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult NewOrganizationType(EditOrganizationTypeViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewNewOrganizationType(viewModel);
            }
            var organizationType = new OrganizationType(viewModel.OrganizationTypeName, viewModel.OrganizationTypeAbbreviation, viewModel.LegendColor, viewModel.ShowOnProjectMaps ?? false);
            viewModel.UpdateModel(organizationType, CurrentPerson);
            HttpRequestStorage.DatabaseEntities.AllOrganizationTypes.Add(organizationType);

            HttpRequestStorage.DatabaseEntities.SaveChanges();
            SetMessageForDisplay(
                $"New {FieldDefinition.OrganizationType.GetFieldDefinitionLabel()} {organizationType.OrganizationTypeName} successfully created!");
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [OrganizationAndRelationshipTypeManageFeature]
        public PartialViewResult EditOrganizationType(OrganizationTypePrimaryKey organizationTypePrimaryKey)
        {
            var organizationType = organizationTypePrimaryKey.EntityObject;
            var viewModel = new EditOrganizationTypeViewModel(organizationType);
            return ViewEditOrganizationType(viewModel);
        }

        [HttpPost]
        [OrganizationAndRelationshipTypeManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditOrganizationType(OrganizationTypePrimaryKey organizationTypePrimaryKey, EditOrganizationTypeViewModel viewModel)
        {
            var organizationType = organizationTypePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditOrganizationType(viewModel);
            }
            viewModel.UpdateModel(organizationType, CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewNewOrganizationType(EditOrganizationTypeViewModel viewModel)
        {
            return ViewEditOrganizationType(viewModel);
        }

        private PartialViewResult ViewEditOrganizationType(EditOrganizationTypeViewModel viewModel)
        {            
            var viewData = new EditOrganizationTypeViewData();
            return RazorPartialView<EditOrganizationType, EditOrganizationTypeViewData, EditOrganizationTypeViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [OrganizationAndRelationshipTypeManageFeature]
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
                ? $"Are you sure you want to delete this {fieldDefinitionLabel} '{organizationType.OrganizationTypeName}'?"
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage(fieldDefinitionLabel, SitkaRoute<OrganizationAndRelationshipTypeController>.BuildLinkFromExpression(x => x.Index(), "here"));

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [OrganizationAndRelationshipTypeManageFeature]
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

        [HttpGet]
        [OrganizationAndRelationshipTypeManageFeature]
        public PartialViewResult NewRelationshipType()
        {
            var viewModel = new EditRelationshipTypeViewModel();
            return ViewNewRelationshipType(viewModel);
        }

        [HttpPost]
        [OrganizationAndRelationshipTypeManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult NewRelationshipType(EditRelationshipTypeViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewNewRelationshipType(viewModel);
            }
            var relationshipType = new RelationshipType(viewModel.RelationshipTypeName, false, false);
            HttpRequestStorage.DatabaseEntities.AllRelationshipTypes.Add(relationshipType);
            HttpRequestStorage.DatabaseEntities.SaveChanges();

            HttpRequestStorage.DatabaseEntities.OrganizationTypeRelationshipTypes.Load();
            var organizationTypeRelationshipTypes = HttpRequestStorage.DatabaseEntities.AllOrganizationTypeRelationshipTypes.Local;

            viewModel.UpdateModel(relationshipType, organizationTypeRelationshipTypes);
            
            SetMessageForDisplay(
                $"New {FieldDefinition.ProjectRelationshipType.GetFieldDefinitionLabel()} {relationshipType.RelationshipTypeName} successfully created!");
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [OrganizationAndRelationshipTypeManageFeature]
        public PartialViewResult EditRelationshipType(RelationshipTypePrimaryKey relationshipTypePrimaryKey)
        {
            var relationshipType = relationshipTypePrimaryKey.EntityObject;
            var viewModel = new EditRelationshipTypeViewModel(relationshipType);
            return ViewEditRelationshipType(viewModel);
        }

        [HttpPost]
        [OrganizationAndRelationshipTypeManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditRelationshipType(RelationshipTypePrimaryKey relationshipTypePrimaryKey, EditRelationshipTypeViewModel viewModel)
        {
            var relationshipType = relationshipTypePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditRelationshipType(viewModel);
            }

            HttpRequestStorage.DatabaseEntities.OrganizationTypeRelationshipTypes.Load();
            var organizationTypeRelationshipTypes = HttpRequestStorage.DatabaseEntities.AllOrganizationTypeRelationshipTypes.Local;

            viewModel.UpdateModel(relationshipType, organizationTypeRelationshipTypes);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewNewRelationshipType(EditRelationshipTypeViewModel viewModel)
        {
            return ViewEditRelationshipType(viewModel);
        }

        private PartialViewResult ViewEditRelationshipType(EditRelationshipTypeViewModel viewModel)
        {
            var allOrganizationTypes = HttpRequestStorage.DatabaseEntities.OrganizationTypes.ToList();
            var viewData = new EditRelationshipTypeViewData(allOrganizationTypes);
            return RazorPartialView<EditRelationshipType, EditRelationshipTypeViewData, EditRelationshipTypeViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [OrganizationAndRelationshipTypeManageFeature]
        public PartialViewResult DeleteRelationshipType(RelationshipTypePrimaryKey relationshipTypePrimaryKey)
        {
            var relationshipType = relationshipTypePrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(relationshipType.RelationshipTypeID);
            return ViewDeleteRelationshipType(relationshipType, viewModel);
        }

        private PartialViewResult ViewDeleteRelationshipType(RelationshipType relationshipType, ConfirmDialogFormViewModel viewModel)
        {
            var canDelete = relationshipType.CanDelete();
            var confirmMessage = canDelete
                ? $"Are you sure you want to delete this {FieldDefinition.ProjectRelationshipType.GetFieldDefinitionLabel()} '{relationshipType.RelationshipTypeName}'?"
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage(FieldDefinition.ProjectRelationshipType.GetFieldDefinitionLabel(), SitkaRoute<OrganizationAndRelationshipTypeController>.BuildLinkFromExpression(x => x.Index(), "here"));

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [OrganizationAndRelationshipTypeManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteRelationshipType(RelationshipTypePrimaryKey relationshipTypePrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var relationshipType = relationshipTypePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteRelationshipType(relationshipType, viewModel);
            }

            relationshipType.OrganizationTypeRelationshipTypes.DeleteOrganizationTypeRelationshipType();
            relationshipType.DeleteRelationshipType();
            return new ModalDialogFormJsonResult();
        }

    }
}
