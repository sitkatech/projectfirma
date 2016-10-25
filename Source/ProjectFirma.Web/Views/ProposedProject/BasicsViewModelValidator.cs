using System;
using System.Collections.Generic;
using System.Data.Entity;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using FluentValidation;

namespace ProjectFirma.Web.Views.ProposedProject
{
    public class BasicsViewModelValidator : AbstractValidator<BasicsViewModel>
    {
        public const string NeedsLeadImplementingOrganizationMessage = "Lead Implementer must be specified";
        // Validators are singletons, so this list must be initialized every time.
        public Func<IList<Models.ProposedProject>> ProposedProjects = () =>
        {
            HttpRequestStorage.DatabaseEntities.ProposedProjects.Load();
            return HttpRequestStorage.DatabaseEntities.ProposedProjects.Local;
        };

        public BasicsViewModelValidator(IList<Models.ProposedProject> proposedProjects) : this()
        {
            ProposedProjects = (() => proposedProjects);
        }

        public BasicsViewModelValidator()
        {
            RuleFor(x => x.ProposedActionPriorityID).NotNull().WithMessage("Select an Action Priority");
            RuleFor(x => x.ProjectName)
                .NotEmpty()
                .WithName(Models.FieldDefinition.ProjectName.FieldDefinitionDisplayName)
                .Length(1, Models.ProposedProject.FieldLengths.ProjectName)
                .Must((viewModel, proposedProjectName) =>
                {
                    var isProjectNameUnique = Models.ProposedProject.IsProjectNameUnique(ProposedProjects(), proposedProjectName, viewModel.ProposedProjectID);
                    return isProjectNameUnique;
                })
                .WithMessage(FirmaValidationMessages.ProjectNameUnique);
            RuleFor(x => x.ProjectDescription).NotEmpty().Length(1, Models.Project.ProjectDescriptionMaximumLength).WithName(Models.FieldDefinition.ProjectDescription.FieldDefinitionDisplayName);

            RuleFor(x => x.FundingTypeID).NotNull();

            RuleFor(x => x.EstimatedTotalCost).Must((viewModel, x) => viewModel.FundingTypeID != (int) FundingTypeEnum.Capital || viewModel.EstimatedTotalCost.HasValue).WithMessage("Required for Capital projects");
            RuleFor(x => x.SecuredFunding).Must((viewModel, x) => viewModel.FundingTypeID != (int)FundingTypeEnum.Capital || viewModel.SecuredFunding.HasValue).WithMessage("Required for Capital projects");
            RuleFor(x => x.EstimatedAnnualOperatingCost).Must((viewModel, x) => viewModel.FundingTypeID != (int)FundingTypeEnum.OperationsAndMaintenance || viewModel.EstimatedAnnualOperatingCost.HasValue).WithMessage("Required for Operations and Maintenance projects");
                     
            RuleFor(x => x.PlanningDesignStartYear).NotNull();
            RuleFor(x => x.ImplementationStartYear).NotNull();
            RuleFor(x => x.ImplementationStartYear).GreaterThanOrEqualTo(x => x.PlanningDesignStartYear ?? 0).WithMessage(FirmaValidationMessages.ImplementationStartYearGreaterThanPlanningDesignStartYear);
            RuleFor(x => x.CompletionYear).GreaterThanOrEqualTo(x => x.ImplementationStartYear ?? 0).WithMessage(FirmaValidationMessages.CompletionYearGreaterThanEqualToImplementationStartYear);
            RuleFor(x => x.LeadImplementerOrganizationID)
                .NotEmpty()
                .WithMessage(NeedsLeadImplementingOrganizationMessage);
            RuleFor(x => x.IsTransportationProject).NotNull();

            
            
            RuleFor(x => x.ImplementsMultipleProjects).Must((viewModel, x) =>
            {
                var isApprover = new ProposedProjectApproveFeature().HasPermissionByPerson(HttpRequestStorage.Person);
                return !isApprover || x.HasValue;
            }).WithMessage("Approvers are required to provide determine whether a project is a program"); ;
            RuleFor(x => x.TransportationObjectiveID)
                .Must((viewModel, x) =>
                {
                    var isApprover = new ProposedProjectApproveFeature().HasPermissionByPerson(HttpRequestStorage.Person);
                    return !isApprover || !viewModel.IsTransportationProject.HasValue || !viewModel.IsTransportationProject.Value || x.HasValue;
                })
                .WithMessage("Approvers are required to provide a Transportation Objective");
            RuleFor(x => x.OnFederalTransportationImprovementProgramList)
                .Must((viewModel, x) =>
                {
                    var isApprover = new ProposedProjectApproveFeature().HasPermissionByPerson(HttpRequestStorage.Person);
                    return !isApprover || !viewModel.IsTransportationProject.HasValue || !viewModel.IsTransportationProject.Value || x.HasValue;
                })
                .WithMessage("Approvers are required to determine with the project is on the FTIP list");





        }
    }
}