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
using System.Data.Entity.Infrastructure.Pluralization;
using System.Data.Entity.Spatial;
using System.Linq;
using LtInfo.Common.ModalDialog;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Views;

namespace ProjectFirma.Web.Common
{
    public static class MultiTenantHelpers
    {
        private static readonly EnglishPluralizationService PluralizationService = new EnglishPluralizationService();

        public static TenantAttribute GetTenantAttribute()
        {
            return HttpRequestStorage.DatabaseEntities.TenantAttributes.Single();
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

        public static string GetTenantDisplayName()
        {
            return GetTenantAttribute().TenantDisplayName;
        }

        public static string GetTenantName()
        {
            return HttpRequestStorage.Tenant.TenantName;
        }

        public static string GetToolDisplayName()
        {
            return GetTenantAttribute().ToolDisplayName;
        }

        public static string GetTenantSquareLogoUrl()
        {
            return GetTenantAttribute().TenantSquareLogoFileResource != null
                ? GetTenantAttribute().TenantSquareLogoFileResource.GetFileResourceUrl()
                : "/Content/img/ProjectFirma_Logo_Square.png";
        }

        public static string GetTenantSquareLogScaledAsIconoUrl()
        {
            return GetTenantAttribute().TenantSquareLogoFileResource != null
                ? GetTenantAttribute().TenantSquareLogoFileResource
                    .FileResourceUrlScaledThumbnail(100)
                : "/Content/img/ProjectFirma_Logo_Square.png";
        }

        public static string GetTenantBannerLogoUrl()
        {
            return GetTenantAttribute().TenantBannerLogoFileResource != null
                ? GetTenantAttribute().TenantBannerLogoFileResource.GetFileResourceUrl()
                : "/Content/img/ProjectFirma_Logo_2016_FNL.width-600.png";
        }

        public static string GetTenantBannerLogoScaledAsIconUrl()
        {
            return GetTenantAttribute().TenantBannerLogoFileResource != null
                ? GetTenantAttribute().TenantBannerLogoFileResource
                    .FileResourceUrlScaledThumbnail(32)
                : "/Content/img/ProjectFirma_Logo_2016_FNL.width-600.png";
        }

        public static string GetTenantStyleSheetUrl()
        {
            return GetTenantAttribute().TenantStyleSheetFileResource != null
                ? new SitkaRoute<TenantController>(c => c.Style(HttpRequestStorage.Tenant.TenantName))
                    .BuildUrlFromExpression()
                : "~/Content/Bootstrap/firma/default.theme.min.css";
        }

        public static DbGeometry GetDefaultBoundingBox()
        {
            return GetTenantAttribute().DefaultBoundingBox;
        }

        public static int GetMinimumYear()
        {
            return GetTenantAttribute().MinimumYear;
        }

        public static string GetTenantRecaptchaPrivateKey()
        {
            return GetTenantAttribute().RecaptchaPrivateKey;
        }

        public static string GetTenantRecaptchaPublicKey()
        {
            return GetTenantAttribute().RecaptchaPublicKey;
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
            return GetTenantAttribute().TaxonomyLevel;
        }

        public static TaxonomyLevel GetAssociatePerformanceMeasureTaxonomyLevel()
        {
            return GetTenantAttribute().AssociatePerfomanceMeasureTaxonomyLevel;
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

        public static RelationshipType GetCanStewardProjectsOrganizationRelationship()
        {
            return HttpRequestStorage.DatabaseEntities.RelationshipTypes.SingleOrDefault(x => x.CanStewardProjects);
        }

        public static RelationshipType GetRelationshipTypeToReportInAccomplishmentsDashboard()
        {
            return HttpRequestStorage.DatabaseEntities.RelationshipTypes.SingleOrDefault(x =>
                x.ReportInAccomplishmentsDashboard);
        }

        public static bool DisplayAccomplishmentDashboard()
        {
            return GetTenantAttribute().EnableAccomplishmentsDashboard;
        }

        public static RelationshipType GetIsPrimaryContactOrganizationRelationship()
        {
            return HttpRequestStorage.DatabaseEntities.RelationshipTypes.SingleOrDefault(x => x.IsPrimaryContact);
        }

        public static bool ShowProposalsToThePublic()
        {
            return GetTenantAttribute().ShowProposalsToThePublic;
        }

        public static bool ShowLeadImplementerLogoOnFactSheet()
        {
            return GetTenantAttribute().ShowLeadImplementerLogoOnFactSheet;
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
            return GetTenantAttribute().AccomplishmentsDashboardFundingDisplayType;
        }

        public static bool GetAccomplishmentsDashboardIncludeReportingOrganizationType()
        {
            return GetTenantAttribute()
                .AccomplishmentsDashboardIncludeReportingOrganizationType;
        }

        public static ProjectUpdateSetting GetProjectUpdateConfiguration()
        {
            return HttpRequestStorage.DatabaseEntities.ProjectUpdateSettings.SingleOrDefault(x =>
                x.TenantID == HttpRequestStorage.Tenant.TenantID);
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

        public static void AddTechnicalAssistanceParametersMenuItem(LtInfoMenuItem manageMenu, string menuGroupName)
        {
            if (UsesTechnicalAssistanceParameters())
            {
                manageMenu.AddMenuItem(LtInfoMenuItem.MakeItem("Technical Assistance Paramters",
                    ModalDialogFormHelper.ModalDialogFormLink("Technical Assistance Parameters",
                        SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(c => c.TechnicalAssistanceParameters()),
                        "Technical Assistance Parameters", 800,
                        "Save", "Cancel", new List<string>(), null, null).ToString(), menuGroupName));
            }
        }

        public static ProjectStewardshipAreaType GetProjectStewardshipAreaType()
        {
            return GetTenantAttribute().ProjectStewardshipAreaType;
        }
    }
}
