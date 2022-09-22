/*-----------------------------------------------------------------------
<copyright file="ProjectLocationController.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using LtInfo.Common;
using LtInfo.Common.DbSpatial;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.GeoJson;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Map;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using ProjectFirmaModels.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

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
            var viewModel = new ProjectLocationSimpleViewModel(project.GetProjectLocationPoint(true), project.ProjectLocationSimpleType.ToEnum, 
                project.ProjectLocationNotes, project.LocationIsPrivate);
            return ViewEditProjectLocationSummaryPoint(project, viewModel);
        }

        private PartialViewResult ViewEditProjectLocationSummaryPoint(Project project, ProjectLocationSimpleViewModel viewModel)
        {
            var layerGeoJsons = MapInitJson.GetConfiguredGeospatialAreaMapLayers();
            var mapInitJson = new MapInitJson($"project_{project.ProjectID}_EditMap", 10, layerGeoJsons, MapInitJson.GetExternalMapLayers(), BoundingBox.MakeNewDefaultBoundingBox(), false) {AllowFullScreen = false, DisablePopups = true};
            var mapPostUrl = SitkaRoute<ProjectLocationController>.BuildUrlFromExpression(c => c.EditProjectLocationSimple(project, null));
            var mapFormID = GenerateEditProjectLocationFormID(project.ProjectID);
            var geospatialAreaTypes = HttpRequestStorage.DatabaseEntities.GeospatialAreaTypes.OrderBy(x => x.GeospatialAreaTypeName)
                .ToList();
            var viewData = new ProjectLocationSimpleViewData(CurrentFirmaSession, mapInitJson, geospatialAreaTypes, null, mapPostUrl, mapFormID);
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
            var detailedLocationGeoJsonFeatureCollection = project.DetailedLocationToGeoJsonFeatureCollection(true);
            var editableLayerGeoJson = new LayerGeoJson($"{FieldDefinitionEnum.ProjectLocation.ToType().GetFieldDefinitionLabel()} Detail", detailedLocationGeoJsonFeatureCollection, "red", 1, LayerInitialVisibility.LayerInitialVisibilityEnum.Show);

            var layers = MapInitJson.GetConfiguredGeospatialAreaMapLayers();
            var userCanViewPrivateLocations = CurrentFirmaSession.UserCanViewPrivateLocations(project);
            layers.AddRange(MapInitJson.GetProjectLocationSimpleMapLayer(project, userCanViewPrivateLocations));
            var boundingBox = ProjectLocationSummaryMapInitJson.GetProjectBoundingBox(project, userCanViewPrivateLocations);
            var mapInitJson = new MapInitJson(mapDivID, 10, layers, MapInitJson.GetExternalMapLayers(), boundingBox)
            {
                AllowFullScreen = false,
                DisablePopups = true
            };

            var mapFormID = GenerateEditProjectLocationFormID(project.GetEntityID());
            var uploadGisFileUrl = SitkaRoute<ProjectLocationController>.BuildUrlFromExpression(c => c.ImportGdbFile(project.GetEntityID()));
            var saveFeatureCollectionUrl = SitkaRoute<ProjectLocationController>.BuildUrlFromExpression(x => x.EditProjectLocationDetailed(project.GetEntityID(), null));

            var hasSimpleLocationPoint = project.HasProjectLocationPoint(userCanViewPrivateLocations);

            var viewData = new ProjectLocationDetailViewData(project.GetEntityID(), mapInitJson, editableLayerGeoJson, uploadGisFileUrl, mapFormID, 
                saveFeatureCollectionUrl, ProjectLocation.FieldLengths.Annotation, hasSimpleLocationPoint, project.LocationIsPrivate);
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

            SaveProjectDetailedLocations(viewModel, project, out bool hadToMakeValid, out bool atLeastOneCouldNotBeCorrected);
            if (hadToMakeValid && !atLeastOneCouldNotBeCorrected)
            {
                SetWarningForDisplay("One or more of your hand drawn shapes had to be corrected in order to make it a valid geometry. Most likely this resulted in no noticeable changes, but please review the detailed location to verify.");
            }
            if (atLeastOneCouldNotBeCorrected && !hadToMakeValid)
            {
                SetWarningForDisplay("One or more of your hand drawn shapes could not be made into a valid geometry and was not saved. All other shapes were saved. Please review the detailed location to verify.");
            }

            if (atLeastOneCouldNotBeCorrected && hadToMakeValid)
            {
                SetWarningForDisplay("One or more of your hand drawn shapes had to be corrected in order to make it a valid geometry. Most likely this resulted in no noticeable changes." +
                                     " Additionally, one or more of your hand drawn shapes could not be made into a valid geometry and was not saved. All other shapes were saved. Please review the detailed location to verify.");
            }


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
            var isKml = httpPostedFileBase.FileName.EndsWith(".kml");
            var isKmz = httpPostedFileBase.FileName.EndsWith(".kmz");
            var fileEnding = isKml ? ".kml" : isKmz ? ".kmz" : ".gdb.zip";
            using (var disposableTempFile = DisposableTempFile.MakeDisposableTempFileEndingIn(fileEnding))
            {
                var disposableTempFileFileInfo = disposableTempFile.FileInfo;
                httpPostedFileBase.SaveAs(disposableTempFileFileInfo.FullName);
                foreach (var projectLocationStaging in project.ProjectLocationStagings.ToList())
                {
                    projectLocationStaging.DeleteFull(HttpRequestStorage.DatabaseEntities);
                }

                try
                {
                    if (isKml)
                    {
                        ProjectLocationStagingModelExtensions.CreateProjectLocationStagingListFromKml(
                            disposableTempFileFileInfo, httpPostedFileBase.FileName, project, CurrentFirmaSession);
                    }
                    else if (isKmz)
                    {
                        ProjectLocationStagingModelExtensions.CreateProjectLocationStagingListFromKmz(
                            disposableTempFileFileInfo, httpPostedFileBase.FileName, project, CurrentFirmaSession);
                    }
                    else
                    {
                        ProjectLocationStagingModelExtensions.CreateProjectLocationStagingListFromGdb(
                            disposableTempFileFileInfo, httpPostedFileBase.FileName, project, CurrentFirmaSession);
                    }
                    // Run a quick test to see if the uploaded geometries are going to be reducible later.
                    // If they aren't, we can throw the SitkaGeometryDisplayErrorException to capture a record of the uploaded file.
                    var mockGeometries = project.ProjectLocationStagings.SelectMany(x =>
                        x.ToGeoJsonFeatureCollection().Features.Select(y => y.ToSqlGeometry())).ToList();
                    Check.Assert(DbSpatialHelper.CanReduce(mockGeometries), new SitkaGeometryDisplayErrorException("Could not reduce the uploaded geometries."));
                }
                catch (SitkaGeometryDisplayErrorException exception)
                {
                    string preservedFilenameFullPath = ProjectLocationStagingModelExtensions.PreserveFailedLocationImportFile(httpPostedFileBase);
                    throw new SitkaGeometryDisplayErrorException(exception.Message, preservedFilenameFullPath);
                }
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
                            LayerInitialVisibility.LayerInitialVisibilityEnum.Show)).ToList();

            var showFeatureClassColumn = projectLocationStagings.Any(x => x.FeatureClassName.Length > 0);

            var boundingBox = BoundingBox.MakeBoundingBoxFromLayerGeoJsonList(layerGeoJsons);

            var mapInitJson = new MapInitJson($"project_{project.ProjectID}_PreviewMap", 10, layerGeoJsons, MapInitJson.GetExternalMapLayers(), boundingBox, false) { AllowFullScreen = false, DisablePopups = true};
            var mapFormID = GenerateEditProjectLocationFormID(((IProject)project).GetEntityID());
            var approveGisUploadUrl = SitkaRoute<ProjectLocationController>.BuildUrlFromExpression(x => x.ApproveGisUpload(project, null));

            var viewData = new ApproveGisUploadViewData(new List<IProjectLocationStaging>(projectLocationStagings), mapInitJson, mapFormID, approveGisUploadUrl, showFeatureClassColumn);
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
            SaveProjectDetailedLocations(viewModel, project, out bool hadToMakeValid, out bool atLeastOneCouldNotBeCorrected);
            if (hadToMakeValid && !atLeastOneCouldNotBeCorrected)
            {
                SetWarningForDisplay("One or more of your imported shapes had to be corrected in order to make it a valid geometry. Most likely this resulted in no noticeable changes, but please review the detailed location to verify.");
            }
            if (atLeastOneCouldNotBeCorrected && !hadToMakeValid)
            {
                SetWarningForDisplay("One or more of your imported shapes could not be made into a valid geometry and was not saved. All other shapes were saved. Please review the detailed location to verify.");
            }

            if (atLeastOneCouldNotBeCorrected && hadToMakeValid)
            {
                SetWarningForDisplay("One or more of your imported shapes had to be corrected in order to make it a valid geometry. Most likely this resulted in no noticeable changes." +
                                     " Additionally, one or more of your imported shapes could not be made into a valid geometry and was not saved. All other shapes were saved. Please review the detailed location to verify.");
            }
            DbSpatialHelper.Reduce(new List<IHaveSqlGeometry>(project.GetProjectLocationDetailed(true).ToList()));
            return new ModalDialogFormJsonResult();
        }

        private static void SaveProjectDetailedLocations(ProjectLocationDetailViewModel viewModel, Project project, out bool hadToMakeValid, out bool atLeastOneCouldNotBeCorrected)
        {
            foreach (var projectLocation in project.GetProjectLocationDetailedAsProjectLocations(true).ToList())
            {
                projectLocation.DeleteFull(HttpRequestStorage.DatabaseEntities);
            }

            hadToMakeValid = false;
            atLeastOneCouldNotBeCorrected = false;

            

            if (viewModel.WktAndAnnotations != null)
            {
                var dbGeomsToAdd =
                    ProjectCreateController.MakeValidDbGeometriesFromWellKnownTextAndAnnotations(
                        viewModel.WktAndAnnotations, out hadToMakeValid, out atLeastOneCouldNotBeCorrected);
                foreach (var dbGeomTuple in dbGeomsToAdd)
                {
                    project.ProjectLocations.Add(new ProjectLocation(project, dbGeomTuple.Item1, dbGeomTuple.Item2));
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
            var userCanViewPrivateLocations = CurrentFirmaSession.UserCanViewPrivateLocations(project);
            var layerGeoJsons = new List<LayerGeoJson>
                {
                    project.HasProjectLocationPoint(userCanViewPrivateLocations)
                        ? new LayerGeoJson("Simple Location", project.SimpleLocationToGeoJsonFeatureCollection(userCanViewPrivateLocations, true),
                            FirmaHelpers.DefaultColorRange[1], 0.8m, LayerInitialVisibility.LayerInitialVisibilityEnum.Show)
                        : null,
                    project.HasProjectLocationDetailed(userCanViewPrivateLocations)
                        ? new LayerGeoJson("Detailed Location", project.DetailedLocationToGeoJsonFeatureCollection(userCanViewPrivateLocations),
                            FirmaHelpers.DefaultColorRange[1], 0.8m, LayerInitialVisibility.LayerInitialVisibilityEnum.Show)
                        : null
                }
                .Where(x => x != null)
                .ToList();

            foreach (var geospatialAreaType in HttpRequestStorage.DatabaseEntities.GeospatialAreaTypes.ToList().OrderBy(x => x.GeospatialAreaTypeName).ToList())
            {
                layerGeoJsons.Add(geospatialAreaType.GetGeospatialAreaWmsLayerGeoJson("#90C3D4", 0.1m, LayerInitialVisibility.LayerInitialVisibilityEnum.Hide));
            }
            var boundingBox = BoundingBox.MakeBoundingBoxFromProject(project, userCanViewPrivateLocations);
            var mapInitJson = new MapInitJson("EditProjectBoundingBoxMap", 10, layerGeoJsons, MapInitJson.GetExternalMapLayers(), boundingBox)
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
