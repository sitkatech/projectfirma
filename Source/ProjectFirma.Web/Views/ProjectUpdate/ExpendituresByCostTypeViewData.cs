/*-----------------------------------------------------------------------
<copyright file="ExpendituresByCostTypeViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Views.Shared.ExpenditureAndBudgetControls;
using ProjectFirmaModels.Models;
using System.Collections.Generic;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class ExpendituresByCostTypeViewData : ProjectUpdateViewData
    {
        public string RefreshUrl { get; }
        public string DiffUrl { get; }
        public ProjectExpendituresByCostTypeDetailViewData ProjectExpendituresByCostTypeDetailViewData { get; }
        public string RequestFundingSourceUrl { get; }
        public ViewDataForAngularClass ViewDataForAngular { get; }
        public SectionCommentsViewData SectionCommentsViewData { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForProject { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForFundingSource { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForCompletionYear { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForCostType{ get; }


        public ExpendituresByCostTypeViewData(FirmaSession currentFirmaSession, ProjectUpdateBatch projectUpdateBatch, ViewDataForAngularClass viewDataForAngularClass, 
            ProjectExpendituresByCostTypeDetailViewData projectExpendituresByCostTypeDetailViewData, ProjectUpdateStatus projectUpdateStatus, List<string> expendituresValidationErrors)
            : base(currentFirmaSession, projectUpdateBatch, projectUpdateStatus, expendituresValidationErrors, ProjectUpdateSection.Expenditures.ProjectUpdateSectionDisplayName)
        {
            ViewDataForAngular = viewDataForAngularClass;
            RefreshUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.RefreshExpenditures(projectUpdateBatch.Project));
            DiffUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.DiffExpendituresByCostType(projectUpdateBatch.Project));
            RequestFundingSourceUrl = SitkaRoute<HelpController>.BuildUrlFromExpression(x => x.MissingFundingSource());
            ProjectExpendituresByCostTypeDetailViewData = projectExpendituresByCostTypeDetailViewData;
            SectionCommentsViewData = new SectionCommentsViewData(projectUpdateBatch.ExpendituresComment, projectUpdateBatch.IsReturned());
            FieldDefinitionForProject = FieldDefinitionEnum.Project.ToType();
            FieldDefinitionForFundingSource = FieldDefinitionEnum.FundingSource.ToType();
            FieldDefinitionForCompletionYear = FieldDefinitionEnum.CompletionYear.ToType();
            FieldDefinitionForCostType = FieldDefinitionEnum.CostType.ToType();
        }

        public class ViewDataForAngularClass
        {
            public List<int> RequiredCalendarYearRange { get; }
            public List<FundingSourceSimple> AllFundingSources { get; }

            public int ProjectID { get; }
            public int MaxYear { get; }
            public bool UseFiscalYears { get; }
            public bool ShowNoExpendituresExplanation { get; }

            public ViewDataForAngularClass(ProjectFirmaModels.Models.Project project,
                List<FundingSourceSimple> allFundingSources,
                List<int> requiredCalendarYearRange, bool showNoExpendituresExplanation)
            {
                RequiredCalendarYearRange = requiredCalendarYearRange;
                ShowNoExpendituresExplanation = showNoExpendituresExplanation;
                AllFundingSources = allFundingSources;
                ProjectID = project.ProjectID;
                
                MaxYear = FirmaDateUtilities.CalculateCurrentYearToUseForUpToAllowableInputInReporting();
                UseFiscalYears = MultiTenantHelpers.UseFiscalYears();
            }
        }
    }
}
