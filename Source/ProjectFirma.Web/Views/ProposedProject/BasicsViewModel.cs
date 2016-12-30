using System;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using FluentValidation.Attributes;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.ProposedProject
{
    [Validator(typeof(BasicsViewModelValidator))]
    public class BasicsViewModel : FormViewModel
    {
        public int ProposedProjectID { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.TaxonomyTierOne)]
        public int? ProposedTaxonomyTierOneID { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.ProjectName)]
        public string ProjectName { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.ProjectDescription)]
        public string ProjectDescription { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.PlanningDesignStartYear)]
        public int? PlanningDesignStartYear { get; set; }
        
        [FieldDefinitionDisplay(FieldDefinitionEnum.ImplementationStartYear)]
        public int? ImplementationStartYear { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.CompletionYear)]
        public int? CompletionYear { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.EstimatedTotalCost)]
        public Money? EstimatedTotalCost { get; set; }
        
        [FieldDefinitionDisplay(FieldDefinitionEnum.EstimatedAnnualOperatingCost)]
        public Money? EstimatedAnnualOperatingCost { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.SecuredFunding)]
        public Money? SecuredFunding { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.LeadImplementer)]
        public int? LeadImplementerOrganizationID { get; set; }
        
        [FieldDefinitionDisplay(FieldDefinitionEnum.FundingType)]
        public int FundingTypeID { get; set; }
        
        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public BasicsViewModel()
        {
        }

        public BasicsViewModel(Models.ProposedProject proposedProject)
        {
            ProposedTaxonomyTierOneID = proposedProject.TaxonomyTierOneID;
            ProposedProjectID = proposedProject.ProposedProjectID;
            ProjectName = proposedProject.ProjectName;
            ProjectDescription = proposedProject.ProjectDescription;
            LeadImplementerOrganizationID = proposedProject.LeadImplementerOrganizationID;
            FundingTypeID = proposedProject.FundingTypeID;
            EstimatedTotalCost = proposedProject.EstimatedTotalCost;
            EstimatedAnnualOperatingCost = proposedProject.EstimatedAnnualOperatingCost;
            SecuredFunding = proposedProject.SecuredFunding;
            PlanningDesignStartYear = proposedProject.PlanningDesignStartYear;
            ImplementationStartYear = proposedProject.ImplementationStartYear;
            CompletionYear = proposedProject.CompletionYear;
        }

        public BasicsViewModel(int? organizationID)
        {
            LeadImplementerOrganizationID = organizationID;
        }

        public void UpdateModel(Models.ProposedProject proposedProject, Person person)
        {
            proposedProject.ProposingPersonID = person.PersonID;
            proposedProject.LeadImplementerOrganizationID = LeadImplementerOrganizationID.Value;
            proposedProject.TaxonomyTierOneID = ProposedTaxonomyTierOneID;
            proposedProject.ProposedProjectID = ProposedProjectID;
            proposedProject.ProjectName = ProjectName;
            proposedProject.ProjectDescription = ProjectDescription;
            proposedProject.FundingTypeID = FundingTypeID;
            if (FundingTypeID == FundingType.Capital.FundingTypeID)
            {
                proposedProject.EstimatedTotalCost = EstimatedTotalCost;
                proposedProject.SecuredFunding = SecuredFunding;
                proposedProject.EstimatedAnnualOperatingCost = null;
                
            }
            else if (FundingTypeID == FundingType.OperationsAndMaintenance.FundingTypeID)
            {
                proposedProject.EstimatedTotalCost = null;
                proposedProject.SecuredFunding = null;
                proposedProject.EstimatedAnnualOperatingCost = EstimatedAnnualOperatingCost;
            }
            
            proposedProject.PlanningDesignStartYear = PlanningDesignStartYear;
            proposedProject.ImplementationStartYear = ImplementationStartYear;
            proposedProject.CompletionYear = CompletionYear;            
        }
    }
}