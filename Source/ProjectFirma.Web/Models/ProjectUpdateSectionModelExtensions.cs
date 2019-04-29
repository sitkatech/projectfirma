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
                case ProjectUpdateSectionEnum.LocationDetailed:
                    return true;
                case ProjectUpdateSectionEnum.ReportedPerformanceMeasures:
                    return projectUpdateBatch.AreReportedPerformanceMeasuresValid();
                case ProjectUpdateSectionEnum.ExpectedFunding:
                    return true;
                case ProjectUpdateSectionEnum.Expenditures:
                    return projectUpdateBatch.AreExpendituresValid();
                case ProjectUpdateSectionEnum.Photos:
                    return true;
                case ProjectUpdateSectionEnum.ExternalLinks:
                    return true;
                case ProjectUpdateSectionEnum.NotesAndDocuments:
                    return true;
                case ProjectUpdateSectionEnum.ExpectedPerformanceMeasures:
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
                case ProjectUpdateSectionEnum.LocationDetailed:
                    return SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.LocationDetailed(project));
                case ProjectUpdateSectionEnum.ReportedPerformanceMeasures:
                    return SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.ReportedPerformanceMeasures(project));
                case ProjectUpdateSectionEnum.ExpectedFunding:
                    return SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.ExpectedFunding(project));
                case ProjectUpdateSectionEnum.Expenditures:
                    return SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.Expenditures(project));
                case ProjectUpdateSectionEnum.Photos:
                    return SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.Photos(project));
                case ProjectUpdateSectionEnum.ExternalLinks:
                    return SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.ExternalLinks(project));
                case ProjectUpdateSectionEnum.NotesAndDocuments:
                    return SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.DocumentsAndNotes(project));
                case ProjectUpdateSectionEnum.ExpectedPerformanceMeasures:
                    return SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.ExpectedPerformanceMeasures(project));
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}