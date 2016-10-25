using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.EIPPerformanceMeasureActual;
using ProjectFirma.Web.Controllers;
using LtInfo.Common;
using LtInfo.Common.MvcResults;

namespace ProjectFirma.Web.Controllers
{
    public class EIPPerformanceMeasureActualController : FirmaBaseController
    {
        [HttpGet]
        [EIPPerformanceMeasureActualFromProjectManageFeature]
        public PartialViewResult EditEIPPerformanceMeasureActualsForProject(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var eipPerformanceMeasureActualSimples = project.EIPPerformanceMeasureActuals.OrderBy(pam => pam.EIPPerformanceMeasureID).Select(x => new EIPPerformanceMeasureActualSimple(x)).ToList();
            var projectExemptReportingYears = project.ProjectExemptReportingYears.Select(x => new ProjectExemptReportingYearSimple(x)).ToList();
            var currentExemptedYears = projectExemptReportingYears.Select(x => x.CalendarYear).ToList();
            var endYear = DateTime.Now.Year;
            var startYear = project.ImplementationStartYear ?? endYear;
            var possibleYearsToExempt = ProjectFirmaDateUtilities.GetRangeOfYears(startYear, endYear).OrderBy(x => x).ToList();
            projectExemptReportingYears.AddRange(
                possibleYearsToExempt.Where(x => !currentExemptedYears.Contains(x)).Select((x, index) => new ProjectExemptReportingYearSimple(-(index + 1), project.ProjectID, x)));

            var viewModel = new EditEIPPerformanceMeasureActualsViewModel(eipPerformanceMeasureActualSimples,
                project.EIPPerformanceMeasureActualYearsExemptionExplanation,
                projectExemptReportingYears.OrderBy(x => x.CalendarYear).ToList());
            return ViewEditEIPPerformanceMeasureActuals(project, viewModel);
        }

        [HttpPost]
        [EIPPerformanceMeasureActualFromProjectManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditEIPPerformanceMeasureActualsForProject(ProjectPrimaryKey projectPrimaryKey, EditEIPPerformanceMeasureActualsViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditEIPPerformanceMeasureActuals(project, viewModel);
            }
            var currentEIPPerformanceMeasureActuals = project.EIPPerformanceMeasureActuals.ToList();
            return UpdateEIPPerformanceMeasureActuals(viewModel, currentEIPPerformanceMeasureActuals, project);
        }

        private static ActionResult UpdateEIPPerformanceMeasureActuals(EditEIPPerformanceMeasureActualsViewModel viewModel,
            List<EIPPerformanceMeasureActual> currentEIPPerformanceMeasureActuals,
            Project project)
        {
            HttpRequestStorage.DatabaseEntities.EIPPerformanceMeasureActuals.Load();
            var allEIPPerformanceMeasureActuals = HttpRequestStorage.DatabaseEntities.EIPPerformanceMeasureActuals.Local;
            HttpRequestStorage.DatabaseEntities.EIPPerformanceMeasureActualSubcategoryOptions.Load();
            var allEIPPerformanceMeasureActualSubcategoryOptions = HttpRequestStorage.DatabaseEntities.EIPPerformanceMeasureActualSubcategoryOptions.Local;
            viewModel.UpdateModel(currentEIPPerformanceMeasureActuals, allEIPPerformanceMeasureActuals, allEIPPerformanceMeasureActualSubcategoryOptions, project);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditEIPPerformanceMeasureActuals(Project project, EditEIPPerformanceMeasureActualsViewModel viewModel)
        {
            var selectableEIPPerformanceMeasures = HttpRequestStorage.DatabaseEntities.EIPPerformanceMeasures.ToList().Where(pm => pm.EIPPerformanceMeasureType.ValuesAreNotCalculated(project.ImplementsMultipleProjects));
            var showExemptYears = project.ProjectExemptReportingYears.Any() ||
                                  ModelState.Values.SelectMany(x => x.Errors)
                                      .Any(
                                          x =>
                                              x.ErrorMessage == ProjectFirmaValidationMessages.ExplanationNotNecessaryForProjectExemptYears ||
                                              x.ErrorMessage == ProjectFirmaValidationMessages.ExplanationNecessaryForProjectExemptYears);
            var viewData = new EditEIPPerformanceMeasureActualsViewData(project, selectableEIPPerformanceMeasures.ToList(), showExemptYears);
            return RazorPartialView<EditEIPPerformanceMeasureActuals, EditEIPPerformanceMeasureActualsViewData, EditEIPPerformanceMeasureActualsViewModel>(viewData, viewModel);
        }
    }
}