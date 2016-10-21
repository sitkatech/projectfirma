using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Areas.EIP.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Areas.EIP.Views.Map;
using ProjectFirma.Web.Areas.EIP.Views.ProposedProject;
using ProjectFirma.Web.Areas.EIP.Views.Shared.EIPPerformanceMeasureControls;
using ProjectFirma.Web.Areas.EIP.Views.Shared.ProjectControls;
using ProjectFirma.Web.Areas.EIP.Views.Shared.ProjectLocationControls;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.TextControls;
using LtInfo.Common;
using LtInfo.Common.DbSpatial;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using LtInfo.Common.MvcResults;

namespace ProjectFirma.Web.Areas.EIP.Controllers
{
    public class ProposedProjectController : LakeTahoeInfoBaseController
    {
        [ProposedProjectsViewListFeature]
        public ViewResult Summary(ProposedProjectPrimaryKey proposedProjectPrimaryKey)
        {
            var proposedProject = proposedProjectPrimaryKey.EntityObject;
            var mapDivID = string.Format("proposedProject_{0}_Map", proposedProject.ProposedProjectID);
            var projectLocationSummaryMapInitJson = new ProjectLocationSummaryMapInitJson(proposedProject, mapDivID);
            var projectLocationSummaryViewData = new ProjectLocationSummaryViewData(proposedProject, projectLocationSummaryMapInitJson);
            var mapFormID = GenerateEditProjectLocationSimpleFormID(proposedProject);
            var eipPerformanceMeasureExpectedsSummaryViewData =
                new EIPPerformanceMeasureExpectedSummaryViewData(new List<IEIPPerformanceMeasureValue>(proposedProject.EIPPerformanceMeasureExpectedProposeds));
            var entityNotesViewData = new EntityNotesViewData(EntityNote.CreateFromEntityNote(new List<IEntityNote>(proposedProject.ProposedProjectNotes)),
                SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.NewNote(proposedProject)),
                proposedProject.DisplayName,
                true);

            var galleryName = string.Format("ProjectImage{0}", proposedProject.ProposedProjectID);
            var galleryImages = proposedProject.ProposedProjectImages.ToList();
            var imageGalleryViewData = new ImageGalleryViewData(CurrentPerson, galleryName, galleryImages, false, string.Empty, string.Empty, true, x => x.CaptionOnFullView, "Photo");

            var transportationGoals = HttpRequestStorage.DatabaseEntities.TransportationGoals.ToList();
            var transportationGoalsAsFancyTreeNodes = proposedProject.IsTransportationProject
                ? transportationGoals.Select(x => x.ToFancyTreeNode(new List<ITransportationQuestionAnswer>(proposedProject.ProposedProjectTransportationQuestions.ToList()))).ToList()
                : null;
            var transportationAssessmentTreeViewData = new TransportationAssessmentTreeViewData(transportationGoalsAsFancyTreeNodes);


            var viewData = new SummaryViewData(CurrentPerson,
                proposedProject,
                projectLocationSummaryViewData,
                eipPerformanceMeasureExpectedsSummaryViewData, imageGalleryViewData, entityNotesViewData, mapFormID, transportationAssessmentTreeViewData);
            return RazorView<Summary, SummaryViewData>(viewData);
        }

