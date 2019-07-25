
-- Set PSP to use Annual Budget By Cost Type
update dbo.TenantAttribute
set BudgetTypeID = 4
where TenantID = 11

-- Insert Cost Types for PSP 
delete from dbo.CostType where TenantID = 11
go 
insert into dbo.CostType (TenantID, CostTypeName)
values
(11, 'Capital'),
(11, 'Operating'),
(11, 'Transportation')

-- Set default cost type for all ProjectFundingSourceExpenditures
update dbo.ProjectFundingSourceExpenditure
set CostTypeID = (select CostTypeID from dbo.CostType where CostTypeName = 'Capital')
where TenantID = 11

-- Set default cost type for all ProjectFundingSourceExpenditureUpdates
update dbo.ProjectFundingSourceExpenditureUpdate
set CostTypeID = (select CostTypeID from dbo.CostType where CostTypeName = 'Capital')
where TenantID = 11
