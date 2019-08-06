using System;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class ProjectUpdateSectionModelExtensions
    {
        public static bool IsComplete(this ProjectUpdateSection projectUpdateSection, ProjectUpdateBatch projectUpdateBatch)
        {
            if (projectUpdateBatch == null)
            {
                return false;
            }
            switch (projectUpdateSection.ToEnum)
            {
                case ProjectUpdateSectionEnum.Basics:
                    return projectUpdateBatch.AreProjectBasicsValid();
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
                case ProjectUpdateSectionEnum.NotesAndDocuments:
                    return true;
                case ProjectUpdateSectionEnum.ExpectedAccomplishments:
                    return true;
                case ProjectUpdateSectionEnum.TechnicalAssistanceRequests:
                    return true;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        public static string GetSectionUrl(this ProjectUpdateSection projectUpdateSection, Project project)
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
                    return MultiTenantHelpers.GetTenantAttribute().BudgetType == BudgetType.AnnualBudgetByCostType
                            ? SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.ExpectedFundingByCostType(project.ProjectID))
                            : SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.ExpectedFunding(project.ProjectID));
                case ProjectUpdateSectionEnum.Expenditures:
                    return MultiTenantHelpers.GetTenantAttribute().BudgetType == BudgetType.AnnualBudgetByCostType ?
                        SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.ExpendituresByCostType(project)) : 
                        SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.Expenditures(project));
                case ProjectUpdateSectionEnum.Photos:
                    return SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.Photos(project));
                case ProjectUpdateSectionEnum.ExternalLinks:
                    return SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.ExternalLinks(project));
                case ProjectUpdateSectionEnum.NotesAndDocuments:
                    return SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.DocumentsAndNotes(project));
                case ProjectUpdateSectionEnum.ExpectedAccomplishments:
                    return SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.ExpectedPerformanceMeasures(project));
                case ProjectUpdateSectionEnum.TechnicalAssistanceRequests:
                    return SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.TechnicalAssistanceRequests(project));
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}