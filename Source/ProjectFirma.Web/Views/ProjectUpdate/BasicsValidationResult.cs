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

using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using LtInfo.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class BasicsValidationResult
    {
        public static readonly string PlanningDesignStartYearIsRequired = $"{FieldDefinitionEnum.PlanningDesignStartYear.ToType().GetFieldDefinitionLabel()} is a required field.";
        public static readonly string ImplementationStartYearIsRequired = $"{FieldDefinitionEnum.ImplementationStartYear.ToType().GetFieldDefinitionLabel()} is a required field.";
        public static readonly string CompletionYearIsRequired = $"For projects in the Completed or Post-Implementation stage, {FieldDefinitionEnum.CompletionYear.ToType().GetFieldDefinitionLabel()} is a required field.";
        public static readonly string ProjectDescriptionIsRequired = $"{FieldDefinitionEnum.ProjectDescription.ToType().GetFieldDefinitionLabel()} is required.";
        public static readonly string CompletionYearShouldBeLessThanCurrentYear = $"Since the {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} is in Completed or Post-Implementation stage, the {FieldDefinitionEnum.CompletionYear.ToType().GetFieldDefinitionLabel()} needs to be less than or equal to this year";
        public static readonly string PlanningDesignStartYearShouldBeLessThanCurrentYear = $"Since the {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} is in the Planning / Design stage, the {FieldDefinitionEnum.PlanningDesignStartYear.ToType().GetFieldDefinitionLabel()} needs to be less than or equal to this year";
        public static readonly string ImplementationStartYearShouldBeLessThanCurrentYear = $"Since the {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} is in Implementation stage, the {FieldDefinitionEnum.ImplementationStartYear.ToType().GetFieldDefinitionLabel()} needs to be less than or equal to this year";

        private readonly List<string> _warningMessages;

        public BasicsValidationResult(ProjectFirmaModels.Models.ProjectUpdate projectUpdate) 
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
            
            var currentYear = FirmaDateUtilities.CalculateCurrentYearToUseForUpToAllowableInputInReporting();
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
            // Validate that required Custom Attributes are present
            var requiredCustomAttributeTypeIDs = HttpRequestStorage.DatabaseEntities.ProjectCustomAttributeTypes.Where(x => x.IsRequired).Select(x => x.ProjectCustomAttributeTypeID).ToList();
            var projectrequiredCustomAttributeTypeIDs = projectUpdate.GetProjectCustomAttributes().Where(x => x.ProjectCustomAttributeType.IsRequired).Select(x => x.ProjectCustomAttributeTypeID).ToList();
            if (requiredCustomAttributeTypeIDs.Any(x => !projectrequiredCustomAttributeTypeIDs.Contains(x)))
            {
                _warningMessages.Add(FirmaValidationMessages.RequiredCustomAttribute);
            }
        }

        public List<string> GetWarningMessages()
        {     
            return _warningMessages;
        }

        public bool IsValid => !_warningMessages.Any();
    }
}
