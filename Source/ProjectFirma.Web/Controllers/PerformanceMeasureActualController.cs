/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasureActualController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.PerformanceMeasureActual;
using ProjectFirma.Web.Views.Shared.SortOrder;
using ProjectFirmaModels.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace ProjectFirma.Web.Controllers
{
    public class PerformanceMeasureActualController : FirmaBaseController
    {

        private void PrePopulateReportedPerformanceMeasures(Project project, ICollection<PerformanceMeasureExpected> expectedPerformanceMeasures,
            List<PerformanceMeasureActualSimple> performanceMeasureActualSimples)
        {
            var yearRange = project.GetProjectUpdateImplementationStartToCompletionYearRange();
            var reportingPeriods = HttpRequestStorage.DatabaseEntities.PerformanceMeasureReportingPeriods.ToList();
            foreach (var calendarYear in yearRange)
            {
                var reportingPeriod =
                    reportingPeriods.SingleOrDefault(x => x.PerformanceMeasureReportingPeriodCalendarYear == calendarYear);
                if (reportingPeriod == null)
                {
                    var newPerformanceMeasureReportingPeriod =
                        new PerformanceMeasureReportingPeriod(calendarYear, calendarYear.ToString());
                    HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureReportingPeriods.Add(
                        newPerformanceMeasureReportingPeriod);
                    HttpRequestStorage.DatabaseEntities.SaveChanges(CurrentFirmaSession);
                }

                var onesToAdd = expectedPerformanceMeasures.Select(x => new PerformanceMeasureActualSimple(x, calendarYear));
                performanceMeasureActualSimples.AddRange(onesToAdd);
            }
        }

        [HttpGet]
        [PerformanceMeasureActualFromProjectManageFeature]
        public PartialViewResult EditPerformanceMeasureActualsForProject(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;

            var expectedPerformanceMeasures = project.PerformanceMeasureExpecteds;

            var reportedPerformanceMeasures = project.PerformanceMeasureActuals;

            var performanceMeasureActualSimples = new List<PerformanceMeasureActualSimple>();

            if (reportedPerformanceMeasures.Any())
            {
                performanceMeasureActualSimples =
                    project.PerformanceMeasureActuals.OrderBy(pam => pam.PerformanceMeasure.PerformanceMeasureSortOrder).ThenBy(x => x.PerformanceMeasure.GetDisplayName())
                        .ThenByDescending(x => x.PerformanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodCalendarYear)
                        .Select(x => new PerformanceMeasureActualSimple(x))
                        .ToList();
            }
            else
            {
                PrePopulateReportedPerformanceMeasures(project, expectedPerformanceMeasures, performanceMeasureActualSimples);
            }


            var projectExemptReportingYears = project.GetPerformanceMeasuresExemptReportingYears().Select(x => new ProjectExemptReportingYearSimple(x)).ToList();
            var currentExemptedYears = projectExemptReportingYears.Select(x => x.CalendarYear).ToList();
            var endYear = DateTime.Now.Year;
            var startYear = project.ImplementationStartYear ?? endYear;
            var possibleYearsToExempt = FirmaDateUtilities.GetRangeOfYears(startYear, endYear).OrderBy(x => x).ToList();
            projectExemptReportingYears.AddRange(
                possibleYearsToExempt.Where(x => !currentExemptedYears.Contains(x)).Select((x, index) => new ProjectExemptReportingYearSimple(-(index + 1), project.ProjectID, x)));

            var viewModel = new EditPerformanceMeasureActualsViewModel(performanceMeasureActualSimples,
                project.PerformanceMeasureActualYearsExemptionExplanation,
                projectExemptReportingYears.OrderBy(x => x.CalendarYear).ToList());
            return ViewEditPerformanceMeasureActuals(project, viewModel);
        }

        [HttpPost]
        [PerformanceMeasureActualFromProjectManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditPerformanceMeasureActualsForProject(ProjectPrimaryKey projectPrimaryKey, EditPerformanceMeasureActualsViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditPerformanceMeasureActuals(project, viewModel);
            }
            var currentPerformanceMeasureActuals = project.PerformanceMeasureActuals.ToList();
            return UpdatePerformanceMeasureActuals(viewModel, currentPerformanceMeasureActuals, project);
        }

        private static ActionResult UpdatePerformanceMeasureActuals(EditPerformanceMeasureActualsViewModel viewModel,
            List<PerformanceMeasureActual> currentPerformanceMeasureActuals,
            Project project)
        {
            HttpRequestStorage.DatabaseEntities.PerformanceMeasureActuals.Load();
            var allPerformanceMeasureActuals = HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureActuals.Local;
            HttpRequestStorage.DatabaseEntities.PerformanceMeasureActualSubcategoryOptions.Load();
            var allPerformanceMeasureActualSubcategoryOptions = HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureActualSubcategoryOptions.Local;
            HttpRequestStorage.DatabaseEntities.PerformanceMeasureReportingPeriods.Load();
            var allPerformanceMeasureReportingPeriods = HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureReportingPeriods.Local;
            viewModel.UpdateModel(currentPerformanceMeasureActuals, allPerformanceMeasureActuals, allPerformanceMeasureActualSubcategoryOptions, project, allPerformanceMeasureReportingPeriods);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditPerformanceMeasureActuals(Project project, EditPerformanceMeasureActualsViewModel viewModel)
        {
            var performanceMeasures = PerformanceMeasureModelExtensions.GetReportablePerformanceMeasures().ToList().SortByOrderThenName().ToList();
            var showExemptYears = project.GetPerformanceMeasuresExemptReportingYears().Any() ||
                                  ModelState.Values.SelectMany(x => x.Errors)
                                      .Any(
                                          x =>
                                              x.ErrorMessage == FirmaValidationMessages.ExplanationNotNecessaryForProjectExemptYears ||
                                              x.ErrorMessage == FirmaValidationMessages.ExplanationNecessaryForProjectExemptYears ||
                                              x.ErrorMessage == FirmaValidationMessages.ExplanationForProjectExemptYearsExceedsMax(Project.FieldLengths.PerformanceMeasureActualYearsExemptionExplanation) ||
                                              x.ErrorMessage == FirmaValidationMessages.PerformanceMeasureOrExemptYearsRequired);
            var viewData = new EditPerformanceMeasureActualsViewData(project, performanceMeasures, showExemptYears);
            return RazorPartialView<EditPerformanceMeasureActuals, EditPerformanceMeasureActualsViewData, EditPerformanceMeasureActualsViewModel>(viewData, viewModel);
        }
    }
}
