alter table dbo.CostType add constraint AK_CostType_CostTypeID_TenantID unique (CostTypeID, TenantID)
GO

alter table dbo.ProjectFundingSourceExpenditure add constraint FK_ProjectFundingSourceExpenditure_CostType_CostTypeID_TenantID foreign key (CostTypeID, TenantID) references dbo.CostType(CostTypeID, TenantID)
alter table dbo.ProjectFundingSourceExpenditureUpdate add constraint FK_ProjectFundingSourceExpenditureUpdate_CostType_CostTypeID_TenantID foreign key (CostTypeID, TenantID) references dbo.CostType(CostTypeID, TenantID)

create table dbo.ProjectRelevantCostTypeGroup
(
	ProjectRelevantCostTypeGroupID int not null constraint PK_ProjectRelevantCostTypeGroup_ProjectRelevantCostTypeGroupID primary key,
	ProjectRelevantCostTypeGroupName varchar(50) not null constraint AK_ProjectRelevantCostTypeGroup_ProjectRelevantCostTypeGroupName unique,
	ProjectRelevantCostTypeGroupDisplayName varchar(50) not null constraint AK_ProjectRelevantCostTypeGroup_ProjectRelevantCostTypeGroupDisplayName unique
)

create table dbo.ProjectRelevantCostType
(
	ProjectRelevantCostTypeID int not null identity(1,1) constraint PK_ProjectRelevantCostType_ProjectRelevantCostTypeID primary key,
	TenantID int not null constraint FK_ProjectRelevantCostType_Tenant_TenantID foreign key references dbo.Tenant(TenantID),
	ProjectID int not null constraint FK_ProjectRelevantCostType_Project_ProjectID foreign key references dbo.Project(ProjectID),
	CostTypeID int not null constraint FK_ProjectRelevantCostType_CostType_CostTypeID foreign key references dbo.CostType(CostTypeID),
	ProjectRelevantCostTypeGroupID int not null constraint FK_ProjectRelevantCostType_ProjectRelevantCostTypeGroup_ProjectRelevantCostTypeGroupID foreign key references dbo.ProjectRelevantCostTypeGroup(ProjectRelevantCostTypeGroupID),
	constraint AK_ProjectRelevantCostType_ProjectID_CostTypeID_ProjectRelevantCostTypeGroupID unique(ProjectID, CostTypeID, ProjectRelevantCostTypeGroupID),
	constraint FK_ProjectRelevantCostType_Project_ProjectID_TenantID foreign key (ProjectID, TenantID) references dbo.Project(ProjectID, TenantID),
	constraint FK_ProjectRelevantCostType_CostType_CostTypeID_TenantID foreign key (CostTypeID, TenantID) references dbo.CostType(CostTypeID, TenantID)
)

create table dbo.ProjectRelevantCostTypeUpdate
(
	ProjectRelevantCostTypeUpdateID int not null identity(1,1) constraint PK_ProjectRelevantCostTypeUpdate_ProjectRelevantCostTypeUpdateID primary key,
	TenantID int not null constraint FK_ProjectRelevantCostTypeUpdate_Tenant_TenantID foreign key references dbo.Tenant(TenantID),
	ProjectUpdateBatchID int not null constraint FK_ProjectRelevantCostTypeUpdate_ProjectUpdateBatch_ProjectUpdateBatchID foreign key references dbo.ProjectUpdateBatch(ProjectUpdateBatchID),
	CostTypeID int not null constraint FK_ProjectRelevantCostTypeUpdate_CostType_CostTypeID foreign key references dbo.CostType(CostTypeID),
	ProjectRelevantCostTypeGroupID int not null constraint FK_ProjectRelevantCostTypeUpdate_ProjectRelevantCostTypeGroup_ProjectRelevantCostTypeGroupID foreign key references dbo.ProjectRelevantCostTypeGroup(ProjectRelevantCostTypeGroupID),	
	constraint AK_ProjectRelevantCostTypeUpdate_ProjectUpdateBatchID_CostTypeID_ProjectRelevantCostTypeGroupID unique(ProjectUpdateBatchID, CostTypeID, ProjectRelevantCostTypeGroupID),
	constraint FK_ProjectRelevantCostTypeUpdate_ProjectUpdateBatch_ProjectUpdateBatchID_TenantID foreign key (ProjectUpdateBatchID, TenantID) references dbo.ProjectUpdateBatch(ProjectUpdateBatchID, TenantID),
	constraint FK_ProjectRelevantCostTypeUpdate_CostType_CostTypeID_TenantID foreign key (CostTypeID, TenantID) references dbo.CostType(CostTypeID, TenantID)
)
