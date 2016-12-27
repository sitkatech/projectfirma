using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using FluentValidation;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.Shared.ProjectControls
{
    public class EditProjectViewModelValidator : AbstractValidator<EditProjectViewModel>
    {
        public const string NeedsLeadImplementingOrganizationMessage = "Lead Implementer must be specified";
        private const string SinceProjectIsInCompletedStageCompletionYearNeedsToBeLessThanOrEqualToThisYear =
            "Since project is in Completed stage, Completion Year needs to be less than or equal to this year";
        private const string SinceProjectIsInPostImplementationStageCompletionYearNeedsToBeLessThanOrEqualToThisYear =
            "Since project is in Post-Implementation stage, Completion Year needs to be less than or equal to this year";
        private const string SinceProjectHasExistingUpdateCannotChangeStage = "There are updates to this project that have not been submitted.<br />Making this change can potentially affect that update in process.<br />Please delete the update if you want to change this project's stage.";

        // Validators are singletons, so this list must be initialized every time.
        public Func<IList<Models.Project>> Projects = () =>
        {
            HttpRequestStorage.DatabaseEntities.Projects.Load();
            return HttpRequestStorage.DatabaseEntities.Projects.Local;
        };

        public Func<IList<Models.PerformanceMeasureActual>> PerformanceMeasureActuals = () =>
        {
            HttpRequestStorage.DatabaseEntities.PerformanceMeasureActuals.Load();
            return HttpRequestStorage.DatabaseEntities.PerformanceMeasureActuals.Local;
        };

        public Func<IList<PerformanceMeasureExpected>> PerformanceMeasureExpecteds = () =>
        {
            HttpRequestStorage.DatabaseEntities.PerformanceMeasureExpecteds.Load();
            return HttpRequestStorage.DatabaseEntities.PerformanceMeasureExpecteds.Local;
        };

        public EditProjectViewModelValidator(IList<Models.Project> projects,
            IList<Models.PerformanceMeasureActual> performanceMeasureActuals,
            IList<PerformanceMeasureExpected> performanceMeasureExpecteds) : this()
        {
            Projects = (() => projects);
            PerformanceMeasureActuals = (() => performanceMeasureActuals);
            PerformanceMeasureExpecteds = (() => performanceMeasureExpecteds);
        }

        public EditProjectViewModelValidator()
        {
            RuleFor(x => x.ProjectName)
                .NotEmpty()
                .WithName(Models.FieldDefinition.ProjectName.FieldDefinitionDisplayName)
                .Length(1, Models.Project.FieldLengths.ProjectName)
                .Must((viewModel, projectName) => Models.Project.IsProjectNameUnique(Projects(), projectName, viewModel.ProjectID))
                .WithMessage(FirmaValidationMessages.ProjectNameUnique);
            RuleFor(x => x.ProjectDescription).NotEmpty().WithName(Models.FieldDefinition.ProjectDescription.FieldDefinitionDisplayName);
            RuleFor(x => x.ImplementationStartYear).GreaterThanOrEqualTo(x => x.PlanningDesignStartYear ?? 0).WithMessage(FirmaValidationMessages.ImplementationStartYearGreaterThanPlanningDesignStartYear);
            RuleFor(x => x.CompletionYear).GreaterThanOrEqualTo(x => x.ImplementationStartYear ?? 0).WithMessage(FirmaValidationMessages.CompletionYearGreaterThanEqualToImplementationStartYear);
            RuleFor(x => x.TaxonomyTierOneID).NotEmpty().WithName(Models.FieldDefinition.TaxonomyTierOne.FieldDefinitionDisplayName);
            RuleFor(x => x.ProjectStageID).NotEmpty().WithName(Models.FieldDefinition.ProjectStage.FieldDefinitionDisplayName);
            RuleFor(x => x.LeadImplementerOrganizationID)
                .Must((viewModel, leadImplementingOrganizationID) => ModelObjectHelpers.IsRealPrimaryKeyValue(viewModel.ProjectID) || leadImplementingOrganizationID.HasValue)
                .WithMessage(NeedsLeadImplementingOrganizationMessage);
            RuleFor(x => x.CompletionYear)
                .Must((viewModel, completionYear) => viewModel.ProjectStageID != ProjectStage.Completed.ProjectStageID || completionYear <= DateTime.Now.Year)
                .WithMessage(SinceProjectIsInCompletedStageCompletionYearNeedsToBeLessThanOrEqualToThisYear);
            RuleFor(x => x.CompletionYear)
                .Must((viewModel, completionYear) => viewModel.ProjectStageID != ProjectStage.PostImplementation.ProjectStageID || completionYear <= DateTime.Now.Year)
                .WithMessage(SinceProjectIsInPostImplementationStageCompletionYearNeedsToBeLessThanOrEqualToThisYear);
            RuleFor(x => x.ProjectStageID).Must((viewModel, projectStageID) => !viewModel.HasExistingProjectUpdate || (viewModel.HasExistingProjectUpdate && viewModel.OldProjectStageID == viewModel.ProjectStageID)).WithMessage(SinceProjectHasExistingUpdateCannotChangeStage);
        }
    }
}