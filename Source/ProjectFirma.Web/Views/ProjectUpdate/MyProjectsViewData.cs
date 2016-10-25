using System;
using System.Collections.Generic;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Models;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class MyProjectsViewData : FirmaViewData
    {
        public readonly ProjectUpdateStatusGridSpec.ProjectUpdateStatusFilterTypeEnum ProjectUpdateStatusFilterType;
        public readonly string SubmitAllUrl;
        public readonly string AllMyProjectsUrl;
        public readonly string MyProjectsRequiringAnUpdateUrl;
        public readonly string MySubmittedProjectsUrl;
        public readonly string AllProjectsUrl;
        public readonly string SubmittedProjectsUrl;
        public readonly string ProposeNewProjectUrl;

        public readonly bool HasProjectUpdateAdminPermissions;
        public readonly bool HasProposeProjectPermissions;

        public readonly ProjectUpdateStatusGridSpec GridSpec;
        public readonly string GridName;
        public readonly string GridDataUrl;

        public readonly string ArbitraryHtmlPlaceholderID;
        public readonly string ArbitraryHtmlProjectFilterButtonsID;

        public MyProjectsViewData(Person currentPerson, Models.ProjectFirmaPage projectFirmaPage, ProjectUpdateStatusGridSpec.ProjectUpdateStatusFilterTypeEnum projectUpdateStatusFilterType, string gridDataUrl) : base(currentPerson, projectFirmaPage)
        {
            ProjectUpdateStatusFilterType = projectUpdateStatusFilterType;
            switch (projectUpdateStatusFilterType)
            {
                case ProjectUpdateStatusGridSpec.ProjectUpdateStatusFilterTypeEnum.MyProjectsRequiringAnUpdate:
                    PageTitle = string.Format("Projects Requiring an Update for Reporting Year: {0}", ProjectFirmaDateUtilities.CalculateCurrentYearToUseForReporting());
                    break;
                case ProjectUpdateStatusGridSpec.ProjectUpdateStatusFilterTypeEnum.MySubmittedProjects:
                    PageTitle = string.Format("Recently Submitted Projects for Reporting Year: {0}", ProjectFirmaDateUtilities.CalculateCurrentYearToUseForReporting());
                    break;
                case ProjectUpdateStatusGridSpec.ProjectUpdateStatusFilterTypeEnum.AllMyProjects:
                    PageTitle = string.Format("All My Projects for Reporting Year: {0}", ProjectFirmaDateUtilities.CalculateCurrentYearToUseForReporting());
                    break;
                case ProjectUpdateStatusGridSpec.ProjectUpdateStatusFilterTypeEnum.AllProjects:
                    PageTitle = "All Projects";
                    break;
                case ProjectUpdateStatusGridSpec.ProjectUpdateStatusFilterTypeEnum.SubmittedProjects:
                    PageTitle = "Submitted Projects";
                    break;
                default:
                    throw new ArgumentOutOfRangeException("projectUpdateStatusFilterType", projectUpdateStatusFilterType, null);
            }
            SubmitAllUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(tc => tc.SubmitAll());
            AllMyProjectsUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(tc => tc.AllMyProjects());
            MyProjectsRequiringAnUpdateUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(tc => tc.MyProjectsRequiringAnUpdate());
            MySubmittedProjectsUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(tc => tc.MySubmittedProjects());
            AllProjectsUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(tc => tc.AllProjects());
            SubmittedProjectsUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(tc => tc.SubmittedProjects());
            ProposeNewProjectUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(tc => tc.Instructions(null));

            HasProjectUpdateAdminPermissions = new ProjectUpdateAdminFeature().HasPermissionByPerson(CurrentPerson);
            HasProposeProjectPermissions = new ProposedProjectEditFeature().HasPermissionByPerson(CurrentPerson);

            GridSpec = new ProjectUpdateStatusGridSpec(projectUpdateStatusFilterType, currentPerson.IsApprover()) {ObjectNameSingular = "Project", ObjectNamePlural = "Projects", SaveFiltersInCookie = true};
            GridDataUrl = gridDataUrl;
            GridName = "myProjectsGrid";

            ArbitraryHtmlPlaceholderID = string.Format("{0}ArbitrayHtmlPlaceholder", GridName);
            ArbitraryHtmlProjectFilterButtonsID = string.Format("{0}ArbitrayHtmlProjectFilterButtons", GridName);
            GridSpec.ArbitraryHtml = new List<string> {string.Format("<span id='{0}'></span>", ArbitraryHtmlPlaceholderID)};
        }
    }
}