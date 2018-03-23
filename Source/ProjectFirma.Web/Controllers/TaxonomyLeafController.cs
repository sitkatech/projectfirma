/*-----------------------------------------------------------------------
<copyright file="TaxonomyLeafController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Map;
using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using ProjectFirma.Web.Security.Shared;
using ProjectFirma.Web.Views.Shared;
using LtInfo.Common;
using LtInfo.Common.Mvc;
using LtInfo.Common.MvcResults;
using DetailViewData = ProjectFirma.Web.Views.TaxonomyLeaf.DetailViewData;
using Edit = ProjectFirma.Web.Views.TaxonomyLeaf.Edit;
using EditViewData = ProjectFirma.Web.Views.TaxonomyLeaf.EditViewData;
using EditViewModel = ProjectFirma.Web.Views.TaxonomyLeaf.EditViewModel;
using Index = ProjectFirma.Web.Views.TaxonomyLeaf.Index;
using IndexGridSpec = ProjectFirma.Web.Views.TaxonomyLeaf.IndexGridSpec;
using IndexViewData = ProjectFirma.Web.Views.TaxonomyLeaf.IndexViewData;
using Summary = ProjectFirma.Web.Views.TaxonomyLeaf.Detail;

namespace ProjectFirma.Web.Controllers
{
    public class TaxonomyLeafController : FirmaBaseController
    {
        [AnonymousUnclassifiedFeature]
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
            var firmaPage = FirmaPage.GetFirmaPageByPageType(FirmaPageType.TaxonomyLeafList);
            var viewData = new IndexViewData(CurrentPerson, firmaPage);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [AnonymousUnclassifiedFeature]
        public GridJsonNetJObjectResult<TaxonomyLeaf> IndexGridJsonData()
        {
            var gridSpec = new IndexGridSpec(CurrentPerson);
            var taxonomyLeafs = HttpRequestStorage.DatabaseEntities.TaxonomyLeafs.ToList().OrderBy(x => x.TaxonomyLeafName).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<TaxonomyLeaf>(taxonomyLeafs, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [AnonymousUnclassifiedFeature]
        public ViewResult Detail(TaxonomyLeafPrimaryKey taxonomyLeafPrimaryKey)
        {
            var taxonomyLeaf = taxonomyLeafPrimaryKey.EntityObject;

            var taxonomyLeafProjects = taxonomyLeaf.Projects.ToList();
            var projects = new List<IMappableProject>(taxonomyLeafProjects);

            var projectMapCustomization = new ProjectMapCustomization(ProjectLocationFilterType.TaxonomyLeaf, new List<int> {taxonomyLeaf.TaxonomyLeafID}, ProjectColorByType.ProjectStage);
            var projectLocationsLayerGeoJson = new LayerGeoJson($"{FieldDefinition.ProjectLocation.GetFieldDefinitionLabel()}", Project.MappedPointsToGeoJsonFeatureCollection(projects, true), "red", 1, LayerInitialVisibility.Show);
            var projectLocationsMapInitJson = new ProjectLocationsMapInitJson(projectLocationsLayerGeoJson, projectMapCustomization, "TaxonomyLeafProjectMap");

            var projectLocationsMapViewData = new ProjectLocationsMapViewData(projectLocationsMapInitJson.MapDivID, ProjectColorByType.ProjectStage.DisplayName, MultiTenantHelpers.GetTopLevelTaxonomyTiers(), CurrentPerson.CanViewProposals);

            var viewData = new DetailViewData(CurrentPerson, taxonomyLeaf, projectLocationsMapInitJson, projectLocationsMapViewData);

            return RazorView<Summary, DetailViewData>(viewData);
        }

        [HttpGet]
        [TaxonomyLeafManageFeature]
        public PartialViewResult New()
        {
            var viewModel = new EditViewModel();
            return ViewNew(viewModel);
        }

        [HttpPost]
        [TaxonomyLeafManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewNew(viewModel);
            }
            var taxonomyLeaf = new TaxonomyLeaf(viewModel.TaxonomyTierTwoID, string.Empty);
            viewModel.UpdateModel(taxonomyLeaf, CurrentPerson);
            HttpRequestStorage.DatabaseEntities.AllTaxonomyLeafs.Add(taxonomyLeaf);

            HttpRequestStorage.DatabaseEntities.SaveChanges();
            SetMessageForDisplay(string.Format("New {0} {1} successfully created!", FieldDefinition.TaxonomyLeaf.GetFieldDefinitionLabel(), taxonomyLeaf.GetDisplayNameAsUrl()));
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [TaxonomyLeafManageFeature]
        public PartialViewResult Edit(TaxonomyLeafPrimaryKey taxonomyLeafPrimaryKey)
        {
            var taxonomyLeaf = taxonomyLeafPrimaryKey.EntityObject;
            var viewModel = new EditViewModel(taxonomyLeaf);
            return ViewEdit(viewModel, taxonomyLeaf.TaxonomyTierTwo.DisplayName);
        }

        [HttpPost]
        [TaxonomyLeafManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(TaxonomyLeafPrimaryKey taxonomyLeafPrimaryKey, EditViewModel viewModel)
        {
            var taxonomyLeaf = taxonomyLeafPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel, taxonomyLeaf.TaxonomyTierTwo.DisplayName);
            }
            viewModel.UpdateModel(taxonomyLeaf, CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewNew(EditViewModel viewModel)
        {
            return ViewEdit(viewModel, string.Empty);
        }

        private PartialViewResult ViewEdit(EditViewModel viewModel, string taxonomyTierTwoDisplayName)
        {
            var taxonomyTierTwos = HttpRequestStorage.DatabaseEntities.TaxonomyTierTwos.ToList().OrderBy(x => x.DisplayName).ToSelectList(x => x.TaxonomyTierTwoID.ToString(CultureInfo.InvariantCulture), x => x.DisplayName);
            var viewData = new EditViewData(taxonomyTierTwos, taxonomyTierTwoDisplayName);
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [TaxonomyLeafManageFeature]
        public PartialViewResult DeleteTaxonomyLeaf(TaxonomyLeafPrimaryKey taxonomyLeafPrimaryKey)
        {
            var taxonomyLeaf = taxonomyLeafPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(taxonomyLeaf.TaxonomyLeafID);
            return ViewDeleteTaxonomyLeaf(taxonomyLeaf, viewModel);
        }

        private PartialViewResult ViewDeleteTaxonomyLeaf(TaxonomyLeaf taxonomyLeaf, ConfirmDialogFormViewModel viewModel)
        {
            var canDelete = !taxonomyLeaf.HasDependentObjects() && HttpRequestStorage.DatabaseEntities.TaxonomyLeafs.Count() > 1;
            var taxonomyLeafDisplayName = FieldDefinition.TaxonomyLeaf.GetFieldDefinitionLabel();
            var confirmMessage = canDelete
                ? string.Format("Are you sure you want to delete this {0} '{1}'?", taxonomyLeafDisplayName, taxonomyLeaf.DisplayName)
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage(taxonomyLeafDisplayName, SitkaRoute<TaxonomyLeafController>.BuildLinkFromExpression(x => x.Detail(taxonomyLeaf), "here"));

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [TaxonomyLeafManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteTaxonomyLeaf(TaxonomyLeafPrimaryKey taxonomyLeafPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var taxonomyLeaf = taxonomyLeafPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteTaxonomyLeaf(taxonomyLeaf, viewModel);
            }
            taxonomyLeaf.DeleteTaxonomyLeaf();
            return new ModalDialogFormJsonResult();
        }

        [TaxonomyLeafViewFeature]
        public GridJsonNetJObjectResult<Project> ProjectsGridJsonData(TaxonomyLeafPrimaryKey taxonomyLeafPrimaryKey)
        {
            var gridSpec = new BasicProjectInfoGridSpec(CurrentPerson, true);
            var projectTaxonomyLeafs = taxonomyLeafPrimaryKey.EntityObject.GetAssociatedProjects(CurrentPerson);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Project>(projectTaxonomyLeafs, gridSpec);
            return gridJsonNetJObjectResult;
        }
    }
}