        [ProposedProjectsViewListFeature]
        public ViewResult Index()
        {
            var projectFirmaPage = ProjectFirmaPage.GetProjectFirmaPageByPageType(ProjectFirmaPageType.ProposedProjects);
            var viewData = new IndexViewData(CurrentPerson, projectFirmaPage);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [ProposedProjectsViewListFeature]
        public GridJsonNetJObjectResult<ProposedProject> IndexGridJsonData()
        {
            ProposedProjectGridSpec gridSpec;
            var programs = GetIndexGridSpec(CurrentPerson, out gridSpec);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<ProposedProject>(programs, gridSpec);
            return gridJsonNetJObjectResult;
        }

        private static List<ProposedProject> GetIndexGridSpec(Person currentPerson, out ProposedProjectGridSpec gridSpec)
        {
            gridSpec = new ProposedProjectGridSpec(currentPerson);
            return GetProposedProjectsForGrid(x => x.IsEditableToThisPerson(currentPerson));
        }

        public static List<ProposedProject> GetProposedProjectsForGrid(Func<ProposedProject, bool> filterFunction)
        {
            var watersheds = HttpRequestStorage.DatabaseEntities.Watersheds.GetWatershedsWithGeospatialFeatures();
            var jurisdictions = HttpRequestStorage.DatabaseEntities.Jurisdictions.GetJurisdictionsWithGeospatialFeatures();
            var stateProvinces = HttpRequestStorage.DatabaseEntities.StateProvinces.ToList();
            return
                HttpRequestStorage.DatabaseEntities.ProposedProjects.GetProposedProjectsWithGeoSpatialProperties(watersheds,
                    jurisdictions,
                    stateProvinces,
                    filterFunction).Where(x => x.ProposedProjectState != ProposedProjectState.Approved && x.ProposedProjectState != ProposedProjectState.Rejected).ToList();
        }

        [ProposedProjectCreateNewFeature]
        public ViewResult Instructions(int? proposedProjectID)
        {
            if (proposedProjectID.HasValue)
            {
                var proposedProject = HttpRequestStorage.DatabaseEntities.ProposedProjects.GetProposedProject(proposedProjectID.Value);

                var proposalSectionsStatus = new ProposalSectionsStatus(proposedProject);
                var viewData = new InstructionsViewData(CurrentPerson, proposedProject, proposalSectionsStatus);

                return RazorView<Instructions, InstructionsViewData>(viewData);
            }
            else
            {
                var viewData = new InstructionsViewData(CurrentPerson);
                return RazorView<Instructions, InstructionsViewData>(viewData);
            }
        }

        [HttpGet]
        [ProposedProjectCreateNewFeature]
        public ViewResult CreateAndEditBasics()
        {
            return ViewCreateAndEditBasics(new BasicsViewModel(CurrentPerson.OrganizationID));
        }

        private ViewResult ViewCreateAndEditBasics(BasicsViewModel viewModel)
        {
            var actionPriorities = HttpRequestStorage.DatabaseEntities.ActionPriorities;
            var organizations = HttpRequestStorage.DatabaseEntities.Organizations.GetActiveOrganizations().Where(x => x.PrimaryContactPerson != null); 
            var transportationObjectives = HttpRequestStorage.DatabaseEntities.TransportationObjectives;
            var viewData = new BasicsViewData(CurrentPerson, organizations, FundingType.All, transportationObjectives, actionPriorities);

            return RazorView<Basics, BasicsViewData, BasicsViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProposedProjectEditFeature]
        public ViewResult EditBasics(ProposedProjectPrimaryKey proposedProjectPrimaryKey)
        {
            var proposedProject = proposedProjectPrimaryKey.EntityObject;
            var viewModel = new BasicsViewModel(proposedProject);
            return ViewEditBasics(proposedProjectPrimaryKey, viewModel);
        }

        private ViewResult ViewEditBasics(ProposedProjectPrimaryKey proposedProjectPrimaryKey, BasicsViewModel viewModel)
        {
            
            var proposedProject = proposedProjectPrimaryKey.EntityObject;
            var proposalSectionsStatus = new ProposalSectionsStatus(proposedProject);
            proposalSectionsStatus.IsBasicsSectionComplete = ModelState.IsValid && proposalSectionsStatus.IsBasicsSectionComplete;
            
            var actionPriorities = HttpRequestStorage.DatabaseEntities.ActionPriorities;
            var organizations = HttpRequestStorage.DatabaseEntities.Organizations.GetActiveOrganizations().Where(x => x.PrimaryContactPerson != null);
            var transportationObjectives = HttpRequestStorage.DatabaseEntities.TransportationObjectives;
            
            var viewData = new BasicsViewData(CurrentPerson, proposedProject, proposalSectionsStatus, organizations, FundingType.All, transportationObjectives, actionPriorities);

            return RazorView<Basics, BasicsViewData, BasicsViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProposedProjectCreateNewFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult CreateAndEditBasics(BasicsViewModel viewModel)
        {
            var proposedProject = new ProposedProject(viewModel.ProjectName,
                viewModel.ProjectDescription,
                ModelObjectHelpers.NotYetAssignedID,
                CurrentPerson.PersonID,
                DateTime.Now,
                (int) ProjectLocationSimpleType.None.ToEnum,
                viewModel.FundingTypeID,
                (int) ProposedProjectState.Draft.ToEnum,
                false);

            return SaveProposedProjectAndCreateAuditEntry(proposedProject, viewModel);
        }

        [HttpPost]
        [ProposedProjectEditFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditBasics(ProposedProjectPrimaryKey proposedProjectPrimaryKey, BasicsViewModel viewModel)
        {
            var proposedProject = proposedProjectPrimaryKey.EntityObject;
            return SaveProposedProjectAndCreateAuditEntry(proposedProject, viewModel);
        }

        private ActionResult SaveProposedProjectAndCreateAuditEntry(ProposedProject proposedProject, BasicsViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                SetErrorForDisplay("Could not save Proposed Project: Please fix validation errors to proceed.");
                return ModelObjectHelpers.IsRealPrimaryKeyValue(proposedProject.PrimaryKey) ? ViewEditBasics(proposedProject, viewModel) : ViewCreateAndEditBasics(viewModel);
            }

            if (!ModelObjectHelpers.IsRealPrimaryKeyValue(proposedProject.PrimaryKey))
            {
                HttpRequestStorage.DatabaseEntities.ProposedProjects.Add(proposedProject);
            }

            viewModel.UpdateModel(proposedProject, CurrentPerson);
            HttpRequestStorage.DatabaseEntities.SaveChanges();

            var auditLog = new AuditLog(CurrentPerson,
                DateTime.Now,
                AuditLogEventType.Added,
                "ProposedProject",
                proposedProject.ProposedProjectID,
                "ProposedProjectID",
                proposedProject.ProposedProjectID.ToString())
            {
                ProposedProjectID = proposedProject.ProposedProjectID,
                AuditDescription = string.Format("ProposedProject: created {0}", proposedProject.DisplayName)
            };
            HttpRequestStorage.DatabaseEntities.AuditLogs.Add(auditLog);
            SetMessageForDisplay("Proposed Project succesfully saved.");

            return RedirectToAction(new SitkaRoute<ProposedProjectController>(x => x.EditBasics(proposedProject.PrimaryKey)));
        }

        [HttpGet]
        [EIPPerformanceMeasureExpectedProposedFeature]
        public ViewResult EditExpectedEIPPerformanceMeasureValues(ProposedProjectPrimaryKey projectPrimaryKey)
        {
            var proposedProject = projectPrimaryKey.EntityObject;
            var viewModel = new ExpectedEipPerformanceMeasureValuesViewModel(proposedProject);
            return ViewEditExpectedEIPPerformanceMeasureValues(proposedProject, viewModel);
        }

        private ViewResult ViewEditExpectedEIPPerformanceMeasureValues(ProposedProject proposedProject, ExpectedEipPerformanceMeasureValuesViewModel viewModel)
        {
            var selectableEIPPerformanceMeasures = HttpRequestStorage.DatabaseEntities.EIPPerformanceMeasures.ToList().Where(pm => pm.EIPPerformanceMeasureType.ValuesAreNotCalculated(false));
            var proposalSectionsStatus = new ProposalSectionsStatus(proposedProject);
            proposalSectionsStatus.IsEIPPerformanceMeasureSectionComplete = ModelState.IsValid && proposalSectionsStatus.IsEIPPerformanceMeasureSectionComplete;

            var editEIPPerformanceMeasureExpectedsViewData = new EditEIPPerformanceMeasureExpectedViewData(proposedProject, selectableEIPPerformanceMeasures.ToList());
            var viewData = new ExpectedEIPPerformanceMeasureValuesViewData(CurrentPerson, proposedProject, proposalSectionsStatus, editEIPPerformanceMeasureExpectedsViewData);
            return RazorView<ExpectedEIPPerformanceMeasureValues, ExpectedEIPPerformanceMeasureValuesViewData, ExpectedEipPerformanceMeasureValuesViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [EIPPerformanceMeasureExpectedProposedFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditExpectedEIPPerformanceMeasureValues(ProposedProjectPrimaryKey projectPrimaryKey, ExpectedEipPerformanceMeasureValuesViewModel viewModel)
        {
            var proposedProject = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                ShowValidationErrors(viewModel.GetValidationResults().ToList());
                return ViewEditExpectedEIPPerformanceMeasureValues(proposedProject, viewModel);
            }
            var currentEIPPerformanceMeasureExpectedProposeds = proposedProject.EIPPerformanceMeasureExpectedProposeds.ToList();

            HttpRequestStorage.DatabaseEntities.EIPPerformanceMeasureExpectedProposeds.Load();
            var allEIPPerformanceMeasureExpectedProposeds = HttpRequestStorage.DatabaseEntities.EIPPerformanceMeasureExpectedProposeds.Local;

            HttpRequestStorage.DatabaseEntities.EIPPerformanceMeasureExpectedSubcategoryOptionProposeds.Load();
            var allEIPPerformanceMeasureExpectedSubcategoryOptionProposeds = HttpRequestStorage.DatabaseEntities.EIPPerformanceMeasureExpectedSubcategoryOptionProposeds.Local;

            viewModel.UpdateModel(currentEIPPerformanceMeasureExpectedProposeds, allEIPPerformanceMeasureExpectedProposeds, allEIPPerformanceMeasureExpectedSubcategoryOptionProposeds, proposedProject);
            HttpRequestStorage.DatabaseEntities.SaveChanges();

            SetMessageForDisplay("Proposed Project Performance Measures succesfully saved.");
            return RedirectToAction(new SitkaRoute<ProposedProjectController>(x => x.EditExpectedEIPPerformanceMeasureValues(proposedProject)));
        }

        [HttpGet]
        [ProposedProjectThresholdCategoryEditFeature]
        public ViewResult EditThresholdCategories(ProposedProjectPrimaryKey proposedProjectPrimaryKey)
        {
            var proposedProject = proposedProjectPrimaryKey.EntityObject;
            var proposedProjectThresholdCategorySimples = GetProposedProjectThresholdCategorySimples(proposedProject);

            var viewModel = new EditProposedProjectThresholdCategoriesViewModel(proposedProjectThresholdCategorySimples);
            return ViewEditThresholdCategories(proposedProject, viewModel);
        }

        public static List<ProposedProjectThresholdCategorySimple> GetProposedProjectThresholdCategorySimples(ProposedProject proposedProject)
        {
            var selectedProposedProjectThresholdCategories = proposedProject.ProposedProjectThresholdCategories;

            var proposedProjectThresholdCategorySimples =
                HttpRequestStorage.DatabaseEntities.ThresholdCategories.Select(x => new ProposedProjectThresholdCategorySimple { ThresholdCategoryID = x.ThresholdCategoryID }).ToList();

            foreach (var selectedThresholdCategory in selectedProposedProjectThresholdCategories)
            {
                var selectedSimple = proposedProjectThresholdCategorySimples.Single(x => x.ThresholdCategoryID == selectedThresholdCategory.ThresholdCategoryID);
                selectedSimple.Selected = true;
                selectedSimple.ProposedProjectThresholdCategoryNotes = selectedThresholdCategory.ProposedProjectThresholdCategoryNotes;
            }

            return proposedProjectThresholdCategorySimples;
        }

        private ViewResult ViewEditThresholdCategories(ProposedProject proposedProject, EditProposedProjectThresholdCategoriesViewModel viewModel)
        {

            var allThresholdCategories = HttpRequestStorage.DatabaseEntities.ThresholdCategories.OrderBy(p => p.DisplayName).ToList();
            var proposalSectionsStatus = new ProposalSectionsStatus(proposedProject);
            proposalSectionsStatus.IsThresholdCategoriesComplete = ModelState.IsValid && proposalSectionsStatus.IsThresholdCategoriesComplete;

            var viewData = new EditProposedProjectThresholdCategoriesViewData(CurrentPerson, proposedProject, allThresholdCategories, ProposedProjectSectionEnum.ThresholdCategories, proposalSectionsStatus);
            return RazorView<EditProposedProjectThresholdCategories, EditProposedProjectThresholdCategoriesViewData, EditProposedProjectThresholdCategoriesViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProposedProjectThresholdCategoryEditFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditThresholdCategories(ProposedProjectPrimaryKey proposedProjectPrimaryKey, EditProposedProjectThresholdCategoriesViewModel viewModel)
        {
            var proposedProject = proposedProjectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                ShowValidationErrors(viewModel.GetValidationResults().ToList());
                return ViewEditThresholdCategories(proposedProject, viewModel);
            }
            var currentProposedProjectThresholdCategories = viewModel.ProposedProjectThresholdCategorySimples;
            HttpRequestStorage.DatabaseEntities.ProposedProjectThresholdCategories.Load();
            viewModel.UpdateModel(proposedProject, currentProposedProjectThresholdCategories);

            SetMessageForDisplay("Proposed Project Threshold Categories succesfully saved.");
            return RedirectToAction(new SitkaRoute<ProposedProjectController>(x => x.EditThresholdCategories(proposedProject)));
        }

        [HttpGet]
        [ProposedProjectEditFeature]
        public ViewResult EditTransportationAssessment(ProposedProjectPrimaryKey proposedProjectPrimaryKey)
        {
            var proposedProject = proposedProjectPrimaryKey.EntityObject;
            var proposedProjectTransportationQuestionSimples = GetProposedProjectTransportationQuestionSimples(proposedProject);

            var viewModel = new EditTransportationAssessmentViewModel(proposedProjectTransportationQuestionSimples);
            return ViewEditTransportationAssessment(proposedProject, viewModel);
        }

        public static List<ProposedProjectTransportationQuestionSimple> GetProposedProjectTransportationQuestionSimples(ProposedProject proposedProject)
        {           
            var allQuestionsAsSimples =
                HttpRequestStorage.DatabaseEntities.TransportationQuestions.Where(x=> !x.ArchiveDate.HasValue).ToList().Select(x => new ProposedProjectTransportationQuestionSimple(x, proposedProject)).ToList();

            var answeredQuestions = proposedProject.ProposedProjectTransportationQuestions.ToList();

            foreach (var question in allQuestionsAsSimples)
            {
                var matchedQuestionOrNull = answeredQuestions.SingleOrDefault(answeredQuestion => answeredQuestion.TransportationQuestionID == question.TransportationQuestionID);                
                question.Answer = matchedQuestionOrNull == null ? null : matchedQuestionOrNull.Answer;
            }
            return allQuestionsAsSimples;
        }


        [HttpPost]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        [ProposedProjectEditFeature]
        public ActionResult EditTransportationAssessment(ProposedProjectPrimaryKey proposedProjectPrimaryKey, EditTransportationAssessmentViewModel viewModel)
        {
            var proposedProject = proposedProjectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                ShowValidationErrors(viewModel.GetValidationResults().ToList());
                return ViewEditTransportationAssessment(proposedProject, viewModel);
            }

            viewModel.UpdateModel(proposedProject);
            SetMessageForDisplay("Transportation Assessment succesfully saved.");
            return RedirectToAction(new SitkaRoute<ProposedProjectController>(x => x.EditTransportationAssessment(proposedProject)));
        }

        private ViewResult ViewEditTransportationAssessment(ProposedProject proposedProject, EditTransportationAssessmentViewModel viewModel)
        {
            var proposalSectionsStatus = new ProposalSectionsStatus(proposedProject);
            proposalSectionsStatus.IsTransportationAssessmentComplete = ModelState.IsValid && proposalSectionsStatus.IsTransportationAssessmentComplete;
            var transportationGoals = HttpRequestStorage.DatabaseEntities.TransportationGoals.ToList();
            var viewData = new EditTransportationAssessmentViewData(CurrentPerson, proposedProject, transportationGoals, ProposedProjectSectionEnum.TransportationAssessment, proposalSectionsStatus);
            return RazorView<EditTransportationAssessment, EditTransportationAssessmentViewData, EditTransportationAssessmentViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProposedProjectEditFeature]
        public ViewResult EditLocationSimple(ProposedProjectPrimaryKey proposedProjectPrimaryKey)
        {
            var proposedProject = proposedProjectPrimaryKey.EntityObject;
            var viewModel = new LocationSimpleViewModel(proposedProject);
            return ViewEditLocationSimple(proposedProject, viewModel);
        }

        private ViewResult ViewEditLocationSimple(ProposedProject proposedProject, LocationSimpleViewModel viewModel)
        {
            var layerGeoJsons = MapInitJson.GetWatershedAndJurisdictionMapLayers();
            var mapInitJson = new MapInitJson(string.Format("proposedProject_{0}_EditMap", proposedProject.ProposedProjectID), 10, layerGeoJsons, BoundingBox.MakeNewDefaultBoundingBox(), false) {AllowFullScreen = false};
            var proposedProjectLocationAreas = HttpRequestStorage.DatabaseEntities.ProjectLocationAreas.ToSelectList();

            var mapPostUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.EditLocationSimple(proposedProject, null));
            var mapFormID = GenerateEditProjectLocationSimpleFormID(proposedProject);
            var editProjectLocationViewData = new EditProjectLocationSimpleViewData(CurrentPerson, mapInitJson, proposedProjectLocationAreas, mapPostUrl, mapFormID);

            var proposalSectionsStatus = new ProposalSectionsStatus(proposedProject);
            proposalSectionsStatus.IsProjectLocationSimpleSectionComplete = ModelState.IsValid && proposalSectionsStatus.IsProjectLocationSimpleSectionComplete;
            var viewData = new LocationSimpleViewData(CurrentPerson, proposedProject, proposalSectionsStatus, editProjectLocationViewData);
            return RazorView<LocationSimple, LocationSimpleViewData, LocationSimpleViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProposedProjectEditFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditLocationSimple(ProposedProjectPrimaryKey proposedProjectPrimaryKey, LocationSimpleViewModel viewModel)
        {
            var proposedProject = proposedProjectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                ShowValidationErrors(viewModel.GetValidationResults().ToList());
                return ViewEditLocationSimple(proposedProject, viewModel);
            }

            viewModel.UpdateModel(proposedProject);
            SetMessageForDisplay("Proposed Project Location succesfully saved.");
            return RedirectToAction(new SitkaRoute<ProposedProjectController>(x => x.EditLocationSimple(proposedProject)));
        }


        private static string GenerateEditProjectLocationSimpleFormID(ProposedProject proposedProject)
        {
            return string.Format("editMapForProposedProject{0}", proposedProject.ProposedProjectID);
        }

        [HttpGet]
        [ProposedProjectEditFeature]
        public ViewResult EditLocationDetailed(ProposedProjectPrimaryKey proposedProjectPrimaryKey)
        {
            var proposedProject = proposedProjectPrimaryKey.EntityObject;
            var viewModel = new LocationDetailedViewModel();
            return ViewEditLocationDetailed(proposedProject, viewModel);
        }

        private ViewResult ViewEditLocationDetailed(ProposedProject proposedProject, LocationDetailedViewModel viewModel)
        {
            var mapDivID = string.Format("proposedProject_{0}_EditDetailedMap", proposedProject.EntityID);
            var detailedLocationGeoJsonFeatureCollection = proposedProject.DetailedLocationToGeoJsonFeatureCollection();
            var editableLayerGeoJson = new LayerGeoJson("Proposed Project Location Detail", detailedLocationGeoJsonFeatureCollection, "red", 1, LayerInitialVisibility.Show);

            var boundingBox = new BoundingBox(proposedProject.GetProjectLocationDetails().Select(x => x.ProjectLocationGeometry));
            var mapInitJson = new MapInitJson(mapDivID, 10, MapInitJson.GetWatershedAndJurisdictionMapLayers(), boundingBox) { AllowFullScreen = false };

            var mapFormID = GenerateEditProposedProjectLocationFormID(proposedProject.ProposedProjectID);
            var uploadGisFileUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(c => c.ImportGdbFile(proposedProject.EntityID));
            var saveFeatureCollectionUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.EditLocationDetailed(proposedProject, null));
            
            var proposalSectionsStatus = new ProposalSectionsStatus(proposedProject);
            var projectLocationDetailViewData = new ProjectLocationDetailViewData(proposedProject.ProposedProjectID, mapInitJson, editableLayerGeoJson, uploadGisFileUrl, mapFormID, saveFeatureCollectionUrl, ProjectLocation.FieldLengths.Annotation);
            var viewData = new LocationDetailedViewData(CurrentPerson, proposedProject, proposalSectionsStatus, projectLocationDetailViewData);
            return RazorView<LocationDetailed, LocationDetailedViewData, LocationDetailedViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProposedProjectEditFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditLocationDetailed(ProposedProjectPrimaryKey proposedProjectPrimaryKey, LocationDetailedViewModel viewModel)
        {
            var proposedProject = proposedProjectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditLocationDetailed(proposedProject, viewModel);
            }
            SaveDetailedLocations(viewModel, proposedProject);
            return RedirectToAction(new SitkaRoute<ProposedProjectController>(x => x.EditLocationDetailed(proposedProject)));
        }

