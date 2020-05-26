/*-----------------------------------------------------------------------
<copyright file="MultiTenantHelpers.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Pluralization;
using System.Data.Entity.Spatial;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.ModalDialog;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Views;

namespace ProjectFirma.Web.Common
{
    public static class MultiTenantHelpers
    {
        private static List<TenantAttribute> TenantAttributeCache = new List<TenantAttribute>();

        public static void ClearTenantAttributeCacheForAllTenants()
        {
            TenantAttributeCache = new List<TenantAttribute>();
        }

        private static readonly EnglishPluralizationService PluralizationService = new EnglishPluralizationService();

        public static Tenant GetTenantFromHostUrl(Uri urlHost)
        {
            var tenant = Tenant.All.SingleOrDefault(x => urlHost.Host.Equals(FirmaWebConfiguration.FirmaEnvironment.GetCanonicalHostNameForEnvironment(x), StringComparison.InvariantCultureIgnoreCase));
            Check.RequireNotNull(tenant, $"[GetTenantFromHostUrl] Could not determine tenant from host \"{urlHost}\"");
            return tenant;
        }

        public static TenantAttribute GetTenantAttributeFromCache()
        {
            var tenantAttribute = TenantAttributeCache.SingleOrDefault(ta => ta.TenantID == HttpRequestStorage.DatabaseEntities.TenantID);
            if (tenantAttribute == null)
            {
                tenantAttribute = HttpRequestStorage.DatabaseEntities.TenantAttributes
                    .Include(x => x.PrimaryContactPerson)
                    .Include(x => x.PrimaryContactPerson.Organization)
                    .Include(x => x.TenantBannerLogoFileResourceInfo.FileResourceDatas)
                    .Include(x => x.TenantFactSheetLogoFileResourceInfo.FileResourceDatas)
                    .Include(x => x.TenantSquareLogoFileResourceInfo.FileResourceDatas)
                    .Include(x => x.TenantStyleSheetFileResourceInfo.FileResourceDatas)
                    .SingleOrDefault();
                TenantAttributeCache.Add(tenantAttribute);
            }
            Check.EnsureNotNull(tenantAttribute, $"You need to add a Tenant Attribute table entry for TenantID {HttpRequestStorage.DatabaseEntities.TenantID}");
            return tenantAttribute;
        }

        public static string GetTaxonomySystemName()
        {
            return FieldDefinitionEnum.TaxonomySystemName.ToType().GetFieldDefinitionLabel();
        }

        public static string GetTaxonomyLeafDisplayNameForProject()
        {
            return FieldDefinitionEnum.TaxonomyLeafDisplayNameForProject.ToType().GetFieldDefinitionLabel();
        }

        public static string GetPerformanceMeasureName()
        {
            return FieldDefinitionEnum.PerformanceMeasure.ToType().GetFieldDefinitionLabel();
        }

        public static string GetPerformanceMeasureNamePluralized()
        {
            return PluralizationService.Pluralize(GetPerformanceMeasureName());
        }

        public static string GetTenantShortDisplayName()
        {
            return GetTenantAttributeFromCache().TenantShortDisplayName;
        }

        public static string GetTenantName()
        {
            return HttpRequestStorage.Tenant.TenantName;
        }

        public static string GetToolDisplayName()
        {
            return GetTenantAttributeFromCache().ToolDisplayName;
        }

        public static string GetTenantSquareLogoUrl()
        {
            return GetTenantAttributeFromCache().TenantSquareLogoFileResourceInfo != null
                ? GetTenantAttributeFromCache().TenantSquareLogoFileResourceInfo.GetFileResourceUrl()
                : "/Content/img/ProjectFirma_Logo_Square.png";
        }

        public static string GetTenantSquareLogScaledAsIconoUrl()
        {
            return GetTenantAttributeFromCache().TenantSquareLogoFileResourceInfo != null
                ? GetTenantAttributeFromCache().TenantSquareLogoFileResourceInfo
                    .FileResourceUrlScaledThumbnail(100)
                : "/Content/img/ProjectFirma_Logo_Square.png";
        }

        public static string GetTenantBannerLogoUrl()
        {
            var tenantBannerLogoFileResource = GetTenantAttributeFromCache().TenantBannerLogoFileResourceInfo;
            return tenantBannerLogoFileResource != null
                ? tenantBannerLogoFileResource.GetFileResourceUrl()
                : "/Content/img/ProjectFirma_Logo_2016_FNL.width-600.png";
        }

        public static string GetTenantBannerLogoScaledAsIconUrl()
        {
            return GetTenantAttributeFromCache().TenantBannerLogoFileResourceInfo != null
                ? GetTenantAttributeFromCache().TenantBannerLogoFileResourceInfo
                    .FileResourceUrlScaledThumbnail(32)
                : "/Content/img/ProjectFirma_Logo_2016_FNL.width-600.png";
        }

        public static string GetTenantFactSheetLogoUrl()
        {
            return GetTenantAttributeFromCache().TenantFactSheetLogoFileResourceInfo != null
                ? GetTenantAttributeFromCache().TenantFactSheetLogoFileResourceInfo.GetFileResourceUrl()
                : "/Content/img/ProjectFirma_Logo_Square.png";
        }

        public static string GetTenantStyleSheetUrl()
        {
            return GetTenantAttributeFromCache().TenantStyleSheetFileResourceInfo != null
                ? new SitkaRoute<TenantController>(c => c.Style(HttpRequestStorage.Tenant.TenantName))
                    .BuildUrlFromExpression()
                : "~/Content/Bootstrap/firma/base.theme.css";
        }

        public static DbGeometry GetDefaultBoundingBox()
        {
            return GetTenantAttributeFromCache().DefaultBoundingBox;
        }

        public static int GetMinimumYear()
        {
            return GetTenantAttributeFromCache().MinimumYear;
        }

        public static List<TaxonomyTier> GetTopLevelTaxonomyTiers()
        {
            var taxonomyLevel = GetTaxonomyLevel();
            if (taxonomyLevel == TaxonomyLevel.Trunk)
            {
                return HttpRequestStorage.DatabaseEntities.TaxonomyTrunks.ToList().Select(x => new TaxonomyTier(x)).ToList();
            }

            if (taxonomyLevel == TaxonomyLevel.Branch)
            {
                return HttpRequestStorage.DatabaseEntities.TaxonomyBranches.ToList().Select(x => new TaxonomyTier(x)).ToList();
            }

            return new List<TaxonomyTier>();
        }

        public static TaxonomyLevel GetTaxonomyLevel()
        {
            return GetTenantAttributeFromCache().TaxonomyLevel;
        }

        public static TaxonomyLevel GetAssociatePerformanceMeasureTaxonomyLevel()
        {
            return GetTenantAttributeFromCache().AssociatePerfomanceMeasureTaxonomyLevel;
        }

        public static bool IsTaxonomyLevelTrunk()
        {
            return GetTaxonomyLevel() == TaxonomyLevel.Trunk;
        }

        public static bool IsTaxonomyLevelBranch()
        {
            return GetTaxonomyLevel() == TaxonomyLevel.Branch;
        }

        public static bool IsTaxonomyLevelLeaf()
        {
            return GetTaxonomyLevel() == TaxonomyLevel.Leaf;
        }

        public static bool HasIsPrimaryContactOrganizationRelationship()
        {
            return GetIsPrimaryContactOrganizationRelationship() != null;
        }

        public static bool HasCanStewardProjectsOrganizationRelationship()
        {
            return GetCanStewardProjectsOrganizationRelationship() != null;
        }

        public static bool HasAttachmentTypeConfigured()
        {
            return HttpRequestStorage.DatabaseEntities.AttachmentTypes.Any();
        }

        public static OrganizationRelationshipType GetCanStewardProjectsOrganizationRelationship()
        {
            return HttpRequestStorage.DatabaseEntities.OrganizationRelationshipTypes.SingleOrDefault(x => x.CanStewardProjects);
        }

        public static OrganizationRelationshipType GetOrganizationRelationshipTypeToReportInAccomplishmentsDashboard()
        {
            return HttpRequestStorage.DatabaseEntities.OrganizationRelationshipTypes.SingleOrDefault(x =>
                x.ReportInAccomplishmentsDashboard);
        }

        public static bool DisplayAccomplishmentDashboard()
        {
            return GetTenantAttributeFromCache().EnableAccomplishmentsDashboard;
        }

        public static OrganizationRelationshipType GetIsPrimaryContactOrganizationRelationship()
        {
            return HttpRequestStorage.DatabaseEntities.OrganizationRelationshipTypes.SingleOrDefault(x => x.IsPrimaryContact);
        }

        public static bool ShowProposalsToThePublic()
        {
            return GetTenantAttributeFromCache().ShowProposalsToThePublic;
        }

        public static bool ShowLeadImplementerLogoOnFactSheet()
        {
            return GetTenantAttributeFromCache().ShowLeadImplementerLogoOnFactSheet;
        }

        public static List<ClassificationSystem> GetClassificationSystems()
        {
            return HttpRequestStorage.DatabaseEntities.ClassificationSystems.ToList();
        }

        public static List<CustomPage> GetCustomPages()
        {
            return HttpRequestStorage.DatabaseEntities.CustomPages.ToList();
        }

        public static AccomplishmentsDashboardFundingDisplayType GetAccomplishmentsDashboardFundingDisplayType()
        {
            return GetTenantAttributeFromCache().AccomplishmentsDashboardFundingDisplayType;
        }

        public static bool GetAccomplishmentsDashboardIncludeReportingOrganizationType()
        {
            return GetTenantAttributeFromCache()
                .AccomplishmentsDashboardIncludeReportingOrganizationType;
        }

        public static ProjectUpdateSetting GetProjectUpdateConfiguration()
        {
            var projectUpdateConfiguration = HttpRequestStorage.DatabaseEntities.ProjectUpdateSettings.SingleOrDefault(x =>
                x.TenantID == HttpRequestStorage.Tenant.TenantID);
            if (projectUpdateConfiguration == null)
            {
                // 3/27/2020 TK - You need to create an entry for your tenant in dbo.ProjectUpdateSetting
                throw new SitkaDisplayErrorException(
                    $"{GetTenantAttributeFromCache().TenantShortDisplayName} does not have a configuration entry for Project Update Settings. Please <a href=\"mailto: {FirmaWebConfiguration.SitkaSupportEmail}?subject=Project Update Settings are not configured\">contact support</a> to get this issue resolved.");
            }
            return projectUpdateConfiguration;
        }

        public static DateTime GetStartDayOfReportingYear()
        {
            return HttpRequestStorage.Tenant.ReportingYearStartDate;
        }

        public static bool UseFiscalYears()
        {
            return HttpRequestStorage.Tenant.UseFiscalYears;
        }

        public static string FormatReportingYear(int reportingYear)
        {
            if (UseFiscalYears())
            {
                return $"FY{reportingYear}";
            }
            return reportingYear.ToString();
        }

        
        public static bool UsesTechnicalAssistanceParameters()
        {
            return HttpRequestStorage.Tenant.UsesTechnicalAssistanceParameters;
        }

        public static void AddTechnicalAssistanceParametersMenuItem(LtInfoMenuItem manageMenu, FirmaSession currentFirmaSession, string menuGroupName)
        {
            if (UsesTechnicalAssistanceParameters() && new FirmaAdminFeature().HasPermission(currentFirmaSession).HasPermission)
            {
                manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem("Technical Assistance Parameters",
                    ModalDialogFormHelper.ModalDialogFormLink("Technical Assistance Parameters",
                        SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(c => c.TechnicalAssistanceParameters()),
                        "Technical Assistance Parameters", 800,
                        "Save", "Cancel", new List<string>(), null, null).ToString(), menuGroupName));
            }
        }

        public static void AddTechnicalAssistanceReportMenuItem(LtInfoMenuItem resultsMenu, FirmaSession currentFirmaSession)
        {
            if (UsesTechnicalAssistanceParameters() && new TechnicalAssistanceRequestsViewFeature().HasPermissionByFirmaSession(currentFirmaSession))
            {
                resultsMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<TechnicalAssistanceRequestController>(c => c.TechnicalAssistanceReport()), currentFirmaSession, "Technical Assistance Report"));
            }
        }

        // TODO make this into a check to see if the tenant uses custom results pages. For now, it's just the Action Agenda for PSP, so check if the 2 firma page types needed for their custom results page are present for the tenant
        public static bool UsesCustomResultsPages(FirmaSession currentFirmaSession)
        {
            return currentFirmaSession.Tenant == Tenant.ActionAgendaForPugetSound;
        }

        public static void AddFundingStatusMenuItem(LtInfoMenuItem resultsMenu, FirmaSession currentFirmaSession)
        {
            if (UsesCustomResultsPages(currentFirmaSession))
            {
                resultsMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<ResultsController>(c => c.FundingStatus()), currentFirmaSession, "Funding Status"));
            }
        }

        public static ProjectStewardshipAreaType GetProjectStewardshipAreaType()
        {
            return GetTenantAttributeFromCache().ProjectStewardshipAreaType;
        }

        public static string GetTenantGoogleAnalyticsTrackingCode()
        {
            return GetTenantAttributeFromCache().GoogleAnalyticsTrackingCode;
        }

        public static bool UsesEvaluations()
        {
            return GetTenantAttributeFromCache().EnableEvaluations;
        }
        public static void AddEvaluationsMenuItem(LtInfoMenuItem manageMenu, FirmaSession currentFirmaSession, string menuGroupName)
        {
            if (UsesEvaluations() && new FirmaAdminFeature().HasPermission(currentFirmaSession).HasPermission)
            {

                manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem(new SitkaRoute<EvaluationController>(c => c.Index()), currentFirmaSession, FieldDefinitionEnum.ProjectEvaluation.ToType().GetFieldDefinitionLabelPluralized(), "Group1"));
            }
        }

        public static bool DisplayReportsLink()
        {
            return GetTenantAttributeFromCache().EnableReports;
        }

    }
}
