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

namespace ProjectFirma.Web.Common
{
    public static class FirmaValidationMessages
    {
        public static readonly string PasswordRequiredForNewUser = $"{FieldDefinition.Password.GetFieldDefinitionLabel()} is required for new users";
        public static readonly string MustEnterOldPasswordWhenChangingPassword = $"Old {FieldDefinition.Password.GetFieldDefinitionLabel()} is required when changing {FieldDefinition.Password.GetFieldDefinitionLabel()}";
        public static readonly string OldPasswordProvidedIsNotCorrect = $"Old {FieldDefinition.Password.GetFieldDefinitionLabel()} is incorrect";
        public static readonly string CantChangePasswordToBeSameAsOldPassword = $"Can't reset {FieldDefinition.Password.GetFieldDefinitionLabel()} to same as old {FieldDefinition.Password.GetFieldDefinitionLabel()}";
        public static readonly string ImplementationStartYearGreaterThanPlanningDesignStartYear = $"{FieldDefinition.ImplementationStartYear.GetFieldDefinitionLabel()} must be greater than or equal to {FieldDefinition.PlanningDesignStartYear.GetFieldDefinitionLabel()}";
        public static readonly string CompletionYearGreaterThanEqualToImplementationStartYear = $"{FieldDefinition.CompletionYear.GetFieldDefinitionLabel()} must be greater than or equal to the {FieldDefinition.ImplementationStartYear.GetFieldDefinitionLabel()}";
        public static readonly string CompletionYearGreaterThanEqualToPlanningDesignStartYear = $"{FieldDefinition.CompletionYear.GetFieldDefinitionLabel()} must be greater than or equal to the {FieldDefinition.PlanningDesignStartYear.GetFieldDefinitionLabel()}";
        public static readonly string UpdateSectionIsDependentUponBasicsSection = "Your project's \"Basics\" page must be complete before you can begin updating this section.";
        public static readonly string ProjectNameUnique = $"{FieldDefinition.ProjectName.GetFieldDefinitionLabel()} already exists";
        public static readonly string OrganizationNameUnique = $"{FieldDefinition.Organization.GetFieldDefinitionLabel()} name already exists";
        public static readonly string OrganizationShortNameUnique = $"{FieldDefinition.Organization.GetFieldDefinitionLabel()} short name already exists";
        public static readonly string OrganizationMustBeSetForNewUser = $"{FieldDefinition.Organization.GetFieldDefinitionLabel()} must be set for a new user";
        public static readonly string FundingSourceNameUnique = $"{FieldDefinition.FundingSource.GetFieldDefinitionLabel()} name already exists";
        public static readonly string ClassificationNameUnique = $"{FieldDefinition.Classification.GetFieldDefinitionLabel()} name already exists";
        public static readonly string PerformanceMeasureNameUnique = $"{FieldDefinition.PerformanceMeasure.GetFieldDefinitionLabel()} name already exists";
        public static readonly string WatershedNameUnique = $"{FieldDefinition.Watershed.GetFieldDefinitionLabel()} name already exists";
        public static readonly string ExplanationNecessaryForProjectExemptYears = $"Please provide an explanation of why the {FieldDefinition.ReportingYear.GetFieldDefinitionLabelPluralized()} are exempt";
        public static readonly string ExplanationNotNecessaryForProjectExemptYears = $"Explanation is not necessary since no {FieldDefinition.ReportingYear.GetFieldDefinitionLabelPluralized()} are exempt";
        public static readonly string TagNameUnique = $"{FieldDefinition.TagName.GetFieldDefinitionLabel()} already exists";
        public const string LettersNumbersSpacesDashesAndUnderscoresOnly = "Only letters, numbers, spaces, dashes and underscores are allowed.";
        public const string LettersOnly = "Only letters are allowed.";
        public const string MoreThanOneProjectUpdateInProgress = "Cannot determine latest update state; more than one update is in progress!";
        public const string EmailAlreadyUsed = "Email already exists";
        public const string ExpectedFundingValuesCannotBothBeZeroOrEmpty = "Enter a Secured or Unsecured amount for each Funding Source, or remove Funding Sources with no funding amounts.";
    }
}

