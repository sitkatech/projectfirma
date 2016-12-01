using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Views.Shared.PerformanceMeasureControls;

namespace ProjectFirma.Web.Controllers
{
    public class PerformanceMeasureExpectedController : FirmaBaseController
    {
        [HttpGet]
        [PerformanceMeasureExpectedFromProjectManageFeature]
        public PartialViewResult EditPerformanceMeasureExpectedsForProject(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var performanceMeasureExpectedSimples = project.PerformanceMeasureExpecteds.OrderBy(pam => pam.PerformanceMeasureID).Select(x => new PerformanceMeasureExpectedSimple(x)).ToList();
            var viewModel = new EditPerformanceMeasureExpectedViewModel(performanceMeasureExpectedSimples);
            return ViewEditPerformanceMeasureExpecteds(project, viewModel);
        }

        [HttpPost]
        [PerformanceMeasureExpectedFromProjectManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditPerformanceMeasureExpectedsForProject(ProjectPrimaryKey projectPrimaryKey, EditPerformanceMeasureExpectedViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditPerformanceMeasureExpecteds(project, viewModel);
            }
            var currentPerformanceMeasureExpecteds = project.PerformanceMeasureExpecteds.ToList();
            return UpdatePerformanceMeasureExpecteds(viewModel, currentPerformanceMeasureExpecteds);
        }

        private static ActionResult UpdatePerformanceMeasureExpecteds(EditPerformanceMeasureExpectedViewModel viewModel,
            List<PerformanceMeasureExpected> currentPerformanceMeasureExpecteds)
        {
            HttpRequestStorage.DatabaseEntities.PerformanceMeasureExpecteds.Load();
            var allPerformanceMeasureExpecteds = HttpRequestStorage.DatabaseEntities.PerformanceMeasureExpecteds.Local;
            HttpRequestStorage.DatabaseEntities.PerformanceMeasureExpectedSubcategoryOptions.Load();
            var allPerformanceMeasureExpectedSubcategoryOptions = HttpRequestStorage.DatabaseEntities.PerformanceMeasureExpectedSubcategoryOptions.Local;
            viewModel.UpdateModel(currentPerformanceMeasureExpecteds, allPerformanceMeasureExpecteds, allPerformanceMeasureExpectedSubcategoryOptions);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditPerformanceMeasureExpecteds(Project project, EditPerformanceMeasureExpectedViewModel viewModel)
        {
            var performanceMeasures = HttpRequestStorage.DatabaseEntities.PerformanceMeasures.ToList();
            var viewData = new EditPerformanceMeasureExpectedViewData(project, performanceMeasures);
            return RazorPartialView<EditPerformanceMeasureExpected, EditPerformanceMeasureExpectedViewData, EditPerformanceMeasureExpectedViewModel>(viewData, viewModel);
        }
    }
}