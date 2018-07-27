/*-----------------------------------------------------------------------
<copyright file="MyProjectsViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Models;

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

        public MyProjectsViewData(Person currentPerson, Models.FirmaPage firmaPage, ProjectUpdateStatusGridSpec.ProjectUpdateStatusFilterTypeEnum projectUpdateStatusFilterType, string gridDataUrl) : base(currentPerson, firmaPage)
        {
            ProjectUpdateStatusFilterType = projectUpdateStatusFilterType;
            var currentYearToUseForReporting = FirmaDateUtilities.CalculateCurrentYearToUseForRequiredReporting();
            var fieldDefinitionReportingYear = Models.FieldDefinition.ReportingYear.GetFieldDefinitionLabel();
            switch (projectUpdateStatusFilterType)
            {
                case ProjectUpdateStatusGridSpec.ProjectUpdateStatusFilterTypeEnum.MyProjectsRequiringAnUpdate:
                    PageTitle =
                        $"{Models.FieldDefinition.Project.GetFieldDefinitionLabelPluralized()} Requiring an Update for {fieldDefinitionReportingYear}: {currentYearToUseForReporting}";
                    break;
                case ProjectUpdateStatusGridSpec.ProjectUpdateStatusFilterTypeEnum.MySubmittedProjects:
                    PageTitle =
                        $"Recently Submitted {Models.FieldDefinition.Project.GetFieldDefinitionLabelPluralized()} for {fieldDefinitionReportingYear}: {currentYearToUseForReporting}";
                    break;
                case ProjectUpdateStatusGridSpec.ProjectUpdateStatusFilterTypeEnum.AllMyProjects:
                    PageTitle =
                        $"All My {Models.FieldDefinition.Project.GetFieldDefinitionLabelPluralized()} for {fieldDefinitionReportingYear}: {currentYearToUseForReporting}";
                    break;
                case ProjectUpdateStatusGridSpec.ProjectUpdateStatusFilterTypeEnum.AllProjects:
                    PageTitle = $"All {Models.FieldDefinition.Project.GetFieldDefinitionLabelPluralized()}";
                    break;
                case ProjectUpdateStatusGridSpec.ProjectUpdateStatusFilterTypeEnum.SubmittedProjects:
                    PageTitle = $"Submitted {Models.FieldDefinition.Project.GetFieldDefinitionLabelPluralized()}";
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
            ProposeNewProjectUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(tc => tc.InstructionsProposal(null));

            HasProjectUpdateAdminPermissions = new ProjectUpdateAdminFeature().HasPermissionByPerson(CurrentPerson);
            HasProposeProjectPermissions = new ProjectCreateFeature().HasPermissionByPerson(CurrentPerson);

            GridSpec = new ProjectUpdateStatusGridSpec(projectUpdateStatusFilterType, currentPerson.IsAdministrator() || currentPerson.IsSitkaAdministrator()) {ObjectNameSingular = $"{Models.FieldDefinition.Project.GetFieldDefinitionLabel()}",
                ObjectNamePlural = $"{Models.FieldDefinition.Project.GetFieldDefinitionLabelPluralized()}", SaveFiltersInCookie = true};
            GridDataUrl = gridDataUrl;
            GridName = "myProjectsGrid";

            ArbitraryHtmlPlaceholderID = $"{GridName}ArbitrayHtmlPlaceholder";
            ArbitraryHtmlProjectFilterButtonsID = $"{GridName}ArbitrayHtmlProjectFilterButtons";
            GridSpec.ArbitraryHtml = new List<string> {$"<span id='{ArbitraryHtmlPlaceholderID}'></span>"};
        }
    }
}
