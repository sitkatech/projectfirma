/*-----------------------------------------------------------------------
<copyright file="ProjectLocationController.cs" company="Tahoe Regional Planning Agency">
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
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared.ProjectControls;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using ProjectFirma.Web.Security.Shared;
using LtInfo.Common;
using LtInfo.Common.DbSpatial;
using LtInfo.Common.GeoJson;
using LtInfo.Common.MvcResults;

namespace ProjectFirma.Web.Controllers
{
    public class ProjectLocationController : FirmaBaseController
    {
        [HttpGet]
        [ProjectMapManageFeature]
        public PartialViewResult EditProjectLocationSimple(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var viewModel = new EditProjectLocationSimpleViewModel(project.ProjectLocationPoint, project.ProjectLocationAreaID, project.ProjectLocationSimpleType.ToEnum, project.ProjectLocationNotes);
            return ViewEditProjectLocationSummaryPoint(project, viewModel);
        }

        private PartialViewResult ViewEditProjectLocationSummaryPoint(Project project, EditProjectLocationSimpleViewModel viewModel)
        {
            var layerGeoJsons = MapInitJson.GetWatershedMapLayers();
            var mapInitJson = new MapInitJson($"project_{project.ProjectID}_EditMap", 10, layerGeoJsons, BoundingBox.MakeNewDefaultBoundingBox(), false) {AllowFullScreen = false};
            var mapPostUrl = SitkaRoute<ProjectLocationController>.BuildUrlFromExpression(x => x.EditProjectLocationSimple(project, null));
            var mapFormID = GenerateEditProjectLocationFormID(project.ProjectID);
            var tenantAttribute = HttpRequestStorage.Tenant.GetTenantAttribute();
            var geometry = HttpRequestStorage.DatabaseEntities.ProjectLocationAreas.FirstOrDefault(x => x.ProjectLocationAreaID == viewModel.ProjectLocationAreaID)?.GetGeometry();
            var initiallySelectedProjectLocationFeature = geometry != null ? DbGeometryToGeoJsonHelper.FromDbGeometry(geometry) : null;

            var viewData = new EditProjectLocationSimpleViewData(CurrentPerson, mapInitJson, mapPostUrl, mapFormID, tenantAttribute.WatershedLayerName, tenantAttribute.MapServiceUrl, initiallySelectedProjectLocationFeature);
            return RazorPartialView<EditProjectLocationSimple, EditProjectLocationSimpleViewData, EditProjectLocationSimpleViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProjectMapManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditProjectLocationSimple(ProjectPrimaryKey projectPrimaryKey, EditProjectLocationSimpleViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEditProjectLocationSummaryPoint(projectPrimaryKey.EntityObject, viewModel);
            }
            viewModel.UpdateModel(projectPrimaryKey.EntityObject);
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [ProjectLocationEditFeature]
        public PartialViewResult EditProjectLocationDetailed(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var viewModel = new ProjectLocationDetailViewModel();
            return ViewEditProjectLocationDetailed(project, viewModel);
        }

        private PartialViewResult ViewEditProjectLocationDetailed(IProject project, ProjectLocationDetailViewModel viewModel)
        {
            var mapDivID = $"project_{project.EntityID}_EditDetailedMap";
            var detailedLocationGeoJsonFeatureCollection = project.DetailedLocationToGeoJsonFeatureCollection();
            var editableLayerGeoJson = new LayerGeoJson($"{FieldDefinition.ProjectLocation.GetFieldDefinitionLabel()} Detail", detailedLocationGeoJsonFeatureCollection, "red", 1, LayerInitialVisibility.Show);

            var boundingBox = new BoundingBox(project.GetProjectLocationDetails().Select(x => x.ProjectLocationGeometry));
            var mapInitJson = new MapInitJson(mapDivID, 10, MapInitJson.GetWatershedAndProjectLocationSimpleMapLayers(project), boundingBox) {AllowFullScreen = false};

            var mapFormID = GenerateEditProjectLocationFormID(project.EntityID);
            var uploadGisFileUrl = SitkaRoute<ProjectLocationController>.BuildUrlFromExpression(c => c.ImportGdbFile(project.EntityID));
            var saveFeatureCollectionUrl = SitkaRoute<ProjectLocationController>.BuildUrlFromExpression(x => x.EditProjectLocationDetailed(project.EntityID, null));

            var hasSimpleLocationPoint = project.ProjectLocationPoint != null;

            var viewData = new ProjectLocationDetailViewData(project.EntityID, mapInitJson, editableLayerGeoJson, uploadGisFileUrl, mapFormID, saveFeatureCollectionUrl, ProjectLocation.FieldLengths.Annotation, hasSimpleLocationPoint);
            return RazorPartialView<ProjectLocationDetail, ProjectLocationDetailViewData, ProjectLocationDetailViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProjectLocationEditFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditProjectLocationDetailed(ProjectPrimaryKey projectPrimaryKey, ProjectLocationDetailViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditProjectLocationDetailed(project, viewModel);
            }
            SaveProjectDetailedLocations(viewModel, project);
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [ProjectLocationNewFeature]
        public PartialViewResult ImportGdbFile(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var viewModel = new ImportGdbFileViewModel();
            return ViewImportGdbFile(viewModel, project.ProjectID);
        }

        private PartialViewResult ViewImportGdbFile(ImportGdbFileViewModel viewModel, int projectID)
        {
            var mapFormID = GenerateEditProjectLocationFormID(projectID);
            var newGisUploadUrl = SitkaRoute<ProjectLocationController>.BuildUrlFromExpression(x => x.ImportGdbFile(projectID, null));
            var approveGisUploadUrl = SitkaRoute<ProjectLocationController>.BuildUrlFromExpression(x => x.ApproveGisUpload(projectID, null));
            var viewData = new ImportGdbFileViewData(mapFormID, newGisUploadUrl, approveGisUploadUrl);
            return RazorPartialView<ImportGdbFile, ImportGdbFileViewData, ImportGdbFileViewModel>(viewData, viewModel);
        }

        [AnonymousUnclassifiedFeature]
        public JsonNetJObjectResult GetProjectLocationAreaGeoJson(int? projectLocationAreaID)
        {
            var projectLocationArea = HttpRequestStorage.DatabaseEntities.ProjectLocationAreas.SingleOrDefault(x => x.ProjectLocationAreaID == projectLocationAreaID);

            return projectLocationArea == null ? null : new JsonNetJObjectResult(projectLocationArea.GetLayerGeoJson());
        }

        [HttpPost]
        [ProjectLocationNewFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult ImportGdbFile(ProjectPrimaryKey projectPrimaryKey, ImportGdbFileViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewImportGdbFile(viewModel, project.ProjectID);
            }

            var httpPostedFileBase = viewModel.FileResourceData;
            var fileEnding = ".gdb.zip";
            using (var disposableTempFile = DisposableTempFile.MakeDisposableTempFileEndingIn(fileEnding))
            {
                var gdbFile = disposableTempFile.FileInfo;
                httpPostedFileBase.SaveAs(gdbFile.FullName);
                project.ProjectLocationStagings.ToList().DeleteProjectLocationStaging();
                project.ProjectLocationStagings.Clear();
                ProjectLocationStaging.CreateProjectLocationStagingListFromGdb(gdbFile, project, CurrentPerson);
            }
            return ApproveGisUpload(project);
        }

        [HttpGet]
        [ProjectLocationNewFeature]
        public PartialViewResult ApproveGisUpload(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var viewModel = new ProjectLocationDetailViewModel();
            return ViewApproveGisUpload(project, viewModel);
        }

        private PartialViewResult ViewApproveGisUpload(Project project, ProjectLocationDetailViewModel viewModel)
        {
            var projectLocationStagings = project.ProjectLocationStagings.ToList();
            var layerGeoJsons =
                projectLocationStagings.Select(
                    (projectLocationStaging, i) =>
                        new LayerGeoJson(projectLocationStaging.FeatureClassName,
                            projectLocationStaging.ToGeoJsonFeatureCollection(),
                            FirmaHelpers.DefaultColorRange[i],
                            1,
                            LayerInitialVisibility.Show)).ToList();

            var boundingBox = BoundingBox.MakeBoundingBoxFromLayerGeoJsonList(layerGeoJsons);

            var mapInitJson = new MapInitJson($"project_{project.ProjectID}_PreviewMap", 10, layerGeoJsons, boundingBox, false) { AllowFullScreen = false };
            var mapFormID = GenerateEditProjectLocationFormID(((IProject)project).EntityID);
            var approveGisUploadUrl = SitkaRoute<ProjectLocationController>.BuildUrlFromExpression(x => x.ApproveGisUpload(project, null));

            var viewData = new ApproveGisUploadViewData(new List<IProjectLocationStaging>(projectLocationStagings), mapInitJson, mapFormID, approveGisUploadUrl);
            return RazorPartialView<ApproveGisUpload, ApproveGisUploadViewData, ProjectLocationDetailViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProjectLocationNewFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult ApproveGisUpload(ProjectPrimaryKey projectPrimaryKey, ProjectLocationDetailViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewApproveGisUpload(project, viewModel);
            }
            SaveProjectDetailedLocations(viewModel, project);
            DbSpatialHelper.Reduce(new List<IHaveSqlGeometry>(project.ProjectLocations.ToList()));
            return EditProjectLocationDetailed(projectPrimaryKey);
        }

        private static void SaveProjectDetailedLocations(ProjectLocationDetailViewModel viewModel, Project project)
        {
            var projectLocations = project.ProjectLocations.ToList();
            projectLocations.DeleteProjectLocation();
            project.ProjectLocations.Clear();
            if (viewModel.WktAndAnnotations != null)
            {
                foreach (var wktAndAnnotation in viewModel.WktAndAnnotations)
                {
                    project.ProjectLocations.Add(new ProjectLocation(project, DbGeometry.FromText(wktAndAnnotation.Wkt), wktAndAnnotation.Annotation));
                }
            }
        }

        public static string GenerateEditProjectLocationFormID(int projectID)
        {
            return $"editMapForProject{projectID}";
        }

        public ContentResult ProjectLocationAreaIDFromWatershedID(WatershedPrimaryKey watershedPrimaryKey)
        {
            return Content(watershedPrimaryKey.EntityObject.ProjectLocationAreas.Select(x => x.ProjectLocationAreaID).SingleOrDefault().ToString());
        }
    }
}
