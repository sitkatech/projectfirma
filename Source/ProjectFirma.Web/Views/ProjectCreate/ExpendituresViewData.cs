/*-----------------------------------------------------------------------
<copyright file="ExpendituresViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;
using System.Collections.Generic;

namespace ProjectFirma.Web.Views.ProjectCreate
{
    public class ExpendituresViewData : ProjectCreateViewData
    {
        public int ProjectID { get; }
        public string RefreshUrl { get; }
        public string DiffUrl { get; }
        public string RequestFundingSourceUrl { get; }
        public ViewDataForAngularClass ViewDataForAngular { get; }
        public bool ShowCommentsSection { get; }
        public bool CanEditComments { get; }

        public ExpendituresViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.Project project,
            ViewDataForAngularClass viewDataForAngularClass,
            ProposalSectionsStatus proposalSectionsStatus) : base(currentFirmaSession, project, ProjectCreateSection.ReportedExpenditures.ProjectCreateSectionDisplayName, proposalSectionsStatus)
        {
            ProjectID = project.ProjectID;
            ViewDataForAngular = viewDataForAngularClass;
            RefreshUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.RefreshExpenditures(project));
            DiffUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.DiffExpenditures(project));
            RequestFundingSourceUrl = SitkaRoute<HelpController>.BuildUrlFromExpression(x => x.MissingFundingSource());
            ShowCommentsSection = project.IsPendingApproval() || (project.ExpendituresComment != null &&
                                                                  project.ProjectApprovalStatus == ProjectApprovalStatus.Returned);
            CanEditComments = project.IsPendingApproval() && new ProjectEditAsAdminRegardlessOfStageFeature().HasPermission(currentFirmaSession, project).HasPermission;
        }

        public class ViewDataForAngularClass
        {
            public List<int> RequiredCalendarYearRange { get; }
            public List<FundingSourceSimple> AllFundingSources { get; }
            public int ProjectID { get; }
            public int MaxYear { get; }
            public bool UseFiscalYears { get; }

            public ViewDataForAngularClass(ProjectFirmaModels.Models.Project project,
                List<FundingSourceSimple> allFundingSources,
                List<int> requiredCalendarYearRange)
            {
                RequiredCalendarYearRange = requiredCalendarYearRange;
                AllFundingSources = allFundingSources;
                ProjectID = project.ProjectID;
                
                MaxYear = FirmaDateUtilities.CalculateCurrentYearToUseForUpToAllowableInputInReporting();
                UseFiscalYears = MultiTenantHelpers.UseFiscalYears();
            }
        }
    }
}
