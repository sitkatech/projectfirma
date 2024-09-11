/*-----------------------------------------------------------------------
<copyright file="PendingProjectBasicsStageImport.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DbSpatial;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.ExcelWorkbookUtilities;
using MoreLinq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Views.ProjectBulkUpload;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class PendingProjectBasicsStageImportModelExtensions
    {

        public static List<PendingProjectBasicsStageImport> LoadFromXlsFileStream(Stream stream)
        {
            var pendingProjectBasicsStageImports = new List<PendingProjectBasicsStageImport>();
            var dataTable = OpenXmlSpreadSheetDocument.ExcelWorksheetToDataTable(stream, PendingProjectStageImportsHelper.BasicsSheetName, true);
            pendingProjectBasicsStageImports.AddRange(LoadFromXlsFile(dataTable));

            return pendingProjectBasicsStageImports;
        }

        public static List<PendingProjectBasicsStageImport> LoadFromXlsFile(DataTable dataTable)
        {
            EnsureWorksheetHasCorrectShape(dataTable);

            // Create index-to-row dictionary. This is generally discouraged, but we don't have any other way to get the exact cell address, which 
            // can save the user a great deal of time.
            int rowNumber = 0;
            var indexToRowDict = new Dictionary<int, DataRow>();
            foreach (DataRow curDataRow in dataTable.Rows)
            {
                indexToRowDict.Add(rowNumber++, curDataRow);
            }

            // Skip the first row (remove it)            
            var indexesToRemove = new List<int> { 0, 1, 2 };

            // Remove any blank rows
            var basicsColumnNames = new PendingProjectStageImportsHelper().GetBasicsColumnNames();
            foreach (var kvp in indexToRowDict)
            {
                if (PendingProjectBasicsStageImport.RowIsBlank(kvp.Value, basicsColumnNames))
                {
                    indexesToRemove.Add(kvp.Key);
                }
            }

            // Remove entries that we need to discard
            foreach (var i in indexesToRemove)
            {
                indexToRowDict.Remove(i);
            }

            // Turn all valid rows into PendingProjectBasicsStageImport
            return indexToRowDict.Select(kvp => new PendingProjectBasicsStageImport(kvp)).ToList();
        }

        private static void EnsureWorksheetHasCorrectShape(DataTable dataTable)
        {
            var columnNames = new PendingProjectStageImportsHelper().GetBasicsColumnNames();

            var dataRow = dataTable.Rows[0];
            var expectedColumns = columnNames.Values.ToList();
            var actualColumns = dataTable.Columns.Cast<DataColumn>().Select(c => (string)dataRow[c]).ToList();

            var missingColumns = expectedColumns.Except(actualColumns).ToList();
            Check.RequireThrowUserDisplayable(!missingColumns.Any(),
                $"Expected columns [{string.Join("<br/>", expectedColumns)}]\n\nBut got columns [{string.Join("<br/>", actualColumns)}].\n\nThese columns were missing: [{string.Join("<br/>", missingColumns)}]");

        }

        public static IEnumerable<ValidationResult> ValidatePendingProjectBasicsStageImports(this List<PendingProjectBasicsStageImport> pendingProjectBasicsStageImports)
        {
            var errors = new List<ValidationResult>();
            // Project Name cannot be blank
            if (pendingProjectBasicsStageImports.Any(x => string.IsNullOrEmpty(x.ProjectName)))
            {
                errors.Add(new ValidationResult("Project Name cannot be blank in any row."));
            }
            // Project Name must be unique
            var pendingProjectBasicsStageImportsWithProjectName = pendingProjectBasicsStageImports.Where(x => !string.IsNullOrEmpty(x.ProjectName)).ToList();
            var rowsGroupedByProjectName = pendingProjectBasicsStageImportsWithProjectName.GroupBy(x => x.ProjectName.ToUpper()).ToList();
            if (rowsGroupedByProjectName.Count != pendingProjectBasicsStageImportsWithProjectName.Count)
            {
                List<string> duplicateIDs = new List<string>();
                rowsGroupedByProjectName.ForEach(x =>
                {
                    if (x.Count() > 1)
                    {
                        duplicateIDs.Add(x.Key);
                    }
                });
                var duplicateIDsError = string.Join("<br/>", duplicateIDs);
                errors.Add(new ValidationResult($"Project Name must be unique. The following are duplicated:<br/>{duplicateIDsError}"));
            }

            // project name is 140 characters max
            if (pendingProjectBasicsStageImports.Any(x => !string.IsNullOrEmpty(x.ProjectName) && x.ProjectName.Length > Project.FieldLengths.ProjectName))
            {
                var projectNamesWithBadNames = string.Join("<br/>",
                    pendingProjectBasicsStageImports.Where(x => !string.IsNullOrEmpty(x.ProjectName) && x.ProjectName.Length > Project.FieldLengths.ProjectName).Select(x => x.ProjectName));
                errors.Add(new ValidationResult($"Project Name cannot be more than {Project.FieldLengths.ProjectName} characters. The following Project Names are too long:<br/>{projectNamesWithBadNames}"));
            }

            
            var existingProjects = HttpRequestStorage.DatabaseEntities.Projects;
            var existingProjectNames = existingProjects.Select(x => x.ProjectName.ToUpper());
            // Project Names must be unique
            if (pendingProjectBasicsStageImports.Any(x => !string.IsNullOrEmpty(x.ProjectName) && existingProjectNames.Contains(x.ProjectName.ToUpper())))
            {
                var badProjectNames = string.Join("<br/>", pendingProjectBasicsStageImports.Where(x =>
                        !string.IsNullOrEmpty(x.ProjectName) && existingProjectNames.Contains(x.ProjectName.ToUpper()))
                    .Select(x => x.ProjectName).Distinct());
                errors.Add(new ValidationResult($"You may only upload new projects using the bulk upload template. Remove any projects that are currently in the database; these can be edited from their project pages. The following Project Names are already in the database:<br/>{badProjectNames}"));
            }
            

            // description required
            if (pendingProjectBasicsStageImports.Any(x => string.IsNullOrEmpty(x.Description)))
            {
                errors.Add(new ValidationResult("Description cannot be blank in any row."));
            }

            // description is 4000 characters max
            if (pendingProjectBasicsStageImports.Any(x => !string.IsNullOrEmpty(x.Description) && x.Description.Length > Project.FieldLengths.ProjectDescription))
            {
                var projectsWithBadDescriptions = string.Join("<br/>",
                    pendingProjectBasicsStageImports
                        .Where(x => !string.IsNullOrEmpty(x.Description) && x.Description.Length > Project.FieldLengths.ProjectDescription &&
                                    !string.IsNullOrEmpty(x.ProjectName)).Select(x => x.ProjectName));
                errors.Add(new ValidationResult($"Description cannot be more than 4000 characters. Descriptions for the following Projects are too long:<br/>{projectsWithBadDescriptions}"));
                if (pendingProjectBasicsStageImports.Any(x => !string.IsNullOrEmpty(x.Description) && x.Description.Length > 4000 && string.IsNullOrEmpty(x.ProjectName)))
                {
                    var badDescriptions = string.Join("<br/>",
                        pendingProjectBasicsStageImports
                            .Where(x => !string.IsNullOrEmpty(x.Description) && x.Description.Length > Project.FieldLengths.ProjectDescription &&
                                        string.IsNullOrEmpty(x.ProjectName)).Select(x => x.Description));
                    errors.Add(new ValidationResult($"Description cannot be more than 4000 characters. The following Descriptions are too long:<br/>{badDescriptions}"));
                }
            }


            // taxonomy leaf required (check enum)
            var taxonomyLeafDisplayNameForProject =
                PendingProjectStageImportsHelper.TenantLabels[MultiTenantHelpers.GetTenantName()][
                    "TaxonomyLeafDisplayNameForProject"];
            if (pendingProjectBasicsStageImports.Any(x => string.IsNullOrEmpty(x.TaxonomyLeaf)))
            {
                errors.Add(new ValidationResult($"{taxonomyLeafDisplayNameForProject} cannot be blank in any row."));
            }
            var taxonomyLeaves = HttpRequestStorage.DatabaseEntities.TaxonomyLeafs.ToList().Select(y => y.GetDisplayName().ToLower().Trim()).ToList();
            if (pendingProjectBasicsStageImportsWithProjectName.Any(x => !string.IsNullOrEmpty(x.TaxonomyLeaf) && !taxonomyLeaves.Contains(x.TaxonomyLeaf.ToLower().Trim())))
            {
                var projectNamesWithBadTaxonomyLeaves = string.Join("<br/>", pendingProjectBasicsStageImports
                    .Where(x => !string.IsNullOrEmpty(x.TaxonomyLeaf) &&
                                !taxonomyLeaves.Contains(x.TaxonomyLeaf.ToLower().Trim())).Select(x => $"{x.ProjectName}" ));
                errors.Add(new ValidationResult($"{taxonomyLeafDisplayNameForProject} must match a record in the system. Values for the following Projects are invalid:<br/>{projectNamesWithBadTaxonomyLeaves}"));
            }

            // project stage required (check enum)
            if (pendingProjectBasicsStageImports.Any(x => string.IsNullOrEmpty(x.ProjectStage)))
            {
                errors.Add(new ValidationResult("Project Stage cannot be blank in any row."));
            }
            var projectStages = ProjectStage.All.Select(y => y.ProjectStageDisplayName.ToLower().Trim()).ToList();
            if (pendingProjectBasicsStageImportsWithProjectName.Any(x => !string.IsNullOrEmpty(x.ProjectStage) && !projectStages.Contains(x.ProjectStage.ToLower().Trim())))
            {
                var projectNamesWithBadProjectStages = string.Join("<br/>", pendingProjectBasicsStageImports
                    .Where(x => !string.IsNullOrEmpty(x.ProjectStage) &&
                                !projectStages.Contains(x.ProjectStage.ToLower().Trim())).Select(x => $"{x.ProjectName}"));
                errors.Add(new ValidationResult($"Project Stage must match a record in the system. Values for the following Projects are invalid:<br/>{projectNamesWithBadProjectStages}"));
            }


            // Planning/Design start year required
            if (pendingProjectBasicsStageImports.Any(x => string.IsNullOrEmpty(x.PlanningDesignStartYear)))
            {
                errors.Add(new ValidationResult("Planning/Design Start Year cannot be blank in any row."));
            }
            // Planning/Design start year must be integer for all rows
            var yearFormat = "yyyy";
            if (pendingProjectBasicsStageImportsWithProjectName.Any(x => !string.IsNullOrWhiteSpace(x.PlanningDesignStartYear) && !DateTime.TryParseExact(x.PlanningDesignStartYear, yearFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out var notUsed)))
            {
                var projectWithBadPlanningDesignStartYears = string.Join("<br/>",
                    pendingProjectBasicsStageImportsWithProjectName.Where(x =>
                            x.PlanningDesignStartYear != null && !DateTime.TryParseExact(x.PlanningDesignStartYear,
                                yearFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out var notUsed))
                        .Select(x => $"{x.ProjectName}").ToList());
                errors.Add(new ValidationResult($"All Planning/Design Start Years must be in YYYY format. Values for the following Projects are invalid:<br/>{projectWithBadPlanningDesignStartYears}"));
            }

            // Implementation start year required
            if (pendingProjectBasicsStageImports.Any(x => string.IsNullOrEmpty(x.ImplementationStartYear)))
            {
                errors.Add(new ValidationResult("Implementation Start Year cannot be blank in any row."));
            }
            if (pendingProjectBasicsStageImportsWithProjectName.Any(x => !string.IsNullOrWhiteSpace(x.ImplementationStartYear) && !DateTime.TryParseExact(x.ImplementationStartYear, yearFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out var notUsed)))
            {
                var projectWithBadImplementationStartYears = string.Join("<br/>",
                    pendingProjectBasicsStageImportsWithProjectName.Where(x =>
                            x.ImplementationStartYear != null && !DateTime.TryParseExact(x.ImplementationStartYear,
                                yearFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out var notUsed))
                        .Select(x => $"{x.ProjectName}").ToList());
                errors.Add(new ValidationResult($"All Implementation Start Years must be in YYYY format. Values for the following Projects are invalid:<br/>{projectWithBadImplementationStartYears}"));
            }

            // Implementation start year cannot be before planning/design start year
            var projectWithEarlyImplementationStartYears = new List<string>();
            foreach (var pendingProjectBasicsStageImport in pendingProjectBasicsStageImportsWithProjectName.Where(x => 
                         !string.IsNullOrWhiteSpace(x.ImplementationStartYear) && int.TryParse(x.ImplementationStartYear, out var notUsedStartYear)
                         && !string.IsNullOrWhiteSpace(x.PlanningDesignStartYear) && int.TryParse(x.PlanningDesignStartYear, out var notUsedPlanningYear)
                         
                         ))
            {
                var startYear = int.Parse(pendingProjectBasicsStageImport.ImplementationStartYear);
                if (startYear < int.Parse(pendingProjectBasicsStageImport.PlanningDesignStartYear))
                {
                    projectWithEarlyImplementationStartYears.Add(pendingProjectBasicsStageImport.ProjectName);
                }
            }
            if (projectWithEarlyImplementationStartYears.Any())
            {
                var projectsWithBadYears = string.Join("<br/>", projectWithEarlyImplementationStartYears);
                errors.Add(new ValidationResult($"Implementation Start Year cannot be before the Planning/Design. Values for the following Project are invalid:<br/>{projectsWithBadYears}"));
            }

            // completion year (required if project stage is Completed)
            if (pendingProjectBasicsStageImports.Any(x => ProjectStage.Completed.ProjectStageDisplayName.ToLower().Trim().Equals(x.ProjectStage?.ToLower().Trim()) && string.IsNullOrEmpty(x.CompletionYear)))
            {
                errors.Add(new ValidationResult($"Completion Year cannot be blank in any row where Project Stage is {ProjectStage.Completed.ProjectStageDisplayName}."));
            }

            // completion year must be integer for all rows
            if (pendingProjectBasicsStageImportsWithProjectName.Any(x => !string.IsNullOrWhiteSpace(x.CompletionYear) && !DateTime.TryParseExact(x.CompletionYear, yearFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out var notUsed)))
            {
                var projectNamesWithBadYears = string.Join("<br/>",
                    pendingProjectBasicsStageImportsWithProjectName.Where(x =>
                            x.CompletionYear != null && !DateTime.TryParseExact(x.CompletionYear, yearFormat,
                                CultureInfo.InvariantCulture, DateTimeStyles.None, out var notUsed))
                        .Select(x => $"{x.ProjectName}").ToList());
                errors.Add(new ValidationResult($"All Completion Years must be in YYYY format. Values for the following Projects are invalid:<br/>{projectNamesWithBadYears}"));
            }

            // completion year cannot be before start year
            var projectNamesWithBadCompletionYears = new List<string>();
            foreach (var pendingProjectBasicsStageImport in pendingProjectBasicsStageImportsWithProjectName.Where(x => !string.IsNullOrWhiteSpace(x.ImplementationStartYear) && int.TryParse(x.ImplementationStartYear, out var notUsedStartYear) && !string.IsNullOrWhiteSpace(x.CompletionYear) && int.TryParse(x.CompletionYear, out var notUsedEndYear)))
            {
                var startYear = int.Parse(pendingProjectBasicsStageImport.ImplementationStartYear);
                var endYear = int.Parse(pendingProjectBasicsStageImport.CompletionYear);
                if (endYear < startYear)
                {
                    projectNamesWithBadCompletionYears.Add(pendingProjectBasicsStageImport.ProjectName);
                }
            }

            if (projectNamesWithBadCompletionYears.Any())
            {
                var projectsWithBadYears = string.Join("<br/>", projectNamesWithBadCompletionYears);
                errors.Add(new ValidationResult($"Completion Year cannot be before Implementation Start Year . Values for the following Projects are invalid:<br/>{projectsWithBadYears}"));
            }

            // Latitude cannot be blank unless Notes provided
            if (pendingProjectBasicsStageImports.Any(x =>
                    string.IsNullOrEmpty(x.Latitude) && string.IsNullOrEmpty(x.SimpleLocationNotes)))
            {
                var projectsMissingLatitude = string.Join("<br/>",
                    pendingProjectBasicsStageImports
                        .Where(x => !string.IsNullOrEmpty(x.ProjectName) && string.IsNullOrEmpty(x.Latitude) && string.IsNullOrEmpty(x.SimpleLocationNotes))
                        .Select(x => x.ProjectName).ToList());
                errors.Add(new ValidationResult(
                    $"Latitude cannot be blank. The following Projects are missing Latitude:<br/> {projectsMissingLatitude}."));
            }

            // all Latitude must be numbers
            if (pendingProjectBasicsStageImports.Where(x => !string.IsNullOrEmpty(x.ProjectName)).Any(x =>
                    !string.IsNullOrWhiteSpace(x.Latitude) && !double.TryParse(x.Latitude, out var notUsed)))
            {
                var projectsWithBadAmounts = string.Join("<br/>",
                    pendingProjectBasicsStageImports
                        .Where(x => !string.IsNullOrEmpty(x.ProjectName) && x.Latitude != null &&
                                    !double.TryParse(x.Latitude, out var notUsed)).Select(x => x.ProjectName).ToList());
                errors.Add(new ValidationResult(
                    $"All Latitude values must be between -90 and 90 decimal degrees. Values for the following Projects are invalid:<br/>{projectsWithBadAmounts}"));
            }

            // Latitude must be between -90 and 90
            var minimumLatitude = -90;
            var maximumLatitude = 90;
            if (pendingProjectBasicsStageImports.Where(x => !string.IsNullOrEmpty(x.ProjectName)).Any(x =>
                    !string.IsNullOrWhiteSpace(x.Latitude) && double.TryParse(x.Latitude, out var latitude) &&
                    (latitude < minimumLatitude || maximumLatitude < latitude)))
            {
                var projectsWithBadLatitudes = string.Join("<br/>",
                    pendingProjectBasicsStageImports.Where(x =>
                        !string.IsNullOrEmpty(x.ProjectName) && x.Latitude != null &&
                        double.TryParse(x.Latitude, out var latitude) &&
                        (latitude < minimumLatitude || maximumLatitude < latitude)).Select(x => x.ProjectName).ToList());
                errors.Add(new ValidationResult(
                    $"All Latitude values must be between -90 and 90 decimal degrees. Values for the following Projects are invalid:<br/>{projectsWithBadLatitudes}"));
            }

            // Longitude cannot be blank
            if (pendingProjectBasicsStageImports.Any(x =>
                    string.IsNullOrEmpty(x.Longitude) && string.IsNullOrEmpty(x.SimpleLocationNotes)))
            {
                var projectsMissingLongitude = string.Join("<br/>",
                    pendingProjectBasicsStageImports
                        .Where(x => !string.IsNullOrEmpty(x.ProjectName) && string.IsNullOrEmpty(x.Longitude) && string.IsNullOrEmpty(x.SimpleLocationNotes))
                        .Select(x => x.ProjectName).ToList());
                errors.Add(new ValidationResult(
                    $"Longitude cannot be blank. The following Projects are missing Longitude:<br/> {projectsMissingLongitude}."));
            }

            // all Longitude must be numbers
            if (pendingProjectBasicsStageImports.Where(x => !string.IsNullOrEmpty(x.ProjectName)).Any(x =>
                    !string.IsNullOrWhiteSpace(x.Longitude) && !double.TryParse(x.Longitude, out var notUsed)))
            {
                var projectsWithBadAmounts = string.Join("<br/>",
                    pendingProjectBasicsStageImports
                        .Where(x => !string.IsNullOrEmpty(x.ProjectName) && x.Longitude != null &&
                                    !double.TryParse(x.Longitude, out var notUsed)).Select(x => x.ProjectName).ToList());
                errors.Add(new ValidationResult(
                    $"All Longitude values must be between -180 and 180 decimal degrees. Values for the following Projects are invalid:<br/>{projectsWithBadAmounts}"));
            }

            // Longitude must be between -180 and 180
            var minimumLongitude = -180;
            var maximumLongitude = 180;
            if (pendingProjectBasicsStageImports.Where(x => !string.IsNullOrEmpty(x.ProjectName)).Any(x =>
                    !string.IsNullOrWhiteSpace(x.Longitude) && double.TryParse(x.Longitude, out var longitude) &&
                    (longitude < minimumLongitude || maximumLongitude < longitude)))
            {
                var projectsWithBadLongitudes = string.Join("<br/>",
                    pendingProjectBasicsStageImports.Where(x =>
                            !string.IsNullOrEmpty(x.ProjectName) && x.Longitude != null &&
                            double.TryParse(x.Longitude, out var latitude) &&
                            (latitude < minimumLongitude || maximumLongitude < latitude)).Select(x => x.ProjectName)
                        .ToList());
                errors.Add(new ValidationResult(
                    $"All Longitude values must be between -180 and 180 decimal degrees. Values for the following Projects are invalid:<br/>{projectsWithBadLongitudes}"));
            }

            // Latitude and Longitude pair required (one cannot be blank if other provided)
            if (pendingProjectBasicsStageImports.Any(x =>
                    !string.IsNullOrEmpty(x.Latitude) && string.IsNullOrEmpty(x.Longitude) ||
                    string.IsNullOrEmpty(x.Latitude) && !string.IsNullOrEmpty(x.Longitude)))
            {
                var projectsMissingLongitude = string.Join("<br/>",
                    pendingProjectBasicsStageImports.Where(x =>
                            !string.IsNullOrEmpty(x.ProjectName) &&
                            (!string.IsNullOrEmpty(x.Latitude) && string.IsNullOrEmpty(x.Longitude) ||
                             string.IsNullOrEmpty(x.Latitude) && !string.IsNullOrEmpty(x.Longitude)))
                        .Select(x => x.ProjectName).ToList());
                errors.Add(new ValidationResult(
                    $"Latitude/Longitude must be provided as a pair. The following Projects are missing Latitude or Longitude:<br/>{projectsMissingLongitude}."));
            }
            // simple location notes is 4000 characters max
            if (pendingProjectBasicsStageImports.Any(x => !string.IsNullOrEmpty(x.SimpleLocationNotes) && x.SimpleLocationNotes.Length > Project.FieldLengths.ProjectLocationNotes))
            {
                var projectsWithBadDescriptions = string.Join("<br/>",
                    pendingProjectBasicsStageImports
                        .Where(x => !string.IsNullOrEmpty(x.SimpleLocationNotes) && x.SimpleLocationNotes.Length > Project.FieldLengths.ProjectLocationNotes &&
                                    !string.IsNullOrEmpty(x.ProjectName)).Select(x => x.ProjectName));
                errors.Add(new ValidationResult($"Simple Location Notes cannot be more than 4000 characters. Simple Location Notes for the following Projects are too long:<br/>{projectsWithBadDescriptions}"));
                if (pendingProjectBasicsStageImports.Any(x => !string.IsNullOrEmpty(x.SimpleLocationNotes) && x.SimpleLocationNotes.Length > 4000 && string.IsNullOrEmpty(x.ProjectName)))
                {
                    var badDescriptions = string.Join("<br/>",
                        pendingProjectBasicsStageImports
                            .Where(x => !string.IsNullOrEmpty(x.SimpleLocationNotes) && x.SimpleLocationNotes.Length > Project.FieldLengths.ProjectLocationNotes &&
                                        string.IsNullOrEmpty(x.ProjectName)).Select(x => x.SimpleLocationNotes));
                    errors.Add(new ValidationResult($"Simple Location Notes cannot be more than 4000 characters. The following Simple Location Notes are too long:<br/>{badDescriptions}"));
                }
            }

            var pendingProjectOwnerOrgStageImportsWithProjectNames = pendingProjectBasicsStageImports.Where(x => !string.IsNullOrEmpty(x.ProjectName)).ToList();
            var primaryContactOrganizationFieldName = PendingProjectStageImportsHelper.TenantLabels[MultiTenantHelpers.GetTenantName()]["PrimaryContactOrganization"];
            // Lead Implementer cannot be blank
            if (pendingProjectBasicsStageImports.Any(x => string.IsNullOrEmpty(x.LeadImplementer)))
            {
                errors.Add(new ValidationResult($"{primaryContactOrganizationFieldName} cannot be blank in any row."));
            }
            // all Lead Implementers must be valid option
            var validOrganizationNames = HttpRequestStorage.DatabaseEntities.Organizations.ToList().Where(x => !x.IsUnknown())
                .Select(x => x.OrganizationName.Trim().ToLower().Trim()).ToList();
            if (pendingProjectOwnerOrgStageImportsWithProjectNames.Any(x => !string.IsNullOrEmpty(x.LeadImplementer) && !validOrganizationNames.Contains(x.LeadImplementer.ToLower().Trim())))
            {
                var projectsWithInvalidOptions = string.Join("<br/>", pendingProjectOwnerOrgStageImportsWithProjectNames.Where(x =>
                    !string.IsNullOrEmpty(x.LeadImplementer) &&
                    !validOrganizationNames.Contains(x.LeadImplementer.ToLower().Trim())).Select(x => $"{x.ProjectName}"));
                errors.Add(new ValidationResult($"{primaryContactOrganizationFieldName} must have a valid match in the reference tab. Values for the following Projects are invalid: {projectsWithInvalidOptions}."));
            }

            // Primary Contact cannot be blank
            var primaryContactFieldName = PendingProjectStageImportsHelper.TenantLabels[MultiTenantHelpers.GetTenantName()]["ProjectPrimaryContact"];
            if (pendingProjectBasicsStageImports.Any(x => string.IsNullOrEmpty(x.PrimaryContact)))
            {
                errors.Add(new ValidationResult($"{primaryContactFieldName} cannot be blank in any row."));
            }
            // all Primary Contacts must be valid option
            var validPrimaryContacts = HttpRequestStorage.DatabaseEntities.People.Where(x =>x.IsActive && x.RoleID != Role.Unassigned.RoleID).ToList().Select(x => $"{x.GetFullNameFirstLastAndOrgShortName().ToLower().Trim()} ({x.Email.ToLower().Trim()})");
            if (pendingProjectOwnerOrgStageImportsWithProjectNames.Any(x => !string.IsNullOrEmpty(x.PrimaryContact) && !validPrimaryContacts.Contains(x.PrimaryContact.ToLower().Trim())))
            {
                var projectNamesWithInvalidOptions = string.Join("<br/>", pendingProjectOwnerOrgStageImportsWithProjectNames.Where(x =>
                    !string.IsNullOrEmpty(x.PrimaryContact) &&
                    !validPrimaryContacts.Contains(x.PrimaryContact.ToLower().Trim())).Select(x => $"{x.ProjectName}"));
                errors.Add(new ValidationResult($"{primaryContactFieldName} must have a valid match in the reference tab. Values for the following Projects are invalid: {projectNamesWithInvalidOptions}."));
            }

            return errors;
        }

        public static List<Project> CreatePendingProjectBasicsFromStagedData(this List<PendingProjectBasicsStageImport> pendingProjectBasicsStageImports, FirmaSession currentFirmaSession)
        {
            // Build dictionary to lookup TaxonomyLeafID from display name
            var taxonomyLeafDisplayNameToID = new Dictionary<string, int>();
            HttpRequestStorage.DatabaseEntities.TaxonomyLeafs.ToList().ForEach(x =>
                taxonomyLeafDisplayNameToID.Add(x.GetDisplayName().ToLower().Trim(), x.TaxonomyLeafID));

            // Build dictionary to lookup ProjectStageID from display name
            var projectStageDisplayNameToID = new Dictionary<string, int>();
            ProjectStage.All.ForEach(x => projectStageDisplayNameToID.Add(x.ProjectStageDisplayName.ToLower().Trim(), x.ProjectStageID));


            // Build dictionary to lookup OrganizationID from display name
            var organizationNameToID = new Dictionary<string, int>();
            HttpRequestStorage.DatabaseEntities.Organizations.ForEach(x => organizationNameToID.Add(x.OrganizationName.ToLower().Trim(), x.OrganizationID));
            var primaryContactRelationshipType = MultiTenantHelpers.GetIsPrimaryContactOrganizationRelationship();
            var projectOrganizations = new List<ProjectOrganization>();

            // Build dictionary to lookup personID from display name
            var personDisplayNameToID = new Dictionary<string, int>();
            HttpRequestStorage.DatabaseEntities.People
                .Where(x => x.IsActive && x.RoleID != Role.Unassigned.RoleID).ForEach(x =>
                    personDisplayNameToID.Add($"{x.GetFullNameFirstLastAndOrgShortName().ToLower().Trim()} ({x.Email.ToLower().Trim()})", x.PersonID));

            var lastUpdatedDate = DateTime.Now;
            var pendingProjects = pendingProjectBasicsStageImports.Select(
                x =>
                {
                    var pendingProject = new Project(
                        taxonomyLeafDisplayNameToID[x.TaxonomyLeaf.ToLower().Trim()],
                        projectStageDisplayNameToID[x.ProjectStage.ToLower().Trim()],
                        x.ProjectName,
                        x.Description,
                        false,
                        !string.IsNullOrEmpty(x.Latitude) && !string.IsNullOrEmpty(x.Longitude) ? ProjectLocationSimpleType.LatLngInput.ProjectLocationSimpleTypeID : ProjectLocationSimpleType.None.ProjectLocationSimpleTypeID,
                        ProjectApprovalStatus.Draft.ProjectApprovalStatusID,
                        lastUpdatedDate,
                        ProjectCategory.Normal.ProjectCategoryID,
                        false)
                    {
                        TenantID = HttpRequestStorage.Tenant.TenantID,
                        PlanningDesignStartYear = !string.IsNullOrEmpty(x.PlanningDesignStartYear) ? int.Parse(x.PlanningDesignStartYear) : (int?)null,
                        ImplementationStartYear = !string.IsNullOrEmpty(x.ImplementationStartYear) ? int.Parse(x.ImplementationStartYear) : (int?)null,
                        CompletionYear = !string.IsNullOrEmpty(x.CompletionYear) ? int.Parse(x.CompletionYear) : (int?)null,
                        ProjectLocationNotes = x.SimpleLocationNotes,
                        PrimaryContactPersonID = personDisplayNameToID[x.PrimaryContact.ToLower().Trim()],
                        ProposingPersonID = currentFirmaSession.PersonID,
                        ProposingDate = lastUpdatedDate,
                    };
                    if (!string.IsNullOrEmpty(x.Latitude) && !string.IsNullOrEmpty(x.Longitude))
                    {
                        pendingProject.ProjectLocationPoint = DbSpatialHelper.MakeDbGeometryFromCoordinates(
                            double.Parse(x.Longitude),
                            double.Parse(x.Latitude),
                            LtInfoGeometryConfiguration.DefaultCoordinateSystemId);
                    }

                    projectOrganizations.Add(new ProjectOrganization(pendingProject.ProjectID, organizationNameToID[x.LeadImplementer.ToLower().Trim()], primaryContactRelationshipType.OrganizationRelationshipTypeID));

                    return pendingProject;
                }
                ).ToList();


            HttpRequestStorage.DatabaseEntities.AllProjects.AddRange(pendingProjects);
            HttpRequestStorage.DatabaseEntities.AllProjectOrganizations.AddRange(projectOrganizations);
            return pendingProjects;
        }

    }
}
