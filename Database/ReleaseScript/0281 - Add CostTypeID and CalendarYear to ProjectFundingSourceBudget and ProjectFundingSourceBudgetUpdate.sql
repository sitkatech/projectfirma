-- Add CalendarYear and CostType fields
alter table dbo.ProjectFundingSourceBudget
add CalendarYear int null

alter table dbo.ProjectFundingSourceBudgetUpdate
add CalendarYear int null

alter table dbo.ProjectFundingSourceBudget
add CostTypeID int null constraint FK_ProjectFundingSourceBudget_CostType_CostTypeID foreign key references dbo.CostType(CostTypeID)

alter table dbo.ProjectFundingSourceBudgetUpdate
add CostTypeID int null constraint FK_ProjectFundingSourceBudgetUpdate_CostType_CostTypeID foreign key references dbo.CostType(CostTypeID)

-- Update unique constraints
alter table dbo.ProjectFundingSourceBudget
drop constraint AK_ProjectFundingSourceBudget_ProjectID_FundingSourceID
go

alter table dbo.ProjectFundingSourceBudget
add constraint AK_ProjectFundingSourceBudget_ProjectID_FundingSourceID_CostTypeID_CalendarYear unique(ProjectID, FundingSourceID, CostTypeID, CalendarYear)
go 

alter table dbo.ProjectFundingSourceBudgetUpdate
drop constraint AK_ProjectFundingSourceBudgetUpdate_ProjectUpdateBatchID_FundingSourceID
go

alter table dbo.ProjectFundingSourceBudgetUpdate
add constraint AK_ProjectFundingSourceBudgetUpdate_ProjectUpdateBatchID_FundingSourceID_CostTypeID_CalendarYear unique(ProjectUpdateBatchID, FundingSourceID, CostTypeID, CalendarYear)
go

--create tables for No Funding Source Identified by Calendar Year

create table dbo.ProjectNoFundingSourceIdentified (
	ProjectNoFundingSourceIdentifiedID int not null identity(1,1) constraint PK_ProjectNoFundingSourceIdentified_ProjectNoFundingSourceIdentifiedID primary key,
	TenantID int not null constraint FK_ProjectNoFundingSourceIdentified_Tenant_TenantID foreign key references dbo.Tenant(TenantID),
	ProjectID int not null constraint FK_ProjectNoFundingSourceIdentified_Project_ProjectID foreign key references dbo.Project(ProjectID),
	CalendarYear int null constraint AK_ProjectNoFundingSourceIdentified_ProjectID_CalendarYear unique(ProjectID, CalendarYear),
	NoFundingSourceIdentifiedYet money null
);

create table dbo.ProjectNoFundingSourceIdentifiedUpdate (
	ProjectNoFundingSourceIdentifiedUpdateID int not null identity(1,1) constraint PK_ProjectNoFundingSourceIdentifiedUpdate_ProjectNoFundingSourceIdentifiedUpdateID primary key,
	TenantID int not null constraint FK_ProjectNoFundingSourceIdentifiedUpdate_Tenant_TenantID foreign key references dbo.Tenant(TenantID),
	ProjectUpdateBatchID int not null constraint FK_ProjectNoFundingSourceIdentifiedUpdate_ProjectUpdateBatch_ProjectUpdateBatchID foreign key references dbo.ProjectUpdateBatch(ProjectUpdateBatchID),
	CalendarYear int null constraint AK_ProjectNoFundingSourceIdentifiedUpdate_ProjectUpdateBatchID_CalendarYear unique(ProjectUpdateBatchID, CalendarYear),
	NoFundingSourceIdentifiedYet money null
);
