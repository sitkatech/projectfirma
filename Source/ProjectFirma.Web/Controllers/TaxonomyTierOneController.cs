/*-----------------------------------------------------------------------
<copyright file="TaxonomyTierOneController.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
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
using DetailViewData = ProjectFirma.Web.Views.TaxonomyTierOne.DetailViewData;
using Edit = ProjectFirma.Web.Views.TaxonomyTierOne.Edit;
using EditViewData = ProjectFirma.Web.Views.TaxonomyTierOne.EditViewData;
using EditViewModel = ProjectFirma.Web.Views.TaxonomyTierOne.EditViewModel;
using Index = ProjectFirma.Web.Views.TaxonomyTierOne.Index;
using IndexGridSpec = ProjectFirma.Web.Views.TaxonomyTierOne.IndexGridSpec;
using IndexViewData = ProjectFirma.Web.Views.TaxonomyTierOne.IndexViewData;
using Summary = ProjectFirma.Web.Views.TaxonomyTierOne.Detail;

namespace ProjectFirma.Web.Controllers
{
    public class TaxonomyTierOneController : FirmaBaseController
    {
        [AnonymousUnclassifiedFeature]
        public ViewResult Index()
        {
            return IndexImpl();
        }

        [AdminFeature]
        public ViewResult Manage()
        {
            return IndexImpl();
        }

        private ViewResult IndexImpl()
        {
            var firmaPage = FirmaPage.GetFirmaPageByPageType(FirmaPageType.TaxonomyTierOneList);
            var viewData = new IndexViewData(CurrentPerson, firmaPage);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [AnonymousUnclassifiedFeature]
        public GridJsonNetJObjectResult<TaxonomyTierOne> IndexGridJsonData()
        {
            var hasDeletePermission = new TaxonomyTierOneManageFeature().HasPermissionByPerson(CurrentPerson);
            var gridSpec = new IndexGridSpec(hasDeletePermission);
            var taxonomyTierOnes = HttpRequestStorage.DatabaseEntities.TaxonomyTierOnes.ToList().OrderBy(x => x.TaxonomyTierOneName).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<TaxonomyTierOne>(taxonomyTierOnes, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [AnonymousUnclassifiedFeature]
        public ViewResult Detail(TaxonomyTierOnePrimaryKey taxonomyTierOnePrimaryKey)
        {
            var taxonomyTierOne = taxonomyTierOnePrimaryKey.EntityObject;

            var taxonomyTierOneProjects = taxonomyTierOne.Projects.ToList();
            var projects = IsCurrentUserAnonymous() ? taxonomyTierOneProjects.Where(p => p.IsVisibleToEveryone()).ToList() : taxonomyTierOneProjects;

            var projectMapCustomization = new ProjectMapCustomization(ProjectLocationFilterType.TaxonomyTierOne, new List<int> {taxonomyTierOne.TaxonomyTierOneID}, ProjectColorByType.ProjectStage);
            var projectLocationsLayerGeoJson = new LayerGeoJson("Project Locations", Project.MappedPointsToGeoJsonFeatureCollection(projects, true), "red", 1, LayerInitialVisibility.Show);
            var namedAreasAsPointsLayerGeoJson = new LayerGeoJson("Named Areas", Project.NamedAreasToPointGeoJsonFeatureCollection(projects, true), "red", 1, LayerInitialVisibility.Show);
            var projectLocationsMapInitJson = new ProjectLocationsMapInitJson(projectLocationsLayerGeoJson, namedAreasAsPointsLayerGeoJson, projectMapCustomization, "TaxonomyTierOneProjectMap");

            var projectLocationsMapViewData = new ProjectLocationsMapViewData(projectLocationsMapInitJson.MapDivID, ProjectColorByType.ProjectStage.DisplayName, HttpRequestStorage.DatabaseEntities.TaxonomyTierThrees.ToList());

            var viewData = new DetailViewData(CurrentPerson, taxonomyTierOne, projectLocationsMapInitJson, projectLocationsMapViewData);

            return RazorView<Summary, DetailViewData>(viewData);
        }

        [HttpGet]
        [TaxonomyTierOneManageFeature]
        public PartialViewResult New()
        {
            var viewModel = new EditViewModel();
            return ViewNew(viewModel);
        }

        [HttpPost]
        [TaxonomyTierOneManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewNew(viewModel);
            }
            var taxonomyTierOne = new TaxonomyTierOne(viewModel.TaxonomyTierTwoID, string.Empty);
            viewModel.UpdateModel(taxonomyTierOne, CurrentPerson);
            HttpRequestStorage.DatabaseEntities.AllTaxonomyTierOnes.Add(taxonomyTierOne);

            HttpRequestStorage.DatabaseEntities.SaveChanges();
            SetMessageForDisplay(string.Format("New {0} {1} successfully created!", MultiTenantHelpers.GetTaxonomyTierOneDisplayName(), taxonomyTierOne.GetDisplayNameAsUrl()));
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [TaxonomyTierOneManageFeature]
        public PartialViewResult Edit(TaxonomyTierOnePrimaryKey taxonomyTierOnePrimaryKey)
        {
            var taxonomyTierOne = taxonomyTierOnePrimaryKey.EntityObject;
            var viewModel = new EditViewModel(taxonomyTierOne);
            return ViewEdit(viewModel, taxonomyTierOne.Projects.Any(), taxonomyTierOne.TaxonomyTierTwo.DisplayName);
        }

        [HttpPost]
        [TaxonomyTierOneManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(TaxonomyTierOnePrimaryKey taxonomyTierOnePrimaryKey, EditViewModel viewModel)
        {
            var taxonomyTierOne = taxonomyTierOnePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel, taxonomyTierOne.Projects.Any(), taxonomyTierOne.TaxonomyTierTwo.DisplayName);
            }
            viewModel.UpdateModel(taxonomyTierOne, CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewNew(EditViewModel viewModel)
        {
            return ViewEdit(viewModel, false, string.Empty);
        }

        private PartialViewResult ViewEdit(EditViewModel viewModel, bool hasProjects, string taxonomyTierTwoDisplayName)
        {
            var taxonomyTierTwos = HttpRequestStorage.DatabaseEntities.TaxonomyTierTwos.ToList().OrderBy(x => x.DisplayName).ToSelectList(x => x.TaxonomyTierTwoID.ToString(CultureInfo.InvariantCulture), x => x.DisplayName);
            var viewData = new EditViewData(taxonomyTierTwos, taxonomyTierTwoDisplayName, hasProjects);
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [TaxonomyTierOneManageFeature]
        public PartialViewResult DeleteTaxonomyTierOne(TaxonomyTierOnePrimaryKey taxonomyTierOnePrimaryKey)
        {
            var taxonomyTierOne = taxonomyTierOnePrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(taxonomyTierOne.TaxonomyTierOneID);
            return ViewDeleteTaxonomyTierOne(taxonomyTierOne, viewModel);
        }

        private PartialViewResult ViewDeleteTaxonomyTierOne(TaxonomyTierOne taxonomyTierOne, ConfirmDialogFormViewModel viewModel)
        {
            var canDelete = !taxonomyTierOne.HasDependentObjects() && HttpRequestStorage.DatabaseEntities.TaxonomyTierOnes.Count() > 1;
            var confirmMessage = canDelete
                ? string.Format("Are you sure you want to delete this {0} '{1}'?", MultiTenantHelpers.GetTaxonomyTierOneDisplayName(), taxonomyTierOne.DisplayName)
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage(MultiTenantHelpers.GetTaxonomyTierOneDisplayName(), SitkaRoute<TaxonomyTierOneController>.BuildLinkFromExpression(x => x.Detail(taxonomyTierOne), "here"));

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [TaxonomyTierOneManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteTaxonomyTierOne(TaxonomyTierOnePrimaryKey taxonomyTierOnePrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var taxonomyTierOne = taxonomyTierOnePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteTaxonomyTierOne(taxonomyTierOne, viewModel);
            }
            taxonomyTierOne.DeleteTaxonomyTierOne();
            return new ModalDialogFormJsonResult();
        }

        [TaxonomyTierOneViewFeature]
        public GridJsonNetJObjectResult<Project> ProjectsGridJsonData(TaxonomyTierOnePrimaryKey taxonomyTierOnePrimaryKey)
        {
            BasicProjectInfoGridSpec gridSpec;
            var projectTaxonomyTierOnes = GetProjectsAndGridSpec(out gridSpec, taxonomyTierOnePrimaryKey.EntityObject);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Project>(projectTaxonomyTierOnes, gridSpec);
            return gridJsonNetJObjectResult;
        }

        private List<Project> GetProjectsAndGridSpec(out BasicProjectInfoGridSpec gridSpec, TaxonomyTierOne taxonomyTierOne)
        {
            gridSpec = new BasicProjectInfoGridSpec(CurrentPerson, true);
            return taxonomyTierOne.Projects.OrderBy(x => x.DisplayName).ToList();
        }
    }
}
