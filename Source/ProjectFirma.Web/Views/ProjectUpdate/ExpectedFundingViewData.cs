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
using ProjectFirmaModels.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using ProjectFirma.Web.Views.Shared.ExpenditureAndBudgetControls;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class ExpectedFundingViewData : ProjectUpdateViewData
    {
        public string RefreshUrl { get; }
        public string DiffUrl { get; }
        public ProjectBudgetSummaryViewData ProjectBudgetSummaryViewData { get; set; }

        public ProjectBudgetsAnnualViewData ProjectBudgetsAnnualViewData { get; set; }

        public string RequestFundingSourceUrl { get; }
        public ViewDataForAngularClass ViewDataForAngular { get; }
        public SectionCommentsViewData SectionCommentsViewData { get; }
        public string FundingTypeDescriptionString { get; }

        public ExpectedFundingViewData(Person currentPerson, ProjectUpdateBatch projectUpdateBatch, ViewDataForAngularClass viewDataForAngularClass, ProjectBudgetSummaryViewData projectBudgetSummaryViewData, ProjectBudgetsAnnualViewData projectBudgetsAnnualViewData, ProjectUpdateStatus projectUpdateStatus, ExpectedFundingValidationResult expectedFundingValidationResult)
            : base(currentPerson, projectUpdateBatch, projectUpdateStatus, expectedFundingValidationResult.GetWarningMessages(), ProjectUpdateSection.Budget.ProjectUpdateSectionDisplayName)
        {
            ViewDataForAngular = viewDataForAngularClass;
            RefreshUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.RefreshExpectedFunding(projectUpdateBatch.Project));
            DiffUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.DiffExpectedFunding(projectUpdateBatch.Project));
            RequestFundingSourceUrl = SitkaRoute<HelpController>.BuildUrlFromExpression(x => x.MissingFundingSource());
            ProjectBudgetSummaryViewData = projectBudgetSummaryViewData;
            ProjectBudgetsAnnualViewData = projectBudgetsAnnualViewData;
            SectionCommentsViewData = new SectionCommentsViewData(projectUpdateBatch.ExpectedFundingComment, projectUpdateBatch.IsReturned());
            ValidationWarnings = expectedFundingValidationResult.GetWarningMessages();
            FundingTypeDescriptionString = projectUpdateBatch.ProjectUpdate.FundingTypeID == FundingType.BudgetVariesByYear.FundingTypeID ? " varies by year or it's a one-year project." : " is the same each year.";
        }

        public class ViewDataForAngularClass
        {
            public List<FundingSourceSimple> AllFundingSources { get; }
            public int ProjectUpdateBatchID { get; }
            public int? FundingTypeID { get; }
            public IEnumerable<SelectListItem> FundingTypes { get; }
            public int? PlanningDesignStartYear { get; }
            public int? CompletionYear { get; }

            public ViewDataForAngularClass(ProjectUpdateBatch projectUpdateBatch,
                List<FundingSourceSimple> allFundingSources,
                IEnumerable<SelectListItem> fundingTypes,
                int? planningDesignStartYear, int? completionYear)
            {
                AllFundingSources = allFundingSources;
                FundingTypes = fundingTypes;
                ProjectUpdateBatchID = projectUpdateBatch.ProjectUpdateBatchID;
                FundingTypeID = projectUpdateBatch.ProjectUpdate.FundingType?.FundingTypeID;
                PlanningDesignStartYear = planningDesignStartYear;
                CompletionYear = completionYear;
            }
        }
    }
}
