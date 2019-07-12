
-- ProjectFundingSourceRequest
-- Rename constraints
EXEC sp_rename 'dbo.PK_ProjectFundingSourceRequest_ProjectFundingSourceRequestID', 'PK_ProjectFundingSourceBudget_ProjectFundingSourceBudgetID', 'OBJECT';
EXEC sp_rename 'dbo.FK_ProjectFundingSourceRequest_FundingSource_FundingSourceID', 'FK_ProjectFundingSourceBudget_FundingSource_FundingSourceID', 'OBJECT';
EXEC sp_rename 'dbo.FK_ProjectFundingSourceRequest_FundingSource_FundingSourceID_TenantID', 'FK_ProjectFundingSourceBudget_FundingSource_FundingSourceID_TenantID', 'OBJECT';
EXEC sp_rename 'dbo.FK_ProjectFundingSourceRequest_Project_ProjectID', 'FK_ProjectFundingSourceBudget_Project_ProjectID', 'OBJECT';
EXEC sp_rename 'dbo.FK_ProjectFundingSourceRequest_Project_ProjectID_TenantID', 'FK_ProjectFundingSourceBudget_Project_ProjectID_TenantID', 'OBJECT';
EXEC sp_rename 'dbo.FK_ProjectFundingSourceRequest_Tenant_TenantID', 'FK_ProjectFundingSourceBudget_Tenant_TenantID', 'OBJECT';
EXEC sp_rename 'dbo.AK_ProjectFundingSourceRequest_ProjectID_FundingSourceID', 'AK_ProjectFundingSourceBudget_ProjectID_FundingSourceID', 'OBJECT';
go


-- Delete check constraint
alter table dbo.ProjectFundingSourceRequest
drop constraint CK_ProjectFundingSourceRequest_SecuredUnsecuredAmountBothCannotBeZero
go

-- Rename fields
EXEC sp_rename 'dbo.ProjectFundingSourceRequest.ProjectFundingSourceRequestID', 'ProjectFundingSourceBudgetID', 'COLUMN';
EXEC sp_rename 'dbo.ProjectFundingSourceRequest.UnsecuredAmount', 'TargetedAmount', 'COLUMN';
go

-- Readd check constraint
alter table dbo.ProjectFundingSourceRequest
add constraint CK_ProjectFundingSourceBudget_SecuredTargetedAmountBothCannotBeZero check  (SecuredAmount <> 0 OR TargetedAmount <> 0)
go

-- Rename table
EXEC sp_rename 'dbo.ProjectFundingSourceRequest', 'ProjectFundingSourceBudget';

-- ProjectFundingSourceRequestUpdate
-- Rename constraints
EXEC sp_rename 'dbo.PK_ProjectFundingSourceRequestUpdate_ProjectFundingSourceRequestUpdateID', 'PK_ProjectFundingSourceBudgetUpdate_ProjectFundingSourceBudgetUpdateID', 'OBJECT';
EXEC sp_rename 'dbo.FK_ProjectFundingSourceRequestUpdate_FundingSource_FundingSourceID', 'FK_ProjectFundingSourceBudgetUpdate_FundingSource_FundingSourceID', 'OBJECT';
EXEC sp_rename 'dbo.FK_ProjectFundingSourceRequestUpdate_FundingSource_FundingSourceID_TenantID', 'FK_ProjectFundingSourceBudgetUpdate_FundingSource_FundingSourceID_TenantID', 'OBJECT';
EXEC sp_rename 'dbo.FK_ProjectFundingSourceRequestUpdate_ProjectUpdateBatch_ProjectUpdateBatchID', 'FK_ProjectFundingSourceBudgetUpdate_ProjectUpdateBatch_ProjectUpdateBatchID', 'OBJECT';
EXEC sp_rename 'dbo.FK_ProjectFundingSourceRequestUpdate_ProjectUpdateBatch_ProjectUpdateBatchID_TenantID', 'FK_ProjectFundingSourceBudgetUpdate_ProjectUpdateBatch_ProjectUpdateBatchID_TenantID', 'OBJECT';
EXEC sp_rename 'dbo.FK_ProjectFundingSourceRequestUpdate_Tenant_TenantID', 'FK_ProjectFundingSourceBudgetUpdate_Tenant_TenantID', 'OBJECT';
EXEC sp_rename 'dbo.AK_ProjectFundingSourceRequestUpdate_ProjectUpdateBatchID_FundingSourceID', 'AK_ProjectFundingSourceBudgetUpdate_ProjectUpdateBatchID_FundingSourceID', 'OBJECT';

-- Delete check constraint
alter table dbo.ProjectFundingSourceRequestUpdate
drop constraint CK_ProjectFundingSourceRequestUpdate_SecuredUnsecuredAmountBothCannotBeZero
go

-- Rename fields
EXEC sp_rename 'dbo.ProjectFundingSourceRequestUpdate.ProjectFundingSourceRequestUpdateID', 'ProjectFundingSourceBudgetUpdateID', 'COLUMN';
EXEC sp_rename 'dbo.ProjectFundingSourceRequestUpdate.UnsecuredAmount', 'TargetedAmount', 'COLUMN';
go

-- Readd check constraint
alter table dbo.ProjectFundingSourceRequestUpdate
add constraint CK_ProjectFundingSourceBudgetUpdate_SecuredTargetedAmountBothCannotBeZero check  (SecuredAmount <> 0 OR TargetedAmount <> 0)
go

-- Rename table
EXEC sp_rename 'dbo.ProjectFundingSourceRequestUpdate', 'ProjectFundingSourceBudgetUpdate';

-- Rename check constraints on Project
EXEC sp_rename 'dbo.CK_Project_AnnualCostForOperationsProjectsOnly', 'CK_Project_AnnualCostForBudgetSameEachYearProjectsOnly', 'OBJECT';
EXEC sp_rename 'dbo.CK_Project_TotalCostForCapitalProjectsOnly', 'CK_Project_TotalCostForBudgetVariesByYearProjectsOnly', 'OBJECT';



-- Update custom field labels
update dbo.FieldDefinitionData
set FieldDefinitionLabel = 'Targeted Funding'
where TenantID = 11 and FieldDefinitionID = 248

update dbo.FieldDefinitionData
set FieldDefinitionLabel = 'No Funding Indentified'
where TenantID = 11 and FieldDefinitionID = 41