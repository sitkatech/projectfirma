
update dbo.ProjectUpdate
set FundingTypeID = 1
where TenantID = 12 and FundingTypeID is null

update dbo.Project
set FundingTypeID = 1
where TenantID = 12 and FundingTypeID is null

update dbo.ProjectFundingSourceBudget
set CalendarYear = 2019, CostTypeID = 4
where TenantID = 12 and CostTypeID is null

