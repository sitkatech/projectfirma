using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Shared;
using LtInfo.Common;
using LtInfo.Common.MvcResults;
using Edit = ProjectFirma.Web.Views.LocalAndRegionalPlan.Edit;
using EditViewData = ProjectFirma.Web.Views.LocalAndRegionalPlan.EditViewData;
using EditViewModel = ProjectFirma.Web.Views.LocalAndRegionalPlan.EditViewModel;
using Index = ProjectFirma.Web.Views.LocalAndRegionalPlan.Index;
using IndexGridSpec = ProjectFirma.Web.Views.LocalAndRegionalPlan.IndexGridSpec;
using IndexViewData = ProjectFirma.Web.Views.LocalAndRegionalPlan.IndexViewData;
using Summary = ProjectFirma.Web.Views.LocalAndRegionalPlan.Summary;
using SummaryViewData = ProjectFirma.Web.Views.LocalAndRegionalPlan.SummaryViewData;

namespace ProjectFirma.Web.Controllers
{
    public class LocalAndRegionalPlanController : FirmaBaseController
    {
        [LocalAndRegionalPlanViewFeature]
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
            var firmaPage = FirmaPage.GetFirmaPageByPageType(FirmaPageType.LocalAndRegionalPlansList);
            var viewData = new IndexViewData(CurrentPerson, firmaPage);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [LocalAndRegionalPlanViewFeature]
        public GridJsonNetJObjectResult<LocalAndRegionalPlan> IndexGridJsonData()
        {
            IndexGridSpec gridSpec;
            var localAndRegionalPlans = GetLocalAndRegionalPlansAndGridSpec(out gridSpec, CurrentPerson);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<LocalAndRegionalPlan>(localAndRegionalPlans, gridSpec);
            return gridJsonNetJObjectResult;
        }

        private static List<LocalAndRegionalPlan> GetLocalAndRegionalPlansAndGridSpec(out IndexGridSpec gridSpec, Person currentPerson)
        {
            gridSpec = new IndexGridSpec(new LocalAndRegionalPlanManageFeature().HasPermissionByPerson(currentPerson));
            return LocalAndRegionalPlans.List();
        }

        [HttpGet]
        [LocalAndRegionalPlanManageFeature]
        public PartialViewResult New()
        {
            var viewModel = new EditViewModel();
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [LocalAndRegionalPlanManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            var localAndRegionalPlan = new LocalAndRegionalPlan(string.Empty, false);
            viewModel.UpdateModel(localAndRegionalPlan, CurrentPerson);
            HttpRequestStorage.DatabaseEntities.LocalAndRegionalPlans.Add(localAndRegionalPlan);
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [LocalAndRegionalPlanManageFeature]
        public PartialViewResult Edit(LocalAndRegionalPlanPrimaryKey localAndRegionalPlanPrimaryKey)
        {
            var localAndRegionalPlan = localAndRegionalPlanPrimaryKey.EntityObject;
            var viewModel = new EditViewModel(localAndRegionalPlan);
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [LocalAndRegionalPlanManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(LocalAndRegionalPlanPrimaryKey localAndRegionalPlanPrimaryKey, EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            var localAndRegionalPlan = localAndRegionalPlanPrimaryKey.EntityObject;
            viewModel.UpdateModel(localAndRegionalPlan, CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEdit(EditViewModel viewModel)
        {
            var viewData = new EditViewData();
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [LocalAndRegionalPlanManageFeature]
        public PartialViewResult DeleteLocalAndRegionalPlan(LocalAndRegionalPlanPrimaryKey localAndRegionalPlanPrimaryKey)
        {
            var localAndRegionalPlan = localAndRegionalPlanPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(localAndRegionalPlan.LocalAndRegionalPlanID);
            return ViewDeleteLocalAndRegionalPlan(localAndRegionalPlan, viewModel);
        }

        private PartialViewResult ViewDeleteLocalAndRegionalPlan(LocalAndRegionalPlan localAndRegionalPlan, ConfirmDialogFormViewModel viewModel)
        {
            var canDelete = !localAndRegionalPlan.HasDependentObjects();
            var confirmMessage = canDelete
                ? string.Format("Are you sure you want to delete this Local and Regional Plan '{0}'?", localAndRegionalPlan.DisplayName)
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage("Local and Regional Plan",
                    SitkaRoute<LocalAndRegionalPlanController>.BuildLinkFromExpression(x => x.Summary(localAndRegionalPlan), "here"));

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [LocalAndRegionalPlanManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteLocalAndRegionalPlan(LocalAndRegionalPlanPrimaryKey localAndRegionalPlanPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var localAndRegionalPlan = localAndRegionalPlanPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteLocalAndRegionalPlan(localAndRegionalPlan, viewModel);
            }
            HttpRequestStorage.DatabaseEntities.LocalAndRegionalPlans.Remove(localAndRegionalPlan);
            return new ModalDialogFormJsonResult();
        }

        [LocalAndRegionalPlanViewFeature]
        public ViewResult Summary(LocalAndRegionalPlanPrimaryKey localAndRegionalPlanPrimaryKey)
        {
            var localAndRegionalPlan = localAndRegionalPlanPrimaryKey.EntityObject;
            var viewData = new SummaryViewData(CurrentPerson, localAndRegionalPlan);
            return RazorView<Summary, SummaryViewData>(viewData);
        }

        [LocalAndRegionalPlanViewFeature]
        public GridJsonNetJObjectResult<Project> ProjectsGridJsonData(LocalAndRegionalPlanPrimaryKey localAndRegionalPlanPrimaryKey)
        {
            var gridSpec = new BasicProjectInfoGridSpec(CurrentPerson, false);
            var projectLocalAndRegionalPlans = localAndRegionalPlanPrimaryKey.EntityObject.AssociatedProjects.OrderBy(x => x.DisplayName).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Project>(projectLocalAndRegionalPlans, gridSpec);
            return gridJsonNetJObjectResult;
        }
        
        [LocalAndRegionalPlanViewFeature]
        public GridJsonNetJObjectResult<Project> TransportationProjectsGridJsonData(LocalAndRegionalPlanPrimaryKey localAndRegionalPlanPrimaryKey)
        {
            var gridSpec = new TransportationListProjectGridSpec(CurrentPerson);
            var projectLocalAndRegionalPlans = localAndRegionalPlanPrimaryKey.EntityObject.AssociatedProjects.OrderBy(x => x.DisplayName).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Project>(projectLocalAndRegionalPlans, gridSpec);
            return gridJsonNetJObjectResult;
        }
    }
}