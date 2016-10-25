using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Map;
using ProjectFirma.Web.Views.Program;
using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.TextControls;
using LtInfo.Common;
using LtInfo.Common.Mvc;
using LtInfo.Common.MvcResults;
using Edit = ProjectFirma.Web.Views.Program.Edit;
using EditViewData = ProjectFirma.Web.Views.Program.EditViewData;
using EditViewModel = ProjectFirma.Web.Views.Program.EditViewModel;
using Index = ProjectFirma.Web.Views.Program.Index;
using IndexGridSpec = ProjectFirma.Web.Views.Program.IndexGridSpec;
using IndexViewData = ProjectFirma.Web.Views.Program.IndexViewData;
using Summary = ProjectFirma.Web.Views.Program.Summary;
using SummaryViewData = ProjectFirma.Web.Views.Program.SummaryViewData;

namespace ProjectFirma.Web.Controllers
{
    public class ProgramController : FirmaBaseController
    {
        [ProgramViewFeature]
        public ViewResult Index()
        {
            return IndexImpl();
        }

        [AdminReadOnlyViewEverythingFeature]
        public ViewResult Manage()
        {
            return IndexImpl();
        }

        private ViewResult IndexImpl()
        {
            var projectFirmaPage = ProjectFirmaPage.GetProjectFirmaPageByPageType(ProjectFirmaPageType.ProgramsList);
            var viewData = new IndexViewData(CurrentPerson, projectFirmaPage);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [ProgramViewFeature]
        public GridJsonNetJObjectResult<Program> IndexGridJsonData()
        {
            IndexGridSpec gridSpec;
            var programs = GetProgramsAndGridSpec(out gridSpec, CurrentPerson);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Program>(programs, gridSpec);
            return gridJsonNetJObjectResult;
        }

        private static List<Program> GetProgramsAndGridSpec(out IndexGridSpec gridSpec, Person currentPerson)
        {
            var hasDeletePermission = new ProgramManageFeature().HasPermissionByPerson(currentPerson);
            gridSpec = new IndexGridSpec(hasDeletePermission);
            return HttpRequestStorage.DatabaseEntities.Programs.ToList().OrderBy(x => x.DisplayNumber).ToList();
        }

        [ProgramViewFeature]
        public ViewResult Summary(ProgramPrimaryKey programPrimaryKey)
        {
            var program = programPrimaryKey.EntityObject;
            var programProjects = program.Projects.ToList();
            var projects = IsCurrentUserAnonymous() ? programProjects.Where(p => p.IsVisibleToEveryone()).ToList() : programProjects;

            var projectMapCustomization = new ProjectMapCustomization(ProjectLocationFilterType.Program, new List<int> {program.ProgramID}, ProjectColorByType.ProjectStage);
            var projectLocationsLayerGeoJson = new LayerGeoJson("Project Locations", Project.MappedPointsToGeoJsonFeatureCollection(projects, true), "red", 1, LayerInitialVisibility.Show);
            var namedAreasAsPointsLayerGeoJson = new LayerGeoJson("Named Areas", Project.NamedAreasToPointGeoJsonFeatureCollection(projects, true), "red", 1, LayerInitialVisibility.Show);
            var projectLocationsMapInitJson = new ProjectLocationsMapInitJson(projectLocationsLayerGeoJson, namedAreasAsPointsLayerGeoJson, projectMapCustomization, "ProgramProjectMap");

            var projectLocationsMapViewData = new ProjectLocationsMapViewData(projectLocationsMapInitJson.MapDivID, ProjectColorByType.ProjectStage.ProjectColorByTypeDisplayName);

            var viewData = new SummaryViewData(CurrentPerson,
                program,
                projectLocationsMapInitJson,
                projectLocationsMapViewData);
            return RazorView<Summary, SummaryViewData>(viewData);
        }

        [HttpGet]
        [ProgramManageFeature]
        public PartialViewResult New()
        {
            var viewModel = new EditViewModel();
            return ViewNew(viewModel);
        }

        [HttpPost]
        [ProgramManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewNew(viewModel);
            }
            var program = new Program(viewModel.FocusAreaID, Program.GetNextProgramNumberForFocusArea(HttpRequestStorage.DatabaseEntities.Programs, viewModel.FocusAreaID), string.Empty);
            viewModel.UpdateModel(program, CurrentPerson);
            HttpRequestStorage.DatabaseEntities.Programs.Add(program);
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [ProgramManageFeature]
        public PartialViewResult Edit(ProgramPrimaryKey programPrimaryKey)
        {
            var program = programPrimaryKey.EntityObject;
            var viewModel = new EditViewModel(program);
            return ViewEdit(viewModel, program.Projects.Any(), program.FocusArea.DisplayName, program.AssociatedProgramsHtmlString);
        }

        [HttpPost]
        [ProgramManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(ProgramPrimaryKey programPrimaryKey, EditViewModel viewModel)
        {
            var program = programPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel, program.Projects.Any(), program.FocusArea.DisplayName, program.AssociatedProgramsHtmlString);
            }
            // reset the program number if focus area is changed
            if (!program.Projects.Any() && program.FocusAreaID != viewModel.FocusAreaID)
            {
                program.ProgramNumber = Program.GetNextProgramNumberForFocusArea(HttpRequestStorage.DatabaseEntities.Programs, viewModel.FocusAreaID);
            }
            viewModel.UpdateModel(program, CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewNew(EditViewModel viewModel)
        {
            return ViewEdit(viewModel, false, string.Empty, null);
        }

        private PartialViewResult ViewEdit(EditViewModel viewModel, bool hasProjects, string focusAreaDisplayName, HtmlString associatedPrograms)
        {
            var focusAreas = HttpRequestStorage.DatabaseEntities.FocusAreas.ToList()
                .OrderBy(x => x.DisplayName)
                .ToSelectList(x => x.FocusAreaID.ToString(CultureInfo.InvariantCulture), x => x.DisplayName);
            var viewData = new EditViewData(focusAreas, focusAreaDisplayName, hasProjects, associatedPrograms, CkEditorExtension.CkEditorToolbar.Minimal);
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProgramManageFeature]
        public PartialViewResult DeleteProgram(ProgramPrimaryKey programPrimaryKey)
        {
            var program = programPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(program.ProgramID);
            return ViewDeleteProgram(program, viewModel);
        }

        private PartialViewResult ViewDeleteProgram(Program program, ConfirmDialogFormViewModel viewModel)
        {
            var canDelete = !program.HasDependentObjects();
            var confirmMessage = canDelete
                ? string.Format("Are you sure you want to delete this Program '{0}'?", program.DisplayName)
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage("Program", SitkaRoute<ProgramController>.BuildLinkFromExpression(x => x.Summary(program), "here"));

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProgramManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteProgram(ProgramPrimaryKey programPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var program = programPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteProgram(program, viewModel);
            }
            HttpRequestStorage.DatabaseEntities.Programs.Remove(program);
            return new ModalDialogFormJsonResult();
        }

        [ProgramViewFeature]
        public GridJsonNetJObjectResult<Project> ProjectsGridJsonData(ProgramPrimaryKey programPrimaryKey)
        {
            BasicProjectInfoGridSpec gridSpec;
            var projectPrograms = GetProjectsAndGridSpec(out gridSpec, programPrimaryKey.EntityObject);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Project>(projectPrograms, gridSpec);
            return gridJsonNetJObjectResult;
        }

        private List<Project> GetProjectsAndGridSpec(out BasicProjectInfoGridSpec gridSpec, Program program)
        {
            gridSpec = new BasicProjectInfoGridSpec(CurrentPerson, true);
            return program.Projects.OrderBy(x => x.DisplayName).ToList();
        }

        [HttpGet]
        [ProgramManageFeature]
        public PartialViewResult EditDescription(ProgramPrimaryKey programPrimaryKey)
        {
            var program = programPrimaryKey.EntityObject;
            var viewModel = new EditRtfContentViewModel(program.ProgramDescriptionHtmlString);
            return ViewEditDescription(program, viewModel);
        }

        [HttpPost]
        [ProgramManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditDescription(ProgramPrimaryKey programPrimaryKey, EditRtfContentViewModel viewModel)
        {
            var program = programPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditDescription(program, viewModel);
            }
            viewModel.UpdateModel(program);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditDescription(Program program, EditRtfContentViewModel viewModel)
        {
            var viewData = new EditRtfContentViewData(CkEditorExtension.CkEditorToolbar.AllOnOneRowNoMaximize,
                SitkaRoute<FileResourceController>.BuildUrlFromExpression(x => x.CkEditorUploadFileResourceForProgram(program, null)));
            return RazorPartialView<EditRtfContent, EditRtfContentViewData, EditRtfContentViewModel>(viewData, viewModel);
        }

        [ProgramViewFeature]
        public PartialViewResult DefinitionAndGuidance(ProgramPrimaryKey programPrimaryKey)
        {
            var program = programPrimaryKey.EntityObject;
            var viewData = new DefinitionAndGuidanceViewData(program);
            return RazorPartialView<DefinitionAndGuidance, DefinitionAndGuidanceViewData>(viewData);
        }
    }
}