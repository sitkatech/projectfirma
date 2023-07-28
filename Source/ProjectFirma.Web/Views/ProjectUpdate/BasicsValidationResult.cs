﻿/*-----------------------------------------------------------------------
<copyright file="BasicsValidationResult.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
Copyright (c) Tahoe Regional Planning Agency and Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
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
        public static string PlanningDesignStartYearIsRequired => $"{FieldDefinitionEnum.PlanningDesignStartYear.ToType().GetFieldDefinitionLabel()} is a required field.";
        public static string ImplementationStartYearIsRequired => $"{FieldDefinitionEnum.ImplementationStartYear.ToType().GetFieldDefinitionLabel()} is a required field.";
        public static string CompletionYearIsRequired => $"For projects in the {ProjectStage.Completed.GetProjectStageDisplayName()} or {ProjectStage.PostImplementation.GetProjectStageDisplayName()} stage, {FieldDefinitionEnum.CompletionYear.ToType().GetFieldDefinitionLabel()} is a required field.";
        public static string ProjectDescriptionIsRequired => $"{FieldDefinitionEnum.ProjectDescription.ToType().GetFieldDefinitionLabel()} is required.";
        public static string CompletionYearShouldBeLessThanCurrentYear => $"Since the {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} is in {ProjectStage.Completed.GetProjectStageDisplayName()} or {ProjectStage.PostImplementation.GetProjectStageDisplayName()} stage, the {FieldDefinitionEnum.CompletionYear.ToType().GetFieldDefinitionLabel()} needs to be less than or equal to this year";
        public static string PlanningDesignStartYearShouldBeLessThanCurrentYear => $"Since the {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} is in the {ProjectStage.PlanningDesign.GetProjectStageDisplayName()} stage, the {FieldDefinitionEnum.PlanningDesignStartYear.ToType().GetFieldDefinitionLabel()} needs to be less than or equal to this year";
        public static string ImplementationStartYearShouldBeLessThanCurrentYear => $"Since the {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} is in {ProjectStage.Implementation.GetProjectStageDisplayName()} stage, the {FieldDefinitionEnum.ImplementationStartYear.ToType().GetFieldDefinitionLabel()} needs to be less than or equal to this year";

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
        }

        public List<string> GetWarningMessages()
        {     
            return _warningMessages;
        }

        public bool IsValid => !_warningMessages.Any();
    }
}
