
-- Project
delete from dbo.ProjectNoFundingSourceIdentified
where ProjectID in (12814, 12858, 12862, 12863, 12920, 13339) and CalendarYear = 2018

-- Project Update need to insert missing budget entry for 2018
insert into dbo.ProjectFundingSourceBudgetUpdate(TenantID, ProjectUpdateBatchID, FundingSourceID, SecuredAmount, TargetedAmount, CalendarYear, CostTypeID)
values
(11, 8192, 8642, 0, 0, 2018, 9)

