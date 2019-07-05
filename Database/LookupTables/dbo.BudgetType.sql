delete from dbo.BudgetType
go

insert into dbo.BudgetType(BudgetTypeID, BudgetTypeName, BudgetTypeDisplayName, BudgetTypeDescription)
values
(1, 'NoBudget', 'No Budget', 'No project budget information will be provided.'),
(2, 'SimpleBudget', 'Simple Budget', 'Enter project budgets by funding source.'),
(3, 'AnnualBudget', 'Annual Budget', 'Enter project budgets by year and funding source'),
(4, 'AnnualBudgetByCostType', 'Annual Budget by Cost Type', 'Enter project budgets by year, funding source, and cost type.')