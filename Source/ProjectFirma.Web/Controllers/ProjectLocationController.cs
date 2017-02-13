using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared.ProjectControls;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security.Shared;
using LtInfo.Common;
using LtInfo.Common.DbSpatial;
using LtInfo.Common.Mvc;
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
            var mapInitJson = new MapInitJson(string.Format("project_{0}_EditMap", project.ProjectID), 10, layerGeoJsons, BoundingBox.MakeNewDefaultBoundingBox(), false) {AllowFullScreen = false};
            var projectLocationAreas = HttpRequestStorage.DatabaseEntities.ProjectLocationAreas.ToSelectList(x => x.ProjectLocationAreaID.ToString(), x => x.ProjectLocationAreaDisplayName);
            var mapPostUrl = SitkaRoute<ProjectLocationController>.BuildUrlFromExpression(x => x.EditProjectLocationSimple(project, null));
            var mapFormID = GenerateEditProjectLocationFormID(project.ProjectID);
            var viewData = new EditProjectLocationSimpleViewData(CurrentPerson, mapInitJson, projectLocationAreas, mapPostUrl, mapFormID);
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
            var mapDivID = string.Format("project_{0}_EditDetailedMap", project.EntityID);
            var detailedLocationGeoJsonFeatureCollection = project.DetailedLocationToGeoJsonFeatureCollection();
            var editableLayerGeoJson = new LayerGeoJson("Project Location Detail", detailedLocationGeoJsonFeatureCollection, "red", 1, LayerInitialVisibility.Show);

            var boundingBox = new BoundingBox(project.GetProjectLocationDetails().Select(x => x.ProjectLocationGeometry));
            var mapInitJson = new MapInitJson(mapDivID, 10, MapInitJson.GetWatershedMapLayers(), boundingBox) {AllowFullScreen = false};

            var mapFormID = GenerateEditProjectLocationFormID(project.EntityID);
            var uploadGisFileUrl = SitkaRoute<ProjectLocationController>.BuildUrlFromExpression(c => c.ImportGdbFile(project.EntityID));
            var saveFeatureCollectionUrl = SitkaRoute<ProjectLocationController>.BuildUrlFromExpression(x => x.EditProjectLocationDetailed(project.EntityID, null));
            var viewData = new ProjectLocationDetailViewData(project.EntityID, mapInitJson, editableLayerGeoJson, uploadGisFileUrl, mapFormID, saveFeatureCollectionUrl, ProjectLocation.FieldLengths.Annotation);
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
                HttpRequestStorage.DatabaseEntities.ProjectLocationStagings.DeleteProjectLocationStaging(project.ProjectLocationStagings.ToList());
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

            var mapInitJson = new MapInitJson(string.Format("project_{0}_PreviewMap", project.ProjectID), 10, layerGeoJsons, boundingBox, false) { AllowFullScreen = false };
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
            HttpRequestStorage.DatabaseEntities.ProjectLocations.DeleteProjectLocation(projectLocations);
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
            return string.Format("editMapForProject{0}", projectID);
        }
    }
}