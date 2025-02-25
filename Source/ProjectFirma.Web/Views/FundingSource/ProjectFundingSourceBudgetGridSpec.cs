﻿using ProjectFirmaModels.Models;
using LtInfo.Common;
using LtInfo.Common.AgGridWrappers;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.FundingSource
{
    public class ProjectFundingSourceBudgetGridSpec : GridSpec<ProjectFirmaModels.Models.ProjectFundingSourceBudget>
    {
        public ProjectFundingSourceBudgetGridSpec()
        {
            Add(FieldDefinitionEnum.Project.ToType().ToGridHeaderString(),
                a => new HtmlLinkObject(a.Project.GetDisplayName(), a.Project.GetDetailUrl()).ToJsonObjectForAgGrid(),
                350,
                AgGridColumnFilterType.HtmlLinkJson);
            Add(FieldDefinitionEnum.ProjectStage.ToType().ToGridHeaderString(), x => x.Project.ProjectStage.GetProjectStageDisplayName(), 90, AgGridColumnFilterType.SelectFilterStrict);
            Add(FieldDefinitionEnum.SecuredFunding.ToType().ToGridHeaderString(), a => a.SecuredAmount, 100, AgGridColumnFormatType.Currency, AgGridColumnAggregationType.Total);
            Add(FieldDefinitionEnum.TargetedFunding.ToType().ToGridHeaderString(), a => a.TargetedAmount, 100, AgGridColumnFormatType.Currency, AgGridColumnAggregationType.Total);
        }
    }
}