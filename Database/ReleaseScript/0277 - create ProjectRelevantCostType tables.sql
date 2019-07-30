alter table dbo.CostType add constraint AK_CostType_CostTypeID_TenantID unique (CostTypeID, TenantID)
GO

alter table dbo.ProjectFundingSourceExpenditure add constraint FK_ProjectFundingSourceExpenditure_CostType_CostTypeID_TenantID foreign key (CostTypeID, TenantID) references dbo.CostType(CostTypeID, TenantID)
alter table dbo.ProjectFundingSourceExpenditureUpdate add constraint FK_ProjectFundingSourceExpenditureUpdate_CostType_CostTypeID_TenantID foreign key (CostTypeID, TenantID) references dbo.CostType(CostTypeID, TenantID)


create table dbo.ProjectExpenditureRelevantCostType
(
	ProjectExpenditureRelevantCostTypeID int not null identity(1,1) constraint PK_ProjectExpenditureRelevantCostType_ProjectExpenditureRelevantCostTypeID primary key,
	TenantID int not null constraint FK_ProjectExpenditureRelevantCostType_Tenant_TenantID foreign key references dbo.Tenant(TenantID),
	ProjectID int not null constraint FK_ProjectExpenditureRelevantCostType_Project_ProjectID foreign key references dbo.Project(ProjectID),
	CostTypeID int not null constraint FK_ProjectExpenditureRelevantCostType_CostType_CostTypeID foreign key references dbo.CostType(CostTypeID),
	constraint AK_ProjectExpenditureRelevantCostType_ProjectID_CostTypeID unique(ProjectID, CostTypeID),
	constraint FK_ProjectExpenditureRelevantCostType_Project_ProjectID_TenantID foreign key (ProjectID, TenantID) references dbo.Project(ProjectID, TenantID),
	constraint FK_ProjectExpenditureRelevantCostType_CostType_CostTypeID_TenantID foreign key (CostTypeID, TenantID) references dbo.CostType(CostTypeID, TenantID)
)

create table dbo.ProjectBudgetRelevantCostType
(
	ProjectBudgetRelevantCostTypeID int not null identity(1,1) constraint PK_ProjectBudgetRelevantCostType_ProjectBudgetRelevantCostTypeID primary key,
	TenantID int not null constraint FK_ProjectBudgetRelevantCostType_Tenant_TenantID foreign key references dbo.Tenant(TenantID),
	ProjectID int not null constraint FK_ProjectBudgetRelevantCostType_Project_ProjectID foreign key references dbo.Project(ProjectID),
	CostTypeID int not null constraint FK_ProjectBudgetRelevantCostType_CostType_CostTypeID foreign key references dbo.CostType(CostTypeID),
	constraint AK_ProjectBudgetRelevantCostType_ProjectID_CostTypeID unique(ProjectID, CostTypeID),
	constraint FK_ProjectBudgetRelevantCostType_Project_ProjectID_TenantID foreign key (ProjectID, TenantID) references dbo.Project(ProjectID, TenantID),
	constraint FK_ProjectBudgetRelevantCostType_CostType_CostTypeID_TenantID foreign key (CostTypeID, TenantID) references dbo.CostType(CostTypeID, TenantID)
)