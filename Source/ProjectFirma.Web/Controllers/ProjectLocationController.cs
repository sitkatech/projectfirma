/*-----------------------------------------------------------------------
<copyright file="ProjectLocationController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Views.Shared.ProjectControls;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using LtInfo.Common;
using LtInfo.Common.DbSpatial;
using LtInfo.Common.Mvc;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Map;

namespace ProjectFirma.Web.Controllers
{
    public class ProjectLocationController : FirmaBaseController
    {
        public const string EditProjectBoundingBoxFormID = "EditProjectBoundingBoxForm";

        [HttpGet]
        [ProjectEditAsAdminFeature]
        public PartialViewResult EditProjectLocationSimple(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var viewModel = new ProjectLocationSimpleViewModel(project.ProjectLocationPoint, project.ProjectLocationSimpleType.ToEnum, project.ProjectLocationNotes);
            return ViewEditProjectLocationSummaryPoint(project, viewModel);
        }

        private PartialViewResult ViewEditProjectLocationSummaryPoint(Project project, ProjectLocationSimpleViewModel viewModel)
        {
            var layerGeoJsons = MapInitJson.GetAllGeospatialAreaMapLayers(LayerInitialVisibility.Hide);
            var mapInitJson = new MapInitJson($"project_{project.ProjectID}_EditMap", 10, layerGeoJsons, BoundingBox.MakeNewDefaultBoundingBox(), false) {AllowFullScreen = false, DisablePopups = true};
            var tenantAttribute = MultiTenantHelpers.GetTenantAttribute();
            var mapPostUrl = SitkaRoute<ProjectLocationController>.BuildUrlFromExpression(c => c.EditProjectLocationSimple(project, null));
            var mapFormID = GenerateEditProjectLocationFormID(project.ProjectID);
            var geospatialAreaTypes = HttpRequestStorage.DatabaseEntities.GeospatialAreaTypes.OrderBy(x => x.GeospatialAreaTypeName)
                .ToList();
            var viewData = new ProjectLocationSimpleViewData(CurrentPerson, mapInitJson, geospatialAreaTypes, null, mapPostUrl, mapFormID);
            return RazorPartialView<ProjectLocationSimple, ProjectLocationSimpleViewData, ProjectLocationSimpleViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProjectEditAsAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditProjectLocationSimple(ProjectPrimaryKey projectPrimaryKey, ProjectLocationSimpleViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEditProjectLocationSummaryPoint(projectPrimaryKey.EntityObject, viewModel);
            }
            viewModel.UpdateModel(projectPrimaryKey.EntityObject);
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [ProjectEditAsAdminFeature]
        public PartialViewResult EditProjectLocationDetailed(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var viewModel = new ProjectLocationDetailViewModel();
            return ViewEditProjectLocationDetailed(project, viewModel);
        }

        private PartialViewResult ViewEditProjectLocationDetailed(Project project, ProjectLocationDetailViewModel viewModel)
        {
            var mapDivID = $"project_{project.GetEntityID()}_EditDetailedMap";
            var detailedLocationGeoJsonFeatureCollection = project.DetailedLocationToGeoJsonFeatureCollection();
            var editableLayerGeoJson = new LayerGeoJson($"{FieldDefinitionEnum.ProjectLocation.ToType().GetFieldDefinitionLabel()} Detail", detailedLocationGeoJsonFeatureCollection, "red", 1, LayerInitialVisibility.Show);

            var layers = MapInitJson.GetAllGeospatialAreaMapLayers(LayerInitialVisibility.Show);
            layers.AddRange(MapInitJson.GetProjectLocationSimpleMapLayer(project));
            var boundingBox = ProjectLocationSummaryMapInitJson.GetProjectBoundingBox(project);
            var mapInitJson = new MapInitJson(mapDivID, 10, layers, boundingBox)
            {
                AllowFullScreen = false,
                DisablePopups = true
            };

            var mapFormID = GenerateEditProjectLocationFormID(project.GetEntityID());
            var uploadGisFileUrl = SitkaRoute<ProjectLocationController>.BuildUrlFromExpression(c => c.ImportGdbFile(project.GetEntityID()));
            var saveFeatureCollectionUrl = SitkaRoute<ProjectLocationController>.BuildUrlFromExpression(x => x.EditProjectLocationDetailed(project.GetEntityID(), null));

            var hasSimpleLocationPoint = project.ProjectLocationPoint != null;

            var viewData = new ProjectLocationDetailViewData(project.GetEntityID(), mapInitJson, editableLayerGeoJson, uploadGisFileUrl, mapFormID, saveFeatureCollectionUrl, ProjectLocation.FieldLengths.Annotation, hasSimpleLocationPoint);
            return RazorPartialView<ProjectLocationDetail, ProjectLocationDetailViewData, ProjectLocationDetailViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProjectEditAsAdminFeature]
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
        [ProjectEditAsAdminFeature]
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

        [HttpPost]
        [ProjectEditAsAdminFeature]
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
                foreach (var projectLocationStaging in project.ProjectLocationStagings.ToList())
                {
                    projectLocationStaging.DeleteFull(HttpRequestStorage.DatabaseEntities);
                }
                ProjectLocationStagingModelExtensions.CreateProjectLocationStagingListFromGdb(gdbFile, httpPostedFileBase.FileName, project, CurrentPerson);
            }
            return ApproveGisUpload(project);
        }

        [HttpGet]
        [ProjectEditAsAdminFeature]
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

            var mapInitJson = new MapInitJson($"project_{project.ProjectID}_PreviewMap", 10, layerGeoJsons, boundingBox, false) { AllowFullScreen = false, DisablePopups = true};
            var mapFormID = GenerateEditProjectLocationFormID(((IProject)project).GetEntityID());
            var approveGisUploadUrl = SitkaRoute<ProjectLocationController>.BuildUrlFromExpression(x => x.ApproveGisUpload(project, null));

            var viewData = new ApproveGisUploadViewData(new List<IProjectLocationStaging>(projectLocationStagings), mapInitJson, mapFormID, approveGisUploadUrl);
            return RazorPartialView<ApproveGisUpload, ApproveGisUploadViewData, ProjectLocationDetailViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProjectEditAsAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult ApproveGisUpload(ProjectPrimaryKey projectPrimaryKey, ProjectLocationDetailViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewApproveGisUpload(project, viewModel);
            }
            SaveProjectDetailedLocations(viewModel, project);
            DbSpatialHelper.Reduce(new List<IHaveDbGeometry>(project.ProjectLocations.ToList()));
            return EditProjectLocationDetailed(projectPrimaryKey);
        }

        private static void SaveProjectDetailedLocations(ProjectLocationDetailViewModel viewModel, Project project)
        {
            foreach (var projectLocation in project.ProjectLocations.ToList())
            {
                projectLocation.DeleteFull(HttpRequestStorage.DatabaseEntities);
            }
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

        [HttpGet]
        [ProjectEditAsAdminFeature]
        public PartialViewResult EditProjectBoundingBox(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var viewModel = new EditProjectBoundingBoxViewModel(project);
            return ViewEditProjectBoundingBox(project, viewModel);
        }

        [HttpPost]
        [ProjectEditAsAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditProjectBoundingBox(ProjectPrimaryKey projectPrimaryKey, EditProjectBoundingBoxViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditProjectBoundingBox(project, viewModel);
            }

            viewModel.UpdateModel(project);
            SetMessageForDisplay($"The custom map extent for {project.ProjectName} has been successfully updated.");

            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditProjectBoundingBox(Project project, EditProjectBoundingBoxViewModel viewModel)
        {
            var layerGeoJsons = new List<LayerGeoJson>
                {
                    project.HasProjectLocationPoint
                        ? new LayerGeoJson("Simple Location", project.SimpleLocationToGeoJsonFeatureCollection(true),
                            FirmaHelpers.DefaultColorRange[1], 0.8m, LayerInitialVisibility.Show)
                        : null,
                    project.HasProjectLocationDetail
                        ? new LayerGeoJson("Detailed Location", project.DetailedLocationToGeoJsonFeatureCollection(),
                            FirmaHelpers.DefaultColorRange[1], 0.8m, LayerInitialVisibility.Show)
                        : null
                }
                .Where(x => x != null)
                .ToList();

            foreach (var geospatialAreaType in HttpRequestStorage.DatabaseEntities.GeospatialAreaTypes.ToList().OrderBy(x => x.GeospatialAreaTypeName).ToList())
            {
                layerGeoJsons.Add(geospatialAreaType.GetGeospatialAreaWmsLayerGeoJson("#90C3D4", 0.1m, LayerInitialVisibility.Hide));
            }
            var boundingBox = BoundingBox.MakeBoundingBoxFromProject(project);
            var mapInitJson = new MapInitJson("EditProjectBoundingBoxMap", 10, layerGeoJsons, boundingBox)
            {
                AllowFullScreen = false,
                DisablePopups = true
            };
            var editProjectBoundingBoxUrl =
                SitkaRoute<ProjectLocationController>.BuildUrlFromExpression(c => c.EditProjectBoundingBox(project));

            var viewData = new EditProjectBoundingBoxViewData(mapInitJson, editProjectBoundingBoxUrl, EditProjectBoundingBoxFormID);
            return RazorPartialView<EditProjectBoundingBox, EditProjectBoundingBoxViewData, EditProjectBoundingBoxViewModel>(viewData, viewModel);
        }
    }
}
