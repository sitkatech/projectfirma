using ProjectFirma.Web.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ProjectFirma.Web.Views.ProjectBulkUpload
{
    public class PendingProjectStageImportsHelper
    {
        public const string BasicsSheetName = "Basics";
        public const string SourcesSheetNameTemplate = @"REF - {0}";
        public const string OrganizationSourcesSheetName = "REF - Organization";

        /// <summary>
        /// A static dictionary of the Tenant Labels used in the spreadsheets. This is static even though these labels are dynamic in the application
        /// because the spreadsheets have them hard-coded. If the labels change, they need to be updated here and in the spreadsheets as well.
        /// </summary>
        public static Dictionary<string, Dictionary<string, string>> TenantLabels = new Dictionary<string, Dictionary<string, string>>
        {
            {"SitkaTechnologyGroup", new Dictionary<string, string>
            {
                {"TaxonomyLeafDisplayNameForProject", "Taxonomy Tier One"},
                {"PrimaryContactOrganization", "Lead Implementer"},
                {"ProjectPrimaryContact", "Project Primary Contact"}
            }},
            {"ClackamasPartnership", new Dictionary<string, string>
            {
                {"TaxonomyLeafDisplayNameForProject", "Primary Limiting Factor"},
                {"PrimaryContactOrganization", "Lead Implementer"},
                {"ProjectPrimaryContact", "Project Primary Contact"}
            }},
            {"RCDProjectTracker", new Dictionary<string, string>
            {
                {"TaxonomyLeafDisplayNameForProject", "Primary Resource Area"},
                {"PrimaryContactOrganization", "Lead Implementer"},
                {"ProjectPrimaryContact", "Project Primary Contact"}
            }},
            {"NCRPProjectTracker", new Dictionary<string, string>
            {
                {"TaxonomyLeafDisplayNameForProject", "Objectives"},
                {"PrimaryContactOrganization", "Project Sponsor"},
                {"ProjectPrimaryContact", "Administrative Contact"}
            }},
            {"DemoProjectFirma", new Dictionary<string, string>
            {
                {"TaxonomyLeafDisplayNameForProject", "Grant's Primary Program"},
                {"PrimaryContactOrganization", "Lead Implementer"},
                {"ProjectPrimaryContact", "Grant Primary Contact"}
            }},
            {"JohnDayBasinPartnership", new Dictionary<string, string>
            {
                {"TaxonomyLeafDisplayNameForProject", "Project Type"},
                {"PrimaryContactOrganization", "Lead Implementer"},
                {"ProjectPrimaryContact", "Project Manager"}
            }},
            {"SSMPProjectTracker", new Dictionary<string, string>
            {
                {"TaxonomyLeafDisplayNameForProject", "Project Type"},
                {"PrimaryContactOrganization", "Lead Implementer"},
                {"ProjectPrimaryContact", "Project Primary Contact"}
            }},
            {"TCSProjectTracker", new Dictionary<string, string>
            {
                {"TaxonomyLeafDisplayNameForProject", "Focus Area"},
                {"PrimaryContactOrganization", "Lead Implementer"},
                {"ProjectPrimaryContact", "Project Primary Contact"}
            }}
        };

        public Dictionary<string, string> GetBasicsColumnNames()
        {
            return new Dictionary<string, string>
            {
                { "A", "Project Name" },
                { "B", "Description" },
                { "C", $"{TenantLabels[MultiTenantHelpers.GetTenantName()]["TaxonomyLeafDisplayNameForProject"]}" },//
                { "D", "Project Stage" },
                { "E", "Planning/Design Start Year" },
                { "F", "Implementation Start Year" },
                { "G", "Completion Year" },
                { "H", "Latitude" },
                { "I", "Longitude" },
                { "J", "Simple Location Notes" },
                { "K", $"{TenantLabels[MultiTenantHelpers.GetTenantName()]["PrimaryContactOrganization"]}" },
                { "L", $"{TenantLabels[MultiTenantHelpers.GetTenantName()]["ProjectPrimaryContact"]}" }
            };
        }

        public static string BuildErrorMessageDisplay(List<ValidationResult> errors)
        {
            if (errors.Any())
            {
                var error = new StringBuilder("<ul>");
                errors.ForEach(x =>
                {
                    error.Append("<li>");
                    error.Append(x.ErrorMessage);
                    error.Append("</li>");
                });

                error.Append("</ul>");
                return error.ToString();
            }

            return null;
        }

        public static string BuildErrorMessageDisplay(Dictionary<string, IEnumerable<ValidationResult>> sheetNamesAndErrors)
        {
            var sheetNamesInOrder = new List<string>
            {
                BasicsSheetName
            };
            if (sheetNamesAndErrors.Any(x => x.Value.Any()))
            {
                var error = new StringBuilder();
                foreach (var sheetName in sheetNamesInOrder)
                {

                    var errors = sheetNamesAndErrors.ContainsKey(sheetName)
                        ? sheetNamesAndErrors[sheetName].ToList()
                        : new List<ValidationResult>();
                    if (errors.Any())
                    {
                        error.Append($"{sheetName} Tab:");
                        error.Append("<ul>");
                        errors.ForEach(x =>
                        {
                            error.Append("<li>");
                            error.Append(x.ErrorMessage);
                            error.Append("</li>");
                        });

                        error.Append("</ul>");
                    }
                    
                }
                
                return error.ToString();
            }

            return null;
        }
    }
}