/*-----------------------------------------------------------------------
<copyright file="FirmaValidationMessages.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
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
namespace ProjectFirma.Web.Common
{
    public static class FirmaValidationMessages
    {        
        public const string PasswordRequiredForNewUser = "Password is required for new users";
        public const string MustEnterOldPasswordWhenChangingPassword = "Old password is required when changing password";
        public const string OldPasswordProvidedIsNotCorrect = "Old password is incorrect";
        public const string CantChangePasswordToBeSameAsOldPassword = "Can't reset password to same as old password";
        public const string EmailAlreadyUsed = "Email already exists";
        public const string ImplementationStartYearGreaterThanPlanningDesignStartYear = "Implementation Start Year must be greater than or equal to Planning / Design Start Year";
        public const string CompletionYearGreaterThanEqualToImplementationStartYear = "Completion Year must be greater than or equal to the Implementation Start Year";
        public const string CompletionYearGreaterThanEqualToPlanningDesignStartYear = "Completion Year must be greater than or equal to the Planning / Design Start Year";
        public const string UpdateSectionIsDependentUponBasicsSection = "Your project's \"Basics\" page must be complete before you can begin updating this section.";
        public const string ProjectNameUnique = "Project name already exists";
        public const string OrganizationNameUnique = "Organization name already exists";
        public const string OrganizationAbbreviationUnique = "Organization abbreviation already exists";
        public const string OrganizationMustBeSetForNewUser = "Organization must be set for a new user";
        public const string ProjectOrganizationLeadShouldBeSetIfThereAreAnyOrganizations = "Please select one of the organizations as the lead implementer";
        public const string AllProjectOrganizationShouldEitherBeTheLeadOrImplementerOrFunder = "For each organization, please select if it is an implementer, funder or both";
        public const string LeadImplementingOrganizationMustHavePrimaryContactSet = "The Lead implementer Organization must have a primary contact set";
        public const string FundingSourceNameUnique = "Funding Source name already exists";
        public const string ClassificationNameUnique = "Classification name already exists";
        public const string PerformanceMeasureNameUnique = "PerformanceMeasure name already exists";
        public const string WatershedNameUnique = "Watershed name already exists";
        public const string ExplanationNecessaryForProjectExemptYears = "Please provide an explanation of why the reporting years are exempt";
        public const string ExplanationNotNecessaryForProjectExemptYears = "Explanation is not necessary since no reporting years are exempt";
        public const string TagNameUnique = "Tag name already exists";
        public const string LettersNumbersSpacesDashesAndUnderscoresOnly = "Only letters, numbers, spaces, dashes and underscores are allowed.";
        public const string LettersOnly = "Only letters are allowed.";
        public const string MoreThanOneProjectUpdateInProgress = "Cannot determine latest update state; more than one update is in progress!";

    }
}
