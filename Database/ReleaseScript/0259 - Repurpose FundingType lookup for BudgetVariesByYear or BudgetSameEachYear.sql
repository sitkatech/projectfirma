
-- Repurpose FundingType lookup 
update dbo.FundingType
set FundingTypeName = 'BudgetVariesByYear', FundingTypeDisplayName = 'Budget varies by year, or it''s a one-year project' where FundingTypeID = 1
go
update dbo.FundingType
set FundingTypeName = 'BudgetSameEachYear', FundingTypeDisplayName = 'Budget is the same each year (e.g. annual maintenance)' where FundingTypeID = 2
go

-- FundingTypeID needs to be nullable since it will no longer be entered when a project is created (in Basics)
alter table dbo.Project
alter column FundingTypeID int null
go

-- No longer going to support custom labels
drop table dbo.FundingTypeData