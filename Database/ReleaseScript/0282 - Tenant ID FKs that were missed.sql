
alter table dbo.ProjectFundingSourceBudget add constraint FK_ProjectFundingSourceBudget_CostType_CostTypeID_TenantID foreign key (CostTypeID, TenantID) references dbo.CostType(CostTypeID, TenantID)
alter table dbo.ProjectFundingSourceBudgetUpdate add constraint FK_ProjectFundingSourceBudgetUpdate_CostType_CostTypeID_TenantID foreign key (CostTypeID, TenantID) references dbo.CostType(CostTypeID, TenantID)
alter table dbo.ProjectNoFundingSourceIdentified add constraint FK_ProjectNoFundingSourceIdentified_Project_ProjectID_TenantID foreign key (ProjectID, TenantID) references dbo.Project(ProjectID, TenantID)
alter table dbo.ProjectNoFundingSourceIdentifiedUpdate add constraint FK_ProjectNoFundingSourceIdentifiedUpdate_ProjectUpdateBatch_ProjectUpdateBatchID_TenantID foreign key (ProjectUpdateBatchID, TenantID) references dbo.ProjectUpdateBatch(ProjectUpdateBatchID, TenantID)

-- These are legit exceptions
--alter table dbo.ReleaseNote add constraint FK_ReleaseNote_Person_CreatePersonID_TenantID foreign key (CreatePersonID, TenantID) references dbo.Person(PersonID, TenantID)
--alter table dbo.ReleaseNote add constraint FK_ReleaseNote_Person_UpdatePersonID_TenantID foreign key (UpdatePersonID, TenantID) references dbo.Person(PersonID, TenantID)
