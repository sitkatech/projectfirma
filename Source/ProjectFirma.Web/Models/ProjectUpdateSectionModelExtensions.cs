﻿using System;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class ProjectUpdateSectionModelExtensions
    {
        public static bool IsComplete(this ProjectUpdateSection projectUpdateSection, ProjectUpdateBatch projectUpdateBatch, int? classificationSystemID = null)
        {
            if (projectUpdateBatch == null)
            {
                return false;
            }

            var currentFirmaSession = HttpRequestStorage.FirmaSession;

            switch (projectUpdateSection.ToEnum)
            {
                case ProjectUpdateSectionEnum.Basics:
                    return projectUpdateBatch.AreProjectBasicsValid();
                case ProjectUpdateSectionEnum.CustomAttributes:
                    return projectUpdateBatch.AreProjectCustomAttributesValid(currentFirmaSession);
                case ProjectUpdateSectionEnum.LocationSimple:
                    return projectUpdateBatch.IsProjectLocationSimpleValid();
                case ProjectUpdateSectionEnum.Organizations:
                    return projectUpdateBatch.AreOrganizationsValid();
                case ProjectUpdateSectionEnum.Contacts:
                    return projectUpdateBatch.AreContactsValid();
                case ProjectUpdateSectionEnum.LocationDetailed:
                    return true;
                case ProjectUpdateSectionEnum.ReportedAccomplishments:
                    return projectUpdateBatch.AreReportedPerformanceMeasuresValid();
                case ProjectUpdateSectionEnum.Budget:
                    return true;
                case ProjectUpdateSectionEnum.Expenditures:
                    return projectUpdateBatch.AreExpendituresValid();
                case ProjectUpdateSectionEnum.Photos:
                    return true;
                case ProjectUpdateSectionEnum.ExternalLinks:
                    return true;
                case ProjectUpdateSectionEnum.AttachmentsAndNotes:
                    return true;
                case ProjectUpdateSectionEnum.ExpectedAccomplishments:
                    return true;
                case ProjectUpdateSectionEnum.BulkSetSpatialInformation:
                    return true;
                case ProjectUpdateSectionEnum.PartnerFinder:
                    return true;
                case ProjectUpdateSectionEnum.Classifications:
                    if (classificationSystemID.HasValue)
                    {
                        return projectUpdateBatch.ValidateClassifications(classificationSystemID.Value).IsValid;
                    }
                    return false;
                default:
                    throw new ArgumentOutOfRangeException($"IsComplete(): Unhandled Project Update Section Enum: {projectUpdateSection.ToEnum}");
            }
        }
        public static string GetSectionUrl(this ProjectUpdateSection projectUpdateSection, Project project, int? classificationSystemID = null)
        {
            if (!ModelObjectHelpers.IsRealPrimaryKeyValue(
                project.GetLatestNotApprovedUpdateBatch().ProjectUpdateBatchID))
            {
                return null;
            }

            switch (projectUpdateSection.ToEnum)
            {
                case ProjectUpdateSectionEnum.Basics:
                    return SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.Basics(project));
                case ProjectUpdateSectionEnum.CustomAttributes:
                    return SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.ProjectCustomAttributes(project));
                case ProjectUpdateSectionEnum.LocationSimple:
                    return SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.LocationSimple(project));
                case ProjectUpdateSectionEnum.Organizations:
                    return SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.Organizations(project));
                case ProjectUpdateSectionEnum.Contacts:
                    return SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.Contacts(project));
                case ProjectUpdateSectionEnum.LocationDetailed:
                    return SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.LocationDetailed(project));
                case ProjectUpdateSectionEnum.ReportedAccomplishments:
                    return SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.ReportedPerformanceMeasures(project));
                case ProjectUpdateSectionEnum.Budget:
                    return MultiTenantHelpers.GetTenantAttributeFromCache().BudgetType == BudgetType.AnnualBudgetByCostType
                            ? SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.ExpectedFundingByCostType(project.ProjectID))
                            : SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.ExpectedFunding(project.ProjectID));
                case ProjectUpdateSectionEnum.Expenditures:
                    return MultiTenantHelpers.GetTenantAttributeFromCache().BudgetType == BudgetType.AnnualBudgetByCostType ?
                        SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.ExpendituresByCostType(project)) : 
                        SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.Expenditures(project));
                case ProjectUpdateSectionEnum.Photos:
                    return SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.Photos(project));
                case ProjectUpdateSectionEnum.ExternalLinks:
                    return SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.ExternalLinks(project));
                case ProjectUpdateSectionEnum.AttachmentsAndNotes:
                    return SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.AttachmentsAndNotes(project));
                case ProjectUpdateSectionEnum.ExpectedAccomplishments:
                    return SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.ExpectedPerformanceMeasures(project));
                case ProjectUpdateSectionEnum.BulkSetSpatialInformation:
                    return SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.BulkSetSpatialInformation(project));
                case ProjectUpdateSectionEnum.PartnerFinder:
                    return SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.PartnerFinder(project));
                case ProjectUpdateSectionEnum.Classifications:
                    return classificationSystemID.HasValue ? SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.Classifications(project, classificationSystemID.Value)) : null;

                default:
                    throw new ArgumentOutOfRangeException($"Unhandled Project Update Section Enum: {projectUpdateSection.ToEnum}");
            }
        }
    }
}