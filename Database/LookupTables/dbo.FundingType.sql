
delete from dbo.FundingType

insert dbo.FundingType (FundingTypeID, FundingTypeName, FundingTypeDisplayName) 
values 
(1, 'BudgetVariesByYear', 'Budget varies by year, or it''s a one-year project'),
(2, 'BudgetSameEachYear', 'Budget is the same each year (e.g. annual maintenance)')