        [HttpGet]
        [ProposedProjectEditFeature]
        public PartialViewResult ImportGdbFile(ProposedProjectPrimaryKey proposedProjectPrimaryKey)
        {
            var proposedProject = proposedProjectPrimaryKey.EntityObject;
            var viewModel = new ImportGdbFileViewModel();
            return ViewImportGdbFile(viewModel, proposedProject.ProposedProjectID);
        }

        private PartialViewResult ViewImportGdbFile(ImportGdbFileViewModel viewModel, int proposedProjectID)
        {
            var mapFormID = GenerateEditProposedProjectLocationFormID(proposedProjectID);
            var newGisUploadUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.ImportGdbFile(proposedProjectID, null));
            var approveGisUploadUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.ApproveGisUpload(proposedProjectID, null));
            var viewData = new ImportGdbFileViewData(mapFormID, newGisUploadUrl, approveGisUploadUrl);
            return RazorPartialView<ImportGdbFile, ImportGdbFileViewData, ImportGdbFileViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProposedProjectEditFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult ImportGdbFile(ProposedProjectPrimaryKey proposedProjectPrimaryKey, ImportGdbFileViewModel viewModel)
        {
            var proposedProject = proposedProjectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewImportGdbFile(viewModel, proposedProject.ProposedProjectID);
            }

            var httpPostedFileBase = viewModel.FileResourceData;
            var fileEnding = ".gdb.zip";
            using (var disposableTempFile = DisposableTempFile.MakeDisposableTempFileEndingIn(fileEnding))
            {
                var gdbFile = disposableTempFile.FileInfo;
                httpPostedFileBase.SaveAs(gdbFile.FullName);
                HttpRequestStorage.DatabaseEntities.ProposedProjectLocationStagings.RemoveRange(proposedProject.ProposedProjectLocationStagings.ToList());
                proposedProject.ProposedProjectLocationStagings.Clear();
                ProposedProjectLocationStaging.CreateProposedProjectLocationStagingListFromGdb(gdbFile, proposedProject, CurrentPerson);
            }
            return ApproveGisUpload(proposedProject);
        }

        [HttpGet]
        [ProposedProjectEditFeature]
        public PartialViewResult ApproveGisUpload(ProposedProjectPrimaryKey proposedProjectPrimaryKey)
        {
            var proposedProject = proposedProjectPrimaryKey.EntityObject;
            var viewModel = new ProjectLocationDetailViewModel();
            return ViewApproveGisUpload(proposedProject, viewModel);
        }

        private PartialViewResult ViewApproveGisUpload(ProposedProject proposedProject, ProjectLocationDetailViewModel viewModel)
        {
            var projectLocationStagings = proposedProject.ProposedProjectLocationStagings.ToList();
            var layerGeoJsons =
                projectLocationStagings.Select(
                    (projectLocationStaging, i) =>
                        new LayerGeoJson(projectLocationStaging.FeatureClassName,
                            projectLocationStaging.ToGeoJsonFeatureCollection(),
                            ProjectFirmaHelpers.DefaultColorRange[i],
                            1,
                            LayerInitialVisibility.Show)).ToList();

            var boundingBox = BoundingBox.MakeBoundingBoxFromLayerGeoJsonList(layerGeoJsons);

            var mapInitJson = new MapInitJson(string.Format("proposedProject_{0}_PreviewMap", proposedProject.ProposedProjectID), 10, layerGeoJsons, boundingBox, false) {AllowFullScreen = false};
            var mapFormID = GenerateEditProposedProjectLocationFormID(proposedProject.ProposedProjectID);
            var approveGisUploadUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.ApproveGisUpload(proposedProject, null));

            var viewData = new ApproveGisUploadViewData(new List<IProjectLocationStaging>(projectLocationStagings), mapInitJson, mapFormID, approveGisUploadUrl);
            return RazorPartialView<ApproveGisUpload, ApproveGisUploadViewData, ProjectLocationDetailViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProposedProjectEditFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult ApproveGisUpload(ProposedProjectPrimaryKey proposedProjectPrimaryKey, ProjectLocationDetailViewModel viewModel)
        {
            var proposedProject = proposedProjectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewApproveGisUpload(proposedProject, viewModel);
            }
            SaveDetailedLocations(viewModel, proposedProject);
            DbSpatialHelper.Reduce(new List<IHaveSqlGeometry>(proposedProject.ProposedProjectLocations.ToList()));
            return new ModalDialogFormJsonResult();
        }

        private static void SaveDetailedLocations(ProjectLocationDetailViewModel viewModel, ProposedProject proposedProject)
        {
            var proposedProjectLocations = proposedProject.ProposedProjectLocations.ToList();
            HttpRequestStorage.DatabaseEntities.ProposedProjectLocations.RemoveRange(proposedProjectLocations);
            proposedProject.ProposedProjectLocations.Clear();
            if (viewModel.WktAndAnnotations != null)
            {
                foreach (var wktAndAnnotation in viewModel.WktAndAnnotations)
                {
                    proposedProject.ProposedProjectLocations.Add(new ProposedProjectLocation(proposedProject, DbGeometry.FromText(wktAndAnnotation.Wkt), wktAndAnnotation.Annotation));
                }
            }
        }

        public static string GenerateEditProposedProjectLocationFormID(int proposedProjectID)
        {
            return string.Format("editMapForProposedProject{0}", proposedProjectID);
        }

        [ProposedProjectEditFeature]
        public ViewResult EditNotes(ProposedProjectPrimaryKey proposedProjectPrimaryKey)
        {
            var proposedProject = proposedProjectPrimaryKey.EntityObject;
            var entityNotes = new List<IEntityNote>(proposedProject.ProposedProjectNotes);
            var addNoteUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.NewNote(proposedProject));
            var canEditNotes = new ProposedProjectNoteManageFeature().HasPermissionByPerson(CurrentPerson);
            var entityNotesViewData = new EntityNotesViewData(EntityNote.CreateFromEntityNote(entityNotes), addNoteUrl, "Proposed Project", canEditNotes);

            var proposalSectionsStatus = new ProposalSectionsStatus(proposedProject);
            var viewData = new NotesViewData(CurrentPerson, proposedProject, proposalSectionsStatus, entityNotesViewData);
            return RazorView<Notes, NotesViewData>(viewData);
        }


        [HttpGet]
        [ProposedProjectNoteCreateFeature]
        public PartialViewResult NewNote(ProposedProjectPrimaryKey proposedProjectPrimaryKey)
        {
            var viewModel = new EditNoteViewModel();
            return ViewEditNote(viewModel);
        }

        [HttpPost]
        [ProposedProjectNoteCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult NewNote(ProposedProjectPrimaryKey proposedProjectPrimaryKey, EditNoteViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEditNote(viewModel);
            }
            var proposedProject = proposedProjectPrimaryKey.EntityObject;
            var proposedProjectNote = ProposedProjectNote.CreateNewBlank(proposedProject);
            viewModel.UpdateModel(proposedProjectNote, CurrentPerson);
            HttpRequestStorage.DatabaseEntities.ProposedProjectNotes.Add(proposedProjectNote);
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [ProposedProjectNoteManageFeature]
        public PartialViewResult EditNote(ProposedProjectNotePrimaryKey proposedProjectNotePrimaryKey)
        {
            var proposedProjectNote = proposedProjectNotePrimaryKey.EntityObject;
            var viewModel = new EditNoteViewModel(proposedProjectNote.Note);
            return ViewEditNote(viewModel);
        }

        [HttpPost]
        [ProposedProjectNoteManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditNote(ProposedProjectNotePrimaryKey proposedProjectNotePrimaryKey, EditNoteViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEditNote(viewModel);
            }
            var proposedProjectNote = proposedProjectNotePrimaryKey.EntityObject;
            viewModel.UpdateModel(proposedProjectNote, CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditNote(EditNoteViewModel viewModel)
        {
            var viewData = new EditNoteViewData();
            return RazorPartialView<EditNote, EditNoteViewData, EditNoteViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProposedProjectNoteManageFeature]
        public PartialViewResult DeleteNote(ProposedProjectNotePrimaryKey proposedProjectNotePrimaryKey)
        {
            var proposedProjectNote = proposedProjectNotePrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(proposedProjectNote.ProposedProjectNoteID);
            return ViewDeleteNote(proposedProjectNote, viewModel);
        }

        private PartialViewResult ViewDeleteNote(ProposedProjectNote proposedProjectNote, ConfirmDialogFormViewModel viewModel)
        {
            var canDelete = !proposedProjectNote.HasDependentObjects();
            var confirmMessage = canDelete
                ? string.Format("Are you sure you want to delete this note for proposedProject '{0}'?", proposedProjectNote.ProposedProject.DisplayName)
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage("ProposedProject Note");

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);

            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProposedProjectNoteManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteNote(ProposedProjectNotePrimaryKey proposedProjectNotePrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var proposedProjectNote = proposedProjectNotePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteNote(proposedProjectNote, viewModel);
            }
            HttpRequestStorage.DatabaseEntities.ProposedProjectNotes.Remove(proposedProjectNote);
            return new ModalDialogFormJsonResult();
        }

        [ProposedProjectEditFeature]
        public ViewResult EditPhotos(ProposedProjectPrimaryKey proposedProjectPrimaryKey)
        {
            var proposedProject = proposedProjectPrimaryKey.EntityObject;

            var viewData = BuildImageGalleryViewData(proposedProject, CurrentPerson);
            return RazorView<Photos, PhotoViewData>(viewData);
        }

        private static PhotoViewData BuildImageGalleryViewData(ProposedProject proposedProject, Person currentPerson)
        {
            var proposalSectionsStatus = new ProposalSectionsStatus(proposedProject);
            var newPhotoForProjectUrl = SitkaRoute<ProposedProjectImageController>.BuildUrlFromExpression(x => x.New(proposedProject));
            var galleryName = string.Format("ProjectImage{0}", proposedProject.ProposedProjectID);
            var projectImages = proposedProject.ProposedProjectImages.ToList();
            var imageGalleryViewData = new PhotoViewData(currentPerson, galleryName, projectImages, newPhotoForProjectUrl, x => x.CaptionOnFullView, proposedProject, proposalSectionsStatus);
            return imageGalleryViewData;
        }

        [HttpGet]
        [ProposedProjectEditFeature]
        public PartialViewResult DeleteProposedProject(ProposedProjectPrimaryKey proposedProjectPrimaryKey)
        {
            var viewModel = new ConfirmDialogFormViewModel(proposedProjectPrimaryKey.PrimaryKeyValue);
            return ViewDeleteProposedProject(proposedProjectPrimaryKey.EntityObject, viewModel);
        }

        private PartialViewResult ViewDeleteProposedProject(ProposedProject proposedProject, ConfirmDialogFormViewModel viewModel)
        {
            var canDelete = proposedProject.CanDelete().HasPermission;
            var confirmMessage = canDelete
                ? String.Format("Are you sure you want to delete Proposed Project \"{0}\"?", proposedProject.DisplayName)
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage("ProposedProject", SitkaRoute<ProposedProjectController>.BuildLinkFromExpression(x => x.Summary(proposedProject), "here"));

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProposedProjectEditFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteProposedProject(ProposedProjectPrimaryKey proposedProjectPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var proposedProject = proposedProjectPrimaryKey.EntityObject;
            var permissionCheckResult = proposedProject.CanDelete();
            if (!permissionCheckResult.HasPermission)
            {
                throw new SitkaRecordNotAuthorizedException(permissionCheckResult.PermissionDeniedMessage);
            }
            if (!ModelState.IsValid)
            {
                return ViewDeleteProposedProject(proposedProject, viewModel);
            }
            DeleteProposedProject(proposedProject);
            return new ModalDialogFormJsonResult();
        }

        private static void DeleteProposedProject(ProposedProject proposedProject)
        {
            HttpRequestStorage.DatabaseEntities.ProposedProjectNotes.RemoveRange(proposedProject.ProposedProjectNotes);
            HttpRequestStorage.DatabaseEntities.ProposedProjectThresholdCategories.RemoveRange(proposedProject.ProposedProjectThresholdCategories);
            var proposedProjectEIPPerformanceMeasureExpecteds = proposedProject.EIPPerformanceMeasureExpectedProposeds.ToList();
            HttpRequestStorage.DatabaseEntities.EIPPerformanceMeasureExpectedSubcategoryOptionProposeds.RemoveRange(
                proposedProjectEIPPerformanceMeasureExpecteds.SelectMany(x => x.EIPPerformanceMeasureExpectedSubcategoryOptionProposeds));
            HttpRequestStorage.DatabaseEntities.EIPPerformanceMeasureExpectedProposeds.RemoveRange(proposedProjectEIPPerformanceMeasureExpecteds);
            HttpRequestStorage.DatabaseEntities.ProposedProjects.Remove(proposedProject);
        }

        [HttpGet]
        [ProposedProjectEditFeature]
        public PartialViewResult Submit(ProposedProjectPrimaryKey proposedProjectPrimaryKey)
        {
            var proposedProject = proposedProjectPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(proposedProject.ProposedProjectID);
            var viewData = new ConfirmDialogFormViewData(string.Format("Are you sure you want to submit Proposed Project \"{0}\" to TRPA?", proposedProject.DisplayName));
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProposedProjectEditFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Submit(ProposedProjectPrimaryKey proposedProjectPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var proposedProject = proposedProjectPrimaryKey.EntityObject;
            proposedProject.ProposedProjectStateID = (int)ProposedProjectStateEnum.Submitted;
            proposedProject.SubmissionDate = DateTime.Now;
            var peopleToNotify = HttpRequestStorage.DatabaseEntities.People.GetPeopleWhoReceiveEIPNotifications();
            Notification.SendProposedProjectSubmittedMessage(peopleToNotify, proposedProject); 
            SetMessageForDisplay("Proposed Project succesfully submitted to TRPA for review.");
            return new ModalDialogFormJsonResult(proposedProject.GetSummaryUrl());
        }

        [HttpGet]
        [ProposedProjectApproveFeature]
        public PartialViewResult Approve(ProposedProjectPrimaryKey proposedProjectPrimaryKey)
        {
            var proposedProject = proposedProjectPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(proposedProject.ProposedProjectID);
            return ViewApprove(viewModel);
        }

        [HttpPost]
        [ProposedProjectApproveFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Approve(ProposedProjectPrimaryKey proposedProjectPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewApprove(viewModel);
            }
            var proposedProject = proposedProjectPrimaryKey.EntityObject;
            Check.Assert(proposedProject.ProposedProjectState == ProposedProjectState.Submitted,
                "Project is not in Submitted state. Actual state is: " + proposedProject.ProposedProjectState.ProposedProjectStateDisplayName);

            Check.Assert(new ProposalSectionsStatus(proposedProject).AreAllSectionsValid, "Proposal is not ready for submittal.");

            var project = proposedProject.PromoteToProject(proposedProject);
            HttpRequestStorage.DatabaseEntities.Projects.Add(project);
            HttpRequestStorage.DatabaseEntities.SaveChanges();
            proposedProject.ProposedProjectStateID = (int)ProposedProjectStateEnum.Approved;
            proposedProject.ProjectID = project.ProjectID;
            proposedProject.ApprovalDate = DateTime.Now;
            HttpRequestStorage.DatabaseEntities.SaveChanges();
            GenerateApprovalAuditLogEntries(project, proposedProject);

            SetMessageForDisplay(string.Format("Proposed Project \"{0}\" succesfully approved as an actual project in the Planning/Design stage.", UrlTemplate.MakeHrefString(project.GetSummaryUrl(), project.DisplayName)));

            return new ModalDialogFormJsonResult(project.GetSummaryUrl());
        }

        private void GenerateApprovalAuditLogEntries(Project project, ProposedProject proposedProject)
        {
            var auditLog = new AuditLog(CurrentPerson, DateTime.Now, AuditLogEventType.Added, "Project", project.ProjectID, "ProjectID", project.ProjectID.ToString())
            {
                ProposedProjectID = proposedProject.ProposedProjectID,
                ProjectID = project.ProjectID,
                AuditDescription = string.Format("Project: created via approval of Proposed Project {0}", proposedProject.DisplayName)
            };
            HttpRequestStorage.DatabaseEntities.AuditLogs.Add(auditLog);
        }

        private PartialViewResult ViewApprove(ConfirmDialogFormViewModel viewModel)
        {
            var viewData = new ConfirmDialogFormViewData("Are you sure you want to approve this Project?");
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProposedProjectEditFeature]
        public PartialViewResult Withdraw(ProposedProjectPrimaryKey proposedProjectPrimaryKey)
        {
            var proposedProject = proposedProjectPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(proposedProject.ProposedProjectID);
            var viewData = new ConfirmDialogFormViewData(string.Format("Are you sure you want to withdraw Proposed Project \"{0}\" from TRPA review?", proposedProject.DisplayName));
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProposedProjectEditFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Withdraw(ProposedProjectPrimaryKey proposedProjectPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var proposedProject = proposedProjectPrimaryKey.EntityObject;
            proposedProject.ProposedProjectStateID = (int)ProposedProjectStateEnum.Draft;
            SetMessageForDisplay("Proposed Project withdrawn from TRPA review.");
            return new ModalDialogFormJsonResult(proposedProject.GetSummaryUrl());
        }

        [HttpGet]
        [ProposedProjectApproveFeature]
        public PartialViewResult Return(ProposedProjectPrimaryKey proposedProjectPrimaryKey)
        {
            var proposedProject = proposedProjectPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(proposedProject.ProposedProjectID);
            var viewData = new ConfirmDialogFormViewData(string.Format("Are you sure you want to return Proposed Project \"{0}\" to Submitter?", proposedProject.DisplayName));
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProposedProjectApproveFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Return(ProposedProjectPrimaryKey proposedProjectPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var proposedProject = proposedProjectPrimaryKey.EntityObject;
            proposedProject.ProposedProjectStateID = (int)ProposedProjectStateEnum.Draft;
            SetMessageForDisplay("Proposed Project returned to Submitter for additional clarifactions/corrections.");
            return new ModalDialogFormJsonResult(proposedProject.GetSummaryUrl());
        }

        [HttpGet]
        [ProposedProjectApproveFeature]
        public PartialViewResult Reject(ProposedProjectPrimaryKey proposedProjectPrimaryKey)
        {
            var proposedProject = proposedProjectPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(proposedProject.ProposedProjectID);
            var viewData = new ConfirmDialogFormViewData(string.Format("Are you sure you want to reject Proposed Project \"{0}\"?", proposedProject.DisplayName));
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProposedProjectApproveFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Reject(ProposedProjectPrimaryKey proposedProjectPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var proposedProject = proposedProjectPrimaryKey.EntityObject;
            proposedProject.ProposedProjectStateID = (int)ProposedProjectStateEnum.Rejected;
            SetMessageForDisplay("Proposed Project was rejected.");
            return new ModalDialogFormJsonResult(proposedProject.GetSummaryUrl());
        }

        [ProposedProjectViewFeature]
        public GridJsonNetJObjectResult<AuditLog> AuditLogsGridJsonData(ProposedProjectPrimaryKey proposedProjectPrimaryKey)
        {
            AuditLogsGridSpec gridSpec;
            var auditLogs = GetAuditLogsAndGridSpec(out gridSpec, proposedProjectPrimaryKey.EntityObject);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<AuditLog>(auditLogs, gridSpec);
            return gridJsonNetJObjectResult;
        }

        private static List<AuditLog> GetAuditLogsAndGridSpec(out AuditLogsGridSpec gridSpec, ProposedProject proposedProject)
        {
            gridSpec = new AuditLogsGridSpec();
            var auditLogs = HttpRequestStorage.DatabaseEntities.AuditLogs.GetAuditLogEntriesForProposedProject(proposedProject);
            return auditLogs;
        }

        private void ShowValidationErrors(List<ValidationResult> validationResults)
        {
            var validationErrorMessages = string.Empty;
            if (validationResults.Any())
            {
                validationErrorMessages = string.Format(" Please fix these errors: <ul>{0}</ul>",
                    string.Join(Environment.NewLine, validationResults.Select(x => string.Format("<li>{0}</li>", x.ErrorMessage))));
            }
            SetErrorForDisplay(string.Format("Could not save Proposed Project.{0}", validationErrorMessages));
        }
    }
}