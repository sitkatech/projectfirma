/*-----------------------------------------------------------------------
<copyright file="FirmaValidationMessages.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Common
{
    public static class FirmaValidationMessages
    {
        public static readonly string ImplementationStartYearGreaterThanPlanningDesignStartYear = $"{FieldDefinitionEnum.ImplementationStartYear.ToType().GetFieldDefinitionLabel()} must be greater than or equal to {FieldDefinitionEnum.PlanningDesignStartYear.ToType().GetFieldDefinitionLabel()}.";
        public static readonly string CompletionYearGreaterThanEqualToImplementationStartYear = $"{FieldDefinitionEnum.CompletionYear.ToType().GetFieldDefinitionLabel()} must be greater than or equal to the {FieldDefinitionEnum.ImplementationStartYear.ToType().GetFieldDefinitionLabel()}.";
        public static readonly string CompletionYearGreaterThanEqualToPlanningDesignStartYear = $"{FieldDefinitionEnum.CompletionYear.ToType().GetFieldDefinitionLabel()} must be greater than or equal to the {FieldDefinitionEnum.PlanningDesignStartYear.ToType().GetFieldDefinitionLabel()}.";
        public static readonly string UpdateSectionIsDependentUponBasicsSection = "Your project's \"Basics\" page must be complete before you can begin updating this section.";
        public static readonly string ProjectNameUnique = $"{FieldDefinitionEnum.ProjectName.ToType().GetFieldDefinitionLabel()} already exists.";
        public static readonly string OrganizationNameUnique = $"{FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabel()} name already exists.";
        public static readonly string OrganizationShortNameUnique = $"{FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabel()} short name already exists.";
        public static readonly string FundingSourceNameUnique = $"{FieldDefinitionEnum.FundingSource.ToType().GetFieldDefinitionLabel()} name already exists.";
        public static readonly string ClassificationNameUnique = $"{FieldDefinitionEnum.Classification.ToType().GetFieldDefinitionLabel()} name already exists.";
        public static readonly string PerformanceMeasureNameUnique = $"{FieldDefinitionEnum.PerformanceMeasure.ToType().GetFieldDefinitionLabel()} name already exists.";
        public static readonly string ExplanationNecessaryForProjectExemptYears = $"Please provide an explanation of why the {FieldDefinitionEnum.ReportingYear.ToType().GetFieldDefinitionLabelPluralized()} are exempt.";
        public static readonly string ExplanationNotNecessaryForProjectExemptYears = $"Explanation is not necessary since no {FieldDefinitionEnum.ReportingYear.ToType().GetFieldDefinitionLabelPluralized()} are exempt.";
        public static readonly string TagNameUnique = $"{FieldDefinitionEnum.TagName.ToType().GetFieldDefinitionLabel()} already exists.";
        public static readonly string CompletionYearMustBePastOrPresentForCompletedProjects = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()} in the Completed and Post-Implementation stages cannot have a {FieldDefinitionEnum.CompletionYear.ToType().GetFieldDefinitionLabel()} in the future.";
        public static readonly string RequiredCustomAttribute = $"All required {FieldDefinitionEnum.ProjectCustomAttribute.ToType().GetFieldDefinitionLabelPluralized()} must have values provided.";
        public const string LettersNumbersSpacesDashesAndUnderscoresOnly = "Only letters, numbers, spaces, dashes and underscores are allowed.";
        public const string LettersOnly = "Only letters are allowed.";
        public const string MoreThanOneProjectUpdateInProgress = "Cannot determine latest update state; more than one update is in progress.";
        public static readonly string ImplementationYearMustBePastOrPresentForImplementationProjects = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()} in the Implementation stage cannot have an {FieldDefinitionEnum.ImplementationStartYear.ToType().GetFieldDefinitionLabel()} in the future.";
    }
}

