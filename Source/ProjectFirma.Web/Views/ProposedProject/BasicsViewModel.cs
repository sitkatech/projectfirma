/*-----------------------------------------------------------------------
<copyright file="BasicsViewModel.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common.Models;
using ProjectFirma.Web.Views.Shared.ProjectControls;

namespace ProjectFirma.Web.Views.ProposedProject
{
    public class BasicsViewModel : FormViewModel, IValidatableObject
    {
        public int ProposedProjectID { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.TaxonomyTierOne)]
        [Required]
        public int? ProposedTaxonomyTierOneID { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.ProjectName)]
        [Required]
        public string ProjectName { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.ProjectDescription)]
        [Required]
        public string ProjectDescription { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.PlanningDesignStartYear)]
        [Required]
        public int? PlanningDesignStartYear { get; set; }
        
        [FieldDefinitionDisplay(FieldDefinitionEnum.ImplementationStartYear)]
        [Required]
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
        [Required]
        public int? LeadImplementerOrganizationID { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.PrimaryContact)]
        public Person PrimaryContactPerson { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.FundingType)]
        [Required]
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
            PrimaryContactPerson = proposedProject.PrimaryContactPerson;
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

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
           return GetValidationResults();
        }

        public IEnumerable<ValidationResult> GetValidationResults()
        {
            var errors = new List<ValidationResult>();

            var projects = HttpRequestStorage.DatabaseEntities.Projects.ToList();
            var proposedProjects = HttpRequestStorage.DatabaseEntities.ProposedProjects.ToList();
            if (!Models.ProposedProject.IsProjectNameUnique(proposedProjects, ProjectName, ProposedProjectID) || !Models.Project.IsProjectNameUnique(projects, ProjectName, ModelObjectHelpers.NotYetAssignedID))
            {
                errors.Add(new SitkaValidationResult<EditProjectViewModel, string>(FirmaValidationMessages.ProjectNameUnique, m => m.ProjectName));
            }

            if (ImplementationStartYear < PlanningDesignStartYear)
            {
                errors.Add(new SitkaValidationResult<EditProjectViewModel, int?>(FirmaValidationMessages.ImplementationStartYearGreaterThanPlanningDesignStartYear, m => m.ImplementationStartYear));
            }

            if (CompletionYear < ImplementationStartYear)
            {
                errors.Add(new SitkaValidationResult<EditProjectViewModel, int?>(FirmaValidationMessages.CompletionYearGreaterThanEqualToImplementationStartYear, m => m.CompletionYear));
            }

            return errors;
        }
    }
}
