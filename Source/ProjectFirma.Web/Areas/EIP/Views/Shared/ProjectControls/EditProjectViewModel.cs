using System;
using System.ComponentModel.DataAnnotations;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using FluentValidation.Attributes;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Areas.EIP.Views.Shared.ProjectControls
{
    [Validator(typeof(EditProjectViewModelValidator))]
    public class EditProjectViewModel : FormViewModel
    {
        public int ProjectID { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.ProjectName)]
        public string ProjectName { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.ProjectDescription)]
        [StringLength(Models.Project.ProjectDescriptionMaximumLength)]
        public string ProjectDescription { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.Stage)]
        public int ProjectStageID { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.FundingType)]
        public int FundingTypeID { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.ImplementationStartYear)]
        public int? ImplementationStartYear { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.PlanningDesignStartYear)]
        public int? PlanningDesignStartYear { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.CompletionYear)]
        public int? CompletionYear { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.ActionPriority)]
        public int ActionPriorityID { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.EstimatedTotalCost)]
        public Money? EstimatedTotalCost { get; set; }
        
        [FieldDefinitionDisplay(FieldDefinitionEnum.EstimatedAnnualOperatingCost)]
        public Money? EstimatedAnnualOperatingCost { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.SecuredFunding)]
        public Money? SecuredFunding { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.LeadImplementer)]
        public int? LeadImplementerOrganizationID { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.ProjectIsAProgram)]
        public bool ImplementsMultipleProjects { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.ProjectIsATransportationProject)]
        public bool IsTransportationProject { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.TransportationObjective)]
        public int? TransportationObjectiveID { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.ProjectOnFTIPList)]
        public bool OnFederalTransportationImprovementProgramList { get; set; }

        public bool HasExistingProjectUpdate { get; set; }
        public int? OldProjectStageID { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditProjectViewModel()
        {
        }

        public EditProjectViewModel(Models.Project project, bool hasExistingProjectUpdate)
        {
            ActionPriorityID = project.ActionPriorityID;
            ProjectID = project.ProjectID;
            ProjectName = project.ProjectName;
            ProjectDescription = project.ProjectDescription;
            ProjectStageID = project.ProjectStageID;
            OldProjectStageID = project.ProjectStageID;
            FundingTypeID = project.FundingTypeID;
            ImplementationStartYear = project.ImplementationStartYear;
            PlanningDesignStartYear = project.PlanningDesignStartYear;
            CompletionYear = project.CompletionYear;
            EstimatedTotalCost = project.EstimatedTotalCost;
            EstimatedAnnualOperatingCost = project.EstimatedAnnualOperatingCost;
            SecuredFunding = project.SecuredFunding;
            LeadImplementerOrganizationID = project.LeadImplementerOrganizationID;
            ImplementsMultipleProjects = project.ImplementsMultipleProjects;
            IsTransportationProject = project.IsTransportationProject;
            TransportationObjectiveID = project.TransportationObjectiveID;
            OnFederalTransportationImprovementProgramList = project.OnFederalTransportationImprovementProgramList;
            HasExistingProjectUpdate = hasExistingProjectUpdate;
        }

        public EditProjectViewModel(Models.ProposedProject proposedProject)
        {
            ActionPriorityID = proposedProject.ActionPriorityID.Value;
            ProjectName = proposedProject.ProjectName;
            ProjectDescription = proposedProject.ProjectDescription;
            ProjectStageID = ProjectStage.PlanningDesign.ProjectStageID;
            OldProjectStageID = ProjectStage.PlanningDesign.ProjectStageID;
            FundingTypeID = proposedProject.FundingTypeID;
            ImplementationStartYear = proposedProject.ImplementationStartYear;
            PlanningDesignStartYear = proposedProject.PlanningDesignStartYear;
            CompletionYear = proposedProject.CompletionYear;
            EstimatedTotalCost = proposedProject.EstimatedTotalCost;
            EstimatedAnnualOperatingCost = proposedProject.EstimatedAnnualOperatingCost;
            SecuredFunding = proposedProject.SecuredFunding;
            LeadImplementerOrganizationID = proposedProject.LeadImplementerOrganizationID;
            ImplementsMultipleProjects = false;
            IsTransportationProject = proposedProject.IsTransportationProject;
            TransportationObjectiveID = null;
            OnFederalTransportationImprovementProgramList = false;
            HasExistingProjectUpdate = false;
        }

        public void UpdateModel(Models.Project project)
        {
            project.ProjectName = ProjectName;
            project.ProjectDescription = ProjectDescription;
            project.ProjectStageID = ProjectStageID;
            project.FundingTypeID = FundingTypeID;
            project.ImplementationStartYear = ImplementationStartYear;
            project.PlanningDesignStartYear = PlanningDesignStartYear;
            project.CompletionYear = CompletionYear;

            if (FundingTypeID == FundingType.Capital.FundingTypeID)
            {
                project.EstimatedTotalCost = EstimatedTotalCost;
                project.SecuredFunding = SecuredFunding;
                project.EstimatedAnnualOperatingCost = null;
                
            }
            else if (FundingTypeID == FundingType.OperationsAndMaintenance.FundingTypeID)
            {
                project.EstimatedTotalCost = null;
                project.SecuredFunding = null;
                project.EstimatedAnnualOperatingCost = EstimatedAnnualOperatingCost; 
            }
            
            project.ImplementsMultipleProjects = ImplementsMultipleProjects;

            if (!ModelObjectHelpers.IsRealPrimaryKeyValue(project.ProjectID))
            {
                project.ActionPriorityID = ActionPriorityID;

                Check.RequireNotNull(LeadImplementerOrganizationID, EditProjectViewModelValidator.NeedsLeadImplementingOrganizationMessage);
                if (LeadImplementerOrganizationID != null)
                {
                    project.ProjectImplementingOrganizations.Add(new ProjectImplementingOrganization(ProjectID, LeadImplementerOrganizationID.Value, true));
                }
            }
            project.TransportationObjectiveID = IsTransportationProject ? TransportationObjectiveID : null;
            project.OnFederalTransportationImprovementProgramList = project.TransportationObjectiveID.HasValue && OnFederalTransportationImprovementProgramList;
        }

        public void UpdateModel(Models.Project project, short nextProjectNumber)
        {
            UpdateModel(project);
            // set the project number
            project.ProjectNumber = nextProjectNumber;
        }
    }
}