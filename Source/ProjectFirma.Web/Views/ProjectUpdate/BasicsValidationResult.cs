/*-----------------------------------------------------------------------
<copyright file="BasicsValidationResult.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System;
using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class BasicsValidationResult
    {
        public static readonly string PlanningDesignStartYearIsRequired = $"{Models.FieldDefinition.PlanningDesignStartYear.GetFieldDefinitionLabel()} is a required field.";
        public static readonly string ImplementationStartYearIsRequired = $"{Models.FieldDefinition.ImplementationStartYear.GetFieldDefinitionLabel()} is a required field.";
        public static readonly string CompletionYearIsRequired = $"For projects in the Completed or Post-Implementation stage, {Models.FieldDefinition.CompletionYear.GetFieldDefinitionLabel()} is a required field.";
        public static readonly string ProjectDescriptionIsRequired = $"{Models.FieldDefinition.ProjectDescription.GetFieldDefinitionLabel()} is required.";
        public static readonly string CompletionYearShouldBeLessThanCurrentYear = $"Since project is in Completed or Post-Implementation stage, the {Models.FieldDefinition.CompletionYear.GetFieldDefinitionLabel()} needs to be less than or equal to this year";
        public static readonly string PlanningDesignStartYearShouldBeLessThanCurrentYear = $"Since project is in the Planning / Design stage, the {Models.FieldDefinition.PlanningDesignStartYear.GetFieldDefinitionLabel()} needs to be less than or equal to this year";
        public static readonly string ImplementationStartYearShouldBeLessThanCurrentYear = $"Since project is in Implementation stage, the {Models.FieldDefinition.ImplementationStartYear.GetFieldDefinitionLabel()} needs to be less than or equal to this year";

        private readonly List<string> _warningMessages;

        public BasicsValidationResult(Models.ProjectUpdate projectUpdate)
        {
            _warningMessages = new List<string>();

            if (projectUpdate.PlanningDesignStartYear == null)
            {
                _warningMessages.Add(PlanningDesignStartYearIsRequired);
            }
            if (projectUpdate.ImplementationStartYear == null && projectUpdate.ProjectStage != ProjectStage.Terminated && projectUpdate.ProjectStage != ProjectStage.Deferred )
            {
                _warningMessages.Add(ImplementationStartYearIsRequired);
            }
                        
            if ((projectUpdate.ProjectStage == ProjectStage.Completed || projectUpdate.ProjectStage == ProjectStage.PostImplementation) && projectUpdate.CompletionYear == null)
            {
                _warningMessages.Add(CompletionYearIsRequired);
            }

            if (GeneralUtility.IsNullOrEmptyOrOnlyWhitespace(projectUpdate.ProjectDescription))
            {
                _warningMessages.Add(ProjectDescriptionIsRequired);
            }
            
            var currentYear = DateTime.Now.Year;
            if ((projectUpdate.ProjectStage == ProjectStage.Completed || projectUpdate.ProjectStage == ProjectStage.PostImplementation) && projectUpdate.CompletionYear > currentYear)
            {
                _warningMessages.Add(CompletionYearShouldBeLessThanCurrentYear);
            }
            if (projectUpdate.ProjectStage == ProjectStage.PlanningDesign && projectUpdate.PlanningDesignStartYear > currentYear)
            {
                _warningMessages.Add(PlanningDesignStartYearShouldBeLessThanCurrentYear);
            }
            if (projectUpdate.ProjectStage == ProjectStage.Implementation && projectUpdate.ImplementationStartYear > currentYear)
            {
                _warningMessages.Add(ImplementationStartYearShouldBeLessThanCurrentYear);
            }

            if (projectUpdate.ImplementationStartYear < projectUpdate.PlanningDesignStartYear)
            {
                _warningMessages.Add(FirmaValidationMessages.ImplementationStartYearGreaterThanPlanningDesignStartYear);
            }
            if (projectUpdate.CompletionYear < projectUpdate.ImplementationStartYear)
            {
                _warningMessages.Add(FirmaValidationMessages.CompletionYearGreaterThanEqualToImplementationStartYear);
            }
            if (projectUpdate.CompletionYear < projectUpdate.PlanningDesignStartYear)
            {
                _warningMessages.Add(FirmaValidationMessages.CompletionYearGreaterThanEqualToPlanningDesignStartYear);
            }
        }

        public List<string> GetWarningMessages()
        {     
            return _warningMessages;
        }

        public bool IsValid => !_warningMessages.Any();
    }
}
