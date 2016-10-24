using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared.EIPPerformanceMeasureControls;
using ProjectFirma.Web.Controllers;
using LtInfo.Common;
using LtInfo.Common.MvcResults;

namespace ProjectFirma.Web.Controllers
{
    public class EIPPerformanceMeasureExpectedController : LakeTahoeInfoBaseController
    {
        [HttpGet]
        [EIPPerformanceMeasureExpectedFromProjectManageFeature]
        public PartialViewResult EditEIPPerformanceMeasureExpectedsForProject(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var eipPerformanceMeasureExpectedSimples = project.EIPPerformanceMeasureExpecteds.OrderBy(pam => pam.EIPPerformanceMeasureID).Select(x => new EIPPerformanceMeasureExpectedSimple(x)).ToList();
            var viewModel = new EditEIPPerformanceMeasureExpectedViewModel(eipPerformanceMeasureExpectedSimples);
            return ViewEditEIPPerformanceMeasureExpecteds(project, viewModel);
        }

        [HttpPost]
        [EIPPerformanceMeasureExpectedFromProjectManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditEIPPerformanceMeasureExpectedsForProject(ProjectPrimaryKey projectPrimaryKey, EditEIPPerformanceMeasureExpectedViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditEIPPerformanceMeasureExpecteds(project, viewModel);
            }
            var currentEIPPerformanceMeasureExpecteds = project.EIPPerformanceMeasureExpecteds.ToList();
            return UpdateEIPPerformanceMeasureExpecteds(viewModel, currentEIPPerformanceMeasureExpecteds);
        }

        private static ActionResult UpdateEIPPerformanceMeasureExpecteds(EditEIPPerformanceMeasureExpectedViewModel viewModel,
            List<EIPPerformanceMeasureExpected> currentEIPPerformanceMeasureExpecteds)
        {
            HttpRequestStorage.DatabaseEntities.EIPPerformanceMeasureExpecteds.Load();
            var allEIPPerformanceMeasureExpecteds = HttpRequestStorage.DatabaseEntities.EIPPerformanceMeasureExpecteds.Local;
            HttpRequestStorage.DatabaseEntities.EIPPerformanceMeasureExpectedSubcategoryOptions.Load();
            var allEIPPerformanceMeasureExpectedSubcategoryOptions = HttpRequestStorage.DatabaseEntities.EIPPerformanceMeasureExpectedSubcategoryOptions.Local;
            viewModel.UpdateModel(currentEIPPerformanceMeasureExpecteds, allEIPPerformanceMeasureExpecteds, allEIPPerformanceMeasureExpectedSubcategoryOptions);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditEIPPerformanceMeasureExpecteds(Project project, EditEIPPerformanceMeasureExpectedViewModel viewModel)
        {
            var selectableEIPPerformanceMeasures = HttpRequestStorage.DatabaseEntities.EIPPerformanceMeasures.ToList().Where(pm => pm.EIPPerformanceMeasureType.ValuesAreNotCalculated(project.ImplementsMultipleProjects));
            var viewData = new EditEIPPerformanceMeasureExpectedViewData(project, selectableEIPPerformanceMeasures.ToList());
            return RazorPartialView<EditEIPPerformanceMeasureExpected, EditEIPPerformanceMeasureExpectedViewData, EditEIPPerformanceMeasureExpectedViewModel>(viewData, viewModel);
        }
    }
}