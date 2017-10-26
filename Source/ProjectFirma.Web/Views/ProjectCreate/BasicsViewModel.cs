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
using System.ComponentModel.DataAnnotations;
using System.Linq;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.ProjectCreate
{
    public class BasicsViewModel : FormViewModel, IValidatableObject
    {
        public int ProjectID { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.TaxonomyTierOne)]
        [Required]
        public int TaxonomyTierOneID { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.ProjectName)]
        [Required]
        public string ProjectName { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.ProjectDescription)]
        [StringLength(Models.Project.FieldLengths.ProjectDescription)]
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

        [FieldDefinitionDisplay(FieldDefinitionEnum.PrimaryContact)]
        public int? PrimaryContactPersonID { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.FundingType)]
        [Required]
        public int FundingTypeID { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.CanApproveProjectsOrganization)]
        public int? ApprovingProjectsOrganizationID { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.IsPrimaryContactOrganization)]
        [Required]
        public int? PrimaryContactOrganizationID { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public BasicsViewModel()
        {
        }

        public BasicsViewModel(Models.Project project)
        {
            TaxonomyTierOneID = project.TaxonomyTierOneID;
            ProjectID = project.ProjectID;
            ProjectName = project.ProjectName;
            ProjectDescription = project.ProjectDescription;
            PrimaryContactPersonID = project.PrimaryContactPersonID;
            FundingTypeID = project.FundingTypeID;
            EstimatedTotalCost = project.EstimatedTotalCost;
            EstimatedAnnualOperatingCost = project.EstimatedAnnualOperatingCost;
            SecuredFunding = project.SecuredFunding;
            PlanningDesignStartYear = project.PlanningDesignStartYear;
            ImplementationStartYear = project.ImplementationStartYear;
            CompletionYear = project.CompletionYear;
            ApprovingProjectsOrganizationID = project.GetCanApproveProjectsOrganization()?.OrganizationID;
            PrimaryContactOrganizationID = project.GetPrimaryContactOrganization()?.OrganizationID;
        }

        /// <summary>
        /// Used by a brand new proposal for setting the default ApprovingProjectsOrganizationID or PrimaryContactOrganizationID
        /// </summary>
        /// <param name="organization"></param>
        public BasicsViewModel(Models.Organization organization)
        {
            if (organization.CanBeAnApprovingOrganization())
            {
                ApprovingProjectsOrganizationID = organization.OrganizationID;
            }
            if (organization.CanBeAPrimaryContactOrganization())
            {
                PrimaryContactOrganizationID = organization.OrganizationID;
            }
        }

        public void UpdateModel(Models.Project project, Person person)
        {
            project.ProposingPersonID = person.PersonID;
            project.TaxonomyTierOneID = TaxonomyTierOneID;
            project.ProposedProjectID = ProjectID;
            project.ProjectName = ProjectName;
            project.ProjectDescription = ProjectDescription;
            project.FundingTypeID = FundingTypeID;
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
            
            project.PlanningDesignStartYear = PlanningDesignStartYear;
            project.ImplementationStartYear = ImplementationStartYear;
            project.CompletionYear = CompletionYear;
            project.PrimaryContactPersonID = PrimaryContactPersonID;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
           return GetValidationResults();
        }

        public IEnumerable<ValidationResult> GetValidationResults()
        {
            var errors = new List<ValidationResult>();

            var projects = HttpRequestStorage.DatabaseEntities.Projects.ToList();
            if (!Models.Project.IsProjectNameUnique(projects, ProjectName, ProjectID))
            {
                errors.Add(new SitkaValidationResult<BasicsViewModel, string>(FirmaValidationMessages.ProjectNameUnique, m => m.ProjectName));
            }

            if (ImplementationStartYear < PlanningDesignStartYear)
            {
                errors.Add(new SitkaValidationResult<BasicsViewModel, int?>(FirmaValidationMessages.ImplementationStartYearGreaterThanPlanningDesignStartYear, m => m.ImplementationStartYear));
            }

            if (CompletionYear < ImplementationStartYear)
            {
                errors.Add(new SitkaValidationResult<BasicsViewModel, int?>(FirmaValidationMessages.CompletionYearGreaterThanEqualToImplementationStartYear, m => m.CompletionYear));
            }

            if (MultiTenantHelpers.HasCanApproveProjectsOrganizationRelationship() && !ApprovingProjectsOrganizationID.HasValue)
            {
                errors.Add(new SitkaValidationResult<BasicsViewModel, int?>(
                    $"{Models.FieldDefinition.CanApproveProjectsOrganization.GetFieldDefinitionLabel()} is required", m => m.ApprovingProjectsOrganizationID));
            }

            return errors;
        }
    }
}
