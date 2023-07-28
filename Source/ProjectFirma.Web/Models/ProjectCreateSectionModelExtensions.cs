﻿using System;
using System.Linq;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Views.ProjectCreate;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class ProjectCreateSectionModelExtensions
    {
        public static bool IsComplete(this ProjectCreateSection projectCreateSection, Project project, int? classificationSystemID = null)
        {
            if (project == null)
            {
                return false;
            }

            var currentFirmaSession = HttpRequestStorage.FirmaSession;

            switch (projectCreateSection.ToEnum)
            {
                case ProjectCreateSectionEnum.Basics:
                    return !new BasicsViewModel(project).GetValidationResults().Any();
                case ProjectCreateSectionEnum.CustomAttributes:
                    return project.AreProjectCustomAttributesValid(currentFirmaSession);
                case ProjectCreateSectionEnum.LocationSimple:
                    var locationSimpleValidationResults = new LocationSimpleViewModel(project).GetValidationResults();
                    return !locationSimpleValidationResults.Any();
                case ProjectCreateSectionEnum.Organizations:
                    return !new OrganizationsViewModel(project, currentFirmaSession).GetValidationResults().ToList().Any();
                case ProjectCreateSectionEnum.Contacts:
                    return !new ContactsViewModel(project, currentFirmaSession).GetValidationResults().ToList().Any();
                case ProjectCreateSectionEnum.LocationDetailed:
                    return true;
                case ProjectCreateSectionEnum.ExpectedAccomplishments:
                    return true;
                case ProjectCreateSectionEnum.ReportedAccomplishments:
                    if (!MultiTenantHelpers.TrackAccomplishments())
                    {
                        return true;
                    }
                    var pmValidationResults = new PerformanceMeasuresViewModel(
                        project.PerformanceMeasureActuals.Select(x => new PerformanceMeasureActualSimple(x)).ToList(),
                        project.PerformanceMeasureActualYearsExemptionExplanation,
                        project.GetPerformanceMeasuresExemptReportingYears().Select(x => new ProjectExemptReportingYearSimple(x)).ToList(), project)
                    {
                        ProjectID = project.ProjectID
                    }.GetValidationResults();
                    return !pmValidationResults.Any();
                case ProjectCreateSectionEnum.Budget:
                    if (!MultiTenantHelpers.ReportFinancialsAtProjectLevel())
                    {
                        return true;
                    }
                    // todo: more complicated than that.
                    return ProjectCreateSection.Basics.IsComplete(project);
                case ProjectCreateSectionEnum.ReportedExpenditures:
                    if (!MultiTenantHelpers.ReportFinancialsAtProjectLevel())
                    {
                        return true;
                    }
                    if (MultiTenantHelpers.GetTenantAttributeFromCache().BudgetType == BudgetType.AnnualBudgetByCostType)
                    {
                        var expectedYears =
                            project.CalculateCalendarYearRangeForExpendituresWithoutAccountingForExistingYears();
                        var missingYears = expectedYears.GetMissingYears(project.ProjectFundingSourceExpenditures.Select(x => x.CalendarYear)).ToList();

                        // for expenditures by cost type, we are just validating that either they have any expenditures for the required year range or they have no expenditures but have an explanation
                        return (project.ProjectFundingSourceExpenditures.Any() && !missingYears.Any() &&
                                string.IsNullOrWhiteSpace(project.ExpendituresNote)) ||
                               (!project.ProjectFundingSourceExpenditures.Any() &&
                                !string.IsNullOrWhiteSpace(project.ExpendituresNote));
                    }
                    else
                    {
                        var projectFundingSourceExpenditures = project.ProjectFundingSourceExpenditures.ToList();
                        var calendarYearRangeForExpenditures = projectFundingSourceExpenditures.CalculateCalendarYearRangeForExpenditures(project);
                        var projectFundingSourceExpenditureBulks = ProjectFundingSourceExpenditureBulk.MakeFromList(projectFundingSourceExpenditures, calendarYearRangeForExpenditures);
                        var validationResults = new ExpendituresViewModel(projectFundingSourceExpenditureBulks,
                                    project)
                                {ProjectID = project.ProjectID}
                            .GetValidationResults();
                        return !validationResults.Any();
                    }

                case ProjectCreateSectionEnum.Classifications:
                    if (classificationSystemID.HasValue)
                    {
                        var projectClassificationSimples = ProjectCreateController.GetProjectClassificationSimples(project, classificationSystemID.Value);
                        var classificationValidationResults = new EditProposalClassificationsViewModel(projectClassificationSimples, project).GetValidationResults();
                        return !classificationValidationResults.Any();
                    }
                    return false;
                case ProjectCreateSectionEnum.Assessment:
                    return !new EditAssessmentViewModel(project.ProjectAssessmentQuestions.Select(x => new ProjectAssessmentQuestionSimple(x)).ToList()).GetValidationResults().Any();
                case ProjectCreateSectionEnum.Photos:
                    return ProjectCreateSection.Basics.IsComplete(project);
                case ProjectCreateSectionEnum.AttachmentsAndNotes:
                    return ProjectCreateSection.Basics.IsComplete(project);
                case ProjectCreateSectionEnum.BulkSetSpatialInformation:
                    return ProjectCreateSection.Basics.IsComplete(project);
                case ProjectCreateSectionEnum.PartnerFinder:
                    return true;
                case ProjectCreateSectionEnum.ExternalLinks:
                    return ProjectCreateSection.Basics.IsComplete(project);
                default:
                    throw new ArgumentOutOfRangeException($"IsComplete(): Unhandled ProjectCreateSection Enum: {projectCreateSection.ToEnum}");
            }
        }
        public static string GetSectionUrl(this ProjectCreateSection projectCreateSection, Project project, int? classificationSystemID = null)
        {
            if (project == null)
            {
                return null;
            }
            switch (projectCreateSection.ToEnum)
            {
                case ProjectCreateSectionEnum.Basics:
                    return SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.EditBasics(project.ProjectID));
                case ProjectCreateSectionEnum.CustomAttributes:
                    return ProjectCreateSection.Basics.IsComplete(project) ? SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.ProjectCustomAttributes(project.ProjectID)) : null;
                case ProjectCreateSectionEnum.LocationSimple:
                    return ProjectCreateSection.Basics.IsComplete(project) ? SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.EditLocationSimple(project.ProjectID)) : null;
                case ProjectCreateSectionEnum.Organizations:
                    return ProjectCreateSection.Basics.IsComplete(project) ? SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.Organizations(project.ProjectID)) : null;
                case ProjectCreateSectionEnum.Contacts:
                    return ProjectCreateSection.Basics.IsComplete(project) ? SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.Contacts(project.ProjectID)) : null;
                case ProjectCreateSectionEnum.LocationDetailed:
                    return ProjectCreateSection.Basics.IsComplete(project) ? SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.EditLocationDetailed(project.ProjectID)) : null;
                case ProjectCreateSectionEnum.ExpectedAccomplishments:
                    return ProjectCreateSection.Basics.IsComplete(project) ? SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.ExpectedPerformanceMeasures(project.ProjectID)) : null;
                case ProjectCreateSectionEnum.ReportedAccomplishments:
                    return ProjectCreateSection.Basics.IsComplete(project) ? SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.PerformanceMeasures(project.ProjectID)) : null;
                case ProjectCreateSectionEnum.Budget:
                    return ProjectCreateSection.Basics.IsComplete(project)
                        ? MultiTenantHelpers.GetTenantAttributeFromCache().BudgetType == BudgetType.AnnualBudgetByCostType
                            ? SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.ExpectedFundingByCostType(project.ProjectID))
                            : SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.ExpectedFunding(project.ProjectID))
                        : null;

                case ProjectCreateSectionEnum.ReportedExpenditures:
                    return ProjectCreateSection.Basics.IsComplete(project) 
                        ? MultiTenantHelpers.GetTenantAttributeFromCache().BudgetType == BudgetType.AnnualBudgetByCostType
                            ? SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.ExpendituresByCostType(project.ProjectID)) 
                            : SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.Expenditures(project.ProjectID))
                        : null;
                case ProjectCreateSectionEnum.Classifications:
                    return classificationSystemID.HasValue && ProjectCreateSection.Basics.IsComplete(project) ? SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.EditClassifications(project.ProjectID, classificationSystemID)) : null;
                case ProjectCreateSectionEnum.Assessment:
                    return ProjectCreateSection.Basics.IsComplete(project) ? SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.EditAssessment(project.ProjectID)) : null;
                case ProjectCreateSectionEnum.Photos:
                    return ProjectCreateSection.Basics.IsComplete(project) ? SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.Photos(project.ProjectID)) : null;
                case ProjectCreateSectionEnum.AttachmentsAndNotes:
                    return ProjectCreateSection.Basics.IsComplete(project) ? SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.AttachmentsAndNotes(project.ProjectID)) : null;
                case ProjectCreateSectionEnum.BulkSetSpatialInformation:
                    return ProjectCreateSection.Basics.IsComplete(project) ? SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.BulkSetSpatialInformation(project.ProjectID)) : null;
                case ProjectCreateSectionEnum.PartnerFinder:
                    return ProjectCreateSection.Basics.IsComplete(project) ? SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.PartnerFinder(project)) : null;
                case ProjectCreateSectionEnum.ExternalLinks:
                    return ProjectCreateSection.Basics.IsComplete(project) ? SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.ExternalLinks(project)) : null;

                default:
                    throw new ArgumentOutOfRangeException($"IsComplete(): Unhandled ProjectCreateSection Enum: {projectCreateSection.ToEnum}");
            }
        }
    }
}