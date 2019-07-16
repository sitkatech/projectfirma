
-- Create BudgetType lookup table
create table BudgetType(
	BudgetTypeID int not null constraint PK_BudgetType_BudgetTypeID primary key,
	BudgetTypeName varchar(100) not null constraint AK_BudgetType_BudgetTypeName unique,
	BudgetTypeDisplayName varchar(100) not null constraint AK_BudgetType_BudgetTypeDisplayName unique,
	BudgetTypeDescription varchar(500) not null
);
insert into dbo.BudgetType(BudgetTypeID, BudgetTypeName, BudgetTypeDisplayName, BudgetTypeDescription)
values
(1, 'NoBudget', 'No Budget', 'No project budget information will be provided.'),
(2, 'SimpleBudget', 'Simple Budget', 'Enter project budgets by funding source.'),
(3, 'AnnualBudget', 'Annual Budget', 'Enter project budgets by year and funding source'),
(4, 'AnnualBudgetByCostType', 'Annual Budget by Cost Type', 'Enter project budgets by year, funding source, and cost type.')

-- Add new BudgetTypeID field to TenantAttribute
alter table. dbo.TenantAttribute
add BudgetTypeID int null constraint FK_TenantAttribute_BudgetType_BudgetTypeID foreign key references dbo.BudgetType(BudgetTypeID)
go 

-- Default all tenants to SimpleBudget
update dbo.TenantAttribute
set BudgetTypeID = 2

-- Make field required
alter table dbo.TenantAttribute
alter column BudgetTypeID int not null