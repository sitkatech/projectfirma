using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using FluentValidation;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Areas.EIP.Views.Shared.ProjectControls
{
    public class EditProjectViewModelValidator : AbstractValidator<EditProjectViewModel>
    {
        public const string NeedsLeadImplementingOrganizationMessage = "Lead Implementer must be specified";
        private const string SinceProjectIsInCompletedStageCompletionYearNeedsToBeLessThanOrEqualToThisYear =
            "Since project is in Completed stage, Completion Year needs to be less than or equal to this year";
        private const string SinceProjectIsInPostImplementationStageCompletionYearNeedsToBeLessThanOrEqualToThisYear =
            "Since project is in Post-Implementation stage, Completion Year needs to be less than or equal to this year";
        private const string HasToImplementsMultipleProjectsIfThereAreValuesForEIPPerformanceMeasure1And2And3And34 =
            "The project has expected or reported values for Performance Measure 1, 2, 3 or 34 entered; please remove those before you can set this project to not implement multiple projects";
        private const string TransportationObjectiveRequiredIfIsTransportationProject = "Since project is a Transportation project, Transportation Objective must be specified";
        private const string SinceProjectHasExistingUpdateCannotChangeStage = "There are updates to this project that have not been submitted.<br />Making this change can potentially affect that update in process.<br />Please delete the update if you want to change this project's stage.";

        // Validators are singletons, so this list must be initialized every time.
        public Func<IList<Models.Project>> Projects = () =>
        {
            HttpRequestStorage.DatabaseEntities.Projects.Load();
            return HttpRequestStorage.DatabaseEntities.Projects.Local;
        };

        public Func<IList<Models.EIPPerformanceMeasureActual>> EIPPerformanceMeasureActuals = () =>
        {
            HttpRequestStorage.DatabaseEntities.EIPPerformanceMeasureActuals.Load();
            return HttpRequestStorage.DatabaseEntities.EIPPerformanceMeasureActuals.Local;
        };

        public Func<IList<Models.EIPPerformanceMeasureExpected>> EIPPerformanceMeasureExpecteds = () =>
        {
            HttpRequestStorage.DatabaseEntities.EIPPerformanceMeasureExpecteds.Load();
            return HttpRequestStorage.DatabaseEntities.EIPPerformanceMeasureExpecteds.Local;
        };

        public EditProjectViewModelValidator(IList<Models.Project> projects,
            IList<Models.EIPPerformanceMeasureActual> eipPerformanceMeasureActuals,
            IList<Models.EIPPerformanceMeasureExpected> eipPerformanceMeasureExpecteds) : this()
        {
            Projects = (() => projects);
            EIPPerformanceMeasureActuals = (() => eipPerformanceMeasureActuals);
            EIPPerformanceMeasureExpecteds = (() => eipPerformanceMeasureExpecteds);
        }

        public EditProjectViewModelValidator()
        {
            RuleFor(x => x.ProjectName)
                .NotEmpty()
                .WithName(Models.FieldDefinition.ProjectName.FieldDefinitionDisplayName)
                .Length(1, Models.Project.FieldLengths.ProjectName)
                .Must((viewModel, projectName) => Models.Project.IsProjectNameUnique(Projects(), projectName, viewModel.ProjectID))
                .WithMessage(ProjectFirmaValidationMessages.ProjectNameUnique);
            RuleFor(x => x.ProjectDescription).NotEmpty().WithName(Models.FieldDefinition.ProjectDescription.FieldDefinitionDisplayName);
            RuleFor(x => x.ImplementationStartYear).GreaterThanOrEqualTo(x => x.PlanningDesignStartYear ?? 0).WithMessage(ProjectFirmaValidationMessages.ImplementationStartYearGreaterThanPlanningDesignStartYear);
            RuleFor(x => x.CompletionYear).GreaterThanOrEqualTo(x => x.ImplementationStartYear ?? 0).WithMessage(ProjectFirmaValidationMessages.CompletionYearGreaterThanEqualToImplementationStartYear);
            RuleFor(x => x.ActionPriorityID).NotEmpty().WithName(Models.FieldDefinition.ActionPriority.FieldDefinitionDisplayName);
            RuleFor(x => x.ProjectStageID).NotEmpty().WithName(Models.FieldDefinition.Stage.FieldDefinitionDisplayName);
            RuleFor(x => x.LeadImplementerOrganizationID)
                .Must((viewModel, leadImplementingOrganizationID) => ModelObjectHelpers.IsRealPrimaryKeyValue(viewModel.ProjectID) || leadImplementingOrganizationID.HasValue)
                .WithMessage(NeedsLeadImplementingOrganizationMessage);
            RuleFor(x => x.CompletionYear)
                .Must((viewModel, completionYear) => viewModel.ProjectStageID != ProjectStage.Completed.ProjectStageID || completionYear <= DateTime.Now.Year)
                .WithMessage(SinceProjectIsInCompletedStageCompletionYearNeedsToBeLessThanOrEqualToThisYear);
            RuleFor(x => x.CompletionYear)
                .Must((viewModel, completionYear) => viewModel.ProjectStageID != ProjectStage.PostImplementation.ProjectStageID || completionYear <= DateTime.Now.Year)
                .WithMessage(SinceProjectIsInPostImplementationStageCompletionYearNeedsToBeLessThanOrEqualToThisYear);
            RuleFor(x => x.ImplementsMultipleProjects).Must((viewModel, implementsMultipleProjects) =>
            {
                if (!implementsMultipleProjects)
                {
                    return
                        EIPPerformanceMeasureActuals()
                            .Where(x => x.ProjectID == viewModel.ProjectID)
                            .ToList()
                            .All(x => !x.EIPPerformanceMeasure.EIPPerformanceMeasureType.ForProjectsImplementsMultiplePrograms()) &&
                        EIPPerformanceMeasureExpecteds()
                            .Where(x => x.ProjectID == viewModel.ProjectID)
                            .ToList()
                            .All(x => !x.EIPPerformanceMeasure.EIPPerformanceMeasureType.ForProjectsImplementsMultiplePrograms());
                }
                return true;
            }).WithMessage(HasToImplementsMultipleProjectsIfThereAreValuesForEIPPerformanceMeasure1And2And3And34);
            RuleFor(x => x.TransportationObjectiveID).NotEmpty().When(viewModel => viewModel.IsTransportationProject).WithMessage(TransportationObjectiveRequiredIfIsTransportationProject);
            RuleFor(x => x.ProjectStageID).Must((viewModel, projectStageID) => !viewModel.HasExistingProjectUpdate || (viewModel.HasExistingProjectUpdate && viewModel.OldProjectStageID == viewModel.ProjectStageID)).WithMessage(SinceProjectHasExistingUpdateCannotChangeStage);
        }
    }
}